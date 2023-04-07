using Newtonsoft.Json;
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

namespace BSPlaylistEditor
{
    public partial class UploadDialog : Form
    {
        internal int uploadedCount = 0;
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
        {
            string songLoaderTemp = editorForm.pullSongLoaderJSON();
            JObject songLoader = JObject.Parse(File.ReadAllText(songLoaderTemp));
            cancelButton.Enabled = false;
            dropZone.Enabled = false;
            statusLabel.Visible = true;
            string[] droppedFiles = e.Data.GetData(DataFormats.FileDrop) as string[]; // Array of paths of dropped items
            string[] uploadQueue = droppedFiles.Where(p => Path.GetExtension(p) == ".zip").ToArray();
            foreach (string file in uploadQueue)
            {
                uploadedCount++;
                statusLabel.Text = $"[{uploadedCount}/{uploadQueue.Length}] {Path.GetFileName(file)}";
                string songTemp = await Task.Run(() => extractSong(file));
                string songHash = await Task.Run(() => generateSongHash(songTemp));
                string deviceFolder = await Task.Run(() => uploadSong(songTemp, songHash));
                songLoader.Add(createLoaderEntry(deviceFolder, songHash));
                if (Directory.Exists(songTemp))
                    Directory.Delete(songTemp, true);
                editorForm.log.Info($"Uploaded song \"{Path.GetFileName(file)}\"");
            }
            File.WriteAllText(songLoaderTemp, JsonConvert.SerializeObject(songLoader));
            editorForm.pushSongLoaderJSON();
            statusLabel.Text = $"Uploaded {uploadedCount} songs";
            cancelButton.Enabled = true;
            dropZone.Enabled = true;
        }
        private string uploadSong(string sourceFolder, string songHash)
        {
            string destFolder = "/sdcard/ModData/com.beatgames.beatsaber/Mods/SongLoader/CustomLevels/" + songHash;
            editorForm.log.Debug($"Pushed \"{sourceFolder}\" to \"{destFolder}\"");
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
            editorForm.log.Debug($"Unpacking \"{zipFile}\" to \"{folderOut}\"");
            ZipFile.ExtractToDirectory(zipFile, folderOut);
            return folderOut;
        }
        private string generateSongHash(string songPath)
        {
            editorForm.log.Debug($"Getting song hash for \"{songPath}\"");
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
        private JProperty createLoaderEntry(string songPath, string songHash)
        {
            string songStats = @"{
                directoryHash: 0,
                sha1: '" + songHash + @"',
                songDuration: 0
                }";
            JObject songStatsObject = JObject.Parse(songStats);
            JProperty songEntry = new JProperty(songPath, songStatsObject);
            return songEntry;
        }
    }
}
