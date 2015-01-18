namespace IIE.Phone.Troj.Host
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.应用端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpneUserInterface = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.scMainPanel = new System.Windows.Forms.SplitContainer();
            this.lvClient = new System.Windows.Forms.ListView();
            this.colImei = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSimNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhoneNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeviceInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).BeginInit();
            this.scMainPanel.Panel1.SuspendLayout();
            this.scMainPanel.Panel2.SuspendLayout();
            this.scMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务器ToolStripMenuItem,
            this.应用端ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(917, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 服务器ToolStripMenuItem
            // 
            this.服务器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExit,
            this.tsShowLog});
            this.服务器ToolStripMenuItem.Name = "服务器ToolStripMenuItem";
            this.服务器ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.服务器ToolStripMenuItem.Text = "服务器";
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(124, 22);
            this.tsExit.Text = "退出";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // tsShowLog
            // 
            this.tsShowLog.Name = "tsShowLog";
            this.tsShowLog.Size = new System.Drawing.Size(124, 22);
            this.tsShowLog.Text = "显示日志";
            this.tsShowLog.Click += new System.EventHandler(this.tsShowLog_Click);
            // 
            // 应用端ToolStripMenuItem
            // 
            this.应用端ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsInstall,
            this.tsOpneUserInterface,
            this.tsDisconnect});
            this.应用端ToolStripMenuItem.Name = "应用端ToolStripMenuItem";
            this.应用端ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.应用端ToolStripMenuItem.Text = "客户端";
            // 
            // tsInstall
            // 
            this.tsInstall.Name = "tsInstall";
            this.tsInstall.Size = new System.Drawing.Size(168, 22);
            this.tsInstall.Text = "安装客户端(USB)";
            this.tsInstall.Click += new System.EventHandler(this.tsInstall_Click);
            // 
            // tsOpneUserInterface
            // 
            this.tsOpneUserInterface.Name = "tsOpneUserInterface";
            this.tsOpneUserInterface.Size = new System.Drawing.Size(168, 22);
            this.tsOpneUserInterface.Text = "打开操作界面";
            this.tsOpneUserInterface.Click += new System.EventHandler(this.tsOpneUserInterface_Click);
            // 
            // tsDisconnect
            // 
            this.tsDisconnect.Name = "tsDisconnect";
            this.tsDisconnect.Size = new System.Drawing.Size(168, 22);
            this.tsDisconnect.Text = "断开连接";
            this.tsDisconnect.Click += new System.EventHandler(this.tsDisconnect_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAbout});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // tsAbout
            // 
            this.tsAbout.Name = "tsAbout";
            this.tsAbout.Size = new System.Drawing.Size(109, 22);
            this.tsAbout.Text = "关于...";
            this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
            // 
            // scMainPanel
            // 
            this.scMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMainPanel.Location = new System.Drawing.Point(0, 25);
            this.scMainPanel.Name = "scMainPanel";
            this.scMainPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainPanel.Panel1
            // 
            this.scMainPanel.Panel1.Controls.Add(this.lvClient);
            // 
            // scMainPanel.Panel2
            // 
            this.scMainPanel.Panel2.Controls.Add(this.rtbLog);
            this.scMainPanel.Size = new System.Drawing.Size(917, 397);
            this.scMainPanel.SplitterDistance = 241;
            this.scMainPanel.TabIndex = 1;
            // 
            // lvClient
            // 
            this.lvClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImei,
            this.colSimNo,
            this.colPhoneNum,
            this.colDeviceInfo,
            this.colRom});
            this.lvClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClient.FullRowSelect = true;
            this.lvClient.GridLines = true;
            this.lvClient.Location = new System.Drawing.Point(0, 0);
            this.lvClient.MultiSelect = false;
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(917, 241);
            this.lvClient.TabIndex = 0;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.View = System.Windows.Forms.View.Details;
            // 
            // colImei
            // 
            this.colImei.Text = "IMEI";
            this.colImei.Width = 247;
            // 
            // colSimNo
            // 
            this.colSimNo.Text = "SIM卡序列号";
            this.colSimNo.Width = 290;
            // 
            // colPhoneNum
            // 
            this.colPhoneNum.Text = "电话号码";
            this.colPhoneNum.Width = 150;
            // 
            // colDeviceInfo
            // 
            this.colDeviceInfo.Text = "品牌及型号";
            this.colDeviceInfo.Width = 158;
            // 
            // colRom
            // 
            this.colRom.Text = "ROM";
            this.colRom.Width = 65;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(917, 152);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 422);
            this.Controls.Add(this.scMainPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainFrm";
            this.Text = "Android木马主控端";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.scMainPanel.Panel1.ResumeLayout(false);
            this.scMainPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMainPanel)).EndInit();
            this.scMainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 服务器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem tsShowLog;
        private System.Windows.Forms.ToolStripMenuItem 应用端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsOpneUserInterface;
        private System.Windows.Forms.ToolStripMenuItem tsDisconnect;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsAbout;
        private System.Windows.Forms.SplitContainer scMainPanel;
        private System.Windows.Forms.ListView lvClient;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ColumnHeader colImei;
        private System.Windows.Forms.ColumnHeader colSimNo;
        private System.Windows.Forms.ColumnHeader colPhoneNum;
        private System.Windows.Forms.ColumnHeader colDeviceInfo;
        private System.Windows.Forms.ColumnHeader colRom;
        private System.Windows.Forms.ToolStripMenuItem tsInstall;
    }
}

