using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Temperature;


public class TemperaturesConversionImplementationCheck
{
    [Fact]
    public void ShouldConvertAllVolumeCombinationsIntoAllOtherVolumeCombinations()
    {
        foreach (var fromUnit in Quantity.Known.Temperature().GetUnits())
        {
            var fromValue = Quantity.Known.Temperature().CreateValue(DateTime.Now, value: 1, fromUnit);

            foreach (var toUnit in Quantity.Known.Temperature().GetUnits())
            {
                var toValue = fromValue.As(toUnit);

                Assert.True(fromValue.IsEqualTo(toValue), $"Conversion from {fromUnit} to {toUnit} did not result in equal quantities.");
            }
        }
    }
}