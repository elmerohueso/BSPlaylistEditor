﻿using BSPlaylistEditor.Models;

namespace BSPlaylistEditor
{
    partial class editorForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editorForm));
            this.playlistDropDown = new System.Windows.Forms.ComboBox();
            this.allSongsProgressBar = new System.Windows.Forms.ProgressBar();
            this.allSongsGridView = new System.Windows.Forms.DataGridView();
            this.playlistGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.playlistProgressBar = new System.Windows.Forms.ProgressBar();
            this.addSongButton = new System.Windows.Forms.Button();
            this.removeSongButton = new System.Windows.Forms.Button();
            this.savePlaylistButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.newPlaylistButton = new System.Windows.Forms.Button();
            this.playlistCoverPreview = new System.Windows.Forms.PictureBox();
            this.deletePlaylistButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshAllSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browsePlaylistBackupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCoverButton = new System.Windows.Forms.Button();
            this.browseCoverDialog = new System.Windows.Forms.OpenFileDialog();
            this.playlistUpButton = new System.Windows.Forms.Button();
            this.playlistDownButton = new System.Windows.Forms.Button();
            this.movePlaylistLabel = new System.Windows.Forms.Label();
            this.songModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.allSongsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistCoverPreview)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playlistDropDown
            // 
            this.playlistDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playlistDropDown.Enabled = false;
            this.playlistDropDown.FormattingEnabled = true;
            this.playlistDropDown.Location = new System.Drawing.Point(569, 26);
            this.playlistDropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playlistDropDown.Name = "playlistDropDown";
            this.playlistDropDown.Size = new System.Drawing.Size(220, 24);
            this.playlistDropDown.TabIndex = 2;
            this.playlistDropDown.SelectedIndexChanged += new System.EventHandler(this.playlistDropDown_SelectedIndexChanged);
            this.playlistDropDown.Click += new System.EventHandler(this.playlistDropDown_Click);
            // 
            // allSongsProgressBar
            // 
            this.allSongsProgressBar.Location = new System.Drawing.Point(167, 26);
            this.allSongsProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allSongsProgressBar.MarqueeAnimationSpeed = 0;
            this.allSongsProgressBar.Name = "allSongsProgressBar";
            this.allSongsProgressBar.Size = new System.Drawing.Size(313, 25);
            this.allSongsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.allSongsProgressBar.TabIndex = 3;
            // 
            // allSongsGridView
            // 
            this.allSongsGridView.AllowUserToAddRows = false;
            this.allSongsGridView.AllowUserToDeleteRows = false;
            this.allSongsGridView.AllowUserToOrderColumns = true;
            this.allSongsGridView.AllowUserToResizeRows = false;
            this.allSongsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allSongsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.allSongsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.allSongsGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.allSongsGridView.Location = new System.Drawing.Point(13, 57);
            this.allSongsGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allSongsGridView.Name = "allSongsGridView";
            this.allSongsGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allSongsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.allSongsGridView.RowHeadersVisible = false;
            this.allSongsGridView.RowHeadersWidth = 51;
            this.allSongsGridView.RowTemplate.Height = 24;
            this.allSongsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allSongsGridView.Size = new System.Drawing.Size(467, 506);
            this.allSongsGridView.TabIndex = 4;
            // 
            // playlistGridView
            // 
            this.playlistGridView.AllowUserToAddRows = false;
            this.playlistGridView.AllowUserToDeleteRows = false;
            this.playlistGridView.AllowUserToOrderColumns = true;
            this.playlistGridView.AllowUserToResizeRows = false;
            this.playlistGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.playlistGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.playlistGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.playlistGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.playlistGridView.Location = new System.Drawing.Point(569, 57);
            this.playlistGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playlistGridView.Name = "playlistGridView";
            this.playlistGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.playlistGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.playlistGridView.RowHeadersVisible = false;
            this.playlistGridView.RowHeadersWidth = 51;
            this.playlistGridView.RowTemplate.Height = 24;
            this.playlistGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playlistGridView.Size = new System.Drawing.Size(467, 506);
            this.playlistGridView.TabIndex = 5;
            this.playlistGridView.Sorted += new System.EventHandler(this.playlistGridView_Sorted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "All Custom Songs";
            // 
            // playlistProgressBar
            // 
            this.playlistProgressBar.Location = new System.Drawing.Point(796, 26);
            this.playlistProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playlistProgressBar.MarqueeAnimationSpeed = 0;
            this.playlistProgressBar.Name = "playlistProgressBar";
            this.playlistProgressBar.Size = new System.Drawing.Size(124, 25);
            this.playlistProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.playlistProgressBar.TabIndex = 7;
            this.playlistProgressBar.Visible = false;
            // 
            // addSongButton
            // 
            this.addSongButton.Enabled = false;
            this.addSongButton.Location = new System.Drawing.Point(488, 185);
            this.addSongButton.Margin = new System.Windows.Forms.Padding(4);
            this.addSongButton.Name = "addSongButton";
            this.addSongButton.Size = new System.Drawing.Size(75, 28);
            this.addSongButton.TabIndex = 8;
            this.addSongButton.Text = ">>>>>";
            this.addSongButton.UseVisualStyleBackColor = true;
            this.addSongButton.Click += new System.EventHandler(this.addSongButton_Click);
            // 
            // removeSongButton
            // 
            this.removeSongButton.Enabled = false;
            this.removeSongButton.Location = new System.Drawing.Point(487, 220);
            this.removeSongButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeSongButton.Name = "removeSongButton";
            this.removeSongButton.Size = new System.Drawing.Size(76, 28);
            this.removeSongButton.TabIndex = 9;
            this.removeSongButton.Text = "<<<<<";
            this.removeSongButton.UseVisualStyleBackColor = true;
            this.removeSongButton.Click += new System.EventHandler(this.removeSongButton_Click);
            // 
            // savePlaylistButton
            // 
            this.savePlaylistButton.Enabled = false;
            this.savePlaylistButton.Location = new System.Drawing.Point(905, 23);
            this.savePlaylistButton.Margin = new System.Windows.Forms.Padding(4);
            this.savePlaylistButton.Name = "savePlaylistButton";
            this.savePlaylistButton.Size = new System.Drawing.Size(100, 28);
            this.savePlaylistButton.TabIndex = 10;
            this.savePlaylistButton.Text = "Save";
            this.savePlaylistButton.UseVisualStyleBackColor = true;
            this.savePlaylistButton.Visible = false;
            this.savePlaylistButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(279, 26);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(200, 20);
            this.searchBox.TabIndex = 11;
            this.searchBox.Visible = false;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(216, 30);
            this.searchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(46, 15);
            this.searchLabel.TabIndex = 12;
            this.searchLabel.Text = "Search";
            this.searchLabel.Visible = false;
            // 
            // newPlaylistButton
            // 
            this.newPlaylistButton.Enabled = false;
            this.newPlaylistButton.Location = new System.Drawing.Point(1013, 23);
            this.newPlaylistButton.Margin = new System.Windows.Forms.Padding(4);
            this.newPlaylistButton.Name = "newPlaylistButton";
            this.newPlaylistButton.Size = new System.Drawing.Size(100, 28);
            this.newPlaylistButton.TabIndex = 13;
            this.newPlaylistButton.Text = "New";
            this.newPlaylistButton.UseVisualStyleBackColor = true;
            this.newPlaylistButton.Visible = false;
            this.newPlaylistButton.Click += new System.EventHandler(this.newPlaylistButton_Click);
            // 
            // playlistCoverPreview
            // 
            this.playlistCoverPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.playlistCoverPreview.Location = new System.Drawing.Point(1044, 57);
            this.playlistCoverPreview.Margin = new System.Windows.Forms.Padding(4);
            this.playlistCoverPreview.Name = "playlistCoverPreview";
            this.playlistCoverPreview.Size = new System.Drawing.Size(132, 122);
            this.playlistCoverPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playlistCoverPreview.TabIndex = 14;
            this.playlistCoverPreview.TabStop = false;
            // 
            // deletePlaylistButton
            // 
            this.deletePlaylistButton.Enabled = false;
            this.deletePlaylistButton.Location = new System.Drawing.Point(797, 23);
            this.deletePlaylistButton.Margin = new System.Windows.Forms.Padding(4);
            this.deletePlaylistButton.Name = "deletePlaylistButton";
            this.deletePlaylistButton.Size = new System.Drawing.Size(100, 28);
            this.deletePlaylistButton.TabIndex = 15;
            this.deletePlaylistButton.Text = "Delete";
            this.deletePlaylistButton.UseVisualStyleBackColor = true;
            this.deletePlaylistButton.Visible = false;
            this.deletePlaylistButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1196, 30);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshAllSongsToolStripMenuItem,
            this.browsePlaylistBackupsToolStripMenuItem,
            this.uploadSongsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshAllSongsToolStripMenuItem
            // 
            this.refreshAllSongsToolStripMenuItem.Name = "refreshAllSongsToolStripMenuItem";
            this.refreshAllSongsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.refreshAllSongsToolStripMenuItem.Text = "Refresh All Songs";
            this.refreshAllSongsToolStripMenuItem.Click += new System.EventHandler(this.refreshAllSongsToolStripMenuItem_Click);
            // 
            // browsePlaylistBackupsToolStripMenuItem
            // 
            this.browsePlaylistBackupsToolStripMenuItem.Name = "browsePlaylistBackupsToolStripMenuItem";
            this.browsePlaylistBackupsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.browsePlaylistBackupsToolStripMenuItem.Text = "Browse Playlist Backups";
            this.browsePlaylistBackupsToolStripMenuItem.Click += new System.EventHandler(this.browsePlaylistBackupsToolStripMenuItem_Click);
            // 
            // uploadSongsToolStripMenuItem
            // 
            this.uploadSongsToolStripMenuItem.Name = "uploadSongsToolStripMenuItem";
            this.uploadSongsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.uploadSongsToolStripMenuItem.Text = "Upload Songs";
            this.uploadSongsToolStripMenuItem.Click += new System.EventHandler(this.uploadSongsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // changeCoverButton
            // 
            this.changeCoverButton.Enabled = false;
            this.changeCoverButton.Location = new System.Drawing.Point(1044, 187);
            this.changeCoverButton.Margin = new System.Windows.Forms.Padding(4);
            this.changeCoverButton.Name = "changeCoverButton";
            this.changeCoverButton.Size = new System.Drawing.Size(133, 28);
            this.changeCoverButton.TabIndex = 17;
            this.changeCoverButton.Text = "Change Cover";
            this.changeCoverButton.UseVisualStyleBackColor = true;
            this.changeCoverButton.Click += new System.EventHandler(this.changeCoverButton_Click);
            // 
            // browseCoverDialog
            // 
            this.browseCoverDialog.Filter = "Image Files(*.JPG;*.PNG)|*.JPG;*.PNG";
            // 
            // playlistUpButton
            // 
            this.playlistUpButton.Enabled = false;
            this.playlistUpButton.Location = new System.Drawing.Point(1084, 267);
            this.playlistUpButton.Margin = new System.Windows.Forms.Padding(4);
            this.playlistUpButton.Name = "playlistUpButton";
            this.playlistUpButton.Size = new System.Drawing.Size(44, 28);
            this.playlistUpButton.TabIndex = 18;
            this.playlistUpButton.Text = "↑";
            this.playlistUpButton.UseVisualStyleBackColor = true;
            this.playlistUpButton.Click += new System.EventHandler(this.playlistUpButton_Click);
            // 
            // playlistDownButton
            // 
            this.playlistDownButton.Enabled = false;
            this.playlistDownButton.Location = new System.Drawing.Point(1084, 303);
            this.playlistDownButton.Margin = new System.Windows.Forms.Padding(4);
            this.playlistDownButton.Name = "playlistDownButton";
            this.playlistDownButton.Size = new System.Drawing.Size(44, 28);
            this.playlistDownButton.TabIndex = 19;
            this.playlistDownButton.Text = "↓";
            this.playlistDownButton.UseVisualStyleBackColor = true;
            this.playlistDownButton.Click += new System.EventHandler(this.playlistDownButton_Click);
            // 
            // movePlaylistLabel
            // 
            this.movePlaylistLabel.AutoSize = true;
            this.movePlaylistLabel.Enabled = false;
            this.movePlaylistLabel.Location = new System.Drawing.Point(1061, 247);
            this.movePlaylistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.movePlaylistLabel.Name = "movePlaylistLabel";
            this.movePlaylistLabel.Size = new System.Drawing.Size(78, 15);
            this.movePlaylistLabel.TabIndex = 20;
            this.movePlaylistLabel.Text = "Move Playlist";
            // 
            // songModelBindingSource
            // 
            this.songModelBindingSource.DataSource = typeof(BSPlaylistEditor.Models.SongModel);
            // 
            // editorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 582);
            this.Controls.Add(this.movePlaylistLabel);
            this.Controls.Add(this.playlistDownButton);
            this.Controls.Add(this.playlistUpButton);
            this.Controls.Add(this.changeCoverButton);
            this.Controls.Add(this.deletePlaylistButton);
            this.Controls.Add(this.playlistCoverPreview);
            this.Controls.Add(this.newPlaylistButton);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.savePlaylistButton);
            this.Controls.Add(this.removeSongButton);
            this.Controls.Add(this.addSongButton);
            this.Controls.Add(this.playlistProgressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playlistGridView);
            this.Controls.Add(this.allSongsGridView);
            this.Controls.Add(this.allSongsProgressBar);
            this.Controls.Add(this.playlistDropDown);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "editorForm";
            this.Text = "Simple Playlist Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allSongsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistCoverPreview)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox playlistDropDown;
        private System.Windows.Forms.ProgressBar allSongsProgressBar;
        private System.Windows.Forms.DataGridView allSongsGridView;
        private System.Windows.Forms.BindingSource songModelBindingSource;
        private System.Windows.Forms.DataGridView playlistGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar playlistProgressBar;
        private System.Windows.Forms.Button addSongButton;
        private System.Windows.Forms.Button removeSongButton;
        private System.Windows.Forms.Button savePlaylistButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button newPlaylistButton;
        private System.Windows.Forms.PictureBox playlistCoverPreview;
        private System.Windows.Forms.Button deletePlaylistButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshAllSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browsePlaylistBackupsToolStripMenuItem;
        private System.Windows.Forms.Button changeCoverButton;
        private System.Windows.Forms.OpenFileDialog browseCoverDialog;
        private System.Windows.Forms.Button playlistUpButton;
        private System.Windows.Forms.Button playlistDownButton;
        private System.Windows.Forms.Label movePlaylistLabel;
        private System.Windows.Forms.ToolStripMenuItem uploadSongsToolStripMenuItem;
    }
}

