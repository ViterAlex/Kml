using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Kml
{

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    [XmlRoot(Namespace = "http://www.opengis.net/kml/2.2", IsNullable = true, ElementName = "kml", DataType = "string")]
    public class Kml
    {
        [XmlElement]
        public Document Document { get; set; }
    }
}
