using System.Xml;
using System.Xml.Serialization;

namespace CotSharp
{
    [XmlRoot("detail")]
    [XmlType(TypeName = "detail")]
    public partial class Detail
    {
        [XmlElement("contact", typeof(Contact))]
        [XmlElement("any")]
        public object[] Any { get; set; }

        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr { get; set; }
    }
}
