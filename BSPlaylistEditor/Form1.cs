/*
 * The main application
 */

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BSPlaylistEditor.ADB;
using System.ComponentModel;
using System.Drawing;
using System.Configuration;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BSPlaylistEditor
{
    public partial class editorForm : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string songLoaderPath = "/sdcard/ModData/com.beatgames.beatsaber/Configs/SongLoader.json"; //Where the SongLoader mod stores the list of custom songs
        public static List<SongModel> allSongs = new List<SongModel>(); //List of all custom songs
        public static List<PlaylistModel> allPlaylists = new List<PlaylistModel>(); //List of all custom playlists
        private DataTable allSongsTable = new DataTable(); //DataTable to drive the left grid
        private DataTable playlistTable = new DataTable(); //DataTable to drive the right grid
        private bool unsavedChanges = false; //Track whether changes have been made to the selected playlist
        private bool UnsavedChanges {
            get
            {
                return unsavedChanges;
            }
            set
            {
                unsavedChanges = value;
                savePlaylistButton.Enabled = value;
            }
        }

        public editorForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string backupFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BSPlayistEditorBackups");
            writeConfigValue("backupFolder", backupFolder,false);
            string tempFolder= Path.Combine(Directory.GetCurrentDirectory(), "BSPlayistEditorTemp");
            writeConfigValue("tempFolder", tempFolder, false);
            log.Info("Starting ADB");
            ADBcontroller.startADB();
            log.Info("Form loaded");
            if (isQuestConnected())
            {
                killBeatSaber();
                loadSongs(true);
            }
            else
            {
                refreshAllSongsToolStripMenuItem.Enabled = false;
                browsePlaylistBackupsToolStripMenuItem.Enabled=false;
            }            
        }

        private bool isQuestConnected()
        {
            List<string> adbDevices = ADBcontroller.adbDevices().Split(new[] { '\r', '\n' }).ToList();
            if (adbDevices[0] != "List of devices attached")
                return false;
            adbDevices.RemoveAt(0);
            foreach(string adbDevice in adbDevices)
            {
                if (adbDevice.StartsWith("1WMHH") || adbDevice.StartsWith("1KWPH"))
                {
                    if (adbDevice.EndsWith("device"))
                        return true;
                    else
                    {
                        DialogResult result = MessageBox.Show("Please authorize the connection on your headset and click \"Retry\".","Not Authorized",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                        if (result == DialogResult.Retry)
                            return isQuestConnected();
                        else
                            return false;
                    }
                }
            }
            DialogResult result1 = MessageBox.Show("Please connect your Quest headset and click \"Retry\".", "Quest not found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            if (result1 == DialogResult.Retry)
                return isQuestConnected();
            return false;
        }

        private async void loadSongs(bool includeSongs)
        {
            Directory.CreateDirectory(readConfigValue("backupFolder"));
            Directory.CreateDirectory(readConfigValue("tempFolder"));
            //Clear the grids
            newPlaylistButton.Visible = false;
            savePlaylistButton.Visible = false;
            deletePlaylistButton.Visible = false;
            playlistDropDown.Enabled = false;
            playlistDropDown.Items.Clear();
            playlistGridView.DataSource = null;
            playlistCoverPreview.Image = null;
            addSongButton.Enabled = false;
            removeSongButton.Enabled = false;
            changeCoverButton.Enabled = false;
            movePlaylistLabel.Enabled = false;
            playlistDownButton.Enabled = false;
            playlistUpButton.Enabled = false;
            

            if (includeSongs)
            {
                //Fetch all custom songs and populate the left grid
                searchLabel.Visible = false;
                searchBox.Visible = false;
                allSongsGridView.DataSource = null;
                allSongsProgressBar.Visible = true;
                allSongsProgressBar.MarqueeAnimationSpeed = 60;
                allSongsTable = await Task.Run(() => songsToDataTable(null));
                allSongsGridView.DataSource = allSongsTable;
                allSongsGridView.Columns["songID"].Visible = false;
                allSongsGridView.Sort(allSongsGridView.Columns["Song Name"], ListSortDirection.Ascending);
                allSongsProgressBar.MarqueeAnimationSpeed = 0;
                allSongsProgressBar.Visible = false;
                searchLabel.Visible = true;
                searchBox.Visible = true;
            }

            //Fetch all custom playlists and populate the right grid with the first playlist
            playlistProgressBar.Visible = true;
            playlistProgressBar.MarqueeAnimationSpeed = 60;
            await Task.Run(() => parseAllPlaylists());
            foreach (PlaylistModel playlist in allPlaylists)
            {
                playlistDropDown.Items.Add(playlist);
            }
            playlistDropDown.DisplayMember = "playlistTitle";
            if(playlistDropDown.Items.Count > 0)
                playlistDropDown.SelectedIndex = 0;
            playlistProgressBar.MarqueeAnimationSpeed = 0;
            playlistProgressBar.Visible = false;
            playlistDropDown.Enabled = true;
            addSongButton.Enabled = true;
            removeSongButton.Enabled = true;
            newPlaylistButton.Visible = true;
            newPlaylistButton.Enabled = true;
            savePlaylistButton.Visible = true;
            savePlaylistButton.Enabled = false;
            deletePlaylistButton.Visible = true;
            deletePlaylistButton.Enabled = true;
            changeCoverButton.Enabled = true;
            movePlaylistLabel.Enabled = true;
            playlistDownButton.Enabled = true;
            playlistUpButton.Enabled = true;
        }

        private void killBeatSaber()
        {
            log.Info($"Making sure Beat Saber is stopped");
            ADBcontroller adb = new ADBcontroller();
            adb.output = false;
            adb.command = $"shell am force-stop com.beatgames.beatsaber";
            adb.runCommand();
        }

        //Method to return the contents of a file as a string over ADB
        private static string getContentsOfFileFromAdb(string filepath)
        {
            log.Info($"Getting contents of file \"{filepath}\" from ADB");
            ADBcontroller adb = new ADBcontroller();
            adb.output = true;
            adb.command = $"shell cat \"{filepath}\"";
            return adb.runCommand();
        }

        //Method to pull a specified file over ADB to a specified destination
        private void pullFileFromADB(string source, string destination)
        {
            log.Info($"Pulling \"{source}\" to \"{destination}\" over ADB");
            ADBcontroller adb = new ADBcontroller();
            adb.output = false;
            adb.command = $"pull \"{source}\" \"{destination}\"";
            adb.runCommand();
        }


        //Method to push a specified file over ADB to a specified destination
        public static void pushFileToADB(string source, string destination)
        {
            log.Info($"Pushing \"{source}\" to \"{destination}\" over ADB");
            ADBcontroller adb = new ADBcontroller();
            adb.output = false;
            adb.command = $"push \"{source}\" \"{destination}\"";
            adb.runCommand();
        }

        //Parse the playlist JSON files into PlaylistModel objects and add them to the list of playlists
        private void parseAllPlaylists()
        {
            log.Info($"Parsing all playlists");
            allPlaylists = new List<PlaylistModel>();
            string playlistCoreJsonPath = "/sdcard/ModData/com.beatgames.beatsaber/Configs/PlaylistCore.json";
            JObject playlistCoreJson = JObject.Parse(getContentsOfFileFromAdb(playlistCoreJsonPath));
            foreach (string playlistPath in playlistCoreJson["order"])
            {
                PlaylistModel playlist = new PlaylistModel();
                playlist.devicePath = playlistPath;
                playlist.tempPath = Path.Combine(readConfigValue("tempFolder"), Path.GetFileName(playlistPath));
                log.Info($"Copying \"{playlistPath}\" to temp");
                pullFileFromADB(playlist.devicePath, playlist.tempPath);
                try
                {
                    log.Info($"Parsing \"{playlist.tempPath}\"");
                    JObject playlistJSON = JObject.Parse(File.ReadAllText(playlist.tempPath, Encoding.Default));
                    log.Info($"Parsing playlist \"{playlistJSON["playlistTitle"].ToString()}\"");
                    playlist.playlistTitle = playlistJSON["playlistTitle"].ToString();
                    playlist.songs = playlistJSON["songs"] as JArray;
                    if (playlistJSON["imageString"] != null)
                        playlist.imageString = playlistJSON["imageString"].ToString();
                    allPlaylists.Add(playlist);
                }
                catch(Exception ex)
                {
                    log.Error($"Error parsing \"{playlist.tempPath}\": {ex}");
                }
            }
        }


        //Monitor the playlist dropdown and update the right grid
        private void playlistDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playlistDropDown.Text.Length == 0)
                return;
            PlaylistModel selectedPlaylist = playlistDropDown.SelectedItem as PlaylistModel;
            updatePlaylistGrid(selectedPlaylist);
        }

        //Add songs to DataTables used to populate the grids
        public static DataTable songsToDataTable(PlaylistModel playlist)
        {
            log.Info($"Preparing songs from \"{playlist}\" to populate the grid");
            List<SongModel> songList = new List<SongModel>();
            if (playlist == null)
            {
                getAllSongsFromAdb();
                songList = allSongs;
            }
            else
            {
                songList = getSongsFromPlaylist(playlist);
            }

            DataTable table = new DataTable();
            DataColumn column;
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "songID";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Song Name";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Artist";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Mapper";
            table.Columns.Add(column);
            foreach (SongModel song in songList)
            {
                DataRow row = table.NewRow();
                row["Song Name"] = song.songName;
                if (song.songSubName != "")
                    row["Song Name"] += $"({song.songSubName})";
                row["Artist"] = song.songAuthorName;
                row["Mapper"] = song.levelAuthorName;
                row["songID"] = song.songID;
                table.Rows.Add(row);
            }
            return table;
        }

        //Read the SongLoader.json to get a list of all custom song folders,
        //then parse the info.dat in each of those folders to create SongModel
        //objects and add them to the list of all songs
        private static void getAllSongsFromAdb()
        {
            log.Info("Parsing all custom songs");
            allSongs = new List<SongModel>();
            JObject songLoader = JObject.Parse(getContentsOfFileFromAdb(songLoaderPath));
            foreach (var song in songLoader)
            {
                string songFolder = song.Key;
                string infoPath = songFolder + "/info.dat";
                JObject songJSON = JObject.Parse(getContentsOfFileFromAdb(infoPath));
                SongModel songModel = new SongModel();
                songModel.folderName = songFolder;
                songModel.songID = song.Value["sha1"].ToString();
                songModel.songName = songJSON["_songName"].ToString();
                songModel.songSubName = songJSON["_songSubName"].ToString();
                songModel.songAuthorName = songJSON["_songAuthorName"].ToString();
                songModel.levelAuthorName = songJSON["_levelAuthorName"].ToString();
                log.Info($"Found \"{songModel.songName}\" at {songModel.folderName}");
                allSongs.Add(songModel);
            }
        }

        public static List<SongModel> getSongsFromPlaylist(PlaylistModel playlist)
        {
            log.Info($"Fetching songs in playlist \"{playlist}\"");
            List<SongModel> songs = new List<SongModel>();
            if (playlist.songs != null)
            {
                foreach (JToken song in playlist.songs)
                {
                    SongModel songModel = new SongModel();
                    SongModel referenceSong = allSongs.Where(x => x.songID.ToLower() == song["hash"].ToString()).FirstOrDefault();
                    //Skip songs that have been deleted but are still referenced by the playlist
                    if (referenceSong == null)
                        continue;
                    songModel.songID = referenceSong.songID;
                    songModel.songName = referenceSong.songName;
                    songModel.songSubName = referenceSong.songSubName;
                    songModel.songAuthorName = referenceSong.songAuthorName;
                    songModel.levelAuthorName = referenceSong.levelAuthorName;
                    songModel.folderName = referenceSong.folderName;
                    log.Info($"Got data for song \"{songModel.songName}\"");
                    songs.Add(songModel);
                }
            }
            return songs;
        }

        public static Image getPlaylistCover(PlaylistModel playlist)
        {
            log.Info($"Fetching cover from playlist \"{playlist}\"");
            Image playlistCoverImage = null;
            if(playlist.imageString != null)
            {
                byte[] playlistCoverBytes = Convert.FromBase64String(playlist.imageString);
                MemoryStream memoryStream = new MemoryStream(playlistCoverBytes);
                playlistCoverImage = Image.FromStream(memoryStream);
            }
            return playlistCoverImage;
        }

        //This method isn't currently used, but can be used to generate the SHA1 hash for a custom song
        private string generateSongHash(DirectoryInfo songFolder)
        {
            string hashHex = "";
            string infoPath = Path.Combine(songFolder.FullName, "Info.dat");
            JObject infoJSON = JObject.Parse(File.ReadAllText(infoPath));
            List<string> filesToHash = new List<string>();
            filesToHash.Add(infoPath);
            string dataToHash = "";

            foreach(JObject difficultyBeatMapSet in infoJSON["_difficultyBeatmapSets"])
            {
                foreach (JObject difficultyBeatMap in difficultyBeatMapSet["_difficultyBeatmaps"])
                {
                    string beatMapPath = Path.Combine(songFolder.FullName, difficultyBeatMap["_beatmapFilename"].ToString());
                    if(File.Exists(beatMapPath))
                        filesToHash.Add(beatMapPath);
                }
            }
            foreach(string file in filesToHash)
            {
                dataToHash += File.ReadAllText(file);
            }
            byte[] UTF8Bytes = Encoding.UTF8.GetBytes(dataToHash);
            byte[] hashBytes = new SHA1Managed().ComputeHash(UTF8Bytes);
            foreach (byte b in hashBytes)
            {
                hashHex += b.ToString("X2");
            }
            return hashHex;
        }

        //Controls adding songs to a playlist
        private void addSongButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = getSongsToAddRemove(sender);
            foreach(DataGridViewRow row in selectedRows)
            {
                log.Info($"Adding song \"{row.Cells["Song Name"].Value}\" to playlist");
                DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                playlistTable.Rows.Add(dataRow.ItemArray);
            }
            UnsavedChanges = true;
        }

        //Controls removing songs from a playlist
        private void removeSongButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = getSongsToAddRemove(sender);
            foreach (DataGridViewRow row in selectedRows)
            {
                log.Info($"Removing song \"{row.Cells["Song Name"].Value}\" from playlist");
                DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                playlistTable.Rows.Remove(dataRow);
            }
            UnsavedChanges = true;
        }

        //Returns the selected rows in the appropriate grid based on which button is pressed
        private DataGridViewSelectedRowCollection getSongsToAddRemove(object sender)
        {
            log.Info("Getting selected songs");
            DataGridView gridToUse = new DataGridView();
            Button senderButton = sender as Button;
            switch (senderButton.Name)
            {
                case "addSongButton":
                    gridToUse = allSongsGridView;
                    break;
                case "removeSongButton":
                    gridToUse = playlistGridView;
                    break;
            }
            List<string> selectedSongIds = new List<string>();
            return gridToUse.SelectedRows;
        }

        //Controls the Save button
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Format the selected playlist appropriately
            PlaylistModel selectedPlayList = playlistDropDown.SelectedItem as PlaylistModel;
            savePlaylist(selectedPlayList);
            UnsavedChanges = false;
        }

        //Prompts to save the playlist changes
        private void savePrompt()
        {
            DialogResult dialog = MessageBox.Show($"Save changes to playlist \"{playlistDropDown.Text}\"?", "Save Changes?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                //Format the selected playlist appropriately
                PlaylistModel selectedPlayList = playlistDropDown.SelectedItem as PlaylistModel;
                savePlaylist(selectedPlayList);
                UnsavedChanges = false;
            }
        }

        //Toggle UI stuff and run the save processes asynchronously
        private async void savePlaylist(PlaylistModel playlist)
        {
            addSongButton.Enabled = false;
            removeSongButton.Enabled = false;
            newPlaylistButton.Visible = false;
            savePlaylistButton.Visible = false;
            deletePlaylistButton.Visible = false;
            playlistDropDown.Enabled = false;
            playlistProgressBar.Visible = true;
            playlistProgressBar.MarqueeAnimationSpeed = 60;
            await Task.Run(() => savePlaylistAsyncStuff(playlist));
            playlistProgressBar.Visible = false;
            playlistDropDown.Enabled = true;
            addSongButton.Enabled = true;
            removeSongButton.Enabled = true;
            newPlaylistButton.Visible = true;
            savePlaylistButton.Visible = true;
            deletePlaylistButton.Visible = true;
            loadSongs(false);
        }
        //Writes the playlist, as displayed, to file and them pushes it via ADB
        private void savePlaylistAsyncStuff(PlaylistModel playlist)
        {            
            backupPlaylist(playlist);
            log.Info($"Saving changes to \"{playlist.playlistTitle}\"");
            JArray songsJSON = new JArray();
            //Reading the songs from the DataGridView instead of the DataTable preserves sorting
            foreach (DataGridViewRow song in playlistGridView.Rows)
            {
                JObject songJSON = new JObject();
                songJSON.Add("hash", song.Cells["songID"].Value.ToString().ToLower());
                songJSON.Add("songName", song.Cells["Song Name"].Value.ToString());
                songsJSON.Add(songJSON);
            }
            playlist.songs = songsJSON;
            playlistToJson(playlist);
        }

        private void playlistToJson(PlaylistModel playlist)
        {
            JObject playlistJSON = new JObject();
            playlistJSON.Add("playlistTitle", playlist.playlistTitle);
            playlistJSON.Add("songs", playlist.songs);
            if (playlist.imageString != null)
                if (playlist.imageString.Length > 0)
                    playlistJSON.Add("imageString", playlist.imageString);
            //Write the playlist to the local copy and push it to the headset
            string source = playlist.tempPath;
            string destination = playlist.devicePath;
            File.WriteAllText(source, playlistJSON.ToString());
            pushFileToADB(source, destination);
        }

        //Check for unsaved playlist changes when closing the application
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UnsavedChanges)
                savePrompt();
            log.Info("Deleting temporary files");
            if (Directory.Exists(readConfigValue("tempFolder")))
                Directory.Delete(readConfigValue("tempFolder"), true);
            log.Info("Stopping ADB");
            ADBcontroller.stopADB();
        }

        //Check for unsaved playlist changes when changing the selected playlist
        private void playlistDropDown_Click(object sender, EventArgs e)
        {
            PlaylistModel selectedPlaylist = playlistDropDown.SelectedItem as PlaylistModel;
            if (UnsavedChanges)
                discardChangesPrompt(selectedPlaylist);
        }

        //Searches all fields in the All Songs list
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            (allSongsGridView.DataSource as DataTable).DefaultView.RowFilter = $"([Song Name] LIKE '%{searchBox.Text}%') OR ([Artist] LIKE '%{searchBox.Text}%') OR ([Mapper] LIKE '%{searchBox.Text}%')";
        }

        //Saving a playlist preserves sorting, so make sure we report that as a pending change
        private void playlistGridView_Sorted(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        //Check for unsaved playlist changes before creating a new one
        private void newPlaylistButton_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
                savePrompt();
            newPlaylistPrompt playlistPrompt = new newPlaylistPrompt();
            if (playlistPrompt.ShowDialog() == DialogResult.OK)
                createNewPlaylist(playlistPrompt.playlistTitle, playlistPrompt.playlistCoverPath);
        }

        private void createNewPlaylist(string playlistTitle, string playlistCoverPath)
        {
            PlaylistModel playlist = new PlaylistModel();
            log.Info($"Creating new playlist \"{playlistTitle}\"");
            string fileName = playlistTitle.Replace(" ", "_") + "_BSPlaylistEditor.json";
            playlist.devicePath = "/sdcard/ModData/com.beatgames.beatsaber/Mods/PlaylistManager/Playlists/" + fileName;
            playlist.tempPath = Path.Combine(readConfigValue("tempFolder"), fileName);
            playlist.playlistTitle = playlistTitle;
            if(playlistCoverPath != null)
            {
                byte[] imageArray = File.ReadAllBytes(playlistCoverPath);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                playlist.imageString = base64ImageRepresentation;
            }
            allPlaylists.Add(playlist);
            playlistDropDown.Items.Add(playlist);
            playlistDropDown.SelectedItem = playlist;
            playlistGridView.DataSource = null;
            savePlaylist(playlist);
            updatePlaylistCore();
        }

        private async void updatePlaylistGrid(PlaylistModel selectedPlaylist)
        {
            if (playlistDropDown.Text.Length == 0)
            {
                playlistGridView.DataSource = null;
                playlistCoverPreview.Image = null;
                return;
            }
            movePlaylistLabel.Enabled = false;
            playlistUpButton.Enabled = false;
            playlistDownButton.Enabled = false;
            changeCoverButton.Enabled = false;
            savePlaylistButton.Visible = false;
            deletePlaylistButton.Visible = false;
            newPlaylistButton.Visible=false;
            playlistProgressBar.MarqueeAnimationSpeed = 60;
            playlistProgressBar.Visible = true;
            playlistDropDown.Enabled = false;
            playlistTable = await Task.Run(() => songsToDataTable(selectedPlaylist));
            playlistCoverPreview.Image = await Task.Run(() => getPlaylistCover(selectedPlaylist)); ;
            playlistGridView.DataSource = playlistTable;
            playlistGridView.Columns["songID"].Visible = false;
            playlistProgressBar.MarqueeAnimationSpeed = 0;
            playlistProgressBar.Visible = false;
            playlistDropDown.Enabled = true;
            savePlaylistButton.Visible = true;
            deletePlaylistButton.Visible = true;
            newPlaylistButton.Visible = true;
            changeCoverButton.Enabled = true;
            if(playlistDropDown.Items.Count > 1)
            {
                movePlaylistLabel.Enabled = true;
                playlistUpButton.Enabled = true;
                playlistDownButton.Enabled = true;
            }
        }

        private void discardChangesPrompt(PlaylistModel selectedPlaylist)
        {
            DialogResult dialog = MessageBox.Show($"Discard changes to playlist \"{playlistDropDown.Text}\"?", "Discard Changes?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                updatePlaylistGrid(selectedPlaylist);
                UnsavedChanges = false;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(playlistDropDown.SelectedItem != null)
            {
                PlaylistModel playlist = playlistDropDown.SelectedItem as PlaylistModel;
                deletePlaylist(playlist);
                playlistDropDown.SelectedIndex = 0;
            }
        }

        private void deletePlaylist(PlaylistModel playlist)
        {
            File.Delete(playlist.tempPath);
            deleteFileOverADB(playlist.devicePath);
            allPlaylists.Remove(playlist);
            playlistDropDown.Items.Remove(playlist);
            updatePlaylistCore();
        }

        private void deleteFileOverADB(string filePath)
        {
            log.Info($"Deleting \"{filePath}\" over ADB");
            ADBcontroller adb = new ADBcontroller();
            adb.output = false;
            adb.command = $"shell rm \"{filePath}\"";
            adb.runCommand();
        }
        public static void writeConfigValue(string key, string value, bool overwrite)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null && overwrite)
                config.AppSettings.Settings[key].Value = value;
            else if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }

        public static string readConfigValue(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            if (config.AppSettings.Settings[key] != null)
                return config.AppSettings.Settings[key].Value;
            else
                return null;
        }
        public void backupPlaylist(PlaylistModel playlist)
        {
            if (playlist.songs == null || playlist.songs.Count == 0)
                return; //Don't backup empty playlists
            string backupFolder = readConfigValue("backupFolder");
            string timeStamp = DateTime.Now.ToString("_yyyyMMdd_HHmmss");
            string fileName = playlist.playlistTitle.Replace(" ", "_") + "_backup" + timeStamp + ".json";
            string source = playlist.tempPath;
            string destination = Path.Combine(backupFolder, fileName);
            if (File.Exists(source))
            {
                log.Info($"Backing up playlist \"{playlist.playlistTitle}\" to \"{destination}\"");
                File.Copy(source, destination, true);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
                savePrompt();
            SettingsDialog settingsWindow = new SettingsDialog();
            if (settingsWindow.ShowDialog() == DialogResult.OK)
                loadSongs(true);
        }

        public static void updatePlaylistCore()
        {
            string playlistCoreJsonPath = "/sdcard/ModData/com.beatgames.beatsaber/Configs/PlaylistCore.json";
            JObject playlistCoreJson = JObject.Parse(getContentsOfFileFromAdb(playlistCoreJsonPath));
            log.Info("Updating PlaylistCore.json");
            JArray playlistPaths = new JArray();
            foreach (PlaylistModel playlist in allPlaylists)
                playlistPaths.Add(playlist.devicePath);
            playlistCoreJson["order"] = playlistPaths;
            //Write the PlaylistCore.json to the local copy and push it to the headset
            string source = Path.Combine(readConfigValue("tempFolder"), "PlaylistCore.json");
            string destination = playlistCoreJsonPath;
            File.WriteAllText(source, playlistCoreJson.ToString());
            pushFileToADB(source, destination);
        }

        private void refreshAllSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
                savePrompt();
            loadSongs(true);
        }

        private void browsePlaylistBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UnsavedChanges)
                savePrompt();
            BackupBrowser backupBrowser = new BackupBrowser();
            backupBrowser.ShowDialog();
            loadSongs(false);
        }

        private void changeCoverButton_Click(object sender, EventArgs e)
        {
            if (browseCoverDialog.ShowDialog() == DialogResult.OK)
            {
                string playlistCoverPath = browseCoverDialog.FileName;
                playlistCoverPreview.Image = Image.FromFile(playlistCoverPath);
                PlaylistModel selectedPlayList = playlistDropDown.SelectedItem as PlaylistModel;
                byte[] imageArray = File.ReadAllBytes(playlistCoverPath);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                selectedPlayList.imageString = base64ImageRepresentation;
                UnsavedChanges = true;
            }
        }

        private void movePlaylist(object sender)
        {
            int selectedItemIndex = playlistDropDown.SelectedIndex;
            int newIndex = selectedItemIndex;
            PlaylistModel selectedPlaylist = playlistDropDown.SelectedItem as PlaylistModel;
            Button senderButton = sender as Button;
            if (senderButton.Name == "playlistUpButton" && selectedItemIndex != 0)
            {
                log.Info($"Moving playlist \"{selectedPlaylist.playlistTitle}\" up.");
                newIndex--;
            }
            else if (senderButton.Name == "playlistDownButton" && selectedItemIndex != playlistDropDown.Items.Count - 1)
            {
                log.Info($"Moving playlist \"{selectedPlaylist.playlistTitle}\" down.");
                newIndex++;
            }
            playlistDropDown.Items.Remove(selectedPlaylist);
            allPlaylists.Remove(selectedPlaylist);
            playlistDropDown.Items.Insert(newIndex, selectedPlaylist);
            allPlaylists.Insert(newIndex, selectedPlaylist);
            playlistDropDown.SelectedIndex = newIndex;
            updatePlaylistCore();
        }

        private void playlistUpButton_Click(object sender, EventArgs e)
        {
            movePlaylist(sender);
        }

        private void playlistDownButton_Click(object sender, EventArgs e)
        {
            movePlaylist(sender);
        }
    }
}
