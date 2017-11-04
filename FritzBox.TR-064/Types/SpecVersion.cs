using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "specVersion", Namespace = "urn:dslforum-org:device-1-0")]
    public class SpecVersion
    {
        [XmlElement(ElementName = "major", Namespace = "urn:dslforum-org:device-1-0")]
        public string Major { get; set; }
        [XmlElement(ElementName = "minor", Namespace = "urn:dslforum-org:device-1-0")]
        public string Minor { get; set; }
    }
}