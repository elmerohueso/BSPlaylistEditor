namespace BSPlaylistEditor
{
    partial class UploadDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dropZone = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(264, 85);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Close";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // dropZone
            // 
            this.dropZone.AllowDrop = true;
            this.dropZone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dropZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropZone.Location = new System.Drawing.Point(12, 9);
            this.dropZone.Name = "dropZone";
            this.dropZone.Size = new System.Drawing.Size(354, 72);
            this.dropZone.TabIndex = 21;
            this.dropZone.Text = "Drop song ZIP files here";
            this.dropZone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dropZone.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropZone_DragDrop);
            this.dropZone.DragOver += new System.Windows.Forms.DragEventHandler(this.dropZone_DragOver);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(9, 91);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 16);
            this.statusLabel.TabIndex = 22;
            this.statusLabel.Text = "Status";
            this.statusLabel.Visible = false;
            // 
            // UploadDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(378, 124);
            this.ControlBox = false;
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.dropZone);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload Songs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label dropZone;
        private System.Windows.Forms.Label statusLabel;
    }
}