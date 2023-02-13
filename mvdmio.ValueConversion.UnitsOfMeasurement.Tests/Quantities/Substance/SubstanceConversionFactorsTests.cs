using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Substance;

[TestClass]
public class SubstanceConversionFactorsTests
{
    [DataTestMethod]
    [DataRow("Mole", 1)]
    [DataRow("Micromole", 1000000)]
    [DataRow("Millimole", 1000)]
    public void MoleConversions(string type, double expected)
    {
        var conversionFactor = GetConversionFactor("Mole", type);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Mole", 0.001)]
    [DataRow("Micromole", 1000)]
    [DataRow("Millimole", 1)]
    public void MillimoleConversions(string type, double expected)
    {
        var conversionFactor = GetConversionFactor("Millimole", type);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Mole", 0.000001)]
    [DataRow("Micromole", 1)]
    [DataRow("Millimole", 0.001)]
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