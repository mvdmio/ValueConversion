using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Distance;

[TestClass]
public class DistanceConversionFactorsTests
{
    [DataTestMethod]
    [DataRow("Centimeter", 1)]
    [DataRow("Feet", 0.0328083989501312)]
    [DataRow("Hectometer", 0.0001)]
    [DataRow("Inch", 0.393700787401575)]
    [DataRow("Kilometer", 1E-05)]
    [DataRow("Meter", 0.01)]
    [DataRow("Mile", 6.21371192237334E-06)]
    [DataRow("Millimeter", 10)]
    [DataRow("Yard", 0.0109361329833771)]
    public void CentimeterConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Centimeter", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 30.48)]
    [DataRow("Feet", 1)]
    [DataRow("Hectometer", 0.003048)]
    [DataRow("Inch", 12)]
    [DataRow("Kilometer", 0.0003048)]
    [DataRow("Meter", 0.3048)]
    [DataRow("Mile", 0.000189393939393939)]
    [DataRow("Millimeter", 304.8)]
    [DataRow("Yard", 0.333333333333333)]
    public void FeetConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Feet", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 10000)]
    [DataRow("Feet", 328.083989501312)]
    [DataRow("Hectometer", 1)]
    [DataRow("Inch", 3937.00787401575)]
    [DataRow("Kilometer", 0.1)]
    [DataRow("Meter", 100)]
    [DataRow("Mile", 0.0621371192237334)]
    [DataRow("Millimeter", 100000)]
    [DataRow("Yard", 109.361329833771)]
    public void HectometerConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectometer", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 2.54)]
    [DataRow("Feet", 0.0833333333333333)]
    [DataRow("Hectometer", 0.000254)]
    [DataRow("Inch", 1)]
    [DataRow("Kilometer", 2.54E-05)]
    [DataRow("Meter", 0.0254)]
    [DataRow("Mile", 1.57828282828283E-05)]
    [DataRow("Millimeter", 25.4)]
    [DataRow("Yard", 0.0277777777777778)]
    public void InchConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Inch", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 100000)]
    [DataRow("Feet", 3280.83989501312)]
    [DataRow("Hectometer", 10)]
    [DataRow("Inch", 39370.0787401575)]
    [DataRow("Kilometer", 1)]
    [DataRow("Meter", 1000)]
    [DataRow("Mile", 0.621371192237334)]
    [DataRow("Millimeter", 1000000)]
    [DataRow("Yard", 1093.61329833771)]
    public void KilometerConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilometer", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 100)]
    [DataRow("Feet", 3.28083989501312)]
    [DataRow("Hectometer", 0.01)]
    [DataRow("Inch", 39.3700787401575)]
    [DataRow("Kilometer", 0.001)]
    [DataRow("Meter", 1)]
    [DataRow("Mile", 0.000621371192237334)]
    [DataRow("Millimeter", 1000)]
    [DataRow("Yard", 1.09361329833771)]
    public void MeterConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Meter", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 160934.4)]
    [DataRow("Feet", 5280)]
    [DataRow("Hectometer", 16.09344)]
    [DataRow("Inch", 63360)]
    [DataRow("Kilometer", 1.609344)]
    [DataRow("Meter", 1609.344)]
    [DataRow("Mile", 1)]
    [DataRow("Millimeter", 1609344)]
    [DataRow("Yard", 1760)]
    public void MileConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Mile", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 0.1)]
    [DataRow("Feet", 0.00328083989501312)]
    [DataRow("Hectometer", 1E-05)]
    [DataRow("Inch", 0.0393700787401575)]
    [DataRow("Kilometer", 1E-06)]
    [DataRow("Meter", 0.001)]
    [DataRow("Mile", 6.21371192237334E-07)]
    [DataRow("Millimeter", 1)]
    [DataRow("Yard", 0.00109361329833771)]
    public void MillimeterConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Millimeter", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centimeter", 91.44)]
    [DataRow("Feet", 3)]
    [DataRow("Hectometer", 0.009144)]
    [DataRow("Inch", 36)]
    [DataRow("Kilometer", 0.0009144)]
    [DataRow("Meter", 0.9144)]
    [DataRow("Mile", 0.000568181818181818)]
    [DataRow("Millimeter", 914.4)]
    [DataRow("Yard", 1)]
    public void YardConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Yard", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    private static double GetConversionFactor(string fromIdentifier, string toIdentifier)
    {
        var quantityValue = Quantity.Known.Distance().CreateValue(value: 1, fromIdentifier);
        var convertedValue = Quantity.Known.Distance().Convert(quantityValue, toIdentifier);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}