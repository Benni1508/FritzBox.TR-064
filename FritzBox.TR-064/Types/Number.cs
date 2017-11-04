using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "number")]
    public class Number
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "quickdial")]
        public string Quickdial { get; set; }
        [XmlAttribute(AttributeName = "vanity")]
        public string Vanity { get; set; }
        [XmlAttribute(AttributeName = "prio")]
        public string Prio { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}