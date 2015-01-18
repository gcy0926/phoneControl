using System;
using System.Configuration;
using System.IO;

namespace IIE.Phone.Troj.Host
{
    public class Config:IConfig
    {
        public int Port { get; private set; }
        public string AppName { get; private set; }

        public Config()
        {
            AppName = ConfigurationManager.AppSettings["appname"];
            Port = int.Parse(ConfigurationManager.AppSettings["port"]);
        }

        public string AdbPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"wa_adb.exe"); }
        }

        public int CmdTimeOut
        {
            get { return 1000; }
        }

        public string FastBootPath
        {
            get { return string.Empty; }
        }

        public string SimulationOsFolder
        {
            get { return string.Empty; }
        }

        public string TempPath
        {
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"temp");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public System.Collections.Generic.IEnumerable<string> ThirdPartAdbProcessNames
        {
            get { return new string[0]; }
        }


        public string ClientApkPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"LauncherActivity.apk"); }
        }
    }
}
