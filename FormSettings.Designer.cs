namespace DesktopClean
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.butOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.cboFileExists = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.numLeaveFor = new System.Windows.Forms.NumericUpDown();
            this.cboHoursMinutes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoClean = new System.Windows.Forms.CheckBox();
            this.txtPathToMove = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilesToExclude = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.numCheckFiles = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFileExplorer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTextEditor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLeaveFor)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(328, 277);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 5;
            this.butOK.Text = "&OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(472, 259);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel3);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.butBrowse);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkAutoClean);
            this.tabPage1.Controls.Add(this.txtPathToMove);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtFilesToExclude);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 233);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.cboFileExists);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(23, 164);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(375, 27);
            this.flowLayoutPanel3.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "If file already exists";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFileExists
            // 
            this.cboFileExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileExists.FormattingEnabled = true;
            this.cboFileExists.Items.AddRange(new object[] {
            "Overwrite existing file",
            "Rename before moving",
            "Don\'t move"});
            this.cboFileExists.Location = new System.Drawing.Point(118, 3);
            this.cboFileExists.Name = "cboFileExists";
            this.cboFileExists.Size = new System.Drawing.Size(145, 21);
            this.cboFileExists.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.numLeaveFor);
            this.flowLayoutPanel1.Controls.Add(this.cboHoursMinutes);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(24, 125);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(375, 25);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "Leave files for";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numLeaveFor
            // 
            this.numLeaveFor.Location = new System.Drawing.Point(91, 3);
            this.numLeaveFor.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numLeaveFor.Name = "numLeaveFor";
            this.numLeaveFor.Size = new System.Drawing.Size(52, 20);
            this.numLeaveFor.TabIndex = 20;
            // 
            // cboHoursMinutes
            // 
            this.cboHoursMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoursMinutes.FormattingEnabled = true;
            this.cboHoursMinutes.Items.AddRange(new object[] {
            "Hours",
            "Minutes"});
            this.cboHoursMinutes.Location = new System.Drawing.Point(149, 3);
            this.cboHoursMinutes.Name = "cboHoursMinutes";
            this.cboHoursMinutes.Size = new System.Drawing.Size(70, 21);
            this.cboHoursMinutes.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "before moving.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(405, 78);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(36, 26);
            this.butBrowse.TabIndex = 24;
            this.butBrowse.Text = "...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Files to exclude:";
            // 
            // chkAutoClean
            // 
            this.chkAutoClean.AutoSize = true;
            this.chkAutoClean.Location = new System.Drawing.Point(24, 203);
            this.chkAutoClean.Name = "chkAutoClean";
            this.chkAutoClean.Size = new System.Drawing.Size(88, 19);
            this.chkAutoClean.TabIndex = 19;
            this.chkAutoClean.Text = "Auto Clean";
            this.chkAutoClean.UseVisualStyleBackColor = true;
            // 
            // txtPathToMove
            // 
            this.txtPathToMove.Location = new System.Drawing.Point(24, 82);
            this.txtPathToMove.Name = "txtPathToMove";
            this.txtPathToMove.Size = new System.Drawing.Size(375, 20);
            this.txtPathToMove.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Path to move to:";
            // 
            // txtFilesToExclude
            // 
            this.txtFilesToExclude.Location = new System.Drawing.Point(23, 32);
            this.txtFilesToExclude.Name = "txtFilesToExclude";
            this.txtFilesToExclude.Size = new System.Drawing.Size(375, 20);
            this.txtFilesToExclude.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.txtFileExplorer);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtTextEditor);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(464, 233);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.numCheckFiles);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(22, 27);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(317, 27);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Check for files every";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numCheckFiles
            // 
            this.numCheckFiles.Location = new System.Drawing.Point(123, 3);
            this.numCheckFiles.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numCheckFiles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCheckFiles.Name = "numCheckFiles";
            this.numCheckFiles.Size = new System.Drawing.Size(54, 20);
            this.numCheckFiles.TabIndex = 1;
            this.numCheckFiles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 26);
            this.label6.TabIndex = 2;
            this.label6.Text = "minutes.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFileExplorer
            // 
            this.txtFileExplorer.Location = new System.Drawing.Point(22, 136);
            this.txtFileExplorer.Name = "txtFileExplorer";
            this.txtFileExplorer.Size = new System.Drawing.Size(317, 20);
            this.txtFileExplorer.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "File Explorer:";
            // 
            // txtTextEditor
            // 
            this.txtTextEditor.Location = new System.Drawing.Point(22, 84);
            this.txtTextEditor.Name = "txtTextEditor";
            this.txtTextEditor.Size = new System.Drawing.Size(317, 20);
            this.txtTextEditor.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Text Editor (for viewing log):";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(409, 277);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 16;
            this.butCancel.Text = "&Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 308);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Desktop Cleaner - Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLeaveFor)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboHoursMinutes;
        private System.Windows.Forms.NumericUpDown numLeaveFor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoClean;
        private System.Windows.Forms.TextBox txtPathToMove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilesToExclude;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.TextBox txtFileExplorer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTextEditor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numCheckFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboFileExists;
    }
}

