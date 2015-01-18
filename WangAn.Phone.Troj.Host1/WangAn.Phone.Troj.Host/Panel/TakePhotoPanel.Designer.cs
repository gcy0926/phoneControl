namespace IIE.Phone.Troj.Host.Panel
{
    partial class TakePhotoPanel
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnBackPhoto = new System.Windows.Forms.Button();
            this.btnPrePhoto = new System.Windows.Forms.Button();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnBackPhoto);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrePhoto);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbPhoto);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 459);
            this.splitContainer1.SplitterDistance = 362;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnBackPhoto
            // 
            this.btnBackPhoto.Location = new System.Drawing.Point(21, 60);
            this.btnBackPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackPhoto.Name = "btnBackPhoto";
            this.btnBackPhoto.Size = new System.Drawing.Size(317, 29);
            this.btnBackPhoto.TabIndex = 1;
            this.btnBackPhoto.Text = "后端拍照";
            this.btnBackPhoto.UseVisualStyleBackColor = true;
            this.btnBackPhoto.Click += new System.EventHandler(this.btnBackPhoto_Click);
            // 
            // btnPrePhoto
            // 
            this.btnPrePhoto.Location = new System.Drawing.Point(21, 22);
            this.btnPrePhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrePhoto.Name = "btnPrePhoto";
            this.btnPrePhoto.Size = new System.Drawing.Size(317, 29);
            this.btnPrePhoto.TabIndex = 0;
            this.btnPrePhoto.Text = "前端拍照";
            this.btnPrePhoto.UseVisualStyleBackColor = true;
            this.btnPrePhoto.Click += new System.EventHandler(this.btnPrePhoto_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPhoto.Location = new System.Drawing.Point(0, 0);
            this.pbPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(721, 459);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            this.pbPhoto.Click += new System.EventHandler(this.pbPhoto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 428);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "*点击图片窗口可以旋转图片";
            // 
            // TakePhotoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TakePhotoPanel";
            this.Size = new System.Drawing.Size(1088, 459);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnBackPhoto;
        private System.Windows.Forms.Button btnPrePhoto;
        private System.Windows.Forms.Label label1;
    }
}
