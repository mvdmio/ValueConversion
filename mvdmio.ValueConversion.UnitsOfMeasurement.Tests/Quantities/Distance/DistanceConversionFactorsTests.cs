using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Distance;


public class DistanceConversionFactorsTests
{
    [Theory]
    [InlineData("Centimeter", 1)]
    [InlineData("Feet", 0.0328083989501312)]
    [InlineData("Hectometer", 0.0001)]
    [InlineData("Inch", 0.393700787401575)]
    [InlineData("Kilometer", 1E-05)]
    [InlineData("Meter", 0.01)]
    [InlineData("Mile", 6.21371192237334E-06)]
    [InlineData("Millimeter", 10)]
    [InlineData("Yard", 0.0109361329833771)]
    public void CentimeterConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Centimeter", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 30.48)]
    [InlineData("Feet", 1)]
    [InlineData("Hectometer", 0.003048)]
    [InlineData("Inch", 12)]
    [InlineData("Kilometer", 0.0003048)]
    [InlineData("Meter", 0.3048)]
    [InlineData("Mile", 0.000189393939393939)]
    [InlineData("Millimeter", 304.8)]
    [InlineData("Yard", 0.333333333333333)]
    public void FeetConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Feet", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 10000)]
    [InlineData("Feet", 328.083989501312)]
    [InlineData("Hectometer", 1)]
    [InlineData("Inch", 3937.00787401575)]
    [InlineData("Kilometer", 0.1)]
    [InlineData("Meter", 100)]
    [InlineData("Mile", 0.0621371192237334)]
    [InlineData("Millimeter", 100000)]
    [InlineData("Yard", 109.361329833771)]
    public void HectometerConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectometer", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 2.54)]
    [InlineData("Feet", 0.0833333333333333)]
    [InlineData("Hectometer", 0.000254)]
    [InlineData("Inch", 1)]
    [InlineData("Kilometer", 2.54E-05)]
    [InlineData("Meter", 0.0254)]
    [InlineData("Mile", 1.57828282828283E-05)]
    [InlineData("Millimeter", 25.4)]
    [InlineData("Yard", 0.0277777777777778)]
    public void InchConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Inch", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 100000)]
    [InlineData("Feet", 3280.83989501312)]
    [InlineData("Hectometer", 10)]
    [InlineData("Inch", 39370.0787401575)]
    [InlineData("Kilometer", 1)]
    [InlineData("Meter", 1000)]
    [InlineData("Mile", 0.621371192237334)]
    [InlineData("Millimeter", 1000000)]
    [InlineData("Yard", 1093.61329833771)]
    public void KilometerConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilometer", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 100)]
    [InlineData("Feet", 3.28083989501312)]
    [InlineData("Hectometer", 0.01)]
    [InlineData("Inch", 39.3700787401575)]
    [InlineData("Kilometer", 0.001)]
    [InlineData("Meter", 1)]
    [InlineData("Mile", 0.000621371192237334)]
    [InlineData("Millimeter", 1000)]
    [InlineData("Yard", 1.09361329833771)]
    public void MeterConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Meter", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 160934.4)]
    [InlineData("Feet", 5280)]
    [InlineData("Hectometer", 16.09344)]
    [InlineData("Inch", 63360)]
    [InlineData("Kilometer", 1.609344)]
    [InlineData("Meter", 1609.344)]
    [InlineData("Mile", 1)]
    [InlineData("Millimeter", 1609344)]
    [InlineData("Yard", 1760)]
    public void MileConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Mile", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 0.1)]
    [InlineData("Feet", 0.00328083989501312)]
    [InlineData("Hectometer", 1E-05)]
    [InlineData("Inch", 0.0393700787401575)]
    [InlineData("Kilometer", 1E-06)]
    [InlineData("Meter", 0.001)]
    [InlineData("Mile", 6.21371192237334E-07)]
    [InlineData("Millimeter", 1)]
    [InlineData("Yard", 0.00109361329833771)]
    public void MillimeterConversions(string identifier, double expected)
    {
        var conversionFactor = GetConversionFactor("Millimeter", identifier);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centimeter", 91.44)]
    [InlineData("Feet", 3)]
    [InlineData("Hectometer", 0.009144)]
    [InlineData("Inch", 36)]
    [InlineData("Kilometer", 0.0009144)]
    [InlineData("Meter", 0.9144)]
    [InlineData("Mile", 0.000568181818181818)]
    [InlineData("Millimeter", 914.4)]
    [InlineData("Yard", 1)]
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