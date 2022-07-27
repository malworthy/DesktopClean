namespace DesktopClean
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using DesktopClean.Properties;
    using System.Text.RegularExpressions;
    using System.Diagnostics;

    public partial class FormSettings : Form
    {
        #region Constructors
        public FormSettings()
        {
            InitializeComponent();
            //if (Settings.Default.FirstTimeRun)
            //    this.WindowState = FormWindowState.Normal;
            cboHoursMinutes.SelectedIndex = 0;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Sets controls on form to match application settings.
        /// </summary>
        private void LoadSettings()
        {
            txtFilesToExclude.Text = Settings.Default.FilesToExclude;
            if (Settings.Default.MoveToPath == "")
            {
                Settings.Default.MoveToPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Cleanup");
            }
            txtPathToMove.Text = Settings.Default.MoveToPath;
            if (Settings.Default.LeaveFor % 60 == 0)
            {
                numLeaveFor.Value = Settings.Default.LeaveFor / 60;
                cboHoursMinutes.Text = "Hours";
            }
            else
            {
                numLeaveFor.Value = Settings.Default.LeaveFor;
                cboHoursMinutes.Text = "Minutes";
            }
            chkAutoClean.Checked = Settings.Default.AutoClean;
            txtFileExplorer.Text = Settings.Default.FileExplorer;
            txtTextEditor.Text = Settings.Default.TextEditor;
            numCheckFiles.Value = Settings.Default.CheckFiles;
            cboFileExists.SelectedIndex = Settings.Default.FileExistsSetting;
        }

        /// <summary>
        /// Saves the application settings.
        /// </summary>
        /// <returns>true = all data saved.  false = could not save due to invalid data</returns>
        private bool SaveSettings()
        {
            string cleanupPath = txtPathToMove.Text;

            if (cleanupPath == "" || cleanupPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                MessageBox.Show("The 'Path to move to' setting is blank or contains invalid characters.",
                    "Invalid Path",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!Directory.Exists(cleanupPath))
            {
                if (MessageBox.Show(string.Format("The folder '{0}' does not exist.  Do you want to create it?", cleanupPath),
                    "Create Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(cleanupPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Could not create cleanup folder.  Please choose another folder.");
                        return false;
                    }
                }
                else
                    return false;
            }


            decimal minutesLeaveFor = numLeaveFor.Value;
            if (cboHoursMinutes.Text == "Hours")
                minutesLeaveFor = minutesLeaveFor * 60;

            Settings.Default.FilesToExclude = txtFilesToExclude.Text;
            Settings.Default.MoveToPath = txtPathToMove.Text;
            Settings.Default.LeaveFor = (long)minutesLeaveFor;
            Settings.Default.AutoClean = chkAutoClean.Checked;
            Settings.Default.TextEditor = txtTextEditor.Text;
            Settings.Default.FileExplorer = txtFileExplorer.Text;
            Settings.Default.CheckFiles = (int)numCheckFiles.Value;
            Settings.Default.FirstTimeRun = false;
            Settings.Default.FileExistsSetting = cboFileExists.SelectedIndex;

            Settings.Default.Save();
            //EnableTimer();

            return true;
        }
        ///// <summary>
        ///// Enables timer control and sets interval to user setting.
        ///// </summary>
        //private void EnableTimer()
        //{
        //    timer1.Enabled = Settings.Default.AutoClean;
        //    if (timer1.Enabled)
        //        timer1.Interval = (Settings.Default.CheckFiles * 1000) * 60;
        //}

        /// <summary>
        /// Performs the cleanup.
        /// </summary>
        /// <param name="cleanALL"></param>
        private void Cleanup(bool cleanALL)
        {
            Cleaner cleaner = new Cleaner();
            cleaner.CleanALL = cleanALL;
            cleaner.Cleanup();
        }
        #endregion

        #region EventHandlers
        //private void cleanNowToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveSettings();
        //    Cleanup(false); 
        //}

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
            //if (!Settings.Default.FirstTimeRun)
            //{
            //    Hide();
            //    Cleanup(false);
            //    EnableTimer();
            //}
        }

        private void FormSettings_Resize(object sender, EventArgs e)
        {
            //if (FormWindowState.Minimized == WindowState)
            //    Hide();
        }

        //private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        //{
        //    Show();
        //    WindowState = FormWindowState.Normal;

        //}

        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Close();
        //    Dispose();
        //}

        private void butOK_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
                Hide();
        }

        //private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        e.Cancel = true;
        //        Hide();
        //    }
        //}

        //private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Settings.Default.TextEditor == "")
        //            Process.Start(Cleaner.LogFile);
        //        else
        //            Process.Start(Settings.Default.TextEditor, Cleaner.LogFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Cannot show Log.");
        //    }
        //}

        //private void openCleanupFolderToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Settings.Default.FileExplorer == "")
        //            Process.Start(Settings.Default.MoveToPath);
        //        else
        //            Process.Start(Settings.Default.FileExplorer, Settings.Default.MoveToPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Cannot Display Cleanup Folder.");
        //    }
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    Cleanup(false);
        //}

        private void butBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                txtPathToMove.Text = folderBrowser.SelectedPath;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        #endregion

    }
}
