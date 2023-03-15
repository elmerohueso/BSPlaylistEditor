using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BSPlaylistEditor
{
    public partial class UploadDialog : Form
    {
        public UploadDialog()
        {
            InitializeComponent();
        }

        private void dropZone_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private async void dropZone_DragDrop(object sender, DragEventArgs e)
        {   cancelButton.Enabled = false;
            dropZone.Enabled = false;
            statusLabel.Visible = true;
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // Array of paths of dropped items
            int i = 0;
            foreach(string file in files)
            {
                FileAttributes attr = File.GetAttributes(file);
                // Only handle dropped files for now
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory && Path.GetExtension(file) == ".zip")
                {
                    i++;
                    statusLabel.Text = $"[{i}/{files.Length}] {Path.GetFileName(file)}";
                    string songTemp = await Task.Run(() => extractSong(file));
                    string songHash = await Task.Run(() => generateSongHash(songTemp));
                    string deviceFolder = await Task.Run(() => uploadSong(songTemp, songHash));
                    if (Directory.Exists(songTemp))
                        Directory.Delete(songTemp, true);
                    editorForm.log.Info($"Extracted song \"{Path.GetFileName(file)}\" to \"{deviceFolder}\"");
                    // add updating the songloader.json
                }
            }
            statusLabel.Text = $"Uploaded {i} songs";
            cancelButton.Enabled = true;
            dropZone.Enabled = true;
        }
        private string uploadSong(string sourceFolder, string songHash)
        {
            string destFolder = "/sdcard/ModData/com.beatgames.beatsaber/Mods/SongLoader/CustomLevels/" + songHash;
            editorForm.pushFileToADB(sourceFolder, destFolder);
            return destFolder;
        }
        private string extractSong(string zipFile)
        {
            string tempFolder = editorForm.readConfigValue("tempFolder");
            string zipName = Path.GetFileNameWithoutExtension(zipFile);
            string folderOut = Path.Combine(tempFolder, zipName);
            if(Directory.Exists(folderOut))
                Directory.Delete(folderOut, true);
            ZipFile.ExtractToDirectory(zipFile, folderOut);
            return folderOut;
        }
        //This method isn't currently used, but can be used to generate the SHA1 hash for a custom song
        private string generateSongHash(string songPath)
        {
            DirectoryInfo songFolder = new DirectoryInfo(songPath);
            string hashHex = "";
            string infoPath = Path.Combine(songFolder.FullName, "Info.dat");
            JObject infoJSON = JObject.Parse(File.ReadAllText(infoPath));
            List<string> filesToHash = new List<string>();
            filesToHash.Add(infoPath);
            string dataToHash = "";

            foreach (JObject difficultyBeatMapSet in infoJSON["_difficultyBeatmapSets"])
            {
                foreach (JObject difficultyBeatMap in difficultyBeatMapSet["_difficultyBeatmaps"])
                {
                    string beatMapPath = Path.Combine(songFolder.FullName, difficultyBeatMap["_beatmapFilename"].ToString());
                    if (File.Exists(beatMapPath))
                        filesToHash.Add(beatMapPath);
                }
            }
            foreach (string file in filesToHash)
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
    }
}
