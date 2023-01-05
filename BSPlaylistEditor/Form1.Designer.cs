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
            this.saveButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.songModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.allSongsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playlistDropDown
            // 
            this.playlistDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playlistDropDown.Enabled = false;
            this.playlistDropDown.FormattingEnabled = true;
            this.playlistDropDown.Location = new System.Drawing.Point(427, 9);
            this.playlistDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.playlistDropDown.Name = "playlistDropDown";
            this.playlistDropDown.Size = new System.Drawing.Size(166, 21);
            this.playlistDropDown.TabIndex = 2;
            this.playlistDropDown.SelectedIndexChanged += new System.EventHandler(this.playlistDropDown_SelectedIndexChanged);
            this.playlistDropDown.Click += new System.EventHandler(this.playlistDropDown_Click);
            // 
            // allSongsProgressBar
            // 
            this.allSongsProgressBar.Location = new System.Drawing.Point(125, 9);
            this.allSongsProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.allSongsProgressBar.MarqueeAnimationSpeed = 0;
            this.allSongsProgressBar.Name = "allSongsProgressBar";
            this.allSongsProgressBar.Size = new System.Drawing.Size(235, 20);
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
            this.allSongsGridView.Location = new System.Drawing.Point(10, 34);
            this.allSongsGridView.Margin = new System.Windows.Forms.Padding(2);
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
            this.allSongsGridView.RowTemplate.Height = 24;
            this.allSongsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allSongsGridView.Size = new System.Drawing.Size(350, 411);
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
            this.playlistGridView.Location = new System.Drawing.Point(427, 34);
            this.playlistGridView.Margin = new System.Windows.Forms.Padding(2);
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
            this.playlistGridView.RowTemplate.Height = 24;
            this.playlistGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playlistGridView.Size = new System.Drawing.Size(350, 411);
            this.playlistGridView.TabIndex = 5;
            this.playlistGridView.Sorted += new System.EventHandler(this.playlistGridView_Sorted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "All Custom Songs";
            // 
            // playlistProgressBar
            // 
            this.playlistProgressBar.Location = new System.Drawing.Point(597, 9);
            this.playlistProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.playlistProgressBar.MarqueeAnimationSpeed = 0;
            this.playlistProgressBar.Name = "playlistProgressBar";
            this.playlistProgressBar.Size = new System.Drawing.Size(93, 20);
            this.playlistProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.playlistProgressBar.TabIndex = 7;
            this.playlistProgressBar.Visible = false;
            // 
            // addSongButton
            // 
            this.addSongButton.Enabled = false;
            this.addSongButton.Location = new System.Drawing.Point(366, 138);
            this.addSongButton.Name = "addSongButton";
            this.addSongButton.Size = new System.Drawing.Size(56, 23);
            this.addSongButton.TabIndex = 8;
            this.addSongButton.Text = ">>>>>";
            this.addSongButton.UseVisualStyleBackColor = true;
            this.addSongButton.Click += new System.EventHandler(this.addSongButton_Click);
            // 
            // removeSongButton
            // 
            this.removeSongButton.Enabled = false;
            this.removeSongButton.Location = new System.Drawing.Point(365, 167);
            this.removeSongButton.Name = "removeSongButton";
            this.removeSongButton.Size = new System.Drawing.Size(57, 23);
            this.removeSongButton.TabIndex = 9;
            this.removeSongButton.Text = "<<<<<";
            this.removeSongButton.UseVisualStyleBackColor = true;
            this.removeSongButton.Click += new System.EventHandler(this.removeSongButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(696, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(209, 9);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(151, 20);
            this.searchBox.TabIndex = 11;
            this.searchBox.Visible = false;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(162, 12);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(41, 13);
            this.searchLabel.TabIndex = 12;
            this.searchLabel.Text = "Search";
            this.searchLabel.Visible = false;
            // 
            // songModelBindingSource
            // 
            this.songModelBindingSource.DataSource = typeof(BSPlaylistEditor.SongModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 456);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeSongButton);
            this.Controls.Add(this.addSongButton);
            this.Controls.Add(this.playlistProgressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playlistGridView);
            this.Controls.Add(this.allSongsGridView);
            this.Controls.Add(this.allSongsProgressBar);
            this.Controls.Add(this.playlistDropDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Simple Playlist Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allSongsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playlistGridView)).EndInit();
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
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchLabel;
    }
}

