using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Kml {
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public class DataValueImg
    {
        /// <remarks/>
        [XmlAttribute("height")]
        public ushort Height { get; set; }

        /// <remarks/>
        [XmlAttribute("src")]
        public string Source { get; set; }
    }
}