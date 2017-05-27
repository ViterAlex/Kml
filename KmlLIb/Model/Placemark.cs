using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Kml {
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public class Placemark
    {
        [XmlElement("styleUrl")]
        public string StyleUrl { get; set; }

        [XmlArrayItem("Data", IsNullable = false)]
        public List<Data> ExtendedData{ get; set; }

        public Point Point { get; set; }
    }
}