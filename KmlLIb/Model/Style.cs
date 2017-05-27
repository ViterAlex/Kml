using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Kml {
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public  class Style
    {
        /// <remarks/>
        public LineStyle LineStyle { get; set; }

        /// <remarks/>
        public PolyStyle PolyStyle { get; set; }

        /// <remarks/>
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}