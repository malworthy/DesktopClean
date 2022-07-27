using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DesktopClean.Properties;
using System.IO;
using System.Windows.Forms;


namespace DesktopClean
{
    public partial class MainComponent : Component
    {
        public MainComponent()
        {
            InitializeComponent();
            if (Settings.Default.FirstTimeRun)
            {
                ShowSettings();
            }
            else
                EnableTimer();
        }

        public MainComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public DialogResult ShowSettings()
        {
            FormSettings frmSettings = new FormSettings();
            DialogResult result = frmSettings.ShowDialog();
            EnableTimer();
            return result;
        }

        #region EventHandlers
        private void cleanNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cleanup(true);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Cleaner.LogFile))
                {
                    if (Settings.Default.TextEditor == "")
                        Process.Start(Cleaner.LogFile);
                    else
                        Process.Start(Settings.Default.TextEditor, Cleaner.LogFile);
                }
                else
                {
                    MessageBox.Show("The Log file is empty.  No files have been moved yet.",
                        "Log File Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot show Log.");
            }
        }

        private void openCleanupFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Settings.Default.FileExplorer == "")
                    Process.Start(Settings.Default.MoveToPath);
                else
                    Process.Start(Settings.Default.FileExplorer, Settings.Default.MoveToPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Display Cleanup Folder.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cleanup(false);
        }
        #endregion

        /// <summary>
        /// Enables timer control and sets interval to user setting.
        /// </summary>
        private void EnableTimer()
        {
            timer1.Enabled = Settings.Default.AutoClean;
            if (timer1.Enabled)
                timer1.Interval = (Settings.Default.CheckFiles * 1000) * 60;
        }

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
    }
}
