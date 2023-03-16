using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Distance;


public class DistanceConversionImplementationCheck
{
    [Fact]
    public void ShouldConvertAllDistanceCombinationsIntoAllOtherDistanceCombinations()
    {
        foreach (var fromDistanceUnit in Quantity.Known.Distance().GetUnits())
        {
            var fromValue = Quantity.Known.Distance().CreateValue(DateTime.Now, value: 1, fromDistanceUnit);

            foreach (var toDistanceUnit in Quantity.Known.Distance().GetUnits())
            {
                var toValue = fromValue.As(toDistanceUnit);

                Assert.True(fromValue.IsEqualTo(toValue), $"Conversion from {fromDistanceUnit.Identifier} to {toDistanceUnit.Identifier} did not result in equal quantities.");

                var conversionFactor = toValue.GetValue();
                var expected = fromValue.GetValue() * conversionFactor;
                var actual = toValue.GetValue();

                Assert.Equal(expected, actual);
            }
        }
    }
}