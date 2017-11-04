using System.Collections.Generic;
using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "telephony")]
    public class Telephony
    {
        [XmlElement(ElementName = "services")]
        public string Services { get; set; }
        [XmlElement(ElementName = "number")]
        public List<Number> Number { get; set; }
    }
}