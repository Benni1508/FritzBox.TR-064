using System.Xml;
using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "GetInfoResponse")]
    public class WlanInfo
    {
        public WlanInfo(XmlNode node)
        {
            var doc = new XmlDocument();
            doc.LoadXml(node.OuterXml);
            this.BasicAuthenticationMode = doc.GetElementsByTagName("NewBasicAuthenticationMode")[0].InnerText;
            this.BasicEncryptionModes = doc.GetElementsByTagName("NewBasicEncryptionModes")[0].InnerText;
            this.BeaconType = doc.GetElementsByTagName("NewBeaconType")[0].InnerText;
            this.Enable = doc.GetElementsByTagName("NewEnable")[0].InnerText;
            this.MACAddressControlEnabled = doc.GetElementsByTagName("NewMACAddressControlEnabled")[0].InnerText;
            this.MaxBitRate = doc.GetElementsByTagName("NewMaxBitRate")[0].InnerText;
            this.SSID = doc.GetElementsByTagName("NewSSID")[0].InnerText;
            this.Standard = doc.GetElementsByTagName("NewStandard")[0].InnerText;
            this.Status = doc.GetElementsByTagName("NewStatus")[0].InnerText;
        }

            public string BasicAuthenticationMode { get; set; }
            public string BasicEncryptionModes { get; set; }
            public string BeaconType { get; set; }
            public string Enable { get; set; }
            public string MACAddressControlEnabled { get; set; }
            public string MaxBitRate { get; set; }
            public string SSID { get; set; }
            public string Standard { get; set; }
            public string Status { get; set; }
    }
}