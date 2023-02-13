using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Pressure;

[TestClass]
public class PressureConversionFactorTests
{
    [DataTestMethod]
    [DataRow("Atmosphere", 9.869232667160129E-06)]
    [DataRow("Bar", 1E-05)]
    [DataRow("Centibar", 0.001)]
    [DataRow("Decibar", 0.0001)]
    [DataRow("Kilobar", 1E-08)]
    [DataRow("Megabar", 1E-11)]
    [DataRow("Microbar", 10)]
    [DataRow("Millibar", 0.01)]
    [DataRow("Decapascal", 0.1)]
    [DataRow("Gigapascal", 1E-09)]
    [DataRow("Hectopascal", 0.01)]
    [DataRow("Kilopascal", 0.001)]
    [DataRow("Megapascal", 1E-06)]
    [DataRow("Pascal", 1)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572595E-08)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587E-09)]
    public void PascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Pascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 1)]
    [DataRow("Bar", 1.01325)]
    [DataRow("Centibar", 101.325)]
    [DataRow("Decibar", 10.1325)]
    [DataRow("Kilobar", 0.00101325)]
    [DataRow("Megabar", 1.01325E-06)]
    [DataRow("Microbar", 1013250)]
    [DataRow("Millibar", 1013.25)]
    [DataRow("Decapascal", 10132.5)]
    [DataRow("Gigapascal", 0.000101325)]
    [DataRow("Hectopascal", 1013.25)]
    [DataRow("Kilopascal", 101.325)]
    [DataRow("Megapascal", 0.101325)]
    [DataRow("Pascal", 101325)]
    [DataRow("PoundForcePerSquareFoot", 0.0021162166228048183)]
    [DataRow("PoundForcePerSquareInch", 0.00014695948782266708)]
    public void AtmosphereConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Atmosphere", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 0.9869232667160128)]
    [DataRow("Bar", 1)]
    [DataRow("Centibar", 100)]
    [DataRow("Decibar", 10)]
    [DataRow("Kilobar", 0.001)]
    [DataRow("Megabar", 1E-06)]
    [DataRow("Microbar", 1000000)]
    [DataRow("Millibar", 1000)]
    [DataRow("Decapascal", 10000)]
    [DataRow("Gigapascal", 0.0001)]
    [DataRow("Hectopascal", 1000)]
    [DataRow("Kilopascal", 100)]
    [DataRow("Megapascal", 0.1)]
    [DataRow("Pascal", 100000)]
    [DataRow("PoundForcePerSquareFoot", 0.0020885434224572593)]
    [DataRow("PoundForcePerSquareInch", 0.0001450377377968587)]
    public void BarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Bar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 0.009869232667160128)]
    [DataRow("Bar", 0.01)]
    [DataRow("Centibar", 1)]
    [DataRow("Decibar", 0.1)]
    [DataRow("Kilobar", 1E-05)]
    [DataRow("Megabar", 1E-08)]
    [DataRow("Microbar", 10000)]
    [DataRow("Millibar", 10)]
    [DataRow("Decapascal", 100)]
    [DataRow("Gigapascal", 1E-06)]
    [DataRow("Hectopascal", 10)]
    [DataRow("Kilopascal", 1)]
    [DataRow("Megapascal", 0.001)]
    [DataRow("Pascal", 1000)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572596E-05)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587E-06)]
    public void CentibarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Centibar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 0.09869232667160129)]
    [DataRow("Bar", 0.1)]
    [DataRow("Centibar", 10)]
    [DataRow("Decibar", 1)]
    [DataRow("Kilobar", 0.0001)]
    [DataRow("Megabar", 1E-07)]
    [DataRow("Microbar", 100000)]
    [DataRow("Millibar", 100)]
    [DataRow("Decapascal", 1000)]
    [DataRow("Gigapascal", 1E-05)]
    [DataRow("Hectopascal", 100)]
    [DataRow("Kilopascal", 10)]
    [DataRow("Megapascal", 0.01)]
    [DataRow("Pascal", 10000)]
    [DataRow("PoundForcePerSquareFoot", 0.00020885434224572594)]
    [DataRow("PoundForcePerSquareInch", 1.4503773779685869E-05)]
    public void DecibarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Decibar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 986.9232667160128)]
    [DataRow("Bar", 1000)]
    [DataRow("Centibar", 100000)]
    [DataRow("Decibar", 10000)]
    [DataRow("Kilobar", 1)]
    [DataRow("Megabar", 0.001)]
    [DataRow("Microbar", 1000000000)]
    [DataRow("Millibar", 1000000)]
    [DataRow("Decapascal", 10000000)]
    [DataRow("Gigapascal", 0.1)]
    [DataRow("Hectopascal", 1000000)]
    [DataRow("Kilopascal", 100000)]
    [DataRow("Megapascal", 100)]
    [DataRow("Pascal", 100000000)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572594)]
    [DataRow("PoundForcePerSquareInch", 0.1450377377968587)]
    public void KilobarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilobar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 986923.2667160128)]
    [DataRow("Bar", 1000000)]
    [DataRow("Centibar", 100000000)]
    [DataRow("Decibar", 10000000)]
    [DataRow("Kilobar", 1000)]
    [DataRow("Megabar", 1)]
    [DataRow("Microbar", 1000000000000)]
    [DataRow("Millibar", 1000000000)]
    [DataRow("Decapascal", 10000000000)]
    [DataRow("Gigapascal", 100)]
    [DataRow("Hectopascal", 1000000000)]
    [DataRow("Kilopascal", 100000000)]
    [DataRow("Megapascal", 100000)]
    [DataRow("Pascal", 100000000000)]
    [DataRow("PoundForcePerSquareFoot", 2088.5434224572596)]
    [DataRow("PoundForcePerSquareInch", 145.0377377968587)]
    public void MegabarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Megabar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 0.0009869232667160128)]
    [DataRow("Bar", 0.001)]
    [DataRow("Centibar", 0.1)]
    [DataRow("Decibar", 0.01)]
    [DataRow("Kilobar", 1E-06)]
    [DataRow("Megabar", 1E-09)]
    [DataRow("Microbar", 1000)]
    [DataRow("Millibar", 1)]
    [DataRow("Decapascal", 10)]
    [DataRow("Gigapascal", 1E-07)]
    [DataRow("Hectopascal", 1)]
    [DataRow("Kilopascal", 0.1)]
    [DataRow("Megapascal", 0.0001)]
    [DataRow("Pascal", 100)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572595E-06)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587E-07)]
    public void MillibarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Millibar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 9.86923266716013E-07)]
    [DataRow("Bar", 1E-06)]
    [DataRow("Centibar", 0.0001)]
    [DataRow("Decibar", 1E-05)]
    [DataRow("Kilobar", 1E-09)]
    [DataRow("Megabar", 1E-12)]
    [DataRow("Microbar", 1)]
    [DataRow("Millibar", 0.001)]
    [DataRow("Decapascal", 0.01)]
    [DataRow("Gigapascal", 1E-10)]
    [DataRow("Hectopascal", 0.001)]
    [DataRow("Kilopascal", 0.0001)]
    [DataRow("Megapascal", 1.0000000000000001E-07)]
    [DataRow("Pascal", 0.1)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572598E-09)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587E-10)]
    public void MicrobarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Microbar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 9.869232667160128E-05)]
    [DataRow("Bar", 0.0001)]
    [DataRow("Centibar", 0.01)]
    [DataRow("Decibar", 0.001)]
    [DataRow("Kilobar", 1E-07)]
    [DataRow("Megabar", 1E-10)]
    [DataRow("Microbar", 100)]
    [DataRow("Millibar", 0.1)]
    [DataRow("Decapascal", 1)]
    [DataRow("Gigapascal", 1E-08)]
    [DataRow("Hectopascal", 0.1)]
    [DataRow("Kilopascal", 0.01)]
    [DataRow("Megapascal", 1E-05)]
    [DataRow("Pascal", 10)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572595E-07)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587E-08)]
    public void DecapascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Decapascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 9869.232667160128)]
    [DataRow("Bar", 10000)]
    [DataRow("Centibar", 1000000)]
    [DataRow("Decibar", 100000)]
    [DataRow("Kilobar", 10)]
    [DataRow("Megabar", 0.01)]
    [DataRow("Microbar", 10000000000)]
    [DataRow("Millibar", 10000000)]
    [DataRow("Decapascal", 100000000)]
    [DataRow("Gigapascal", 1)]
    [DataRow("Hectopascal", 10000000)]
    [DataRow("Kilopascal", 1000000)]
    [DataRow("Megapascal", 1000)]
    [DataRow("Pascal", 1000000000)]
    [DataRow("PoundForcePerSquareFoot", 20.885434224572595)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587)]
    public void GigapascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Gigapascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 0.0009869232667160128)]
    [DataRow("Bar", 0.001)]
    [DataRow("Centibar", 0.1)]
    [DataRow("Decibar", 0.01)]
    [DataRow("Kilobar", 1E-06)]
    [DataRow("Megabar", 1E-09)]
    [DataRow("Microbar", 1000)]
    [DataRow("Millibar", 1)]
    [DataRow("Decapascal", 10)]
    [DataRow("Gigapascal", 1E-07)]
    [DataRow("Hectopascal", 1)]
    [DataRow("Kilopascal", 0.1)]
    [DataRow("Megapascal", 0.0001)]
    [DataRow("Pascal", 100)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572595E-06)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587E-07)]
    public void HectopascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectopascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 0.009869232667160128)]
    [DataRow("Bar", 0.01)]
    [DataRow("Centibar", 1)]
    [DataRow("Decibar", 0.1)]
    [DataRow("Kilobar", 1E-05)]
    [DataRow("Megabar", 1E-08)]
    [DataRow("Microbar", 10000)]
    [DataRow("Millibar", 10)]
    [DataRow("Decapascal", 100)]
    [DataRow("Gigapascal", 1E-06)]
    [DataRow("Hectopascal", 10)]
    [DataRow("Kilopascal", 1)]
    [DataRow("Megapascal", 0.001)]
    [DataRow("Pascal", 1000)]
    [DataRow("PoundForcePerSquareFoot", 2.0885434224572596E-05)]
    [DataRow("PoundForcePerSquareInch", 1.450377377968587E-06)]
    public void KilopascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilopascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 9.869232667160128)]
    [DataRow("Bar", 10)]
    [DataRow("Centibar", 1000)]
    [DataRow("Decibar", 100)]
    [DataRow("Kilobar", 0.01)]
    [DataRow("Megabar", 1E-05)]
    [DataRow("Microbar", 10000000)]
    [DataRow("Millibar", 10000)]
    [DataRow("Decapascal", 100000)]
    [DataRow("Gigapascal", 0.001)]
    [DataRow("Hectopascal", 10000)]
    [DataRow("Kilopascal", 1000)]
    [DataRow("Megapascal", 1)]
    [DataRow("Pascal", 1000000)]
    [DataRow("PoundForcePerSquareFoot", 0.020885434224572594)]
    [DataRow("PoundForcePerSquareInch", 0.0014503773779685869)]
    public void MegapascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Megapascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 6804.596387860844)]
    [DataRow("Bar", 6894.75729)]
    [DataRow("Centibar", 689475.729)]
    [DataRow("Decibar", 68947.5729)]
    [DataRow("Kilobar", 6.89475729)]
    [DataRow("Megabar", 0.00689475729)]
    [DataRow("Microbar", 6894757290)]
    [DataRow("Millibar", 6894757.29)]
    [DataRow("Decapascal", 68947572.9)]
    [DataRow("Gigapascal", 0.689475729)]
    [DataRow("Hectopascal", 6894757.29)]
    [DataRow("Kilopascal", 689475.729)]
    [DataRow("Megapascal", 689.475729)]
    [DataRow("Pascal", 689475729)]
    [DataRow("PoundForcePerSquareFoot", 14.399999987468739)]
    [DataRow("PoundForcePerSquareInch", 1)]
    public void PoundForcePerSquareInchConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("PoundForcePerSquareInch", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Atmosphere", 472.5414162348877)]
    [DataRow("Bar", 478.80259)]
    [DataRow("Centibar", 47880.259)]
    [DataRow("Decibar", 4788.0259)]
    [DataRow("Kilobar", 0.47880259)]
    [DataRow("Megabar", 0.00047880259)]
    [DataRow("Microbar", 478802590)]
    [DataRow("Millibar", 478802.59)]
    [DataRow("Decapascal", 4788025.9)]
    [DataRow("Gigapascal", 0.047880259)]
    [DataRow("Hectopascal", 478802.59)]
    [DataRow("Kilopascal", 47880.259)]
    [DataRow("Megapascal", 47.880259)]
    [DataRow("Pascal", 47880259)]
    [DataRow("PoundForcePerSquareFoot", 1)]
    [DataRow("PoundForcePerSquareInch", 0.06944444450487683)]
    public void PoundForcePerSquareFootConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("PoundForcePerSquareFoot", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    private static double GetConversionFactor(string from, string to)
    {
        var quantityValue = Quantity.Known.Pressure().CreateValue(value: 1, from);
        var convertedValue = Quantity.Known.Pressure().Convert(quantityValue, to);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}