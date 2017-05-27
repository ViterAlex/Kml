using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kml.Tests
{
    [TestClass()]
    public class ReaderTests
    {
        private const string COORD = "59.6688973006233,55.1764803603797";
        private Kml _kml;

        [TestMethod]
        public void Read_NotNull()
        {
            _kml = Reader.Read<Kml>("layer.kml");
            Assert.IsNotNull(_kml);
        }

        [TestMethod]
        public void Kml_Point_Lat_IsNotDoubleNaN()
        {
            var pt = new Point
            {
                Coordinates = COORD
            };
            Assert.AreEqual(59.6688973006233, pt.Lat);
        }[TestMethod]
        public void Kml_Point_Lon_IsNotDoubleNaN()
        {
            var pt = new Point
            {
                Coordinates = COORD
            };
            Assert.AreEqual(55.1764803603797, pt.Lon);
        }
    }
}