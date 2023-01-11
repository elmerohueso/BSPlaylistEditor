﻿/*
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

namespace BSPlaylistEditor
{
    public partial class editorForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string songLoaderPath = "/sdcard/ModData/com.beatgames.beatsaber/Configs/SongLoader.json"; //Where the SongLoader mod stores the list of custom songs
        private string devicePlaylistFolder = "/sdcard/ModData/com.beatgames.beatsaber/Mods/PlaylistManager/Playlists"; //Where the PlaylistManager mod stores custom playlist files
        private string localPlaylistFolder; //Temporary local storage for manipulating playlist files
        private List<SongModel> allSongs = new List<SongModel>(); //List of all custom songs
        private List<PlaylistModel> allPlaylists = new List<PlaylistModel>(); //List of all custom playlists
        private DataTable allSongsTable = new DataTable(); //DataTable to drive the left grid
        private DataTable playlistTable = new DataTable(); //DataTable to drive the right grid
        private bool unsavedChanges = false; //Track whether changes have been made to the selected playlist

        public editorForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            log.Info("Form loaded");
            //Fetch all custom songs and populate the left grid
            allSongsProgressBar.MarqueeAnimationSpeed = 60;
            allSongsTable = await Task.Run(() => songsToDataTable("All Songs"));
            allSongsGridView.DataSource = allSongsTable;
            allSongsGridView.Columns["songID"].Visible = false;
            allSongsGridView.Sort(allSongsGridView.Columns["Song Name"], ListSortDirection.Ascending);
            allSongsProgressBar.MarqueeAnimationSpeed = 0;
            allSongsProgressBar.Visible = false;
            searchLabel.Visible = true;
            searchBox.Visible = true;

            //Fetch all custom playlists and populate the right grid with the first playlist
            playlistDropDown.Visible = true;
            playlistProgressBar.MarqueeAnimationSpeed = 60;
            await Task.Run(() => getPlaylistsFromAdb());
            foreach (PlaylistModel playlist in allPlaylists)
            {
                playlistDropDown.Items.Add(playlist);
            }
            playlistDropDown.DisplayMember = "playlistTitle";
            playlistDropDown.SelectedIndex = 0;
            playlistProgressBar.MarqueeAnimationSpeed = 0;
            playlistProgressBar.Visible = false;
            playlistDropDown.Enabled = true;
            addSongButton.Enabled = true;
            removeSongButton.Enabled = true;
            saveButton.Enabled = true;
            newPlaylistButton.Visible = true;
            newPlaylistButton.Enabled = true;
        }

        //Method to return the contents of a file as a string over ADB
        private string getContentsOfFileFromAdb(string filepath)
        {
            log.Info($"Getting contents of file \"{filepath}\" from ADB");
            ADBcontroller adb = new ADBcontroller();
            adb.output = true;
            adb.command = $"shell cat \"{filepath}\"";
            return adb.runCommand();
        }

        //Method to pull an entire folder over ADB into a temporary folder
        private string pullFolderContentsFromADB(string folder)
        {
            log.Info($"Pulling folder \"{folder}\" over ADB");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "temp", Path.GetFileName(folder));
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            ADBcontroller adb = new ADBcontroller();
            adb.output = false;
            adb.command = $"pull \"{folder}\" \"{outputFolder}\"";
            adb.runCommand();
            return outputFolder;
        }


        //Method to push a specified file over ADB to a specified destination
        private void pushFileToADB(string source, string destination)
        {
            log.Info($"Pushing \"{source}\" to \"{destination}\" over ADB");
            ADBcontroller adb = new ADBcontroller();
            adb.output = false;
            adb.command = $"push \"{source}\" \"{destination}\"";
            adb.runCommand();
        }

        //Pull the playlist files locally for easier manipulation
        private void getPlaylistsFromAdb()
        {
            log.Info($"Storing all playlists locally");
            localPlaylistFolder = pullFolderContentsFromADB(devicePlaylistFolder);
            getAllPlaylists();
        }

        //Parse the playlist JSON files into PlaylistModel objects and add them to the list of playlists
        private void getAllPlaylists()
        {
            log.Info($"Parsing all playlists");
            allPlaylists = new List<PlaylistModel>();
            DirectoryInfo directoryInfo = new DirectoryInfo(localPlaylistFolder);
            FileInfo[] playlistFiles = directoryInfo.GetFiles();
            foreach (FileInfo playlistFile in playlistFiles)
            {
                JObject playlistJSON = JObject.Parse(File.ReadAllText(playlistFile.FullName, Encoding.Default));
                PlaylistModel playlistModel = new PlaylistModel();
                log.Info($"Parsing playlist \"{playlistJSON["playlistTitle"].ToString()}\"");
                playlistModel.fileName = playlistFile.Name;
                playlistModel.playlistTitle = playlistJSON["playlistTitle"].ToString();
                playlistModel.songs = playlistJSON["songs"] as JArray;
                if (playlistJSON["imageString"] != null)
                    playlistModel.imageString = playlistJSON["imageString"].ToString();
                allPlaylists.Add(playlistModel);
            }
        }


        //Monitor the playlist dropdown and update the right grid
        private async void playlistDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playlistDropDown.Text.Length == 0)
                return;
            playlistProgressBar.MarqueeAnimationSpeed = 60;
            playlistProgressBar.Visible = true;
            playlistDropDown.Enabled = false;
            saveButton.Enabled = false;
            string selectedPlaylist = playlistDropDown.Text;
            playlistTable = await Task.Run(() => songsToDataTable(selectedPlaylist));
            playlistGridView.DataSource = playlistTable;
            playlistGridView.Columns["songID"].Visible = false;
            playlistProgressBar.MarqueeAnimationSpeed = 0;
            playlistProgressBar.Visible = false;
            playlistDropDown.Enabled = true;
            saveButton.Enabled = true;
        }

        //Add songs to DataTables used to populate the grids
        private DataTable songsToDataTable(string playlist)
        {
            log.Info($"Preparing songs from \"{playlist}\" to populate the grid");
            List<SongModel> songList = new List<SongModel>();
            if (playlist == "All Songs")
            {
                if (allSongs.Count == 0)
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
        private void getAllSongsFromAdb()
        {
            log.Info("Parsing all custom songs");
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

        //Playlists only contain song names and hashes, so we have to match them with allSongs
        //to get all other information needed to build SongModel objects to populate the grid
        private List<SongModel> getSongsFromPlaylist(string playlist)
        {
            log.Info($"Fetching songs in playlist \"{playlist}\"");
            List<SongModel> songs = new List<SongModel>();
            PlaylistModel playlistModel = allPlaylists.Where(x => x.playlistTitle.ToString() == playlist).FirstOrDefault();
            if(playlistModel.songs != null)
            {
                foreach (JToken song in playlistModel.songs)
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
            unsavedChanges = true;
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
            unsavedChanges = true;
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
            savePrompt();
        }

        //Prompts to save the playlist changes
        private void savePrompt()
        {
            DialogResult dialog = MessageBox.Show($"Save changes to playlist \"{playlistDropDown.Text}\"?", "Save Changes?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                dataTableToPlaylist();
                unsavedChanges = false;
            }
        }

        //Writes the playlist, as displayed, to file and them pushes it via ADB
        private void dataTableToPlaylist()
        {
            //Format the selected playlist appropriately
            PlaylistModel selectedPlayList = playlistDropDown.SelectedItem as PlaylistModel;
            log.Info($"Saving changes to \"{selectedPlayList.fileName}\"");
            JArray songsJSON = new JArray();
            //Reading the songs from the DataGridView instead of the DataTable preserves sorting
            foreach (DataGridViewRow song in playlistGridView.Rows)
            {
                JObject songJSON = new JObject();
                songJSON.Add("hash", song.Cells["songID"].Value.ToString().ToLower());
                songJSON.Add("songName", song.Cells["Song Name"].Value.ToString());
                songsJSON.Add(songJSON);
            }
            JObject playlistJSON = new JObject();
            playlistJSON.Add("playlistTitle", selectedPlayList.playlistTitle);
            playlistJSON.Add("songs", songsJSON);
            if(selectedPlayList.imageString.Length > 0)
                playlistJSON.Add("imageString", selectedPlayList.imageString);
            //Write the playlist to the local copy and push it to the headset
            string source = Path.Combine(localPlaylistFolder, selectedPlayList.fileName);
            string destination = devicePlaylistFolder + "/" + selectedPlayList.fileName;
            File.WriteAllText(source, playlistJSON.ToString());
            pushFileToADB(source, destination);
            //Refresh the playlists
            getAllPlaylists();
        }

        //Check for unsaved playlist changes when closing the application
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
                savePrompt();
            Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "temp"), true);
        }

        //Check for unsaved playlist changes when changing the selected playlist
        private void playlistDropDown_Click(object sender, EventArgs e)
        {
            if(unsavedChanges)
                savePrompt();
        }

        //Searches all fields in the All Songs list
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            (allSongsGridView.DataSource as DataTable).DefaultView.RowFilter = $"([Song Name] LIKE '%{searchBox.Text}%') OR ([Artist] LIKE '%{searchBox.Text}%') OR ([Mapper] LIKE '%{searchBox.Text}%')";
        }

        //Saving a playlist preserves sorting, so make sure we report that as a pending change
        private void playlistGridView_Sorted(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        //Check for unsaved playlist changes before creating a new one
        private void newPlaylistButton_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
                savePrompt();
            newPlaylistPrompt playlistPrompt = new newPlaylistPrompt();
            if (playlistPrompt.ShowDialog() == DialogResult.OK)
                createNewPlaylist(playlistPrompt.playlistTitle, playlistPrompt.playlistCoverPath);
        }

        private void createNewPlaylist(string playlistTitle, string playlistCoverPath)
        {
            PlaylistModel playlistModel = new PlaylistModel();
            log.Info($"Creating new playlist \"{playlistTitle}\"");
            string fileName = playlistTitle.Replace(" ", "_") + "_BSPlaylistEditor";
            playlistModel.fileName = fileName + ".json";
            playlistModel.playlistTitle = playlistTitle;
            if(playlistCoverPath != null)
            {
                byte[] imageArray = File.ReadAllBytes(playlistCoverPath);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                playlistModel.imageString = base64ImageRepresentation;
            }
            allPlaylists.Add(playlistModel);
            playlistDropDown.Items.Add(playlistModel);
            playlistDropDown.SelectedItem = playlistModel;
            unsavedChanges=true;
        }
    }
}