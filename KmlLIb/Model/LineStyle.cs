using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace Kml
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public class LineStyle
    {
        [XmlElement("color")]
        public string ColorString { get; set; }
        [XmlIgnore]
        public Color Color
        {
            get
            {
                var cc = new ColorConverter();
                var color = cc.ConvertFromString($"#{ColorString}");
                if (color != null)
                    return (Color)color;
                return Color.Transparent;
            }
        }

        /// <remarks/>
        [XmlElement("width")]
        public byte Width { get; set; }
    }
}