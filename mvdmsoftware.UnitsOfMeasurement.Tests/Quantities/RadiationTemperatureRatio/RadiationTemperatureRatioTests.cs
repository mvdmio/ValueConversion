using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.UnitsOfMeasurement.Bases;
using System.Threading.Tasks;

namespace Ridder.UnitsOfMeasurement.Tests.Quantities.RadiationTemperatureRatio
{
    [TestClass]
    public class RadiationTemperatureRatioTests
    {
        [TestMethod]
        public async Task ShouldProduceTheCorrectQuantityWhenDeserlializingTheQuantityIdentifier()
        {
            var radiation = Quantity.Rate(Quantity.Energy, Quantity.Area);
            var radiationTemperatureRatio = Quantity.Rate(radiation, Quantity.Temperature);

            var deserializedRadiationTemperatureRatio = Quantity.Of(radiationTemperatureRatio.Identifier) as RateCombinedQuantity;

            Assert.AreEqual(radiationTemperatureRatio.NumeratorQuantity.Identifier, deserializedRadiationTemperatureRatio.NumeratorQuantity.Identifier);
            Assert.AreEqual(radiationTemperatureRatio.DenominatorQuantity.Identifier, deserializedRadiationTemperatureRatio.DenominatorQuantity.Identifier);
        }
    }
}
