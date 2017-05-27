using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Kml {
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public class Document
    {

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("Style")]
        public Style Style { get; set; }

        [XmlElement("Placemark")]
        public List<Placemark> Placemarks { get; set; }
    }
}