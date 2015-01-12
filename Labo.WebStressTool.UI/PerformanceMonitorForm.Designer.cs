namespace Labo.WebStressTool.UI
{
    partial class PerformanceMonitorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCpu = new System.Windows.Forms.Label();
            this.lblBytesRecieved = new System.Windows.Forms.Label();
            this.lblBytesSent = new System.Windows.Forms.Label();
            this.lblFreeMemory = new System.Windows.Forms.Label();
            this.lblConnectionsEstablished = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cpu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Connections Established:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bytes Recieved:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(13, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bytes Sent:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(13, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Free Memory:";
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCpu.Location = new System.Drawing.Point(197, 13);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCpu.Size = new System.Drawing.Size(33, 15);
            this.lblCpu.TabIndex = 5;
            this.lblCpu.Text = "[cpu]";
            // 
            // lblBytesRecieved
            // 
            this.lblBytesRecieved.AutoSize = true;
            this.lblBytesRecieved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBytesRecieved.Location = new System.Drawing.Point(197, 87);
            this.lblBytesRecieved.Name = "lblBytesRecieved";
            this.lblBytesRecieved.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBytesRecieved.Size = new System.Drawing.Size(90, 15);
            this.lblBytesRecieved.TabIndex = 6;
            this.lblBytesRecieved.Text = "[bytes recieved]";
            // 
            // lblBytesSent
            // 
            this.lblBytesSent.AutoSize = true;
            this.lblBytesSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBytesSent.Location = new System.Drawing.Point(197, 63);
            this.lblBytesSent.Name = "lblBytesSent";
            this.lblBytesSent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBytesSent.Size = new System.Drawing.Size(67, 15);
            this.lblBytesSent.TabIndex = 7;
            this.lblBytesSent.Text = "[bytes sent]";
            // 
            // lblFreeMemory
            // 
            this.lblFreeMemory.AutoSize = true;
            this.lblFreeMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFreeMemory.Location = new System.Drawing.Point(196, 38);
            this.lblFreeMemory.Name = "lblFreeMemory";
            this.lblFreeMemory.Size = new System.Drawing.Size(82, 15);
            this.lblFreeMemory.TabIndex = 8;
            this.lblFreeMemory.Text = "[free memory]";
            // 
            // lblConnectionsEstablished
            // 
            this.lblConnectionsEstablished.AutoSize = true;
            this.lblConnectionsEstablished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblConnectionsEstablished.Location = new System.Drawing.Point(197, 111);
            this.lblConnectionsEstablished.Name = "lblConnectionsEstablished";
            this.lblConnectionsEstablished.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblConnectionsEstablished.Size = new System.Drawing.Size(145, 15);
            this.lblConnectionsEstablished.TabIndex = 9;
            this.lblConnectionsEstablished.Text = "[connections established]";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PerformanceMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 146);
            this.Controls.Add(this.lblConnectionsEstablished);
            this.Controls.Add(this.lblFreeMemory);
            this.Controls.Add(this.lblBytesSent);
            this.Controls.Add(this.lblBytesRecieved);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PerformanceMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Performance Monitoring";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblBytesRecieved;
        private System.Windows.Forms.Label lblBytesSent;
        private System.Windows.Forms.Label lblFreeMemory;
        private System.Windows.Forms.Label lblConnectionsEstablished;
        private System.Windows.Forms.Timer timer;
    }
}