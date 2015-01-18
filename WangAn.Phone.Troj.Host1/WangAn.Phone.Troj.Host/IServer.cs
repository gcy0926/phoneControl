namespace IIE.Phone.Troj.Host
{
    public interface IServer
    {
        void SetOnlineAsyn();
        void Realse();
        void CommandSender(string imei, short command, byte[] args);
        void CommandFileSender(string imei, short command, byte[] pathData, string downPath, string downName);
        void CommandStopSender(string imei, short command, byte[] args, int channel);

    }
}
