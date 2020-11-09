using System.Xml;
using System.Xml.Serialization;

namespace CotSharp
{
    /// <remarks/>
    [XmlRoot("detail")]
    [XmlType(TypeName = "detail")]
    public partial class Detail
    {
        /// <remarks/>
        [XmlElement("contact", typeof(Contact))]
        [XmlElement("any")]
        public object[] Any { get; set; }

        /// <remarks/>
        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr { get; set; }
    }
}
