using System;
using System.ComponentModel;
using InOut.Utils;

namespace InOut.PacketImp
{
    [Serializable]
    public class PreferencePacket : IPacket
    {
        [Alias("ip")]
        public string Ip { get; set; }
        [Alias("port")]
        public int Port { get; set; }
        [Alias("waitTrigger")]
        public bool WaitTrigger { get; set; }
        [Alias("phoneNumberCall")]
        public string[] PhoneNumberCall { get; set; }
        [Alias("phoneNumberSMS")]
        public string[] PhoneNumberSMS { get; set; }
        [Alias("keywordSMS")]
        public string[] KeywordSMS { get; set; }

        public PreferencePacket()
        {

        }

        public PreferencePacket(String ip, int port, bool wait, string[] phones, string[] sms, string[] kw)
        {
            Ip = ip;
            Port = port;
            WaitTrigger = wait;
            PhoneNumberCall = phones;
            PhoneNumberSMS = sms;
            KeywordSMS = kw;
        }

        public byte[] Build()
        {
            return PacketUtil.Build(this);
        }

        public void Parse(byte[] packet)
        {
            PacketUtil.Parse(packet, this);
        }

    }
}
