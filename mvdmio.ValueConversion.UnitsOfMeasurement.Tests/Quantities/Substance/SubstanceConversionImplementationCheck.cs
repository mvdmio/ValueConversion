using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Substance;


public class SubstanceConversionImplementationCheck
{
    [Fact]
    public void ShouldConvertAllSubstanceCombinationsIntoAllOtherSubstanceCombinations()
    {
        foreach (var fromUnit in Quantity.Known.Substance().GetUnits())
        {
            var fromValue = Quantity.Known.Substance().CreateValue(DateTime.Now, value: 1, fromUnit);

            foreach (var toUnit in Quantity.Known.Substance().GetUnits())
            {
                var toValue = fromValue.As(toUnit);

                Assert.True(fromValue.IsEqualTo(toValue), $"Conversion from {fromUnit} to {toUnit} did not result in equal quantities.");

                var conversionFactor = toValue.GetValue();
                var expected = fromValue.GetValue() * conversionFactor;
                var actual = toValue.GetValue();

                Assert.Equal(expected, actual);
            }
        }
    }
}