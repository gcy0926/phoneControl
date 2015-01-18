namespace IIE.Phone.Troj.Host.Panel
{
    partial class ReadSmsPanel
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSmsKeyWord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSmsContent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSmsSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvSms = new System.Windows.Forms.ListView();
            this.colSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsRead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbSmsKeyWord);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbSmsContent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPhoneNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbSmsSource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(619, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSmsKeyWord
            // 
            this.tbSmsKeyWord.Location = new System.Drawing.Point(394, 63);
            this.tbSmsKeyWord.Name = "tbSmsKeyWord";
            this.tbSmsKeyWord.Size = new System.Drawing.Size(192, 21);
            this.tbSmsKeyWord.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "关键字：";
            // 
            // cbSmsContent
            // 
            this.cbSmsContent.FormattingEnabled = true;
            this.cbSmsContent.Items.AddRange(new object[] {
            "全部",
            "已读",
            "未读"});
            this.cbSmsContent.Location = new System.Drawing.Point(394, 30);
            this.cbSmsContent.Name = "cbSmsContent";
            this.cbSmsContent.Size = new System.Drawing.Size(192, 20);
            this.cbSmsContent.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "短信内容：";
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(80, 63);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(192, 21);
            this.tbPhoneNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "电话号码：";
            // 
            // cbSmsSource
            // 
            this.cbSmsSource.FormattingEnabled = true;
            this.cbSmsSource.Items.AddRange(new object[] {
            "全部",
            "发送",
            "接收"});
            this.cbSmsSource.Location = new System.Drawing.Point(80, 30);
            this.cbSmsSource.Name = "cbSmsSource";
            this.cbSmsSource.Size = new System.Drawing.Size(192, 20);
            this.cbSmsSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "短信源：";
            // 
            // lvSms
            // 
            this.lvSms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSource,
            this.colIsRead,
            this.colPhoneNumber,
            this.colContent});
            this.lvSms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSms.FullRowSelect = true;
            this.lvSms.Location = new System.Drawing.Point(0, 100);
            this.lvSms.Name = "lvSms";
            this.lvSms.Size = new System.Drawing.Size(816, 267);
            this.lvSms.TabIndex = 1;
            this.lvSms.UseCompatibleStateImageBehavior = false;
            this.lvSms.View = System.Windows.Forms.View.Details;
            // 
            // colSource
            // 
            this.colSource.Text = "源";
            // 
            // colIsRead
            // 
            this.colIsRead.Text = "是否已读";
            this.colIsRead.Width = 105;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.Text = "电话号码";
            this.colPhoneNumber.Width = 122;
            // 
            // colContent
            // 
            this.colContent.Text = "短信内容";
            this.colContent.Width = 515;
            // 
            // ReadSmsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvSms);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReadSmsPanel";
            this.Size = new System.Drawing.Size(816, 367);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvSms;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSmsSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSmsKeyWord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSmsContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colSource;
        private System.Windows.Forms.ColumnHeader colContent;
        private System.Windows.Forms.ColumnHeader colPhoneNumber;
        private System.Windows.Forms.ColumnHeader colIsRead;
        private System.Windows.Forms.Button btnSearch;
    }
}
