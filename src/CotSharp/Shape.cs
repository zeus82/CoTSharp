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
    [XmlRoot("shape")]
    [XmlType(TypeName = "shape")]
    public partial class Shape
    {

        private shapeEllipse ellipseField;

        private shapePolyline polylineField;

        private ShapeDxf dxfField;

        private decimal versionField;

        private bool versionFieldSpecified;

        /// <remarks/>
        public shapeEllipse ellipse
        {
            get
            {
                return this.ellipseField;
            }
            set
            {
                this.ellipseField = value;
            }
        }

        /// <remarks/>
        public shapePolyline polyline
        {
            get
            {
                return this.polylineField;
            }
            set
            {
                this.polylineField = value;
            }
        }

        /// <remarks/>
        public ShapeDxf dxf
        {
            get
            {
                return this.dxfField;
            }
            set
            {
                this.dxfField = value;
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