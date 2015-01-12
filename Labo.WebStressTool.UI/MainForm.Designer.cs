namespace Labo.WebStressTool.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fiddlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtxtMaxConcurrentRequests = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtSleepMin = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxtSleepMax = new System.Windows.Forms.MaskedTextBox();
            this.lvRequests = new System.Windows.Forms.ListView();
            this.columnUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHttpStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStartStressTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDurationInMinutes = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStopStressTest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRunningRequestsCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblQueueLength = new System.Windows.Forms.Label();
            this.lblSuccessfulRequestsCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalRequestsCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCpu = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusAvailableMemory = new System.Windows.Forms.ToolStripStatusLabel();
            this.cpuImageList = new System.Windows.Forms.ImageList(this.components);
            this.timerPerformanceInfo = new System.Windows.Forms.Timer(this.components);
            this.performanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationInMinutes)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fiddlerToolStripMenuItem,
            this.performanceToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(684, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fiddlerToolStripMenuItem
            // 
            this.fiddlerToolStripMenuItem.Name = "fiddlerToolStripMenuItem";
            this.fiddlerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.fiddlerToolStripMenuItem.Text = "Fiddler";
            this.fiddlerToolStripMenuItem.Click += new System.EventHandler(this.fiddlerToolStripMenuItem_Click);
            // 
            // mtxtMaxConcurrentRequests
            // 
            this.mtxtMaxConcurrentRequests.Location = new System.Drawing.Point(166, 38);
            this.mtxtMaxConcurrentRequests.Mask = "00000";
            this.mtxtMaxConcurrentRequests.Name = "mtxtMaxConcurrentRequests";
            this.mtxtMaxConcurrentRequests.PromptChar = ' ';
            this.mtxtMaxConcurrentRequests.Size = new System.Drawing.Size(42, 20);
            this.mtxtMaxConcurrentRequests.TabIndex = 1;
            this.mtxtMaxConcurrentRequests.Text = "500";
            this.mtxtMaxConcurrentRequests.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max Concurrent Requests:";
            // 
            // mtxtSleepMin
            // 
            this.mtxtSleepMin.Location = new System.Drawing.Point(166, 68);
            this.mtxtSleepMin.Mask = "0000";
            this.mtxtSleepMin.Name = "mtxtSleepMin";
            this.mtxtSleepMin.PromptChar = ' ';
            this.mtxtSleepMin.Size = new System.Drawing.Size(42, 20);
            this.mtxtSleepMin.TabIndex = 3;
            this.mtxtSleepMin.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time between Requests (ms):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(212, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // mtxtSleepMax
            // 
            this.mtxtSleepMax.Location = new System.Drawing.Point(229, 68);
            this.mtxtSleepMax.Mask = "0000";
            this.mtxtSleepMax.Name = "mtxtSleepMax";
            this.mtxtSleepMax.PromptChar = ' ';
            this.mtxtSleepMax.Size = new System.Drawing.Size(42, 20);
            this.mtxtSleepMax.TabIndex = 6;
            // 
            // lvRequests
            // 
            this.lvRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUrl,
            this.columnStatus,
            this.columnHttpStatus,
            this.columnTime});
            this.lvRequests.FullRowSelect = true;
            this.lvRequests.GridLines = true;
            this.lvRequests.HideSelection = false;
            this.lvRequests.Location = new System.Drawing.Point(12, 94);
            this.lvRequests.MultiSelect = false;
            this.lvRequests.Name = "lvRequests";
            this.lvRequests.ShowGroups = false;
            this.lvRequests.Size = new System.Drawing.Size(660, 303);
            this.lvRequests.TabIndex = 7;
            this.lvRequests.UseCompatibleStateImageBehavior = false;
            this.lvRequests.View = System.Windows.Forms.View.Details;
            // 
            // columnUrl
            // 
            this.columnUrl.Text = "Url";
            this.columnUrl.Width = 300;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 70;
            // 
            // columnHttpStatus
            // 
            this.columnHttpStatus.Text = "Http Status";
            this.columnHttpStatus.Width = 100;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Time";
            this.columnTime.Width = 80;
            // 
            // btnStartStressTest
            // 
            this.btnStartStressTest.Location = new System.Drawing.Point(568, 458);
            this.btnStartStressTest.Name = "btnStartStressTest";
            this.btnStartStressTest.Size = new System.Drawing.Size(102, 29);
            this.btnStartStressTest.TabIndex = 8;
            this.btnStartStressTest.Text = "Start Stress Test";
            this.btnStartStressTest.UseVisualStyleBackColor = true;
            this.btnStartStressTest.Click += new System.EventHandler(this.btnStartStressTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Duration:";
            // 
            // nudDurationInMinutes
            // 
            this.nudDurationInMinutes.Location = new System.Drawing.Point(395, 37);
            this.nudDurationInMinutes.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDurationInMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDurationInMinutes.Name = "nudDurationInMinutes";
            this.nudDurationInMinutes.Size = new System.Drawing.Size(37, 20);
            this.nudDurationInMinutes.TabIndex = 10;
            this.nudDurationInMinutes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "minutes";
            // 
            // btnStopStressTest
            // 
            this.btnStopStressTest.Location = new System.Drawing.Point(469, 458);
            this.btnStopStressTest.Name = "btnStopStressTest";
            this.btnStopStressTest.Size = new System.Drawing.Size(93, 29);
            this.btnStopStressTest.TabIndex = 12;
            this.btnStopStressTest.Text = "Stop Stress Test";
            this.btnStopStressTest.UseVisualStyleBackColor = true;
            this.btnStopStressTest.Click += new System.EventHandler(this.btnStopStressTest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Running Requests:";
            // 
            // lblRunningRequestsCount
            // 
            this.lblRunningRequestsCount.AutoSize = true;
            this.lblRunningRequestsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRunningRequestsCount.Location = new System.Drawing.Point(147, 411);
            this.lblRunningRequestsCount.Name = "lblRunningRequestsCount";
            this.lblRunningRequestsCount.Size = new System.Drawing.Size(14, 15);
            this.lblRunningRequestsCount.TabIndex = 14;
            this.lblRunningRequestsCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(12, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Queue Length:";
            // 
            // lblQueueLength
            // 
            this.lblQueueLength.AutoSize = true;
            this.lblQueueLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblQueueLength.Location = new System.Drawing.Point(147, 430);
            this.lblQueueLength.Name = "lblQueueLength";
            this.lblQueueLength.Size = new System.Drawing.Size(14, 15);
            this.lblQueueLength.TabIndex = 16;
            this.lblQueueLength.Text = "0";
            // 
            // lblSuccessfulRequestsCount
            // 
            this.lblSuccessfulRequestsCount.AutoSize = true;
            this.lblSuccessfulRequestsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSuccessfulRequestsCount.Location = new System.Drawing.Point(351, 430);
            this.lblSuccessfulRequestsCount.Name = "lblSuccessfulRequestsCount";
            this.lblSuccessfulRequestsCount.Size = new System.Drawing.Size(14, 15);
            this.lblSuccessfulRequestsCount.TabIndex = 20;
            this.lblSuccessfulRequestsCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(202, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Successful Requests:";
            // 
            // lblTotalRequestsCount
            // 
            this.lblTotalRequestsCount.AutoSize = true;
            this.lblTotalRequestsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalRequestsCount.Location = new System.Drawing.Point(351, 411);
            this.lblTotalRequestsCount.Name = "lblTotalRequestsCount";
            this.lblTotalRequestsCount.Size = new System.Drawing.Size(14, 15);
            this.lblTotalRequestsCount.TabIndex = 18;
            this.lblTotalRequestsCount.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(202, 411);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Total Requests:";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusInfo,
            this.toolStripStatusCpu,
            this.toolStripStatusAvailableMemory});
            this.statusBar.Location = new System.Drawing.Point(0, 497);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(684, 22);
            this.statusBar.TabIndex = 21;
            this.statusBar.Text = "Ready";
            // 
            // toolStripStatusInfo
            // 
            this.toolStripStatusInfo.AutoSize = false;
            this.toolStripStatusInfo.Name = "toolStripStatusInfo";
            this.toolStripStatusInfo.Size = new System.Drawing.Size(350, 17);
            this.toolStripStatusInfo.Text = "Ready";
            this.toolStripStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusInfo.ToolTipText = "Status Information";
            // 
            // toolStripStatusCpu
            // 
            this.toolStripStatusCpu.AutoSize = false;
            this.toolStripStatusCpu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusCpu.Image")));
            this.toolStripStatusCpu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusCpu.Name = "toolStripStatusCpu";
            this.toolStripStatusCpu.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusCpu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusCpu.ToolTipText = "Cpu Usage";
            // 
            // toolStripStatusAvailableMemory
            // 
            this.toolStripStatusAvailableMemory.AutoSize = false;
            this.toolStripStatusAvailableMemory.Name = "toolStripStatusAvailableMemory";
            this.toolStripStatusAvailableMemory.Size = new System.Drawing.Size(200, 17);
            // 
            // cpuImageList
            // 
            this.cpuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("cpuImageList.ImageStream")));
            this.cpuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.cpuImageList.Images.SetKeyName(0, "Mem1.ICO");
            this.cpuImageList.Images.SetKeyName(1, "Mem2.ICO");
            this.cpuImageList.Images.SetKeyName(2, "Mem3.ICO");
            this.cpuImageList.Images.SetKeyName(3, "Mem4.ICO");
            this.cpuImageList.Images.SetKeyName(4, "Mem5.ICO");
            this.cpuImageList.Images.SetKeyName(5, "Mem6.ICO");
            this.cpuImageList.Images.SetKeyName(6, "Mem7.ICO");
            this.cpuImageList.Images.SetKeyName(7, "Mem8.ICO");
            this.cpuImageList.Images.SetKeyName(8, "Mem9.ICO");
            this.cpuImageList.Images.SetKeyName(9, "Mem10.ICO");
            this.cpuImageList.Images.SetKeyName(10, "Mem11.ICO");
            // 
            // timerPerformanceInfo
            // 
            this.timerPerformanceInfo.Enabled = true;
            this.timerPerformanceInfo.Interval = 2000;
            this.timerPerformanceInfo.Tick += new System.EventHandler(this.timerPerformanceInfo_Tick);
            // 
            // performanceToolStripMenuItem
            // 
            this.performanceToolStripMenuItem.Name = "performanceToolStripMenuItem";
            this.performanceToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.performanceToolStripMenuItem.Text = "Performance";
            this.performanceToolStripMenuItem.Click += new System.EventHandler(this.performanceToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 519);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.lblSuccessfulRequestsCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalRequestsCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblQueueLength);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblRunningRequestsCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStopStressTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudDurationInMinutes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStartStressTest);
            this.Controls.Add(this.lvRequests);
            this.Controls.Add(this.mtxtSleepMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtSleepMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtMaxConcurrentRequests);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Labo Stress Test Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationInMinutes)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fiddlerToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox mtxtMaxConcurrentRequests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtSleepMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxtSleepMax;
        private System.Windows.Forms.ListView lvRequests;
        private System.Windows.Forms.ColumnHeader columnUrl;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.Button btnStartStressTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudDurationInMinutes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStopStressTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRunningRequestsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblQueueLength;
        private System.Windows.Forms.Label lblSuccessfulRequestsCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalRequestsCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader columnHttpStatus;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCpu;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusAvailableMemory;
        private System.Windows.Forms.ImageList cpuImageList;
        private System.Windows.Forms.Timer timerPerformanceInfo;
        private System.Windows.Forms.ToolStripMenuItem performanceToolStripMenuItem;
    }
}

