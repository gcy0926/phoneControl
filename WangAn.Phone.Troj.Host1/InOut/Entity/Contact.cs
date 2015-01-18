using System;
using System.ComponentModel;
using InOut.Utils;

namespace InOut.Entity
{
    [Serializable]
    public class Contact
    {
        [Alias("id")]
        public long Id{ get; set; }
        [Alias("times_contacted")]
        public int TimesContacted{ get; set; }
        [Alias("last_time_contacted")]
        public long LastTimeContacted{ get; set; }
        [Alias("display_name")]
        public string DisplayName{ get; set; }
        [Alias("starred")]
        public int Starred{ get; set; }
        [Alias("phones")]
        public string[] Phones{ get; set; }
        [Alias("emails")]
        public string[] Emails{ get; set; }
        [Alias("notes")]
        public string[] Notes{ get; set; }
        [Alias("street")]
        public string Street{ get; set; }
        [Alias("city")]
        public string City{ get; set; }
        [Alias("region")]
        public string Region{ get; set; }
        [Alias("postalcode")]
        public string Postalcode{ get; set; }
        [Alias("country")]
        public string Country{ get; set; }
        [Alias("type_addr")]
        public int TypeAddr{ get; set; }
        [Alias("messaging")]
        public string[] Messaging{ get; set; }
        [Alias("OrganisationName")]
        public string OrganisationName{ get; set; }
        [Alias("OrganisationStatus")]
        public string OrganisationStatus{ get; set; }
        [Alias("photo")]
        public byte[] Photo{ get; set; }
    }
}
