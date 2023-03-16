using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Bases;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.RadiationTemperatureRatio;


public class RadiationTemperatureRatioTests
{
    [Fact]
    public void ShouldProduceTheCorrectQuantityWhenDeserlializingTheQuantityIdentifier()
    {
        var radiation = Quantity.Rate("Energy", "Area");
        var radiationTemperatureRatio = Quantity.Rate(radiation.Identifier, "Temperature");

        var deserializedRadiationTemperatureRatio = Quantity.Of(radiationTemperatureRatio.Identifier) as RateCombinedQuantity;

        Assert.Equal(radiationTemperatureRatio.NumeratorQuantity.Identifier, deserializedRadiationTemperatureRatio.NumeratorQuantity.Identifier);
        Assert.Equal(radiationTemperatureRatio.DenominatorQuantity.Identifier, deserializedRadiationTemperatureRatio.DenominatorQuantity.Identifier);
    }
}