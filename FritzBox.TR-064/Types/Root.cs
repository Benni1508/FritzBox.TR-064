using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "root", Namespace = "urn:dslforum-org:device-1-0")]
    public class Root
    {
        [XmlElement(ElementName = "device", Namespace = "urn:dslforum-org:device-1-0")]
        public Device Device { get; set; }
        [XmlElement(ElementName = "specVersion", Namespace = "urn:dslforum-org:device-1-0")]
        public SpecVersion SpecVersion { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}