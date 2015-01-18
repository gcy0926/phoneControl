using System;
using System.Collections.Generic;
using System.ComponentModel;
using InOut.Utils;

namespace InOut.PacketImp
{
    [Serializable]
    public class AdvancedInformationPacket : IPacket
    {
        [Alias("phoneNumber")]
        public string PhoneNumber { get; set; }
        [Alias("IMEI")]
        public string IMEI { get; set; }
        [Alias("softwareVersion")]
        public string SoftwareVersion { get; set; }
        [Alias("countryCode")]
        public string CountryCode { get; set; }
        [Alias("operatorCode")]
        public string OperatorCode { get; set; }
        [Alias("operatorName")]
        public string OperatorName { get; set; }
        [Alias("simOperatorCode")]
        public string SimOperatorCode { get; set; }
        [Alias("simOperatorName")]
        public string SimOperatorName { get; set; }
        [Alias("simCountryCode")]
        public string SimCountryCode { get; set; }
        [Alias("simSerial")]
        public string SimSerial { get; set; }
        [Alias("wifiAvailable")]
        public bool WifiAvailable { get; set; }
        [Alias("wifiConnectedOrConnecting")]
        public bool WifiConnectedOrConnecting { get; set; }
        [Alias("wifiExtraInfos")]
        public string WifiExtraInfos { get; set; }
        [Alias("wifiReason")]
        public string WifiReason { get; set; }
        [Alias("mobileNetworkName")]
        public string MobileNetworkName { get; set; }
        [Alias("mobileNetworkAvailable")]
        public bool MobileNetworkAvailable { get; set; }
        [Alias("mobileNetworkConnectedOrConnecting")]
        public bool MobileNetworkConnectedOrConnecting { get; set; }
        [Alias("mobileNetworkExtraInfos")]
        public string MobileNetworkExtraInfos { get; set; }
        [Alias("mobileNetworkReason")]
        public string MobileNetworkReason { get; set; }
        [Alias("androidVersion")]
        public string AndroidVersion { get; set; }
        [Alias("androidSdk")]
        public int AndroidSdk { get; set; }
        [Alias("sensors")]
        public List<String> Sensors { get; set; }
        [Alias("batteryHealth")]
        public int BatteryHealth { get; set; }
        [Alias("batteryLevel")]
        public int BatteryLevel { get; set; }
        [Alias("batteryPlugged")]
        public int BatteryPlugged { get; set; }
        [Alias("batteryPresent")]
        public bool BatteryPresent { get; set; }
        [Alias("batteryScale")]
        public int BatteryScale { get; set; }
        [Alias("batteryStatus")]
        public int BatteryStatus { get; set; }
        [Alias("batteryTechnology")]
        public string BatteryTechnology { get; set; }
        [Alias("batteryTemperature")]
        public int BatteryTemperature { get; set; }
        [Alias("batteryVoltage")]
        public int BatteryVoltage { get; set; }

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
