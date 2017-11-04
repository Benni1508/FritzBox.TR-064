
using System.Xml.Serialization;

namespace FritzBox.Tr064.Types
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true, Namespace = "urn:dslforum-org:service:DeviceInfo:1")]
    [XmlRoot(Namespace = "urn:dslforum-org:service:DeviceInfo:1", IsNullable = false)]
    public partial class GetInfoResponse
    {
        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewManufacturerName { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewManufacturerOUI { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewModelName { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewDescription { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewProductClass { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewSerialNumber { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewSoftwareVersion { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewHardwareVersion { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public decimal NewSpecVersion { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public object NewProvisioningCode { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public uint NewUpTime { get; set; }

        /// <remarks/>
        [XmlElement(Namespace = "")]
        public string NewDeviceLog { get; set; }
    }
}

