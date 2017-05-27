using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Kml
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public class DataValue
    {
        [XmlElement("img")]
        public DataValueImg ValueImage { get; set; }

        /// <remarks/>
        [XmlText]
        public string[] Text { get; set; }
    }
}