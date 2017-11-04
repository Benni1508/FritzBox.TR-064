using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "service", Namespace = "urn:dslforum-org:device-1-0")]
    public class Service
    {
        [XmlElement(ElementName = "controlURL", Namespace = "urn:dslforum-org:device-1-0")]
        public string ControlURL { get; set; }
        [XmlElement(ElementName = "eventSubURL", Namespace = "urn:dslforum-org:device-1-0")]
        public string EventSubURL { get; set; }
        [XmlElement(ElementName = "SCPDURL", Namespace = "urn:dslforum-org:device-1-0")]
        public string SCPDURL { get; set; }
        [XmlElement(ElementName = "serviceId", Namespace = "urn:dslforum-org:device-1-0")]
        public string ServiceId { get; set; }
        [XmlElement(ElementName = "serviceType", Namespace = "urn:dslforum-org:device-1-0")]
        public string ServiceType { get; set; }
    }
}