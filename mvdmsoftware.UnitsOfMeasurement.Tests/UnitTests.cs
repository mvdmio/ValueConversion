using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ShouldGetUnit()
        {
            var unit = Unit.GetUnit(Quantity.Temperature.GetUnit(TemperatureType.DegreeCelsius).Identifier);

            Assert.AreEqual("DegreeCelsius", unit.Identifier);
        }

        [TestMethod]
        public void ShouldGetRateUnit()
        {
            var distanceQuantity = Quantity.Distance;
            var durationQuantity = Quantity.Duration;
            var quantity = Quantity.Rate(distanceQuantity, durationQuantity);
            var unit = Unit.GetUnit(quantity.GetUnit(distanceQuantity.GetUnit(DistanceType.Kilometer), durationQuantity.GetUnit(DurationType.Hour)).Identifier);

            Assert.AreEqual("Kilometer/Hour", unit.Identifier);
        }

        [TestMethod]
        public void ShouldGetProductUnit()
        {
            var distanceQuantity = Quantity.Distance;
            var durationQuantity = Quantity.Duration;
            var quantity = Quantity.Product(distanceQuantity, durationQuantity);
            var unit = Unit.GetUnit(quantity.GetUnit(distanceQuantity.GetUnit(DistanceType.Kilometer), durationQuantity.GetUnit(DurationType.Hour)).Identifier);

            Assert.AreEqual("Kilometer*Hour", unit.Identifier);
        }
    }
}