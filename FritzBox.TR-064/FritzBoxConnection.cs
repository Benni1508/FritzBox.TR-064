using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using FritzBox.Tr064.Types;

namespace FritzBox.Tr064
{
    public interface IFritzBoxConnection
    {
        GetGenericHostEntryResponse GetHostInformation(int number);
        int GetHostCount();
        Dictionary<string, bool> GetHostStates();
        string GetSsid(WlanType wlanType);
        string GetWlanPassword(WlanType type);
        WlanInfo GetWlanInfo(WlanType type);
        void ChangeGuestWlan(bool enable);
        string GetPhonebooks();
        Phonebooks GetPhonebook();
        GetInfoResponse GetDeviceInfo();

        IPAddress GetExternalIp();
    }

    public class FritzBoxConnection : IFritzBoxConnection
    {
        public static string soapEnvelope =
            "<?xml version=\"1.0\"?>" +
            "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
            "<s:Header>" +
            "<h:ClientAuth xmlns:h=\"http://soap-authentication.org/digest/2001/10/\" s:mustUnderstand=\"1\">" +
            "<Nonce></Nonce>" +
            "<Auth></Auth>" +
            "<UserID></UserID>" +
            "<Realm></Realm>" +
            "</h:ClientAuth>" +
            "</s:Header>" +
            "<s:Body></s:Body>" +
            "</s:Envelope>";

        private readonly string fbUrl;
        private readonly string password;
        private readonly string user;
        private Service[] services;

        public FritzBoxConnection(string fbUrl, string user, string password)
        {
            this.fbUrl = fbUrl;
            this.password = password;
            this.user = user;
        }


        public GetGenericHostEntryResponse GetHostInformation(int number)
        {
            var urn = "urn:dslforum-org:service:Hosts:1";
            var action = "GetGenericHostEntry";


            var xml = GetRequestXml(action, urn, new KeyValuePair<string, string>("NewIndex", number.ToString()));

            var response = Request(action, urn, xml);

            var responseDoc = new XmlDocument();
            responseDoc.LoadXml(response.InnerXml);

            var body = responseDoc.GetElementsByTagName("u:GetGenericHostEntryResponse")[0];
            var xmlserializer = new XmlSerializer(typeof(GetGenericHostEntryResponse));
            return (GetGenericHostEntryResponse)xmlserializer.Deserialize(new StringReader(body.OuterXml));
        }

        public int GetHostCount()
        {
            var urn = "urn:dslforum-org:service:Hosts:1";
            var action = "GetHostNumberOfEntries";

            var xml = GetRequestXml(action, urn);

            var response = Request(action, urn, xml);

            var responseDoc = new XmlDocument();
            responseDoc.LoadXml(response.InnerXml);
            var count = int.Parse(responseDoc.GetElementsByTagName("NewHostNumberOfEntries")[0].InnerText);
            return count;
        }

        public Dictionary<string, bool> GetHostStates()
        {
            var result = new Dictionary<string, bool>();
            var count = this.GetHostCount();
            for (int i = 0; i < count; i++)
            {
                var info = this.GetHostInformation(i);
                result.Add(info.NewMACAddress, info.NewActive == 1);
            }
            return result;
        }

        public string GetSsid(WlanType wlanType)
        {
            var urn = $"urn:dslforum-org:service:WLANConfiguration:{(int)wlanType}";
            var action = "GetSSID";

            var xml = GetRequestXml(action, urn);

            var response = RequestWithAuthentication(action, urn, xml);
            return response.GetElementsByTagName("NewSSID")[0].InnerText;
        }

        public string GetWlanPassword(WlanType type)
        {
            var urn = $"urn:dslforum-org:service:WLANConfiguration:{(int)type}";
            var action = "GetSecurityKeys";

            var xml = GetRequestXml(action, urn);

            var response = RequestWithAuthentication(action, urn, xml);
            return response.GetElementsByTagName("NewKeyPassphrase")[0].InnerText;
        }

        public WlanInfo GetWlanInfo(WlanType type)
        {
            var urn = $"urn:dslforum-org:service:WLANConfiguration:{(int)type}";
            var action = "GetInfo";

            var xml = GetRequestXml(action, urn);

            var response = RequestWithAuthentication(action, urn, xml);
            var node =  response.GetElementsByTagName("u:GetInfoResponse")[0];
            var se =new WlanInfo(node);
            return se;
        }

        public void ChangeGuestWlan(bool enable)
        {
            var urn = "urn:dslforum-org:service:WLANConfiguration:3";
            var action = "SetEnable";

            var xml = GetRequestXml(action, urn, new KeyValuePair<string, string>("NewEnable", enable ? "1" : "0"));

            RequestWithAuthentication(action, urn, xml);
        }

        private XmlDocument RequestWithAuthentication(string action, string urn, XmlDocument xml)
        {
            var preAuth = Request(action, urn, xml);
            this.SetAuth(preAuth, xml);
            return Request(action, urn, xml);
        }

        private XmlDocument Request(string action, string urn, XmlDocument xml)
        {
            var controlUrl = GetControlUrl(urn);
            var webrequest = WebRequest.Create($"{fbUrl}:49000{controlUrl}");
            webrequest.Headers.Add("SOAPAction", $"{urn}#{action}");
            webrequest.ContentType = "text/xml; charset=\"UTF-8\"";
            webrequest.ContentType = "text/xml";
            webrequest.Method = "POST";

            var requestStream = webrequest.GetRequestStream();

            xml.Save(requestStream);
            requestStream.Close();
            var resp = webrequest.GetResponse();
            var responseStream = resp.GetResponseStream();
            var responseXml = new XmlDocument();
            responseXml.Load(responseStream);
            responseStream.Close();
            return responseXml;
        }
        private List<Device> GetDevices(Device device, List<Device> devices)
        {
            if (device.DeviceList != null)
            {
                devices.AddRange(device.DeviceList.Device);
                foreach (var device1 in device.DeviceList.Device)
                {
                    GetDevices(device1, devices);
                }
            }

            return devices;
        }

        private string GetControlUrl(string urn)
        {
            if (this.services == null)
            {
                var webrequest = WebRequest.Create($"{fbUrl}:49000/tr64desc.xml");
                var response = webrequest.GetResponse();
                var responseStream = response.GetResponseStream();
                var responseText = new StreamReader(responseStream).ReadToEnd();


                var se = new XmlSerializer(typeof(Root));
                var tr064Desc = (Root)se.Deserialize(new StringReader(responseText));
                var all = GetDevices(tr064Desc.Device, new List<Device>(new[] { tr064Desc.Device }));
                var services = all.SelectMany(a => a.ServiceList?.Service).Select(s => s).ToArray();
                this.services = services;
            }

            var mainSerivce = services.FirstOrDefault(s =>
                    s.ServiceType.Equals(urn, StringComparison.InvariantCultureIgnoreCase));

            return mainSerivce.ControlURL;
        }


        public string GetPhonebooks()
        {
            var urn = "urn:dslforum-org:service:X_AVM-DE_OnTel:1";
            var action = "GetPhonebookList";

            var xml = GetRequestXml(action, urn);

            var rs1 = RequestWithAuthentication(action, urn, xml);

            var listResponse = rs1.GetElementsByTagName("PhonebookList")[0];
            return listResponse.InnerText;
        }

        private static XmlDocument GetRequestXml(string action, string urn,
            params KeyValuePair<string, string>[] parameter)
        {
            var xml = new XmlDocument();
            xml.LoadXml(soapEnvelope);
            var actionTag = xml.CreateElement("u", action, urn);
            foreach (var param in parameter)
            {
                var paramNode = xml.CreateElement(param.Key);
                paramNode.InnerText = param.Value;
                actionTag.AppendChild(paramNode);
            }
            xml.GetElementsByTagName("s:Body")[0].AppendChild(actionTag);
            return xml;
        }

        public Phonebooks GetPhonebook()
        {
            var urn = "urn:dslforum-org:service:X_AVM-DE_OnTel:1";
            var action = "GetPhonebook";

            var xml = GetRequestXml(action, urn, new KeyValuePair<string, string>("NewPhonebookID", "0"));

            var rs1 = RequestWithAuthentication(action, urn, xml);
            var url = rs1.GetElementsByTagName("NewPhonebookURL")[0].InnerText;

            var wr = WebRequest.Create(url);
            var response = wr.GetResponse();
            var responseStream = response.GetResponseStream();
            var responseText = new StreamReader(responseStream).ReadToEnd();

            var xmlserializer = new XmlSerializer(typeof(Phonebooks));
            var re = (Phonebooks)xmlserializer.Deserialize(new StringReader(responseText));
            return re;
        }


        public GetInfoResponse GetDeviceInfo()
        {
            var urn = "urn:dslforum-org:service:DeviceInfo:1";
            var action = "GetInfo";

            var xml = GetRequestXml(action, urn);
            var response2 = RequestWithAuthentication(action, urn, xml);

            var body = response2.GetElementsByTagName("u:GetInfoResponse")[0];
            var xmlserializer = new XmlSerializer(typeof(GetInfoResponse));
            var re = (GetInfoResponse)xmlserializer.Deserialize(new StringReader(body.OuterXml));

            return re;
        }

        public IPAddress GetExternalIp()
        {
            var urn = "urn:dslforum-org:service:WANPPPConnection:1";
            var action = "GetExternalIPAddress";

            var xml = GetRequestXml(action, urn);
            var response = RequestWithAuthentication(action, urn, xml);
            var ip = response.GetElementsByTagName("NewExternalIPAddress")[0].InnerText;
            return IPAddress.Parse(ip);
            
        }

        private void SetAuth(XmlDocument response, XmlDocument xmlDocument)
        {
            var nonce = response.GetElementsByTagName("Nonce")[0].InnerText;
            var realm = response.GetElementsByTagName("Realm")[0].InnerText;

            xmlDocument.GetElementsByTagName("Nonce")[0].InnerText = nonce;
            xmlDocument.GetElementsByTagName("Realm")[0].InnerText = realm;
            xmlDocument.GetElementsByTagName("UserID")[0].InnerText = "benni";

            var au = $"{user}:{realm}:{password}";
            var first = Helpers.Md5(au);
            var auth = Helpers.Md5($"{first}:{nonce}");
            xmlDocument.GetElementsByTagName("Auth")[0].InnerText = auth;
        }
    }
}