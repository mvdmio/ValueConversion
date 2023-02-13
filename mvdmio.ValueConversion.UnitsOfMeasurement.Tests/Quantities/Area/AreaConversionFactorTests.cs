using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Area;

[TestClass]
public class AreaConversionFactorTests : ConversionTestBase
{
    [DataTestMethod]
    [DataRow("Acre", 1)]
    [DataRow("Hectare", 0.404685642)]
    [DataRow("SquareCentimeter", 40468564.2)]
    [DataRow("SquareDecimeter", 404685.642)]
    [DataRow("SquareFoot", 43559.9999741666)]
    [DataRow("SquareInch", 6272639.99627999)]
    [DataRow("SquareKilometer", 0.00404685642)]
    [DataRow("SquareMeter", 4046.85642)]
    [DataRow("SquareMile", 0.00156249999927606)]
    [DataRow("SquareYard", 4839.99999712962)]
    public void AcreConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Acre", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 2.47105381613712)]
    [DataRow("Hectare", 1)]
    [DataRow("SquareCentimeter", 100000000)]
    [DataRow("SquareDecimeter", 1000000)]
    [DataRow("SquareFoot", 107639.104167097)]
    [DataRow("SquareInch", 15500031.000062)]
    [DataRow("SquareKilometer", 0.01)]
    [DataRow("SquareMeter", 10000)]
    [DataRow("SquareMile", 0.00386102158592535)]
    [DataRow("SquareYard", 11959.9004630108)]
    public void HectareConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectare", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 2.47105381613712e-08)]
    [DataRow("Hectare", 1e-08)]
    [DataRow("SquareCentimeter", 1)]
    [DataRow("SquareDecimeter", 0.01)]
    [DataRow("SquareFoot", 0.00107639104167097)]
    [DataRow("SquareInch", 0.15500031000062)]
    [DataRow("SquareKilometer", 1e-10)]
    [DataRow("SquareMeter", 0.0001)]
    [DataRow("SquareMile", 3.86102158592535e-11)]
    [DataRow("SquareYard", 0.000119599004630108)]
    public void SquareCentimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareCentimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 2.47105381613712e-06)]
    [DataRow("Hectare", 1e-06)]
    [DataRow("SquareCentimeter", 100)]
    [DataRow("SquareDecimeter", 1)]
    [DataRow("SquareFoot", 0.107639104167097)]
    [DataRow("SquareInch", 15.500031000062)]
    [DataRow("SquareKilometer", 1e-08)]
    [DataRow("SquareMeter", 0.01)]
    [DataRow("SquareMile", 3.86102158592535e-09)]
    [DataRow("SquareYard", 0.0119599004630108)]
    public void SquareDecimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareDecimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 2.29568411522739E-05)]
    [DataRow("Hectare", 9.290304E-06)]
    [DataRow("SquareCentimeter", 929.0304)]
    [DataRow("SquareDecimeter", 9.290304)]
    [DataRow("SquareFoot", 1)]
    [DataRow("SquareInch", 144)]
    [DataRow("SquareKilometer", 9.290304E-08)]
    [DataRow("SquareMeter", 0.09290304)]
    [DataRow("SquareMile", 3.58700642838086E-08)]
    [DataRow("SquareYard", 0.111111111111111)]
    public void SquareFootConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareFoot", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 1.59422508001902e-07)]
    [DataRow("Hectare", 6.4516e-08)]
    [DataRow("SquareCentimeter", 6.4516)]
    [DataRow("SquareDecimeter", 0.064516)]
    [DataRow("SquareFoot", 0.00694444444444444)]
    [DataRow("SquareInch", 1)]
    [DataRow("SquareKilometer", 6.4516E-10)]
    [DataRow("SquareMeter", 0.00064516)]
    [DataRow("SquareMile", 2.4909766863756E-10)]
    [DataRow("SquareYard", 0.000771604938271605)]
    public void SquareInchConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareInch", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 247.105381613712)]
    [DataRow("Hectare", 100)]
    [DataRow("SquareCentimeter", 10000000000)]
    [DataRow("SquareDecimeter", 100000000)]
    [DataRow("SquareFoot", 10763910.4167097)]
    [DataRow("SquareInch", 1550003100.0062)]
    [DataRow("SquareKilometer", 1)]
    [DataRow("SquareMeter", 1000000)]
    [DataRow("SquareMile", 0.386102158592535)]
    [DataRow("SquareYard", 1195990.04630108)]
    public void SquareKilometerConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareKilometer", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 0.000247105381613712)]
    [DataRow("Hectare", 0.0001)]
    [DataRow("SquareCentimeter", 10000)]
    [DataRow("SquareDecimeter", 100)]
    [DataRow("SquareFoot", 10.7639104167097)]
    [DataRow("SquareInch", 1550.0031000062)]
    [DataRow("SquareKilometer", 0.000001)]
    [DataRow("SquareMeter", 1)]
    [DataRow("SquareMile", 0.000000386102158592535)]
    [DataRow("SquareYard", 1.19599004630108)]
    public void SquareMeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareMeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 640.000000296526)]
    [DataRow("Hectare", 258.998811)]
    [DataRow("SquareCentimeter", 25899881100)]
    [DataRow("SquareDecimeter", 258998811)]
    [DataRow("SquareFoot", 27878399.9963833)]
    [DataRow("SquareInch", 4014489599.4792)]
    [DataRow("SquareKilometer", 2.58998811)]
    [DataRow("SquareMeter", 2589988.11)]
    [DataRow("SquareMile", 1)]
    [DataRow("SquareYard", 3097599.99959815)]
    public void SquareMileConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("SquareMile", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Acre", 0.000206611570370465)]
    [DataRow("Hectare", 8.3612736e-05)]
    [DataRow("SquareCentimeter", 8361.2736)]
    [DataRow("SquareDecimeter", 83.612736)]
    [DataRow("SquareFoot", 9)]
    [DataRow("SquareInch", 1296)]
    [DataRow("SquareKilometer", 8.3612736E-07)]
    [DataRow("SquareMeter", 0.83612736)]
    [DataRow("SquareMile", 3.22830578554278E-07)]
    [DataRow("SquareYard", 1)]
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