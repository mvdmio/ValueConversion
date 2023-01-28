using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.RadiationTemperatureRatio
{
    [TestClass]
    public class RadiationTemperatureRatioTests
    {
        [TestMethod]
        public void ShouldProduceTheCorrectQuantityWhenDeserlializingTheQuantityIdentifier()
        {
            var radiation = Quantity.Rate(Quantity.Energy, Quantity.Area);
            var radiationTemperatureRatio = Quantity.Rate(radiation, Quantity.Temperature);

            var deserializedRadiationTemperatureRatio = Quantity.Of(radiationTemperatureRatio.Identifier) as RateCombinedQuantity;

            Assert.AreEqual(radiationTemperatureRatio.NumeratorQuantity.Identifier, deserializedRadiationTemperatureRatio.NumeratorQuantity.Identifier);
            Assert.AreEqual(radiationTemperatureRatio.DenominatorQuantity.Identifier, deserializedRadiationTemperatureRatio.DenominatorQuantity.Identifier);
        }
    }
}
