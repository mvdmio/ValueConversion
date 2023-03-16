using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Volume;


public class VolumeConversionImplementationCheck
{
    [Fact]
    public void ShouldConvertAllVolumeCombinationsIntoAllOtherVolumeCombinations()
    {
        foreach (var fromUnit in Quantity.Known.Volume().GetUnits())
        {
            var fromValue = Quantity.Known.Volume().CreateValue(DateTime.Now, value: 1, fromUnit);

            foreach (var toUnit in Quantity.Known.Volume().GetUnits())
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