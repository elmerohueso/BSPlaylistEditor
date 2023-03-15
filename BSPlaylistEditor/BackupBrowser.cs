using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BSPlaylistEditor.Models;

namespace BSPlaylistEditor
{
    public partial class BackupBrowser : Form
    {
        private static List<PlaylistModel> playlistBackups = new List<PlaylistModel>(); //List of backed up playlists
        private DataTable playlistTable = new DataTable(); //DataTable to drive the grid
        public BackupBrowser()
        {
            InitializeComponent();
        }

        private async void BackupBrowser_Load(object sender, EventArgs e)
        {
            //Fetch all playlist backups and populate the grid with the first playlist
            string backupFolder = editorForm.readConfigValue("backupFolder");
            restoreBackupButton.Visible = false;
            deleteBackupButton.Visible = false;
            backupsProgressBar.Visible = true;
            backupsProgressBar.MarqueeAnimationSpeed = 60;
            playlistBackups = await Task.Run(() => getPlaylistBackups(backupFolder));
            backupListGridView.DataSource = backupsToDataTable(playlistBackups);
            backupListGridView.Columns["Object"].Visible = false;
            backupsProgressBar.MarqueeAnimationSpeed = 0;
            backupsProgressBar.Visible = false;
            restoreBackupButton.Visible = true;
            deleteBackupButton.Visible = true;
        }


        private List<PlaylistModel> getPlaylistBackups(string backupFolder)
        {
            editorForm.log.Info($"Parsing playlist backups");
            List<PlaylistModel> backups = new List<PlaylistModel>();
            DirectoryInfo directoryInfo = new DirectoryInfo(backupFolder);
            foreach (FileInfo file in directoryInfo.GetFiles("*.json"))
            {
                JObject playlistJSON = JObject.Parse(File.ReadAllText(file.FullName));
                PlaylistModel playlist = new PlaylistModel();
                string fileName = playlistJSON["playlistTitle"].ToString().Replace(" ", "_") + "_BSPlaylistEditor.json";
                playlist.devicePath = "/sdcard/ModData/com.beatgames.beatsaber/Mods/PlaylistManager/Playlists/" + fileName;
                playlist.tempPath = file.FullName;
                playlist.playlistTitle = playlistJSON["playlistTitle"].ToString();
                string filnameTimestamp = Path.GetFileNameWithoutExtension(file.FullName).Split(new string[] { "_backup_" }, StringSplitOptions.None).Last();
                Trace.WriteLine(filnameTimestamp);
                playlist.backupDate = DateTime.ParseExact(filnameTimestamp,"yyyyMMdd_HHmmss", System.Globalization.CultureInfo.InvariantCulture);
                playlist.songs = playlistJSON["songs"] as JArray;
                if (playlistJSON["imageString"] != null)
                    playlist.imageString = playlistJSON["imageString"].ToString();
                if (playlist.songs.Count > 0)    
                    backups.Add(playlist); //Don't show backups that have no songs
            }
            return backups;
        }

        private async void updatePlaylistGrid(PlaylistModel selectedPlaylist)
        {
            restoreBackupButton.Visible = false;
            deleteBackupButton.Visible = false;
            playlistProgressBar.Visible = true;
            playlistProgressBar.MarqueeAnimationSpeed = 60;
            playlistTable = await Task.Run(() => editorForm.songsToDataTable(selectedPlaylist));
            playlistCoverPreview.Image = await Task.Run(() => editorForm.getPlaylistCover(selectedPlaylist));
            playlistGridView.DataSource = playlistTable;
            playlistGridView.Columns["songID"].Visible = false;
            foreach (DataGridViewColumn column in playlistGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            playlistProgressBar.MarqueeAnimationSpeed = 0;
            playlistProgressBar.Visible = false;
            restoreBackupButton.Visible = true;
            deleteBackupButton.Visible = true;
            restoreBackupButton.Enabled = true;
            deleteBackupButton.Enabled = true;
        }
        private DataTable backupsToDataTable(List<PlaylistModel> playlistBackups)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Object", typeof(PlaylistModel));
            table.Columns.Add("Playlist Title", typeof(string));
            table.Columns.Add("Backup Date", typeof(DateTime));
            foreach (PlaylistModel playlist in playlistBackups)
            {
                DataRow row = table.NewRow();
                row["Object"] = playlist;
                row["Playlist Title"] = playlist.playlistTitle;
                row["Backup Date"] = playlist.backupDate;
                table.Rows.Add(row);
            }
            return table;
        }

        private void backupListGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (backupListGridView.SelectedRows.Count != 0)
            {
                restoreBackupButton.Enabled = true;
                deleteBackupButton.Enabled = true;
                DataGridViewRow selectedRow = backupListGridView.SelectedRows[0];
                PlaylistModel selectedPlaylist = selectedRow.Cells["Object"].Value as PlaylistModel;
                updatePlaylistGrid(selectedPlaylist);
            }
            else
            {
                restoreBackupButton.Enabled = false;
                deleteBackupButton.Enabled = false;
            }
        }

        private async void restoreBackupButton_Click(object sender, EventArgs e)
        {
            string backupFolder = editorForm.readConfigValue("backupFolder");
            backupListGridView.Enabled = false;
            playlistGridView.Enabled = false;
            restoreBackupButton.Visible = false;
            deleteBackupButton.Visible = false;
            backupsProgressBar.Visible = true;
            backupsProgressBar.MarqueeAnimationSpeed = 60;
            DataGridViewRow selectedRow = backupListGridView.SelectedRows[0];
            PlaylistModel selectedPlaylist = selectedRow.Cells["Object"].Value as PlaylistModel;
            await Task.Run(() => restoreBackup(selectedPlaylist));
            playlistBackups = await Task.Run(() => getPlaylistBackups(backupFolder));
            backupListGridView.DataSource = backupsToDataTable(playlistBackups);
            backupListGridView.Columns["Object"].Visible = false;
            backupsProgressBar.MarqueeAnimationSpeed = 0;
            backupsProgressBar.Visible = false;
            restoreBackupButton.Visible = true;
            deleteBackupButton.Visible = true;
            backupListGridView.Enabled = true;
            playlistGridView.Enabled = true;
        }

        private void restoreBackup(PlaylistModel playlist)
        {
            editorForm.log.Info($"Playlist \"{playlist.playlistTitle}\" selected for restore");
            PlaylistModel originalPlaylist = editorForm.allPlaylists.Where(p => p.playlistTitle == playlist.playlistTitle).FirstOrDefault();
            if(originalPlaylist != null)
            {
                editorForm.log.Warn("Existing playlist found");
                if (MessageBox.Show($"The headset has an existing playlist named \"{playlist.playlistTitle}\". Would you like to replace it?", "Replace existing playlist?", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    string message = $"Playlist \"{playlist.playlistTitle}\" not restored.";
                    MessageBox.Show(message, "Restore canceled", MessageBoxButtons.OK);
                    editorForm.log.Info("Restore canceled.");
                    return;
                }
                editorForm.pushFileToADB(playlist.tempPath, originalPlaylist.devicePath);
            }
            else
            {
                editorForm.pushFileToADB(playlist.tempPath, playlist.devicePath);
                editorForm.allPlaylists.Add(playlist);
                editorForm.updatePlaylistCore();
            }
            editorForm.log.Info($"Playlist \"{playlist.playlistTitle}\" restored");
        }

        private async void deleteBackupButton_Click(object sender, EventArgs e)
        {
            string backupFolder = editorForm.readConfigValue("backupFolder");
            backupListGridView.Enabled = false;
            playlistGridView.Enabled = false;
            restoreBackupButton.Visible = false;
            deleteBackupButton.Visible = false;
            backupsProgressBar.Visible = true;
            backupsProgressBar.MarqueeAnimationSpeed = 60;
            DataGridViewRow selectedRow = backupListGridView.SelectedRows[0];
            PlaylistModel selectedPlaylist = selectedRow.Cells["Object"].Value as PlaylistModel;
            await Task.Run(() => deleteBackup(selectedPlaylist));
            playlistBackups = await Task.Run(() => getPlaylistBackups(backupFolder));
            backupListGridView.DataSource = backupsToDataTable(playlistBackups);
            backupListGridView.Columns["Object"].Visible = false;
            backupsProgressBar.MarqueeAnimationSpeed = 0;
            backupsProgressBar.Visible = false;
            restoreBackupButton.Visible = true;
            deleteBackupButton.Visible = true;
            backupListGridView.Enabled = true;
            playlistGridView.Enabled = true;
        }

        private void deleteBackup(PlaylistModel playlist)
        {
            editorForm.log.Info($"Playlist \"{playlist.playlistTitle}\" selected for deletion");
            try
            {
                File.Delete(playlist.tempPath);
                editorForm.log.Info($"Deleted \"{playlist.tempPath}\"");
            }
            catch (Exception ex)
            {
                editorForm.log.Error($"Failed to delete \"{playlist.tempPath}\" with error: {ex}");
            }
        }
    }
}
