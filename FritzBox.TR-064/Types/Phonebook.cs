using System.Collections.Generic;
using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "phonebook")]
    public class Phonebook
    {
        [XmlElement(ElementName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlElement(ElementName = "contact")]
        public List<Contact> Contact { get; set; }
        [XmlAttribute(AttributeName = "owner")]
        public string Owner { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}