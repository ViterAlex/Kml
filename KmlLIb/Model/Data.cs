using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Kml {
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public class Data
    {
        [XmlElement("value")]
        public DataValue Value { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}