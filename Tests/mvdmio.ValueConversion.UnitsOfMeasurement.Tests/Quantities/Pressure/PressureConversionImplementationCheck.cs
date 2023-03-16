using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Pressure;


public class PressureConversionImplementationCheck
{
    [Fact]
    public void ShouldConvertAllPressureCombinationsIntoAllOtherPressureCombinations()
    {
        foreach (var fromUnit in Quantity.Known.Pressure().GetUnits())
        {
            var fromValue = Quantity.Known.Pressure().CreateValue(DateTime.Now, value: 1, fromUnit);

            foreach (var toUnit in Quantity.Known.Pressure().GetUnits())
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