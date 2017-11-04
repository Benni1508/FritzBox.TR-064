using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "deviceList", Namespace = "urn:dslforum-org:device-1-0")]
    public class DeviceList
    {
        [XmlElement(ElementName = "device", Namespace = "urn:dslforum-org:device-1-0")]
        public Device[] Device { get; set; }
    }
}