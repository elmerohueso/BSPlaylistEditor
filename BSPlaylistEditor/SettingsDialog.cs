using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSPlaylistEditor
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void tempFolderBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select a folder to store temporary files";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tempFolderBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void backupFolderBrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select a folder to store playlist backups";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                backupFolderBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            tempFolderBox.Text = editorForm.readConfigValue("tempFolder");
            backupFolderBox.Text = editorForm.readConfigValue("backupFolder");
        }

        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            string tempFolder = tempFolderBox.Text;
            if(Path.GetFileName(tempFolder.TrimEnd(Path.DirectorySeparatorChar)) != "BSPlayistEditorTemp")
                tempFolder = Path.Combine(tempFolder, "BSPlayistEditorTemp");
            string backupFolder = backupFolderBox.Text;
            if (Path.GetFileName(backupFolder.TrimEnd(Path.DirectorySeparatorChar)) != "BSPlayistEditorBackups")
                backupFolder = Path.Combine(backupFolder, "BSPlayistEditorBackups");
            editorForm.writeConfigValue("tempFolder", tempFolder, true);
            editorForm.writeConfigValue("backupFolder", backupFolder, true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
