using System.Xml.Serialization;

namespace CotSharp
{
    /// <summary>
    /// This is a Cursor On Target sub-schema representing communications parameters for
    /// contacting a friendly element for human-to-human communcations. The objective of
    /// this schema is to carry the essential information needed to contact this entity by
    /// a variety of means.  None of the modes of contact (e.g., e-mail, phone, etc) is
    /// required.
    /// </summary>
    [XmlRoot("contact")]
    [XmlType(TypeName = "contact")]
    public class Contact
    {
        [XmlAnyElement]
        [XmlElement("any")]
        public System.Xml.XmlElement[] Any { get; set; }

        /// <summary>
        /// The unit's voice call sign
        /// </summary>
        [XmlAttribute("callsign")]
        public string Callsign { get; set; }

        /// <summary>
        /// DSN number for this element (if applicable)
        /// </summary>
        [XmlAttribute("dsn")]
        public string Dsn { get; set; }

        /// <summary>
        /// e-mail address for this element (if applicable)
        /// </summary>
        [XmlAttribute("email")]
        public string Email { get; set; }

        /// <summary>
        /// The frequency (in MHz) on which the unit may be contacted via voice.
        /// </summary>
        [XmlAttribute("freq")]
        public decimal? Freq { get; set; }

        /// <summary>
        /// DNS-resolvable host name
        /// </summary>
        [XmlAttribute("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Amplifies the radio frequency information provided.  Contains the modulation type
        /// for the communication.  (Coding tbd, should cover complex modulations such as
        /// SINCGARS hopping, csma, etc...) am|fm
        /// </summary>
        [XmlAttribute("modulation")]
        public string Modulation { get; set; }

        /// <summary>
        /// Phone number for this element (if applicable)
        /// </summary>
        [XmlAttribute("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Version tag for this sub schema.  Neccessary to ensure upward compatibility with future revisions.
        /// </summary>
        [XmlAttribute("version")]
        public decimal Version { get; set; }

        /// <summary>
        /// If the version is specified
        /// </summary>
        [XmlIgnore]
        public bool VersionSpecified { get; set; }
    }
}
