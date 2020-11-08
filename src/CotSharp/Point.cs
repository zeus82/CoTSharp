using System.Xml.Serialization;

namespace CotSharp
{
    /// <summary>
    /// Represents a point on the earth
    /// </summary>
    [XmlType(TypeName = "point")]
    public partial class Point
    {
        /// <summary>
        ///Circular Error around point defined by lat and lon fields in meters. Although
        ///named ce, this field is intended to define a circular area around the event point, not
        ///necessarily an error (e.g. Describing a reservation area is not an
        ///"error").  If it is appropriate for the "ce" field to represent
        ///an error value (e.g. event describes laser designated target), the
        ///value will represent the one sigma point for a zero mean
        ///normal (Guassian) distribution.
        /// </summary>
        [XmlAttribute("ce")]
        public decimal Ce { get; set; }

        /// <summary>
        /// HAE acronym for Height above Ellipsoid based on WGS-84 ellipsoid (measured in meters).
        /// </summary>
        [XmlAttribute("hae")]
        public decimal Hae { get; set; }

        /// <summary>
        /// Latitude based on WGS-84 ellipsoid in signed degree-decimal format (e.g. -33.350000). Range -90 -> +90.
        /// </summary>
        [XmlAttribute("lat")]
        public decimal Lat { get; set; }

        /// <summary>
        ///Linear Error in meters associated with the HAE field. Although named le, this
        ///field is intended to define a height range about the event point, not
        ///necessarily an error. This field, along with the ce field allow for the
        ///definition of a cylindrical volume about the point. If it is appropriate
        ///for the "le" field to represent an error (e.g. event describes laser
        ///designated target), the value will represent the one sigma point for
        ///a zero mean normal (Guassian) distribution.
        /// </summary>
        [XmlAttribute("le")]
        public decimal Le { get; set; }

        /// <summary>
        /// Longitude based on WGS-84 ellipsoid in signed degree-decimal format (e.g. 44.383333). Range -180 -> +180.
        /// </summary>
        [XmlAttribute("lon")]
        public decimal Lon { get; set; }
    }
}
