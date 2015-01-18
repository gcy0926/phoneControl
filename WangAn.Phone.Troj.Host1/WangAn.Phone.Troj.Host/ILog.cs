using System;
using WangAn.Command;

namespace IIE.Phone.Troj.Host
{
    public interface ILog:WangAn.Command.ILog
    {

        void RecordError(string p);
        void LogTxt(string p);
        void LogErrTxt(string p);
        void ClientLogTxt(string imei, long date, string message);
        void ClientErrLogTxt(string imei, long date, string message);

        event  Action<string> LogHandler;
        event Action<string, string> ClientLogHandler;
    }
}
