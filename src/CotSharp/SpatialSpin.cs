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
    [XmlRoot("spatialSpin")]
    [XmlType(TypeName = "spatialSpin")]
    public partial class SpatialSpin
    {

        private System.Xml.XmlElement[] anyField;

        private decimal rollField;

        private decimal pitchField;

        private decimal yawField;

        private bool yawFieldSpecified;

        private decimal eRollField;

        private bool eRollFieldSpecified;

        private decimal ePitchField;

        private bool ePitchFieldSpecified;

        private decimal eYawField;

        private bool eYawFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public decimal roll
        {
            get
            {
                return this.rollField;
            }
            set
            {
                this.rollField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal pitch
        {
            get
            {
                return this.pitchField;
            }
            set
            {
                this.pitchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal yaw
        {
            get
            {
                return this.yawField;
            }
            set
            {
                this.yawField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool yawSpecified
        {
            get
            {
                return this.yawFieldSpecified;
            }
            set
            {
                this.yawFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal eRoll
        {
            get
            {
                return this.eRollField;
            }
            set
            {
                this.eRollField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool eRollSpecified
        {
            get
            {
                return this.eRollFieldSpecified;
            }
            set
            {
                this.eRollFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ePitch
        {
            get
            {
                return this.ePitchField;
            }
            set
            {
                this.ePitchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ePitchSpecified
        {
            get
            {
                return this.ePitchFieldSpecified;
            }
            set
            {
                this.ePitchFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal eYaw
        {
            get
            {
                return this.eYawField;
            }
            set
            {
                this.eYawField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool eYawSpecified
        {
            get
            {
                return this.eYawFieldSpecified;
            }
            set
            {
                this.eYawFieldSpecified = value;
            }
        }
    }

}