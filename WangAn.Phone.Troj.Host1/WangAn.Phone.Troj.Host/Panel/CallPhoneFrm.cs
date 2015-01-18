using System;
using System.Windows.Forms;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class CallPhoneFrm : Form
    {
        public string PhoneNumber
        {
            get
            {
                return tbNumber.Text.Trim();
            }
        }

        public CallPhoneFrm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PhoneNumber))
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
