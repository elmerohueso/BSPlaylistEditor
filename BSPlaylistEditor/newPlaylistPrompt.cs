using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSPlaylistEditor
{
    public partial class newPlaylistPrompt : Form
    {
        public string playlistCoverPath { get; set; }
        public string playlistTitle { get; set; }
        public newPlaylistPrompt()
        {
            InitializeComponent();
        }

        private void cancelPlaylistButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playlistCoverBrowseButton_Click(object sender, EventArgs e)
        {
            if(browseCoverDialog.ShowDialog() == DialogResult.OK)
            {
                playlistCoverPath = browseCoverDialog.FileName;
                playlistCoverPicture.Image = Image.FromFile(playlistCoverPath);            
            }
        }

        private void savePlaylistButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(playlistTitleBox.Text))
            {
                playlistTitle = playlistTitleBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void newPlaylistPrompt_Load(object sender, EventArgs e)
        {
            playlistTitleBox.Focus();
        }
    }
}
