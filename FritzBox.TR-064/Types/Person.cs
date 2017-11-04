using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "person")]
    public class Person
    {
        [XmlElement(ElementName = "realName")]
        public string RealName { get; set; }
    }
}