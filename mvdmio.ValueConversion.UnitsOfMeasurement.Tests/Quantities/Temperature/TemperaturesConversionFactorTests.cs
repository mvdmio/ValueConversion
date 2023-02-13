using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Temperature;

[TestClass]
public class TemperaturesConversionFactorTests
{
    [DataTestMethod]
    [DataRow(1, "DegreeFahrenheit", 1)]
    [DataRow(10, "DegreeFahrenheit", 10)]
    [DataRow(-1, "DegreeFahrenheit", -1)]
    [DataRow(-10, "DegreeFahrenheit", -10)]
    [DataRow(1, "DegreeCelsius", -17.2222222222222)]
    [DataRow(10, "DegreeCelsius", -12.2222222222222)]
    [DataRow(-1, "DegreeCelsius", -18.3333333333333)]
    [DataRow(-10, "DegreeCelsius", -23.3333333333333)]
    [DataRow(1, "Kelvin", 255.927777777778)]
    [DataRow(10, "Kelvin", 260.927777777778)]
    [DataRow(-1, "Kelvin", 254.816666666667)]
    [DataRow(-10, "Kelvin", 249.816666666667)]
        
    public void DegreeFahrenheitConversions(double value, string to, double expected)
    {
        var convertedTemperature = GetConvertedValue(value, "DegreeFahrenheit", to);
        AssertExtensions.AreWithinPercentTolerance(expected, convertedTemperature);
    }

    [DataTestMethod]
    [DataRow(1, "DegreeFahrenheit", 33.8)]
    [DataRow(10, "DegreeFahrenheit", 50)]
    [DataRow(-1, "DegreeFahrenheit", 30.2)]
    [DataRow(-10, "DegreeFahrenheit", 14)]
    [DataRow(1, "DegreeCelsius", 1)]
    [DataRow(10, "DegreeCelsius", 10)]
    [DataRow(-1, "DegreeCelsius", -1)]
    [DataRow(-10, "DegreeCelsius", -10)]
    [DataRow(1, "Kelvin", 274.15)]
    [DataRow(10, "Kelvin", 283.15)]
    [DataRow(-1, "Kelvin", 272.15)]
    [DataRow(-10, "Kelvin", 263.15)]
    public void DegreeCelsiusConversions(double value, string to, double expected)
    {
        var convertedTemperature = GetConvertedValue(value, "DegreeCelsius", to);
        AssertExtensions.AreWithinPercentTolerance(expected, convertedTemperature);
    }

    [DataTestMethod]
    [DataRow(1, "DegreeFahrenheit", -457.87)]
    [DataRow(10, "DegreeFahrenheit", -441.67)]
    [DataRow(100, "DegreeFahrenheit", -279.67)]
    [DataRow(1000, "DegreeFahrenheit", 1340.33)]
    [DataRow(1, "DegreeCelsius", -272.15)]
    [DataRow(10, "DegreeCelsius", -263.15)]
    [DataRow(100, "DegreeCelsius", -173.15)]
    [DataRow(1000, "DegreeCelsius", 726.85)]
    [DataRow(1, "Kelvin", 1)]
    [DataRow(10, "Kelvin", 10)]
    [DataRow(100, "Kelvin", 100)]
    [DataRow(1000, "Kelvin", 1000)]
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