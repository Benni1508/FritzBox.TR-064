 
namespace FritzBox.Tr064.Types
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:dslforum-org:service:Hosts:1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:dslforum-org:service:Hosts:1", IsNullable = false)]
    public partial class GetGenericHostEntryResponse
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string NewIPAddress { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string NewAddressSource { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public double NewLeaseTimeRemaining { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string NewMACAddress { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string NewInterfaceType { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public byte NewActive { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string NewHostName { get; set; }
    }
}

