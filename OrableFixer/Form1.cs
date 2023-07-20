using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrableFixer.Properties;
using OracleFix;

namespace OrableFixer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings() {
            if (Settings.Default.SavedOptions == null) {
                Settings.Default.SavedOptions = new Options();
                SaveSettings();
                return;
            }
            this.MakeBackupCheckBox.Checked= Settings.Default.SavedOptions.MakeBackup;
            this.MakeCommandsPublic.Checked= Settings.Default.SavedOptions.MakeCommandsPublic;
            this.rootFolder.Text= Settings.Default.SavedOptions.RootFolder;
            this.RecurseCheckbox.Checked= Settings.Default.SavedOptions.RecurseDirectories;
            this.FilterBox.Text = Settings.Default.SavedOptions.FileFilter;
            this.FixCastsCheckBox.Checked = Settings.Default.SavedOptions.FixCasts;
            this.FixNullsCheckBox.Checked = Settings.Default.SavedOptions.FixNullTests;
        }

        private void button1_Click(object sender, EventArgs e) {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                rootFolder.Text = fbd.SelectedPath;                
            }
        }

        private void SaveSettings()
        {
            Settings.Default.SavedOptions.MakeBackup = this.MakeBackupCheckBox.Checked;
            Settings.Default.SavedOptions.MakeCommandsPublic = this.MakeCommandsPublic.Checked;
            Settings.Default.SavedOptions.RootFolder = this.rootFolder.Text;
            Settings.Default.SavedOptions.RecurseDirectories = this.RecurseCheckbox.Checked;
            Settings.Default.SavedOptions.FileFilter = this.FilterBox.Text;
            Settings.Default.SavedOptions.FixNullTests = this.FixNullsCheckBox.Checked;
            Settings.Default.SavedOptions.FixCasts = this.FixCastsCheckBox.Checked;
            Settings.Default.Save();
        }

        private void Process_Click(object sender, EventArgs e)
        {
            var options = new Options
                          {
                              RootFolder = rootFolder.Text,
                              RecurseDirectories = RecurseCheckbox.Checked,
                              MakeCommandsPublic = MakeCommandsPublic.Checked,
                              MakeBackup = MakeBackupCheckBox.Checked,
                              FixCasts = FixCastsCheckBox.Checked,
                              FixNullTests = FixNullsCheckBox.Checked,
                              FileFilter = "*.designer.cs"
                          };
            options.ProgressCallback += new OracleFix.ProgressCallback(Processor_ProgressCallback);
            Processor.Process(options);
        }

        void Processor_ProgressCallback(object sender, OracleFix.ProgressCallbackArgs args)
        {
            LogListBox.Items.Add(args.Status);
            LogListBox.Update();
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            LogListBox.Items.Clear();
            LogListBox.Update();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            SaveSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}