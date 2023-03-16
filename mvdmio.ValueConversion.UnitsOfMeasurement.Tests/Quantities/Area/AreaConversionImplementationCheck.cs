using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Area;


public class AreaConversionImplementationCheck : ConversionImplementationCheckBase
{
    [Fact]
    public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
    {
        TestQuantityConversionImplementation(Quantity.Known.Area());
    }
}