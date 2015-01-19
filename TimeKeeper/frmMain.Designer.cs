namespace TimeKeeper
{
    partial class frmMain
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
			this.pnlTime = new System.Windows.Forms.Panel();
			this.btnClockIn = new System.Windows.Forms.Button();
			this.btnClockOut = new System.Windows.Forms.Button();
			this.txtClockedIn = new System.Windows.Forms.TextBox();
			this.lblClockedIn = new System.Windows.Forms.Label();
			this.lblChargeCodes = new System.Windows.Forms.Label();
			this.btnAddChargeCode = new System.Windows.Forms.Button();
			this.lblNewChargeCodeNum = new System.Windows.Forms.Label();
			this.txtNewChargeCode = new System.Windows.Forms.TextBox();
			this.btnChangeChargeCode = new System.Windows.Forms.Button();
			this.tmrSeconds = new System.Windows.Forms.Timer(this.components);
			this.lblCurrentChargeCode = new System.Windows.Forms.Label();
			this.txtCurrentChargeCode = new System.Windows.Forms.TextBox();
			this.txtNewChargeCodeName = new System.Windows.Forms.TextBox();
			this.lblNewChargeCodeName = new System.Windows.Forms.Label();
			this.chckScrollable = new System.Windows.Forms.CheckBox();
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuImport = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.autoSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.onoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtAutoSaveTime = new System.Windows.Forms.ToolStripTextBox();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAndExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chckChangeOnClick = new System.Windows.Forms.CheckBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.lblFileName = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.menuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTime
			// 
			this.pnlTime.AutoScroll = true;
			this.pnlTime.AutoSize = true;
			this.pnlTime.Location = new System.Drawing.Point(0, 160);
			this.pnlTime.Name = "pnlTime";
			this.pnlTime.Size = new System.Drawing.Size(549, 238);
			this.pnlTime.TabIndex = 0;
			// 
			// btnClockIn
			// 
			this.btnClockIn.Enabled = false;
			this.btnClockIn.Location = new System.Drawing.Point(6, 32);
			this.btnClockIn.Name = "btnClockIn";
			this.btnClockIn.Size = new System.Drawing.Size(75, 23);
			this.btnClockIn.TabIndex = 1;
			this.btnClockIn.Text = "Clock In";
			this.btnClockIn.UseVisualStyleBackColor = true;
			this.btnClockIn.Click += new System.EventHandler(this.btnClockIn_Click);
			// 
			// btnClockOut
			// 
			this.btnClockOut.Enabled = false;
			this.btnClockOut.Location = new System.Drawing.Point(87, 32);
			this.btnClockOut.Name = "btnClockOut";
			this.btnClockOut.Size = new System.Drawing.Size(75, 23);
			this.btnClockOut.TabIndex = 2;
			this.btnClockOut.Text = "Clock Out";
			this.btnClockOut.UseVisualStyleBackColor = true;
			this.btnClockOut.Click += new System.EventHandler(this.btnClockOut_Click);
			// 
			// txtClockedIn
			// 
			this.txtClockedIn.Enabled = false;
			this.txtClockedIn.Location = new System.Drawing.Point(168, 54);
			this.txtClockedIn.Name = "txtClockedIn";
			this.txtClockedIn.Size = new System.Drawing.Size(100, 20);
			this.txtClockedIn.TabIndex = 99;
			this.txtClockedIn.Text = "00:00:00";
			// 
			// lblClockedIn
			// 
			this.lblClockedIn.AutoSize = true;
			this.lblClockedIn.Location = new System.Drawing.Point(168, 37);
			this.lblClockedIn.Name = "lblClockedIn";
			this.lblClockedIn.Size = new System.Drawing.Size(87, 13);
			this.lblClockedIn.TabIndex = 4;
			this.lblClockedIn.Text = "Time Clocked In:";
			// 
			// lblChargeCodes
			// 
			this.lblChargeCodes.AutoSize = true;
			this.lblChargeCodes.Location = new System.Drawing.Point(12, 134);
			this.lblChargeCodes.Name = "lblChargeCodes";
			this.lblChargeCodes.Size = new System.Drawing.Size(77, 13);
			this.lblChargeCodes.TabIndex = 99;
			this.lblChargeCodes.Text = "Charge Codes:";
			// 
			// btnAddChargeCode
			// 
			this.btnAddChargeCode.Location = new System.Drawing.Point(326, 82);
			this.btnAddChargeCode.Name = "btnAddChargeCode";
			this.btnAddChargeCode.Size = new System.Drawing.Size(80, 39);
			this.btnAddChargeCode.TabIndex = 7;
			this.btnAddChargeCode.Text = "Add Charge Code";
			this.btnAddChargeCode.UseVisualStyleBackColor = true;
			this.btnAddChargeCode.Click += new System.EventHandler(this.btnAddChargeCode_Click);
			// 
			// lblNewChargeCodeNum
			// 
			this.lblNewChargeCodeNum.AutoSize = true;
			this.lblNewChargeCodeNum.Location = new System.Drawing.Point(130, 92);
			this.lblNewChargeCodeNum.Name = "lblNewChargeCodeNum";
			this.lblNewChargeCodeNum.Size = new System.Drawing.Size(97, 13);
			this.lblNewChargeCodeNum.TabIndex = 99;
			this.lblNewChargeCodeNum.Text = "New Charge Code:";
			// 
			// txtNewChargeCode
			// 
			this.txtNewChargeCode.Location = new System.Drawing.Point(127, 111);
			this.txtNewChargeCode.Name = "txtNewChargeCode";
			this.txtNewChargeCode.Size = new System.Drawing.Size(100, 20);
			this.txtNewChargeCode.TabIndex = 5;
			// 
			// btnChangeChargeCode
			// 
			this.btnChangeChargeCode.Enabled = false;
			this.btnChangeChargeCode.Location = new System.Drawing.Point(412, 96);
			this.btnChangeChargeCode.Name = "btnChangeChargeCode";
			this.btnChangeChargeCode.Size = new System.Drawing.Size(137, 25);
			this.btnChangeChargeCode.TabIndex = 8;
			this.btnChangeChargeCode.Text = "Change Charge Code";
			this.btnChangeChargeCode.UseVisualStyleBackColor = true;
			this.btnChangeChargeCode.Click += new System.EventHandler(this.btnChangeChargeCode_Click);
			// 
			// tmrSeconds
			// 
			this.tmrSeconds.Interval = 1000;
			this.tmrSeconds.Tick += new System.EventHandler(this.tmrSeconds_Tick);
			// 
			// lblCurrentChargeCode
			// 
			this.lblCurrentChargeCode.AutoSize = true;
			this.lblCurrentChargeCode.Location = new System.Drawing.Point(409, 38);
			this.lblCurrentChargeCode.Name = "lblCurrentChargeCode";
			this.lblCurrentChargeCode.Size = new System.Drawing.Size(109, 13);
			this.lblCurrentChargeCode.TabIndex = 10;
			this.lblCurrentChargeCode.Text = "Current Charge Code:";
			// 
			// txtCurrentChargeCode
			// 
			this.txtCurrentChargeCode.Enabled = false;
			this.txtCurrentChargeCode.Location = new System.Drawing.Point(412, 54);
			this.txtCurrentChargeCode.Multiline = true;
			this.txtCurrentChargeCode.Name = "txtCurrentChargeCode";
			this.txtCurrentChargeCode.Size = new System.Drawing.Size(137, 36);
			this.txtCurrentChargeCode.TabIndex = 99;
			// 
			// txtNewChargeCodeName
			// 
			this.txtNewChargeCodeName.Location = new System.Drawing.Point(15, 111);
			this.txtNewChargeCodeName.Name = "txtNewChargeCodeName";
			this.txtNewChargeCodeName.Size = new System.Drawing.Size(100, 20);
			this.txtNewChargeCodeName.TabIndex = 6;
			// 
			// lblNewChargeCodeName
			// 
			this.lblNewChargeCodeName.AutoSize = true;
			this.lblNewChargeCodeName.Location = new System.Drawing.Point(20, 92);
			this.lblNewChargeCodeName.Name = "lblNewChargeCodeName";
			this.lblNewChargeCodeName.Size = new System.Drawing.Size(63, 13);
			this.lblNewChargeCodeName.TabIndex = 99;
			this.lblNewChargeCodeName.Text = "New Name:";
			// 
			// chckScrollable
			// 
			this.chckScrollable.AutoSize = true;
			this.chckScrollable.Location = new System.Drawing.Point(212, 137);
			this.chckScrollable.Name = "chckScrollable";
			this.chckScrollable.Size = new System.Drawing.Size(78, 17);
			this.chckScrollable.TabIndex = 10;
			this.chckScrollable.Text = "Scrollable?";
			this.chckScrollable.UseVisualStyleBackColor = true;
			this.chckScrollable.CheckedChanged += new System.EventHandler(this.chckScrollable_CheckedChanged);
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.saveAndExitToolStripMenuItem});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(561, 24);
			this.menuMain.TabIndex = 100;
			this.menuMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImport,
            this.menuExport,
            this.autoSaveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// menuImport
			// 
			this.menuImport.Name = "menuImport";
			this.menuImport.Size = new System.Drawing.Size(129, 22);
			this.menuImport.Text = "Import";
			this.menuImport.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// menuExport
			// 
			this.menuExport.Name = "menuExport";
			this.menuExport.Size = new System.Drawing.Size(129, 22);
			this.menuExport.Text = "Export";
			this.menuExport.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// autoSaveToolStripMenuItem
			// 
			this.autoSaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onoffToolStripMenuItem,
            this.txtAutoSaveTime});
			this.autoSaveToolStripMenuItem.Name = "autoSaveToolStripMenuItem";
			this.autoSaveToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.autoSaveToolStripMenuItem.Text = "Auto-Save";
			// 
			// onoffToolStripMenuItem
			// 
			this.onoffToolStripMenuItem.Name = "onoffToolStripMenuItem";
			this.onoffToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.onoffToolStripMenuItem.Text = "On";
			this.onoffToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
			// 
			// txtAutoSaveTime
			// 
			this.txtAutoSaveTime.MaxLength = 10;
			this.txtAutoSaveTime.Name = "txtAutoSaveTime";
			this.txtAutoSaveTime.Size = new System.Drawing.Size(150, 23);
			this.txtAutoSaveTime.Text = "Auto Save Period In Seconds";
			this.txtAutoSaveTime.Leave += new System.EventHandler(this.txtAutoSaveTime_Leave);
			this.txtAutoSaveTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAutoSaveTime_KeyDown);
			this.txtAutoSaveTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAutoSaveTime_KeyUp);
			this.txtAutoSaveTime.Click += new System.EventHandler(this.txtAutoSaveTime_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// saveAndExitToolStripMenuItem
			// 
			this.saveAndExitToolStripMenuItem.Name = "saveAndExitToolStripMenuItem";
			this.saveAndExitToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.saveAndExitToolStripMenuItem.Text = "Save And Exit";
			this.saveAndExitToolStripMenuItem.Click += new System.EventHandler(this.saveAndExitToolStripMenuItem_Click);
			// 
			// chckChangeOnClick
			// 
			this.chckChangeOnClick.AutoSize = true;
			this.chckChangeOnClick.Checked = true;
			this.chckChangeOnClick.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chckChangeOnClick.Location = new System.Drawing.Point(94, 137);
			this.chckChangeOnClick.Name = "chckChangeOnClick";
			this.chckChangeOnClick.Size = new System.Drawing.Size(112, 17);
			this.chckChangeOnClick.TabIndex = 9;
			this.chckChangeOnClick.Text = "Change On Click?";
			this.chckChangeOnClick.UseVisualStyleBackColor = true;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(6, 61);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(156, 23);
			this.btnReset.TabIndex = 3;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// lblFileName
			// 
			this.lblFileName.AutoSize = true;
			this.lblFileName.Location = new System.Drawing.Point(303, 37);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(90, 13);
			this.lblFileName.TabIndex = 103;
			this.lblFileName.Text = "Export File Name:";
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(306, 54);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(100, 20);
			this.txtFileName.TabIndex = 4;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(561, 400);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.chckChangeOnClick);
			this.Controls.Add(this.chckScrollable);
			this.Controls.Add(this.txtNewChargeCodeName);
			this.Controls.Add(this.lblNewChargeCodeName);
			this.Controls.Add(this.txtCurrentChargeCode);
			this.Controls.Add(this.lblCurrentChargeCode);
			this.Controls.Add(this.btnChangeChargeCode);
			this.Controls.Add(this.txtNewChargeCode);
			this.Controls.Add(this.lblNewChargeCodeNum);
			this.Controls.Add(this.btnAddChargeCode);
			this.Controls.Add(this.lblChargeCodes);
			this.Controls.Add(this.lblClockedIn);
			this.Controls.Add(this.txtClockedIn);
			this.Controls.Add(this.btnClockOut);
			this.Controls.Add(this.btnClockIn);
			this.Controls.Add(this.pnlTime);
			this.Controls.Add(this.menuMain);
			this.Name = "frmMain";
			this.Text = "TimeKeeper";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

	private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Button btnClockIn;
        private System.Windows.Forms.Button btnClockOut;
        private System.Windows.Forms.TextBox txtClockedIn;
        private System.Windows.Forms.Label lblClockedIn;
        private System.Windows.Forms.Label lblChargeCodes;
        private System.Windows.Forms.Button btnAddChargeCode;
        private System.Windows.Forms.Label lblNewChargeCodeNum;
        private System.Windows.Forms.TextBox txtNewChargeCode;
        private System.Windows.Forms.Button btnChangeChargeCode;
        private System.Windows.Forms.Timer tmrSeconds;
        private System.Windows.Forms.Label lblCurrentChargeCode;
        private System.Windows.Forms.TextBox txtCurrentChargeCode;
        private System.Windows.Forms.TextBox txtNewChargeCodeName;
	private System.Windows.Forms.Label lblNewChargeCodeName;
        private System.Windows.Forms.CheckBox chckScrollable;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuImport;
	private System.Windows.Forms.CheckBox chckChangeOnClick;
	private System.Windows.Forms.ToolStripMenuItem menuExport;
	private System.Windows.Forms.ToolStripMenuItem autoSaveToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem onoffToolStripMenuItem;
	private System.Windows.Forms.ToolStripTextBox txtAutoSaveTime;
	private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	private System.Windows.Forms.Button btnReset;
	private System.Windows.Forms.ToolStripMenuItem saveAndExitToolStripMenuItem;
	private System.Windows.Forms.Label lblFileName;
	private System.Windows.Forms.TextBox txtFileName;
    }

}

