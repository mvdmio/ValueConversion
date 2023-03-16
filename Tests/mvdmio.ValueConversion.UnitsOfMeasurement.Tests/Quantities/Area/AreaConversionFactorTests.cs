using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Area;


public class AreaConversionFactorTests : ConversionTestBase
{
    [Theory]
    [InlineData("Acre", 1)]
    [InlineData("Hectare", 0.404685642)]
    [InlineData("SquareCentimeter", 40468564.2)]
    [InlineData("SquareDecimeter", 404685.642)]
    [InlineData("SquareFoot", 43559.9999741666)]
    [InlineData("SquareInch", 6272639.99627999)]
    [InlineData("SquareKilometer", 0.00404685642)]
    [InlineData("SquareMeter", 4046.85642)]
    [InlineData("SquareMile", 0.00156249999927606)]
    [InlineData("SquareYard", 4839.99999712962)]
    public void AcreConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Acre", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 2.47105381613712)]
    [InlineData("Hectare", 1)]
    [InlineData("SquareCentimeter", 100000000)]
    [InlineData("SquareDecimeter", 1000000)]
    [InlineData("SquareFoot", 107639.104167097)]
    [InlineData("SquareInch", 15500031.000062)]
    [InlineData("SquareKilometer", 0.01)]
    [InlineData("SquareMeter", 10000)]
    [InlineData("SquareMile", 0.00386102158592535)]
    [InlineData("SquareYard", 11959.9004630108)]
    public void HectareConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectare", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 2.47105381613712e-08)]
    [InlineData("Hectare", 1e-08)]
    [InlineData("SquareCentimeter", 1)]
    [InlineData("SquareDecimeter", 0.01)]
    [InlineData("SquareFoot", 0.00107639104167097)]
    [InlineData("SquareInch", 0.15500031000062)]
    [InlineData("SquareKilometer", 1e-10)]
    [InlineData("SquareMeter", 0.0001)]
    [InlineData("SquareMile", 3.86102158592535e-11)]
    [InlineData("SquareYard", 0.000119599004630108)]
    public void SquareCentimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareCentimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 2.47105381613712e-06)]
    [InlineData("Hectare", 1e-06)]
    [InlineData("SquareCentimeter", 100)]
    [InlineData("SquareDecimeter", 1)]
    [InlineData("SquareFoot", 0.107639104167097)]
    [InlineData("SquareInch", 15.500031000062)]
    [InlineData("SquareKilometer", 1e-08)]
    [InlineData("SquareMeter", 0.01)]
    [InlineData("SquareMile", 3.86102158592535e-09)]
    [InlineData("SquareYard", 0.0119599004630108)]
    public void SquareDecimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareDecimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 2.29568411522739E-05)]
    [InlineData("Hectare", 9.290304E-06)]
    [InlineData("SquareCentimeter", 929.0304)]
    [InlineData("SquareDecimeter", 9.290304)]
    [InlineData("SquareFoot", 1)]
    [InlineData("SquareInch", 144)]
    [InlineData("SquareKilometer", 9.290304E-08)]
    [InlineData("SquareMeter", 0.09290304)]
    [InlineData("SquareMile", 3.58700642838086E-08)]
    [InlineData("SquareYard", 0.111111111111111)]
    public void SquareFootConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareFoot", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 1.59422508001902e-07)]
    [InlineData("Hectare", 6.4516e-08)]
    [InlineData("SquareCentimeter", 6.4516)]
    [InlineData("SquareDecimeter", 0.064516)]
    [InlineData("SquareFoot", 0.00694444444444444)]
    [InlineData("SquareInch", 1)]
    [InlineData("SquareKilometer", 6.4516E-10)]
    [InlineData("SquareMeter", 0.00064516)]
    [InlineData("SquareMile", 2.4909766863756E-10)]
    [InlineData("SquareYard", 0.000771604938271605)]
    public void SquareInchConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareInch", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 247.105381613712)]
    [InlineData("Hectare", 100)]
    [InlineData("SquareCentimeter", 10000000000)]
    [InlineData("SquareDecimeter", 100000000)]
    [InlineData("SquareFoot", 10763910.4167097)]
    [InlineData("SquareInch", 1550003100.0062)]
    [InlineData("SquareKilometer", 1)]
    [InlineData("SquareMeter", 1000000)]
    [InlineData("SquareMile", 0.386102158592535)]
    [InlineData("SquareYard", 1195990.04630108)]
    public void SquareKilometerConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareKilometer", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 0.000247105381613712)]
    [InlineData("Hectare", 0.0001)]
    [InlineData("SquareCentimeter", 10000)]
    [InlineData("SquareDecimeter", 100)]
    [InlineData("SquareFoot", 10.7639104167097)]
    [InlineData("SquareInch", 1550.0031000062)]
    [InlineData("SquareKilometer", 0.000001)]
    [InlineData("SquareMeter", 1)]
    [InlineData("SquareMile", 0.000000386102158592535)]
    [InlineData("SquareYard", 1.19599004630108)]
    public void SquareMeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareMeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 640.000000296526)]
    [InlineData("Hectare", 258.998811)]
    [InlineData("SquareCentimeter", 25899881100)]
    [InlineData("SquareDecimeter", 258998811)]
    [InlineData("SquareFoot", 27878399.9963833)]
    [InlineData("SquareInch", 4014489599.4792)]
    [InlineData("SquareKilometer", 2.58998811)]
    [InlineData("SquareMeter", 2589988.11)]
    [InlineData("SquareMile", 1)]
    [InlineData("SquareYard", 3097599.99959815)]
    public void SquareMileConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareMile", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Acre", 0.000206611570370465)]
    [InlineData("Hectare", 8.3612736e-05)]
    [InlineData("SquareCentimeter", 8361.2736)]
    [InlineData("SquareDecimeter", 83.612736)]
    [InlineData("SquareFoot", 9)]
    [InlineData("SquareInch", 1296)]
    [InlineData("SquareKilometer", 8.3612736E-07)]
    [InlineData("SquareMeter", 0.83612736)]
    [InlineData("SquareMile", 3.22830578554278E-07)]
    [InlineData("SquareYard", 1)]
    public void SquareYardConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareYard", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    private static double GetConversionFactor(string from, string to)
    {
        var quantityValue = Quantity.Known.Area().CreateValue(value: 1, from);
        var convertedValue = Quantity.Known.Area().Convert(quantityValue, to);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}