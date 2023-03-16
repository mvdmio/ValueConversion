using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Angle;


public class AngleConversionImplementationCheck : ConversionImplementationCheckBase
{
    [Fact]
    public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
    {
        TestQuantityConversionImplementation(Quantity.Known.Angle());
    }
}