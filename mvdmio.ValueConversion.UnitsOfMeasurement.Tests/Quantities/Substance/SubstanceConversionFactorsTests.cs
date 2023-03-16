using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Substance;


public class SubstanceConversionFactorsTests
{
    [Theory]
    [InlineData("Mole", 1)]
    [InlineData("Micromole", 1000000)]
    [InlineData("Millimole", 1000)]
    public void MoleConversions(string type, double expected)
    {
        var conversionFactor = GetConversionFactor("Mole", type);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Mole", 0.001)]
    [InlineData("Micromole", 1000)]
    [InlineData("Millimole", 1)]
    public void MillimoleConversions(string type, double expected)
    {
        var conversionFactor = GetConversionFactor("Millimole", type);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Mole", 0.000001)]
    [InlineData("Micromole", 1)]
    [InlineData("Millimole", 0.001)]
    public void MicromoleConversions(string type, double expected)
    {
        var conversionFactor = GetConversionFactor("Micromole", type);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    private static double GetConversionFactor(string from, string to)
    {
        var quantityValue = Quantity.Known.Substance().CreateValue(value: 1, from);
        var convertedValue = Quantity.Known.Substance().Convert(quantityValue, to);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}