using System.Collections.Generic;
using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "serviceList", Namespace = "urn:dslforum-org:device-1-0")]
    public class ServiceList
    {
        [XmlElement(ElementName = "service", Namespace = "urn:dslforum-org:device-1-0")]
        public List<Service> Service { get; set; }
    }
}