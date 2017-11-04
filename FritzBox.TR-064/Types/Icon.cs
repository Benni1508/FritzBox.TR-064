using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "icon", Namespace = "urn:dslforum-org:device-1-0")]
    public class Icon
    {
        [XmlElement(ElementName = "depth", Namespace = "urn:dslforum-org:device-1-0")]
        public string Depth { get; set; }
        [XmlElement(ElementName = "height", Namespace = "urn:dslforum-org:device-1-0")]
        public string Height { get; set; }
        [XmlElement(ElementName = "mimetype", Namespace = "urn:dslforum-org:device-1-0")]
        public string Mimetype { get; set; }
        [XmlElement(ElementName = "url", Namespace = "urn:dslforum-org:device-1-0")]
        public string Url { get; set; }
        [XmlElement(ElementName = "width", Namespace = "urn:dslforum-org:device-1-0")]
        public string Width { get; set; }
    }
}