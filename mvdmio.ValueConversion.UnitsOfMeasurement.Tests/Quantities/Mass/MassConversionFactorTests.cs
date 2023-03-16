using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Mass;


public class MassConversionFactorTests
{
    [Theory]
    [InlineData("Gram", 1)]
    [InlineData("Kilogram", 0.001)]
    [InlineData("Kilopound", 2.20462262184878E-06)]
    [InlineData("Kilotonne", 1E-09)]
    [InlineData("Microgram", 1000000)]
    [InlineData("Milligram", 1000)]
    [InlineData("Ounce", 0.0352739619806867)]
    [InlineData("Pound", 0.00220462262184878)]
    [InlineData("Tonne", 1E-06)]
    public void GramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Gram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 1000)]
    [InlineData("Kilogram", 1)]
    [InlineData("Kilopound", 0.00220462262184878)]
    [InlineData("Kilotonne", 1E-06)]
    [InlineData("Microgram", 1000000000)]
    [InlineData("Milligram", 1000000)]
    [InlineData("Ounce", 35.2739619806867)]
    [InlineData("Pound", 2.20462262184878)]
    [InlineData("Tonne", 0.001)]
    public void KilogramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilogram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 453592.37)]
    [InlineData("Kilogram", 453.59237)]
    [InlineData("Kilopound", 1)]
    [InlineData("Kilotonne", 0.00045359237)]
    [InlineData("Microgram", 453592370000)]
    [InlineData("Milligram", 453592370)]
    [InlineData("Ounce", 16000.0000141096)]
    [InlineData("Pound", 1000)]
    [InlineData("Tonne", 0.45359237)]
    public void KilopoundConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilopound", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 1000000000)]
    [InlineData("Kilogram", 1000000)]
    [InlineData("Kilopound", 2204.62262184878)]
    [InlineData("Kilotonne", 1)]
    [InlineData("Microgram", 1E+15)]
    [InlineData("Milligram", 1000000000000)]
    [InlineData("Ounce", 35273961.9806867)]
    [InlineData("Pound", 2204622.62184878)]
    [InlineData("Tonne", 1000)]
    public void KilotonneConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilotonne", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 1E-06)]
    [InlineData("Kilogram", 1E-09)]
    [InlineData("Kilopound", 2.20462262184878E-12)]
    [InlineData("Kilotonne", 1E-15)]
    [InlineData("Microgram", 1)]
    [InlineData("Milligram", 0.001)]
    [InlineData("Ounce", 3.52739619806867E-08)]
    [InlineData("Pound", 2.20462262184878E-09)]
    [InlineData("Tonne", 1E-12)]
    public void MicrogramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Microgram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 0.001)]
    [InlineData("Kilogram", 1E-06)]
    [InlineData("Kilopound", 2.20462262184878E-09)]
    [InlineData("Kilotonne", 1E-12)]
    [InlineData("Microgram", 1000)]
    [InlineData("Milligram", 1)]
    [InlineData("Ounce", 3.52739619806867E-05)]
    [InlineData("Pound", 2.20462262184878E-06)]
    [InlineData("Tonne", 1E-09)]
    public void MilligramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Milligram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 28.3495231)]
    [InlineData("Kilogram", 0.0283495231)]
    [InlineData("Kilopound", 6.24999999448844E-05)]
    [InlineData("Kilotonne", 2.83495231E-08)]
    [InlineData("Microgram", 28349523.1)]
    [InlineData("Milligram", 28349.5231)]
    [InlineData("Ounce", 1)]
    [InlineData("Pound", 0.0624999999448844)]
    [InlineData("Tonne", 2.83495231E-05)]
    public void OunceConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Ounce", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 453.59237)]
    [InlineData("Kilogram", 0.45359237)]
    [InlineData("Kilopound", 0.001)]
    [InlineData("Kilotonne", 4.5359237E-07)]
    [InlineData("Microgram", 453592370)]
    [InlineData("Milligram", 453592.37)]
    [InlineData("Ounce", 16.0000000141096)]
    [InlineData("Pound", 1)]
    [InlineData("Tonne", 0.00045359237)]
    public void PoundConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Pound", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Gram", 1000000)]
    [InlineData("Kilogram", 1000)]
    [InlineData("Kilopound", 2.20462262184878)]
    [InlineData("Kilotonne", 0.001)]
    [InlineData("Microgram", 1000000000000)]
    [InlineData("Milligram", 1000000000)]
    [InlineData("Ounce", 35273.9619806867)]
    [InlineData("Pound", 2204.62262184878)]
    [InlineData("Tonne", 1)]
    public void TonneConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Tonne", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    private static double GetConversionFactor(string from, string to)
    {
        var quantityValue = Quantity.Known.Mass().CreateValue(value: 1, from);
        var convertedValue = Quantity.Known.Mass().Convert(quantityValue, to);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}