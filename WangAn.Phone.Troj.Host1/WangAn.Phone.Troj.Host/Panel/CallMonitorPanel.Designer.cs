namespace IIE.Phone.Troj.Host.Panel
{
    partial class CallMonitorPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lvCallMonitor = new System.Windows.Forms.ListView();
            this.colIsRead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnd);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(170, 45);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "结束监听";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(58, 45);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始监听";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lvCallMonitor
            // 
            this.lvCallMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIsRead,
            this.colPhoneNumber,
            this.colContent});
            this.lvCallMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCallMonitor.FullRowSelect = true;
            this.lvCallMonitor.Location = new System.Drawing.Point(0, 100);
            this.lvCallMonitor.Name = "lvCallMonitor";
            this.lvCallMonitor.Size = new System.Drawing.Size(816, 267);
            this.lvCallMonitor.TabIndex = 1;
            this.lvCallMonitor.UseCompatibleStateImageBehavior = false;
            this.lvCallMonitor.View = System.Windows.Forms.View.Details;
            // 
            // colIsRead
            // 
            this.colIsRead.Text = "通话类型";
            this.colIsRead.Width = 105;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.Text = "电话号码";
            this.colPhoneNumber.Width = 122;
            // 
            // colContent
            // 
            this.colContent.Text = "时间";
            this.colContent.Width = 515;
            // 
            // CallMonitorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvCallMonitor);
            this.Controls.Add(this.groupBox1);
            this.Name = "CallMonitorPanel";
            this.Size = new System.Drawing.Size(816, 367);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.ListView lvCallMonitor;
        private System.Windows.Forms.ColumnHeader colIsRead;
        private System.Windows.Forms.ColumnHeader colPhoneNumber;
        private System.Windows.Forms.ColumnHeader colContent;
    }
}
