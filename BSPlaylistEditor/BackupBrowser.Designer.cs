namespace BSPlaylistEditor
{
    partial class BackupBrowser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.deleteBackupButton = new System.Windows.Forms.Button();
            this.playlistCoverPreview = new System.Windows.Forms.PictureBox();
            this.restoreBackupButton = new System.Windows.Forms.Button();
            this.playlistProgressBar = new System.Windows.Forms.ProgressBar();
            this.playlistGridView = new System.Windows.Forms.DataGridView();
            this.playlistBackupsLabel = new System.Windows.Forms.Label();
            this.backupListGridView = new System.Windows.Forms.DataGridView();
            this.backupsProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.playlistCoverPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteBackupButton
            // 
            this.deleteBackupButton.Enabled = false;
            this.deleteBackupButton.Location = new System.Drawing.Point(206, 4);
            this.deleteBackupButton.Name = "deleteBackupButton";
            this.deleteBackupButton.Size = new System.Drawing.Size(75, 23);
            this.deleteBackupButton.TabIndex = 22;
            this.deleteBackupButton.Text = "Delete";
            this.deleteBackupButton.UseVisualStyleBackColor = true;
            this.deleteBackupButton.Visible = false;
            this.deleteBackupButton.Click += new System.EventHandler(this.deleteBackupButton_Click);
            // 
            // playlistCoverPreview
            // 
            this.playlistCoverPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.playlistCoverPreview.Location = new System.Drawing.Point(670, 31);
            this.playlistCoverPreview.Name = "playlistCoverPreview";
            this.playlistCoverPreview.Size = new System.Drawing.Size(100, 100);
            this.playlistCoverPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playlistCoverPreview.TabIndex = 21;
            this.playlistCoverPreview.TabStop = false;
            // 
            // restoreBackupButton
            // 
            this.restoreBackupButton.Enabled = false;
            this.restoreBackupButton.Location = new System.Drawing.Point(125, 4);
            this.restoreBackupButton.Name = "restoreBackupButton";
            this.restoreBackupButton.Size = new System.Drawing.Size(75, 23);
            this.restoreBackupButton.TabIndex = 19;
            this.restoreBackupButton.Text = "Restore";
            this.restoreBackupButton.UseVisualStyleBackColor = true;
            this.restoreBackupButton.Visible = false;
            this.restoreBackupButton.Click += new System.EventHandler(this.restoreBackupButton_Click);
            // 
            // playlistProgressBar
            // 
            this.playlistProgressBar.Location = new System.Drawing.Point(315, 7);
            this.playlistProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.playlistProgressBar.MarqueeAnimationSpeed = 0;
            this.playlistProgressBar.Name = "playlistProgressBar";
            this.playlistProgressBar.Size = new System.Drawing.Size(169, 20);
            this.playlistProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.playlistProgressBar.TabIndex = 18;
            this.playlistProgressBar.Visible = false;
            // 
            // playlistGridView
            // 
            this.playlistGridView.AllowUserToAddRows = false;
            this.playlistGridView.AllowUserToDeleteRows = false;
            this.playlistGridView.AllowUserToResizeRows = false;
            this.playlistGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.playlistGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.playlistGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.playlistGridView.DefaultCellStyle = dataGridViewCellStyle20;
            this.playlistGridView.Location = new System.Drawing.Point(315, 31);
            this.playlistGridView.Margin = new System.Windows.Forms.Padding(2);
            this.playlistGridView.MultiSelect = false;
            this.playlistGridView.Name = "playlistGridView";
            this.playlistGridView.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.playlistGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.playlistGridView.RowHeadersVisible = false;
            this.playlistGridView.RowTemplate.Height = 24;
            this.playlistGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playlistGridView.Size = new System.Drawing.Size(350, 411);
            this.playlistGridView.TabIndex = 17;
            // 
            // playlistBackupsLabel
            // 
            this.playlistBackupsLabel.AutoSize = true;
            this.playlistBackupsLabel.Location = new System.Drawing.Point(12, 9);
            this.playlistBackupsLabel.Name = "playlistBackupsLabel";
            this.playlistBackupsLabel.Size = new System.Drawing.Size(84, 13);
            this.playlistBackupsLabel.TabIndex = 25;
            this.playlistBackupsLabel.Text = "Playlist Backups";
            // 
            // backupListGridView
            // 
            this.backupListGridView.AllowUserToAddRows = false;
            this.backupListGridView.AllowUserToDeleteRows = false;
            this.backupListGridView.AllowUserToResizeColumns = false;
            this.backupListGridView.AllowUserToResizeRows = false;
            this.backupListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.backupListGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.backupListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.backupListGridView.DefaultCellStyle = dataGridViewCellStyle23;
            this.backupListGridView.Location = new System.Drawing.Point(10, 31);
            this.backupListGridView.Margin = new System.Windows.Forms.Padding(2);
            this.backupListGridView.MultiSelect = false;
            this.backupListGridView.Name = "backupListGridView";
            this.backupListGridView.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.backupListGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.backupListGridView.RowHeadersVisible = false;
            this.backupListGridView.RowTemplate.Height = 24;
            this.backupListGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.backupListGridView.Size = new System.Drawing.Size(286, 411);
            this.backupListGridView.TabIndex = 24;
            this.backupListGridView.SelectionChanged += new System.EventHandler(this.backupListGridView_SelectionChanged);
            // 
            // backupsProgressBar
            // 
            this.backupsProgressBar.Location = new System.Drawing.Point(125, 7);
            this.backupsProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.backupsProgressBar.MarqueeAnimationSpeed = 0;
            this.backupsProgressBar.Name = "backupsProgressBar";
            this.backupsProgressBar.Size = new System.Drawing.Size(171, 20);
            this.backupsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.backupsProgressBar.TabIndex = 23;
            // 
            // BackupBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.playlistBackupsLabel);
            this.Controls.Add(this.backupListGridView);
            this.Controls.Add(this.backupsProgressBar);
            this.Controls.Add(this.deleteBackupButton);
            this.Controls.Add(this.playlistCoverPreview);
            this.Controls.Add(this.restoreBackupButton);
            this.Controls.Add(this.playlistProgressBar);
            this.Controls.Add(this.playlistGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupBrowser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Playlist Backups";
            this.Load += new System.EventHandler(this.BackupBrowser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playlistCoverPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backupListGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteBackupButton;
        private System.Windows.Forms.PictureBox playlistCoverPreview;
        private System.Windows.Forms.Button restoreBackupButton;
        private System.Windows.Forms.ProgressBar playlistProgressBar;
        private System.Windows.Forms.DataGridView playlistGridView;
        private System.Windows.Forms.Label playlistBackupsLabel;
        private System.Windows.Forms.DataGridView backupListGridView;
        private System.Windows.Forms.ProgressBar backupsProgressBar;
    }
}