﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Diagnostics;
using System.Xml.Serialization;

namespace CotSharp
{

    [DebuggerStepThrough]
    [XmlRoot("spatial")]
    [XmlType(TypeName = "spatial")]
    public partial class Spatial
    {

        private SpatialAttitude attitudeField;

        private spatialSpin spinField;

        private decimal versionField;

        private bool versionFieldSpecified;

        /// <remarks/>
        public SpatialAttitude attitude
        {
            get
            {
                return this.attitudeField;
            }
            set
            {
                this.attitudeField = value;
            }
        }

        /// <remarks/>
        public spatialSpin spin
        {
            get
            {
                return this.spinField;
            }
            set
            {
                this.spinField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool versionSpecified
        {
            get
            {
                return this.versionFieldSpecified;
            }
            set
            {
                this.versionFieldSpecified = value;
            }
        }
    }

}