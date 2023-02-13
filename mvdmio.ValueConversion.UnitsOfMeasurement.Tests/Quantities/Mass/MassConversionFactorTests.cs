using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Mass;

[TestClass]
public class MassConversionFactorTests
{
    [DataTestMethod]
    [DataRow("Gram", 1)]
    [DataRow("Kilogram", 0.001)]
    [DataRow("Kilopound", 2.20462262184878E-06)]
    [DataRow("Kilotonne", 1E-09)]
    [DataRow("Microgram", 1000000)]
    [DataRow("Milligram", 1000)]
    [DataRow("Ounce", 0.0352739619806867)]
    [DataRow("Pound", 0.00220462262184878)]
    [DataRow("Tonne", 1E-06)]
    public void GramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Gram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 1000)]
    [DataRow("Kilogram", 1)]
    [DataRow("Kilopound", 0.00220462262184878)]
    [DataRow("Kilotonne", 1E-06)]
    [DataRow("Microgram", 1000000000)]
    [DataRow("Milligram", 1000000)]
    [DataRow("Ounce", 35.2739619806867)]
    [DataRow("Pound", 2.20462262184878)]
    [DataRow("Tonne", 0.001)]
    public void KilogramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilogram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 453592.37)]
    [DataRow("Kilogram", 453.59237)]
    [DataRow("Kilopound", 1)]
    [DataRow("Kilotonne", 0.00045359237)]
    [DataRow("Microgram", 453592370000)]
    [DataRow("Milligram", 453592370)]
    [DataRow("Ounce", 16000.0000141096)]
    [DataRow("Pound", 1000)]
    [DataRow("Tonne", 0.45359237)]
    public void KilopoundConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilopound", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 1000000000)]
    [DataRow("Kilogram", 1000000)]
    [DataRow("Kilopound", 2204.62262184878)]
    [DataRow("Kilotonne", 1)]
    [DataRow("Microgram", 1E+15)]
    [DataRow("Milligram", 1000000000000)]
    [DataRow("Ounce", 35273961.9806867)]
    [DataRow("Pound", 2204622.62184878)]
    [DataRow("Tonne", 1000)]
    public void KilotonneConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilotonne", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 1E-06)]
    [DataRow("Kilogram", 1E-09)]
    [DataRow("Kilopound", 2.20462262184878E-12)]
    [DataRow("Kilotonne", 1E-15)]
    [DataRow("Microgram", 1)]
    [DataRow("Milligram", 0.001)]
    [DataRow("Ounce", 3.52739619806867E-08)]
    [DataRow("Pound", 2.20462262184878E-09)]
    [DataRow("Tonne", 1E-12)]
    public void MicrogramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Microgram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 0.001)]
    [DataRow("Kilogram", 1E-06)]
    [DataRow("Kilopound", 2.20462262184878E-09)]
    [DataRow("Kilotonne", 1E-12)]
    [DataRow("Microgram", 1000)]
    [DataRow("Milligram", 1)]
    [DataRow("Ounce", 3.52739619806867E-05)]
    [DataRow("Pound", 2.20462262184878E-06)]
    [DataRow("Tonne", 1E-09)]
    public void MilligramConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Milligram", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 28.3495231)]
    [DataRow("Kilogram", 0.0283495231)]
    [DataRow("Kilopound", 6.24999999448844E-05)]
    [DataRow("Kilotonne", 2.83495231E-08)]
    [DataRow("Microgram", 28349523.1)]
    [DataRow("Milligram", 28349.5231)]
    [DataRow("Ounce", 1)]
    [DataRow("Pound", 0.0624999999448844)]
    [DataRow("Tonne", 2.83495231E-05)]
    public void OunceConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Ounce", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 453.59237)]
    [DataRow("Kilogram", 0.45359237)]
    [DataRow("Kilopound", 0.001)]
    [DataRow("Kilotonne", 4.5359237E-07)]
    [DataRow("Microgram", 453592370)]
    [DataRow("Milligram", 453592.37)]
    [DataRow("Ounce", 16.0000000141096)]
    [DataRow("Pound", 1)]
    [DataRow("Tonne", 0.00045359237)]
    public void PoundConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Pound", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Gram", 1000000)]
    [DataRow("Kilogram", 1000)]
    [DataRow("Kilopound", 2.20462262184878)]
    [DataRow("Kilotonne", 0.001)]
    [DataRow("Microgram", 1000000000000)]
    [DataRow("Milligram", 1000000000)]
    [DataRow("Ounce", 35273.9619806867)]
    [DataRow("Pound", 2204.62262184878)]
    [DataRow("Tonne", 1)]
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