﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CotSharp
{
    /// <summary>
    /// This is a Cursor On Target sub-schema for abstract image product metadata. It is 
    /// specifically limited to geographically located (though not necessarily geographically 
    /// registered) image products.  It is not intended to contain all the meta data 
    /// typically found in the NITF header associated with such images, but rather provides 
    /// sufficient "hints" about the ISR product to facilitate collection queuing and ipl 
    /// searching.  Full meta data will reside in the NITF header or other IPL-specific 
    /// schemas.  This sub schema borrows from the NITF standard.  Note, also, that this 
    /// subschema presumes is is contained within a CoT base element which provides 
    /// information about center poiint, etc.  Similarly, the CoT_shape schema can be used to 
    /// delimit the bounds of the image.  Furthermore, this element may conatin a base64 
    /// encoded image file.  In this case, the 'mime' attribute should indicate the image type.
    /// </summary>
    [DebuggerStepThrough]
    [XmlRoot("image")]
    [XmlType(TypeName = "image")]
    public partial class Image
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any { get; set; }

        /// <summary>
        /// Image type, drawn from NITF specification.  E.g., SL - side-looking radar, TI - thermal 
        /// infrared, FL - forward looking infrared, RD - radar, EO - electro-optical, OP - optical, 
        /// HR - high resolution radar, HS - hyperspectral, CP - color frame photography, BP - 
        /// black/white frame photography, SAR - synthetic aperture radar, SARIQ - SAR radio hologram, 
        /// IR - infrared, MS - multispectral, ...
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (DEPRECATED) True if this image has been properly geo-registered
        /// </summary>
        [Obsolete]
        [XmlAttribute("georegistered")]
        public bool Georegistered { get; set; }

        [XmlIgnore]
        public bool GeoregisteredSpecified { get; set; }

        /// <summary>
        /// (REVISED) The source of this image, specifically the CoT UID of the producer. (The intention
        /// is to indicate equipment type used to collect imagery, not organization owning image.)
        /// </summary>
        [XmlAttribute("source")]
        public string Source { get; set; }

        /// <summary>
        /// Image product resolution (expressed in meters per pixel)
        /// </summary>
        [XmlAttribute("resolution")]
        public decimal Resolution { get; set; }

        /// <remarks/>
        [XmlIgnore]
        public bool ResolutionSpecified { get; set; }

        /// <summary>
        /// URL link to image if the image is not embedded
        /// </summary>
        [XmlAttribute("url", DataType = "anyURI")]
        public string Url { get; set; }

        /// <summary>
        /// (REVISED) Approximate angular field of view (degrees)
        /// </summary>
        [XmlAttribute("fov")]
        public decimal Fov { get; set; }

        [XmlIgnore]
        public bool FovSpecified { get; set; }

        /// <summary>
        /// Version tag for this sub schema.  Neccessary to ensure upward compatibility with future revisions.
        /// </summary>
        [XmlAttribute("version")]
        public decimal Version { get; set; }

        [XmlIgnore]
        public bool VersionSpecified { get; set; }

        /// <summary>
        /// Approximate image file size (bytes)
        /// </summary>
        [XmlAttribute("size", DataType = "nonNegativeInteger")]
        public string Size { get; set; }

        /// <summary>
        /// (DEPRECATED) True if image analysis (e.g., markup) is available
        /// </summary>
        [Obsolete]
        [XmlAttribute("analysis")]
        public bool Analysis { get; set; }

        [XmlIgnore]
        public bool AnalysisSpecified { get; set; }

        /// <summary>
        /// If an in-lined image is contained in this entity, then this attribute describes the mime type of that 
        /// image.  The actual image data will be base64 encoded. 
        /// See http://www.w3schools.com/media/media_mimeref.asp for list of common mime types.
        /// </summary>
        [XmlAttribute("mime")]
        public string Mime { get; set; }

        /// <summary>
        /// The width of the image (in pixels)
        /// </summary>
        [XmlAttribute("width", DataType = "nonNegativeInteger")]
        public string Width { get; set; }

        /// <summary>
        /// The height of the image (in pixels)
        /// </summary>
        [XmlAttribute("height", DataType = "nonNegativeInteger")]
        public string Height { get; set; }

        /// <summary>
        /// (NEW) The reason this image was originally produced (BHA, BDA, ISR, ...)  Coding is TBD but will reflect 
        /// the CoT type coding structure.  E.g., a-d-b Assesment-Damage-Bomb, etc...
        /// </summary>
        [XmlAttribute("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Number of data bands within the image. For example, an RGB image as 3 bands (Red, Green, Blue bands/channels)
        /// </summary>
        [XmlAttribute("bands", DataType = "nonNegativeInteger")]
        public string Bands { get; set; }

        /// <summary>
        /// Used only if the attribute 'mime' references a container type (e.g., image/x-nitf21).  In this case, 'mimecsv' 
        /// holds a list of Comma Separated Values to supplement the MIME type in the mime field.  Nominally, the values 
        /// in 'mimecsv' wil lbe mime types of the elements in the composite image.  For example, if 'mime' 'image/x-nitf21', 
        /// then 'mimecsv' may hold 'image/jpeg', 'image/jpeg2000', or 'image/x-eagleeye'.
        /// </summary>
        [XmlAttribute("mimecsv")]
        public string Mimecsv { get; set; }

        /// <summary>
        /// Indicates the orientation of 'north' (true) on the image.  This is an angular measure in degrees.  Zero indicates 
        /// that the north arrow would point up (towards 12 o'clock) on the image, 90 indicates that the the north arrow 
        /// would point right (3 o'clock).
        /// </summary>
        [XmlAttribute("north")]
        public decimal North { get; set; }

        /// <remarks/>
        [XmlIgnore]
        public bool NorthSpecified { get; set; }

        /// <summary>
        /// This expresses how the tradeoff between image quality and compression were made for this image.  This is usually a 
        /// 'relative' quality measure, an unsigned floating point value between 0.0 (highest compression) and 1.0 (highest 
        /// quality). Implementers should attempt to map this scalar value to an approximate linear progression of visual quality 
        /// as determined on a typical sample image.  If the field's value carries an explicit sign (+/-) including +0 or -0, it 
        /// represents the exact value expressed in a range appropriate to the compression type expressed in 'mime' or 'mimecsv'.  
        /// For example,  with 'image/x-eagleeye' the EagleEye clip setting, the quality setting may range from -4096.0 to +4096.0.
        /// </summary>
        [XmlAttribute]
        public string quality { get; set; }
    }

}