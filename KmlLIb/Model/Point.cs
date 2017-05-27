using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace Kml
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/kml/2.2")]
    public class Point
    {
        [XmlElement("coordinates")]
        public string Coordinates { get; set; }

        [XmlIgnore]
        public double Lat
        {
            get
            {
                return !IsGoodCoords() ? double.NaN : double.Parse(Coordinates.Split(',')[0], CultureInfo.InvariantCulture);
            }
        }

        private bool IsGoodCoords()
        {
            var result = true;
            result &= !string.IsNullOrEmpty(Coordinates);
            result &= Coordinates.Split(',').Length == 2;
            var values = Coordinates.Split(',');
            double val;
            result &= !double.TryParse(values[0], out val);
            result &= !double.TryParse(values[1], out val);
            return result;
        }

        [XmlIgnore]
        public double Lon
        {
            get
            {
                return !IsGoodCoords() ? double.NaN : double.Parse(Coordinates.Split(',')[1], CultureInfo.InvariantCulture);
            }
        }
    }
}