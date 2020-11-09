using System.Xml.Serialization;

[XmlRoot("contact")]
[XmlType(TypeName = "contact")]
public partial class Contact
{
    private System.Xml.XmlElement[] anyField;

    private string callsignField;

    private string dsnField;
    private string emailField;
    private decimal freqField;

    private bool freqFieldSpecified;
    private string hostnameField;
    private string modulationField;
    private string phoneField;
    private decimal versionField;

    private bool versionFieldSpecified;

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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string callsign
    {
        get
        {
            return this.callsignField;
        }
        set
        {
            this.callsignField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string dsn
    {
        get
        {
            return this.dsnField;
        }
        set
        {
            this.dsnField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string email
    {
        get
        {
            return this.emailField;
        }
        set
        {
            this.emailField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal freq
    {
        get
        {
            return this.freqField;
        }
        set
        {
            this.freqField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool freqSpecified
    {
        get
        {
            return this.freqFieldSpecified;
        }
        set
        {
            this.freqFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hostname
    {
        get
        {
            return this.hostnameField;
        }
        set
        {
            this.hostnameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string modulation
    {
        get
        {
            return this.modulationField;
        }
        set
        {
            this.modulationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string phone
    {
        get
        {
            return this.phoneField;
        }
        set
        {
            this.phoneField = value;
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
