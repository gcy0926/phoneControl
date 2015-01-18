using System.Collections.Generic;

namespace IIE.Phone.Troj.Host.Model
{
    public class UserInfo
    {
        public string Imei { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Operator { get; set; }
        public string SimCountry{get;set;}
        public string SimOperator{get;set;}
        public string SimSerial{get;set;}

        public UserInfo()
        {
            
        }

        public UserInfo(string imei, Dictionary<string, string> userPropDict)
        {
            //TODO:品牌、型号、ROM版本号
            Imei = imei;
            Country = userPropDict["Country"];
            PhoneNumber = userPropDict["PhoneNumber"];
            Operator = userPropDict["Operator"];
            SimCountry = userPropDict["SimCountry"];
            SimOperator = userPropDict["SimOperator"];
            SimSerial = userPropDict["SimSerial"];

        }
    }
}
