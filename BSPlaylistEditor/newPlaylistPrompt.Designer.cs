namespace BSPlaylistEditor
{
    partial class newPlaylistPrompt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newPlaylistPrompt));
            this.playlistTitleLabel = new System.Windows.Forms.Label();
            this.playlistTitleBox = new System.Windows.Forms.TextBox();
            this.playlistCoverLabel = new System.Windows.Forms.Label();
            this.savePlaylistButton = new System.Windows.Forms.Button();
            this.cancelPlaylistButton = new System.Windows.Forms.Button();
            this.browseCoverDialog = new System.Windows.Forms.OpenFileDialog();
            this.playlistCoverBrowseButton = new System.Windows.Forms.Button();
            this.playlistCoverPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playlistCoverPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // playlistTitleLabel
            // 
            this.playlistTitleLabel.AutoSize = true;
            this.playlistTitleLabel.Location = new System.Drawing.Point(17, 16);
            this.playlistTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playlistTitleLabel.Name = "playlistTitleLabel";
            this.playlistTitleLabel.Size = new System.Drawing.Size(33, 16);
            this.playlistTitleLabel.TabIndex = 0;
            this.playlistTitleLabel.Text = "Title";
            // 
            // playlistTitleBox
            // 
            this.playlistTitleBox.Location = new System.Drawing.Point(21, 37);
            this.playlistTitleBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playlistTitleBox.Name = "playlistTitleBox";
            this.playlistTitleBox.Size = new System.Drawing.Size(193, 22);
            this.playlistTitleBox.TabIndex = 0;
            // 
            // playlistCoverLabel
            // 
            this.playlistCoverLabel.AutoSize = true;
            this.playlistCoverLabel.Location = new System.Drawing.Point(225, 16);
            this.playlistCoverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playlistCoverLabel.Name = "playlistCoverLabel";
            this.playlistCoverLabel.Size = new System.Drawing.Size(43, 16);
            this.playlistCoverLabel.TabIndex = 2;
            this.playlistCoverLabel.Text = "Cover";
            // 
            // savePlaylistButton
            // 
            this.savePlaylistButton.Location = new System.Drawing.Point(259, 167);
            this.savePlaylistButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.savePlaylistButton.Name = "savePlaylistButton";
            this.savePlaylistButton.Size = new System.Drawing.Size(100, 28);
            this.savePlaylistButton.TabIndex = 4;
            this.savePlaylistButton.Text = "Save";
            this.savePlaylistButton.UseVisualStyleBackColor = true;
            this.savePlaylistButton.Click += new System.EventHandler(this.savePlaylistButton_Click);
            // 
            // cancelPlaylistButton
            // 
            this.cancelPlaylistButton.Location = new System.Drawing.Point(151, 167);
            this.cancelPlaylistButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelPlaylistButton.Name = "cancelPlaylistButton";
            this.cancelPlaylistButton.Size = new System.Drawing.Size(100, 28);
            this.cancelPlaylistButton.TabIndex = 5;
            this.cancelPlaylistButton.Text = "Cancel";
            this.cancelPlaylistButton.UseVisualStyleBackColor = true;
            this.cancelPlaylistButton.Click += new System.EventHandler(this.cancelPlaylistButton_Click);
            // 
            // browseCoverDialog
            // 
            this.browseCoverDialog.Filter = "Image Files(*.JPG;*.PNG)|*.JPG;*.PNG";
            // 
            // playlistCoverBrowseButton
            // 
            this.playlistCoverBrowseButton.Location = new System.Drawing.Point(96, 69);
            this.playlistCoverBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playlistCoverBrowseButton.Name = "playlistCoverBrowseButton";
            this.playlistCoverBrowseButton.Size = new System.Drawing.Size(120, 28);
            this.playlistCoverBrowseButton.TabIndex = 1;
            this.playlistCoverBrowseButton.Text = "Browse Cover...";
            this.playlistCoverBrowseButton.UseVisualStyleBackColor = true;
            this.playlistCoverBrowseButton.Click += new System.EventHandler(this.playlistCoverBrowseButton_Click);
            // 
            // playlistCoverPicture
            // 
            this.playlistCoverPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.playlistCoverPicture.Location = new System.Drawing.Point(229, 36);
            this.playlistCoverPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.playlistCoverPicture.Name = "playlistCoverPicture";
            this.playlistCoverPicture.Size = new System.Drawing.Size(132, 122);
            this.playlistCoverPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playlistCoverPicture.TabIndex = 6;
            this.playlistCoverPicture.TabStop = false;
            // 
            // newPlaylistPrompt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(367, 202);
            this.ControlBox = false;
            this.Controls.Add(this.playlistCoverPicture);
            this.Controls.Add(this.playlistCoverBrowseButton);
            this.Controls.Add(this.cancelPlaylistButton);
            this.Controls.Add(this.savePlaylistButton);
            this.Controls.Add(this.playlistCoverLabel);
            this.Controls.Add(this.playlistTitleBox);
            this.Controls.Add(this.playlistTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newPlaylistPrompt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Playlist";
            this.Load += new System.EventHandler(this.newPlaylistPrompt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playlistCoverPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playlistTitleLabel;
        private System.Windows.Forms.TextBox playlistTitleBox;
        private System.Windows.Forms.Label playlistCoverLabel;
        private System.Windows.Forms.Button savePlaylistButton;
        private System.Windows.Forms.Button cancelPlaylistButton;
        private System.Windows.Forms.OpenFileDialog browseCoverDialog;
        private System.Windows.Forms.Button playlistCoverBrowseButton;
        private System.Windows.Forms.PictureBox playlistCoverPicture;
    }
}