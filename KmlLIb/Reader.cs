using System.IO;
using System.Xml.Serialization;

namespace Kml
{
    public static class Reader
    {
        public static T Read<T>(string path)
        {
            using (var stream = new StreamReader(path))
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                return (T)xmlserializer.Deserialize(stream);
            }
        }
    }
}
