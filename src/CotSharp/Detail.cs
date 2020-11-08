using System.Xml;
using System.Xml.Serialization;

namespace CotSharp
{
    [XmlRoot("detail")]
    [XmlType(TypeName = "detail")]
    public partial class Detail
    {
        [XmlAnyElement()]
        public XmlElement[] Any { get; set; }

        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr { get; set; }
    }
}
