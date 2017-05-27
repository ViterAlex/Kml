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

        /// <summary>
        /// Широта
        /// </summary>
        [XmlIgnore]
        public double Lat
        {
            get
            {
                return !IsGoodCoords() ? double.NaN : double.Parse(Coordinates.Split(',')[1], CultureInfo.InvariantCulture);
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

        /// <summary>
        /// Долгота
        /// </summary>
        [XmlIgnore]
        public double Lon
        {
            get
            {
                return !IsGoodCoords() ? double.NaN : double.Parse(Coordinates.Split(',')[0], CultureInfo.InvariantCulture);
            }
        }

        public override string ToString()
        {
            return $"{string.Format(new DegreeFormatter(), "{0}", Lon)} {string.Format(new DegreeFormatter(), "{0}", Lat)}";
        }

        public string ToString(string type)
        {
            switch (type)
            {
                case "lat":
                    return string.Format(new DegreeFormatter(), "{0:NS}", Lat);
                case "lon":
                    return string.Format(new DegreeFormatter(), "{0:WE}", Lon);
                default:
                    return ToString();
            }
        }
    }
}