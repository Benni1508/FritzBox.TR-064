using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "contact")]
    public class Contact
    {
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "person")]
        public Person Person { get; set; }
        [XmlElement(ElementName = "uniqueid")]
        public string Uniqueid { get; set; }
        [XmlElement(ElementName = "telephony")]
        public Telephony Telephony { get; set; }
    }
}