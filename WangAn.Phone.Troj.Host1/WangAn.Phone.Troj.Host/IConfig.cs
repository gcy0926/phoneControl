
using WangAn.Device.Phone;

namespace IIE.Phone.Troj.Host
{
    public interface IConfig:IDeviceConfig
    {
        int Port { get; }
        string AppName { get; }
        string ClientApkPath { get;  }
    }
}
