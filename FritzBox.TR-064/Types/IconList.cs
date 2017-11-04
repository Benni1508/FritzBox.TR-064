using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "iconList", Namespace = "urn:dslforum-org:device-1-0")]
    public class IconList
    {
        [XmlElement(ElementName = "icon", Namespace = "urn:dslforum-org:device-1-0")]
        public Icon Icon { get; set; }
    }
}