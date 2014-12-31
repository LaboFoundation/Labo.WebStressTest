﻿namespace Labo.WebStressTool.UI
{
    partial class FiddlerForm
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
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.listBoxRecord = new System.Windows.Forms.ListBox();
            this.txtDomainsToCollect = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileExtensionsToExclude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearCollectedData = new System.Windows.Forms.Button();
            this.txtRegexToExcludeUrls = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveCollectedData = new System.Windows.Forms.Button();
            this.sfdCollectedData = new System.Windows.Forms.SaveFileDialog();
            this.btnLoadCollectedData = new System.Windows.Forms.Button();
            this.ofdCollectedData = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Location = new System.Drawing.Point(218, 351);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(105, 33);
            this.btnStartRecording.TabIndex = 0;
            this.btnStartRecording.Text = "Start Recording";
            this.btnStartRecording.UseVisualStyleBackColor = true;
            this.btnStartRecording.Click += new System.EventHandler(this.btnStartRecording_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Location = new System.Drawing.Point(329, 351);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(109, 33);
            this.btnStopRecording.TabIndex = 1;
            this.btnStopRecording.Text = "Stop Recording";
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // listBoxRecord
            // 
            this.listBoxRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecord.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxRecord.FormattingEnabled = true;
            this.listBoxRecord.HorizontalScrollbar = true;
            this.listBoxRecord.Location = new System.Drawing.Point(12, 172);
            this.listBoxRecord.Name = "listBoxRecord";
            this.listBoxRecord.Size = new System.Drawing.Size(681, 173);
            this.listBoxRecord.TabIndex = 2;
            this.listBoxRecord.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxRecord_DrawItem);
            // 
            // txtDomainsToCollect
            // 
            this.txtDomainsToCollect.Location = new System.Drawing.Point(361, 28);
            this.txtDomainsToCollect.Multiline = true;
            this.txtDomainsToCollect.Name = "txtDomainsToCollect";
            this.txtDomainsToCollect.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDomainsToCollect.Size = new System.Drawing.Size(332, 56);
            this.txtDomainsToCollect.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(361, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Domain Names to Collect Data:";
            // 
            // txtFileExtensionsToExclude
            // 
            this.txtFileExtensionsToExclude.Location = new System.Drawing.Point(12, 28);
            this.txtFileExtensionsToExclude.Multiline = true;
            this.txtFileExtensionsToExclude.Name = "txtFileExtensionsToExclude";
            this.txtFileExtensionsToExclude.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileExtensionsToExclude.Size = new System.Drawing.Size(332, 56);
            this.txtFileExtensionsToExclude.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File Extensions to Exclude";
            // 
            // btnClearCollectedData
            // 
            this.btnClearCollectedData.Location = new System.Drawing.Point(444, 351);
            this.btnClearCollectedData.Name = "btnClearCollectedData";
            this.btnClearCollectedData.Size = new System.Drawing.Size(119, 33);
            this.btnClearCollectedData.TabIndex = 7;
            this.btnClearCollectedData.Text = "Clear Collected Data";
            this.btnClearCollectedData.UseVisualStyleBackColor = true;
            this.btnClearCollectedData.Click += new System.EventHandler(this.btnClearCollectedData_Click);
            // 
            // txtRegexToExcludeUrls
            // 
            this.txtRegexToExcludeUrls.Location = new System.Drawing.Point(15, 108);
            this.txtRegexToExcludeUrls.Multiline = true;
            this.txtRegexToExcludeUrls.Name = "txtRegexToExcludeUrls";
            this.txtRegexToExcludeUrls.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRegexToExcludeUrls.Size = new System.Drawing.Size(332, 56);
            this.txtRegexToExcludeUrls.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Regex to Exclude Urls";
            // 
            // btnSaveCollectedData
            // 
            this.btnSaveCollectedData.Location = new System.Drawing.Point(574, 351);
            this.btnSaveCollectedData.Name = "btnSaveCollectedData";
            this.btnSaveCollectedData.Size = new System.Drawing.Size(119, 33);
            this.btnSaveCollectedData.TabIndex = 10;
            this.btnSaveCollectedData.Text = "Save Collected Data";
            this.btnSaveCollectedData.UseVisualStyleBackColor = true;
            this.btnSaveCollectedData.Click += new System.EventHandler(this.btnSaveCollectedData_Click);
            // 
            // sfdCollectedData
            // 
            this.sfdCollectedData.DefaultExt = "lwst";
            // 
            // btnLoadCollectedData
            // 
            this.btnLoadCollectedData.Location = new System.Drawing.Point(12, 351);
            this.btnLoadCollectedData.Name = "btnLoadCollectedData";
            this.btnLoadCollectedData.Size = new System.Drawing.Size(119, 33);
            this.btnLoadCollectedData.TabIndex = 11;
            this.btnLoadCollectedData.Text = "Load Collected Data";
            this.btnLoadCollectedData.UseVisualStyleBackColor = true;
            this.btnLoadCollectedData.Click += new System.EventHandler(this.btnLoadCollectedData_Click);
            // 
            // ofdCollectedData
            // 
            this.ofdCollectedData.FileName = "openFileDialog1";
            // 
            // FiddlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 388);
            this.Controls.Add(this.btnLoadCollectedData);
            this.Controls.Add(this.btnSaveCollectedData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRegexToExcludeUrls);
            this.Controls.Add(this.btnClearCollectedData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileExtensionsToExclude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomainsToCollect);
            this.Controls.Add(this.listBoxRecord);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.btnStartRecording);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FiddlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record Http Requests";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiddlerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartRecording;
        private System.Windows.Forms.Button btnStopRecording;
        private System.Windows.Forms.ListBox listBoxRecord;
        private System.Windows.Forms.TextBox txtDomainsToCollect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileExtensionsToExclude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearCollectedData;
        private System.Windows.Forms.TextBox txtRegexToExcludeUrls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveCollectedData;
        private System.Windows.Forms.SaveFileDialog sfdCollectedData;
        private System.Windows.Forms.Button btnLoadCollectedData;
        private System.Windows.Forms.OpenFileDialog ofdCollectedData;
    }
}