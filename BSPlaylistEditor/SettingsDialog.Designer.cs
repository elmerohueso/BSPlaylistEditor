namespace BSPlaylistEditor
{
    partial class SettingsDialog
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
            this.tempFolderBrowseButton = new System.Windows.Forms.Button();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.tempFolderBox = new System.Windows.Forms.TextBox();
            this.tempFolderLabel = new System.Windows.Forms.Label();
            this.backupFolderBrowseButton = new System.Windows.Forms.Button();
            this.backupFolderBox = new System.Windows.Forms.TextBox();
            this.bacupFolderLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // tempFolderBrowseButton
            // 
            this.tempFolderBrowseButton.Location = new System.Drawing.Point(300, 4);
            this.tempFolderBrowseButton.Name = "tempFolderBrowseButton";
            this.tempFolderBrowseButton.Size = new System.Drawing.Size(66, 23);
            this.tempFolderBrowseButton.TabIndex = 9;
            this.tempFolderBrowseButton.Text = "Browse...";
            this.tempFolderBrowseButton.UseVisualStyleBackColor = true;
            this.tempFolderBrowseButton.Click += new System.EventHandler(this.tempFolderBrowseButton_Click);
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.Location = new System.Drawing.Point(210, 71);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSettingsButton.TabIndex = 12;
            this.cancelSettingsButton.Text = "Cancel";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.cancelSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(291, 71);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 11;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // tempFolderBox
            // 
            this.tempFolderBox.Location = new System.Drawing.Point(94, 6);
            this.tempFolderBox.Name = "tempFolderBox";
            this.tempFolderBox.Size = new System.Drawing.Size(200, 20);
            this.tempFolderBox.TabIndex = 7;
            // 
            // tempFolderLabel
            // 
            this.tempFolderLabel.AutoSize = true;
            this.tempFolderLabel.Location = new System.Drawing.Point(22, 9);
            this.tempFolderLabel.Name = "tempFolderLabel";
            this.tempFolderLabel.Size = new System.Drawing.Size(66, 13);
            this.tempFolderLabel.TabIndex = 8;
            this.tempFolderLabel.Text = "Temp Folder";
            // 
            // backupFolderBrowseButton
            // 
            this.backupFolderBrowseButton.Location = new System.Drawing.Point(300, 30);
            this.backupFolderBrowseButton.Name = "backupFolderBrowseButton";
            this.backupFolderBrowseButton.Size = new System.Drawing.Size(66, 23);
            this.backupFolderBrowseButton.TabIndex = 15;
            this.backupFolderBrowseButton.Text = "Browse...";
            this.backupFolderBrowseButton.UseVisualStyleBackColor = true;
            this.backupFolderBrowseButton.Click += new System.EventHandler(this.backupFolderBrowseButton_Click);
            // 
            // backupFolderBox
            // 
            this.backupFolderBox.Location = new System.Drawing.Point(94, 32);
            this.backupFolderBox.Name = "backupFolderBox";
            this.backupFolderBox.Size = new System.Drawing.Size(200, 20);
            this.backupFolderBox.TabIndex = 13;
            // 
            // bacupFolderLabel
            // 
            this.bacupFolderLabel.AutoSize = true;
            this.bacupFolderLabel.Location = new System.Drawing.Point(12, 35);
            this.bacupFolderLabel.Name = "bacupFolderLabel";
            this.bacupFolderLabel.Size = new System.Drawing.Size(76, 13);
            this.bacupFolderLabel.TabIndex = 14;
            this.bacupFolderLabel.Text = "Backup Folder";
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 99);
            this.ControlBox = false;
            this.Controls.Add(this.backupFolderBrowseButton);
            this.Controls.Add(this.backupFolderBox);
            this.Controls.Add(this.bacupFolderLabel);
            this.Controls.Add(this.tempFolderBrowseButton);
            this.Controls.Add(this.cancelSettingsButton);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.tempFolderBox);
            this.Controls.Add(this.tempFolderLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tempFolderBrowseButton;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.TextBox tempFolderBox;
        private System.Windows.Forms.Label tempFolderLabel;
        private System.Windows.Forms.Button backupFolderBrowseButton;
        private System.Windows.Forms.TextBox backupFolderBox;
        private System.Windows.Forms.Label bacupFolderLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}