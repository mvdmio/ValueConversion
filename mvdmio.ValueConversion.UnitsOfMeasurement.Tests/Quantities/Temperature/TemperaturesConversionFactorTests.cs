using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Temperature;


public class TemperaturesConversionFactorTests
{
    [Theory]
    [InlineData(1, "DegreeFahrenheit", 1)]
    [InlineData(10, "DegreeFahrenheit", 10)]
    [InlineData(-1, "DegreeFahrenheit", -1)]
    [InlineData(-10, "DegreeFahrenheit", -10)]
    [InlineData(1, "DegreeCelsius", -17.2222222222222)]
    [InlineData(10, "DegreeCelsius", -12.2222222222222)]
    [InlineData(-1, "DegreeCelsius", -18.3333333333333)]
    [InlineData(-10, "DegreeCelsius", -23.3333333333333)]
    [InlineData(1, "Kelvin", 255.927777777778)]
    [InlineData(10, "Kelvin", 260.927777777778)]
    [InlineData(-1, "Kelvin", 254.816666666667)]
    [InlineData(-10, "Kelvin", 249.816666666667)]
        
    public void DegreeFahrenheitConversions(double value, string to, double expected)
    {
        var convertedTemperature = GetConvertedValue(value, "DegreeFahrenheit", to);
        AssertExtensions.AreWithinPercentTolerance(expected, convertedTemperature);
    }

    [Theory]
    [InlineData(1, "DegreeFahrenheit", 33.8)]
    [InlineData(10, "DegreeFahrenheit", 50)]
    [InlineData(-1, "DegreeFahrenheit", 30.2)]
    [InlineData(-10, "DegreeFahrenheit", 14)]
    [InlineData(1, "DegreeCelsius", 1)]
    [InlineData(10, "DegreeCelsius", 10)]
    [InlineData(-1, "DegreeCelsius", -1)]
    [InlineData(-10, "DegreeCelsius", -10)]
    [InlineData(1, "Kelvin", 274.15)]
    [InlineData(10, "Kelvin", 283.15)]
    [InlineData(-1, "Kelvin", 272.15)]
    [InlineData(-10, "Kelvin", 263.15)]
    public void DegreeCelsiusConversions(double value, string to, double expected)
    {
        var convertedTemperature = GetConvertedValue(value, "DegreeCelsius", to);
        AssertExtensions.AreWithinPercentTolerance(expected, convertedTemperature);
    }

    [Theory]
    [InlineData(1, "DegreeFahrenheit", -457.87)]
    [InlineData(10, "DegreeFahrenheit", -441.67)]
    [InlineData(100, "DegreeFahrenheit", -279.67)]
    [InlineData(1000, "DegreeFahrenheit", 1340.33)]
    [InlineData(1, "DegreeCelsius", -272.15)]
    [InlineData(10, "DegreeCelsius", -263.15)]
    [InlineData(100, "DegreeCelsius", -173.15)]
    [InlineData(1000, "DegreeCelsius", 726.85)]
    [InlineData(1, "Kelvin", 1)]
    [InlineData(10, "Kelvin", 10)]
    [InlineData(100, "Kelvin", 100)]
    [InlineData(1000, "Kelvin", 1000)]
    public void KelvinConversions(double value, string to, double expected)
    {
        var convertedTemperature = GetConvertedValue(value, "Kelvin", to);
        AssertExtensions.AreWithinPercentTolerance(expected, convertedTemperature);
    }

    private static double GetConvertedValue(double value, string from, string to)
    {
        var quantityValue = Quantity.Known.Temperature().CreateValue(value, from);
        var convertedValue = Quantity.Known.Temperature().Convert(quantityValue, to);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}