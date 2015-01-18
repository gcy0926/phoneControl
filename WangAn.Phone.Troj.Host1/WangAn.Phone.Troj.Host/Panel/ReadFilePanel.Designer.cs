namespace IIE.Phone.Troj.Host.Panel
{
    partial class ReadFilePanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadFilePanel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvFile = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFileTree = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.tbDownDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbLastChange = new System.Windows.Forms.Label();
            this.lbPermission = new System.Windows.Forms.Label();
            this.lbHide = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(728, 367);
            this.splitContainer1.SplitterDistance = 435;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvFile
            // 
            this.tvFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFile.Location = new System.Drawing.Point(0, 0);
            this.tvFile.Name = "tvFile";
            this.tvFile.Size = new System.Drawing.Size(435, 367);
            this.tvFile.TabIndex = 0;
            this.tvFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFile_AfterSelect);
            this.tvFile.DoubleClick += new System.EventHandler(this.tvFile_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFileTree);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.tbDownDir);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbLastChange);
            this.groupBox1.Controls.Add(this.lbPermission);
            this.groupBox1.Controls.Add(this.lbHide);
            this.groupBox1.Controls.Add(this.lbSize);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 367);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件信息";
            // 
            // btnFileTree
            // 
            this.btnFileTree.Location = new System.Drawing.Point(32, 316);
            this.btnFileTree.Name = "btnFileTree";
            this.btnFileTree.Size = new System.Drawing.Size(251, 23);
            this.btnFileTree.TabIndex = 8;
            this.btnFileTree.Text = "获取目录树";
            this.btnFileTree.UseVisualStyleBackColor = true;
            this.btnFileTree.Click += new System.EventHandler(this.btnFileTree_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(32, 278);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(251, 23);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // tbDownDir
            // 
            this.tbDownDir.Location = new System.Drawing.Point(32, 231);
            this.tbDownDir.Name = "tbDownDir";
            this.tbDownDir.Size = new System.Drawing.Size(251, 21);
            this.tbDownDir.TabIndex = 6;
            this.tbDownDir.Text = "download";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "下载目录：";
            // 
            // lbLastChange
            // 
            this.lbLastChange.AutoSize = true;
            this.lbLastChange.Location = new System.Drawing.Point(30, 161);
            this.lbLastChange.Name = "lbLastChange";
            this.lbLastChange.Size = new System.Drawing.Size(89, 12);
            this.lbLastChange.TabIndex = 4;
            this.lbLastChange.Text = "最后修改时间：";
            // 
            // lbPermission
            // 
            this.lbPermission.AutoSize = true;
            this.lbPermission.Location = new System.Drawing.Point(30, 131);
            this.lbPermission.Name = "lbPermission";
            this.lbPermission.Size = new System.Drawing.Size(41, 12);
            this.lbPermission.TabIndex = 3;
            this.lbPermission.Text = "权限：";
            // 
            // lbHide
            // 
            this.lbHide.AutoSize = true;
            this.lbHide.Location = new System.Drawing.Point(30, 99);
            this.lbHide.Name = "lbHide";
            this.lbHide.Size = new System.Drawing.Size(65, 12);
            this.lbHide.TabIndex = 2;
            this.lbHide.Text = "是否隐藏：";
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(30, 70);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(41, 12);
            this.lbSize.TabIndex = 1;
            this.lbSize.Text = "大小：";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(30, 36);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 12);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "名称：";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder");
            this.imageList.Images.SetKeyName(1, "openfolder");
            this.imageList.Images.SetKeyName(2, "file");
            // 
            // ReadFilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReadFilePanel";
            this.Size = new System.Drawing.Size(728, 367);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFileTree;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox tbDownDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbLastChange;
        private System.Windows.Forms.Label lbPermission;
        private System.Windows.Forms.Label lbHide;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.ImageList imageList;
    }
}
