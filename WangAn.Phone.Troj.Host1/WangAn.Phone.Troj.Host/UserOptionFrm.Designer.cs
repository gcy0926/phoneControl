namespace IIE.Phone.Troj.Host
{
    partial class UserOptionFrm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.发送命令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCall = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSms = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.录音ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRecordAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.电话监听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.rtbClientLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发送命令ToolStripMenuItem,
            this.录音ToolStripMenuItem,
            this.电话监听ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1088, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 发送命令ToolStripMenuItem
            // 
            this.发送命令ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCall,
            this.tsSms,
            this.tsMessage});
            this.发送命令ToolStripMenuItem.Name = "发送命令ToolStripMenuItem";
            this.发送命令ToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.发送命令ToolStripMenuItem.Text = "发送命令";
            // 
            // tsCall
            // 
            this.tsCall.Name = "tsCall";
            this.tsCall.Size = new System.Drawing.Size(153, 24);
            this.tsCall.Text = "拔打电话";
            this.tsCall.Click += new System.EventHandler(this.tsCall_Click);
            // 
            // tsSms
            // 
            this.tsSms.Name = "tsSms";
            this.tsSms.Size = new System.Drawing.Size(153, 24);
            this.tsSms.Text = "发送短信";
            this.tsSms.Click += new System.EventHandler(this.tsSms_Click);
            // 
            // tsMessage
            // 
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(153, 24);
            this.tsMessage.Text = "发送短消息";
            this.tsMessage.Click += new System.EventHandler(this.tsMessage_Click);
            // 
            // 录音ToolStripMenuItem
            // 
            this.录音ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRecordAudio});
            this.录音ToolStripMenuItem.Name = "录音ToolStripMenuItem";
            this.录音ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.录音ToolStripMenuItem.Text = "录音";
            // 
            // tsRecordAudio
            // 
            this.tsRecordAudio.Name = "tsRecordAudio";
            this.tsRecordAudio.Size = new System.Drawing.Size(138, 24);
            this.tsRecordAudio.Text = "环境录音";
            this.tsRecordAudio.Click += new System.EventHandler(this.tsRecordAudio_Click);
            // 
            // 电话监听ToolStripMenuItem
            // 
            this.电话监听ToolStripMenuItem.Name = "电话监听ToolStripMenuItem";
            this.电话监听ToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.电话监听ToolStripMenuItem.Text = "录制视频";
            this.电话监听ToolStripMenuItem.Click += new System.EventHandler(this.电话监听ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbClientLog);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 598);
            this.splitContainer1.SplitterDistance = 488;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1088, 488);
            this.tcMain.TabIndex = 0;
            // 
            // rtbClientLog
            // 
            this.rtbClientLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbClientLog.Location = new System.Drawing.Point(0, 0);
            this.rtbClientLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbClientLog.Name = "rtbClientLog";
            this.rtbClientLog.ReadOnly = true;
            this.rtbClientLog.Size = new System.Drawing.Size(1088, 105);
            this.rtbClientLog.TabIndex = 0;
            this.rtbClientLog.Text = "";
            // 
            // UserOptionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 625);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserOptionFrm";
            this.Text = "客户端 IMEI:";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 发送命令ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsCall;
        private System.Windows.Forms.ToolStripMenuItem tsSms;
        private System.Windows.Forms.ToolStripMenuItem tsMessage;
        private System.Windows.Forms.ToolStripMenuItem 录音ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsRecordAudio;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.RichTextBox rtbClientLog;
        private System.Windows.Forms.ToolStripMenuItem 电话监听ToolStripMenuItem;
    }
}