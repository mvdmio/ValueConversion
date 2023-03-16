using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Duration;


public class DurationConversionImplementationCheck
{
    [Fact]
    public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
    {
        foreach (var fromUnit in Quantity.Known.Area().GetUnits())
        {
            var fromValue = Quantity.Known.Area().CreateValue(DateTime.Now, 1, fromUnit);

            foreach (var toUnit in Quantity.Known.Area().GetUnits())
            {
                var toValue = fromValue.As(toUnit);

                Assert.True(fromValue.IsEqualTo(toValue), $"Conversion from {fromUnit.Identifier} to {toUnit.Identifier} did not result in equal quantities.");

                var conversionFactor = toValue.GetValue();
                var expected = fromValue.GetValue() * conversionFactor;
                var actual = toValue.GetValue();

                Assert.Equal(expected, actual);
            }
        }
    }
}