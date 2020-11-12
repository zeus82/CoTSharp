using System.Diagnostics;
using System.Xml.Serialization;

namespace CotSharp
{
    [DebuggerStepThrough]
    [XmlRoot("auth")]
    [XmlType(TypeName = "auth")]
    public class CotAuthentication
    {
        [XmlElement("cot")]
        public CoTCredentials Credentials { get; set; }
    }

    [DebuggerStepThrough]
    [XmlRoot("cot")]
    [XmlType(TypeName = "cot")]
    public class CoTCredentials
    {
        [XmlAttribute("password")]
        public string Password { get; set; }

        [XmlAttribute("uid")]
        public string Uid { get; set; }

        [XmlAttribute("username")]
        public string Username { get; set; }
    }
}
