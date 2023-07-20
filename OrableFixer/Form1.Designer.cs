namespace OrableFixer
{
    partial class Form1
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rootFolder = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FixNullsCheckBox = new System.Windows.Forms.CheckBox();
            this.FixCastsCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FilterBox = new System.Windows.Forms.TextBox();
            this.RecurseCheckbox = new System.Windows.Forms.CheckBox();
            this.MakeBackupCheckBox = new System.Windows.Forms.CheckBox();
            this.Process = new System.Windows.Forms.Button();
            this.MakeCommandsPublic = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ClearLog = new System.Windows.Forms.Button();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rootFolder
            // 
            this.rootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rootFolder.Location = new System.Drawing.Point(6, 21);
            this.rootFolder.Name = "rootFolder";
            this.rootFolder.Size = new System.Drawing.Size(224, 20);
            this.rootFolder.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.FixNullsCheckBox);
            this.groupBox1.Controls.Add(this.FixCastsCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FilterBox);
            this.groupBox1.Controls.Add(this.RecurseCheckbox);
            this.groupBox1.Controls.Add(this.MakeBackupCheckBox);
            this.groupBox1.Controls.Add(this.Process);
            this.groupBox1.Controls.Add(this.MakeCommandsPublic);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rootFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select TableAdapter folder";
            // 
            // FixNullsCheckBox
            // 
            this.FixNullsCheckBox.AutoSize = true;
            this.FixNullsCheckBox.Checked = true;
            this.FixNullsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FixNullsCheckBox.Location = new System.Drawing.Point(163, 93);
            this.FixNullsCheckBox.Name = "FixNullsCheckBox";
            this.FixNullsCheckBox.Size = new System.Drawing.Size(89, 17);
            this.FixNullsCheckBox.TabIndex = 9;
            this.FixNullsCheckBox.Text = "Fix Null Tests";
            this.FixNullsCheckBox.UseVisualStyleBackColor = true;
            // 
            // FixCastsCheckBox
            // 
            this.FixCastsCheckBox.AutoSize = true;
            this.FixCastsCheckBox.Checked = true;
            this.FixCastsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FixCastsCheckBox.Location = new System.Drawing.Point(6, 93);
            this.FixCastsCheckBox.Name = "FixCastsCheckBox";
            this.FixCastsCheckBox.Size = new System.Drawing.Size(68, 17);
            this.FixCastsCheckBox.TabIndex = 8;
            this.FixCastsCheckBox.Text = "Fix Casts";
            this.FixCastsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter";
            // 
            // FilterBox
            // 
            this.FilterBox.Location = new System.Drawing.Point(195, 45);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.Size = new System.Drawing.Size(134, 20);
            this.FilterBox.TabIndex = 6;
            this.FilterBox.Text = "*.designer.cs";
            // 
            // RecurseCheckbox
            // 
            this.RecurseCheckbox.AutoSize = true;
            this.RecurseCheckbox.Checked = true;
            this.RecurseCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RecurseCheckbox.Location = new System.Drawing.Point(6, 70);
            this.RecurseCheckbox.Name = "RecurseCheckbox";
            this.RecurseCheckbox.Size = new System.Drawing.Size(120, 17);
            this.RecurseCheckbox.TabIndex = 2;
            this.RecurseCheckbox.Text = "Recurse into folders";
            this.RecurseCheckbox.UseVisualStyleBackColor = true;
            // 
            // MakeBackupCheckBox
            // 
            this.MakeBackupCheckBox.AutoSize = true;
            this.MakeBackupCheckBox.Checked = true;
            this.MakeBackupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MakeBackupCheckBox.Location = new System.Drawing.Point(6, 47);
            this.MakeBackupCheckBox.Name = "MakeBackupCheckBox";
            this.MakeBackupCheckBox.Size = new System.Drawing.Size(93, 17);
            this.MakeBackupCheckBox.TabIndex = 5;
            this.MakeBackupCheckBox.Text = "Make Backup";
            this.MakeBackupCheckBox.UseVisualStyleBackColor = true;
            // 
            // Process
            // 
            this.Process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Process.Location = new System.Drawing.Point(269, 19);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(60, 23);
            this.Process.TabIndex = 4;
            this.Process.Text = "Process";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // MakeCommandsPublic
            // 
            this.MakeCommandsPublic.AutoSize = true;
            this.MakeCommandsPublic.Checked = true;
            this.MakeCommandsPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MakeCommandsPublic.Location = new System.Drawing.Point(163, 70);
            this.MakeCommandsPublic.Name = "MakeCommandsPublic";
            this.MakeCommandsPublic.Size = new System.Drawing.Size(140, 17);
            this.MakeCommandsPublic.TabIndex = 3;
            this.MakeCommandsPublic.Text = "Make Commands Public";
            this.MakeCommandsPublic.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(230, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ClearLog);
            this.groupBox2.Controls.Add(this.LogListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 188);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modification Report";
            // 
            // ClearLog
            // 
            this.ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearLog.Location = new System.Drawing.Point(254, 159);
            this.ClearLog.Name = "ClearLog";
            this.ClearLog.Size = new System.Drawing.Size(75, 23);
            this.ClearLog.TabIndex = 1;
            this.ClearLog.Text = "Clear";
            this.ClearLog.UseVisualStyleBackColor = true;
            this.ClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // LogListBox
            // 
            this.LogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(6, 16);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(323, 134);
            this.LogListBox.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(266, 416);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 447);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Orable Table Adapter Fixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox rootFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox MakeCommandsPublic;
        private System.Windows.Forms.CheckBox RecurseCheckbox;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.Button ClearLog;
        private System.Windows.Forms.CheckBox MakeBackupCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilterBox;
        private System.Windows.Forms.CheckBox FixNullsCheckBox;
        private System.Windows.Forms.CheckBox FixCastsCheckBox;
    }
}

