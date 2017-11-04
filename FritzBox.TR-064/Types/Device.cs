using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    [XmlRoot(ElementName = "device", Namespace = "urn:dslforum-org:device-1-0")]
    public class Device
    {
        [XmlElement(ElementName = "deviceList", Namespace = "urn:dslforum-org:device-1-0")]
        public DeviceList DeviceList { get; set; }
        [XmlElement(ElementName = "deviceType", Namespace = "urn:dslforum-org:device-1-0")]
        public string DeviceType { get; set; }
        [XmlElement(ElementName = "friendlyName", Namespace = "urn:dslforum-org:device-1-0")]
        public string FriendlyName { get; set; }
        [XmlElement(ElementName = "manufacturer", Namespace = "urn:dslforum-org:device-1-0")]
        public string Manufacturer { get; set; }
        [XmlElement(ElementName = "manufacturerURL", Namespace = "urn:dslforum-org:device-1-0")]
        public string ManufacturerURL { get; set; }
        [XmlElement(ElementName = "modelDescription", Namespace = "urn:dslforum-org:device-1-0")]
        public string ModelDescription { get; set; }
        [XmlElement(ElementName = "modelName", Namespace = "urn:dslforum-org:device-1-0")]
        public string ModelName { get; set; }
        [XmlElement(ElementName = "modelNumber", Namespace = "urn:dslforum-org:device-1-0")]
        public string ModelNumber { get; set; }
        [XmlElement(ElementName = "modelURL", Namespace = "urn:dslforum-org:device-1-0")]
        public string ModelURL { get; set; }
        [XmlElement(ElementName = "serviceList", Namespace = "urn:dslforum-org:device-1-0")]
        public ServiceList ServiceList { get; set; }
        [XmlElement(ElementName = "UDN", Namespace = "urn:dslforum-org:device-1-0")]
        public string UDN { get; set; }
        [XmlElement(ElementName = "UPC", Namespace = "urn:dslforum-org:device-1-0")]
        public string UPC { get; set; }
    }
}
