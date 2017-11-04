using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "phonebooks")]
    public class Phonebooks
    {
        [XmlElement(ElementName = "phonebook")]
        public Phonebook Phonebook { get; set; }
    }
}