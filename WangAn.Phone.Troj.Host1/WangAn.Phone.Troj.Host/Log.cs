using System;

namespace IIE.Phone.Troj.Host
{
    public class Log : ILog
    {
        public event Action<string> LogHandler;
        public event Action<string, string> ClientLogHandler;

        protected virtual void OnLogHandler(string obj)
        {
            Action<string> handler = LogHandler;
            if (handler != null) handler(obj);
        }

        protected virtual void OnClientLogHandler(string imei, string message)
        {
            Action<string, string> handler = ClientLogHandler;
            if (handler != null) handler(imei, message);
        }

        public void RecordError(string p)
        {
            OnLogHandler(p);
        }

        public void LogTxt(string p)
        {
            OnLogHandler(p);
        }

        public void LogErrTxt(string p)
        {
            OnLogHandler(p);
        }


        public void ClientLogTxt(string imei, long date, string message)
        {
            //TODO:java时间转发C#时间
            OnClientLogHandler(imei, message);
        }

        public void ClientErrLogTxt(string imei, long date, string message)
        {
            OnClientLogHandler(imei, message);
        }

        public void RecordError(string errorInfo, string exceptionMsg, string stackTrace)
        {

        }

        public void RecordInfo(string output)
        {

        }
    }
}
