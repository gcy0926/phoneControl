using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace IIE.Phone.Troj.Host
{
    class get_ataid
    {
        public static string GetHardDiskID()
        {
            try
            {
                string hdInfo = "";//硬盘序列号  
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
                hdInfo = disk.Properties["VolumeSerialNumber"].Value.ToString();
                disk = null;
                return hdInfo.Trim();
            }
            catch (Exception e)
            {
                return "uHnIk";
            }
        }
    }
}
