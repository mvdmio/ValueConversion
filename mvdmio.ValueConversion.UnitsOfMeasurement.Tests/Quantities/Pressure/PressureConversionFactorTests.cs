using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Pressure;


public class PressureConversionFactorTests
{
    [Theory]
    [InlineData("Atmosphere", 9.869232667160129E-06)]
    [InlineData("Bar", 1E-05)]
    [InlineData("Centibar", 0.001)]
    [InlineData("Decibar", 0.0001)]
    [InlineData("Kilobar", 1E-08)]
    [InlineData("Megabar", 1E-11)]
    [InlineData("Microbar", 10)]
    [InlineData("Millibar", 0.01)]
    [InlineData("Decapascal", 0.1)]
    [InlineData("Gigapascal", 1E-09)]
    [InlineData("Hectopascal", 0.01)]
    [InlineData("Kilopascal", 0.001)]
    [InlineData("Megapascal", 1E-06)]
    [InlineData("Pascal", 1)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572595E-08)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587E-09)]
    public void PascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Pascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 1)]
    [InlineData("Bar", 1.01325)]
    [InlineData("Centibar", 101.325)]
    [InlineData("Decibar", 10.1325)]
    [InlineData("Kilobar", 0.00101325)]
    [InlineData("Megabar", 1.01325E-06)]
    [InlineData("Microbar", 1013250)]
    [InlineData("Millibar", 1013.25)]
    [InlineData("Decapascal", 10132.5)]
    [InlineData("Gigapascal", 0.000101325)]
    [InlineData("Hectopascal", 1013.25)]
    [InlineData("Kilopascal", 101.325)]
    [InlineData("Megapascal", 0.101325)]
    [InlineData("Pascal", 101325)]
    [InlineData("PoundForcePerSquareFoot", 0.0021162166228048183)]
    [InlineData("PoundForcePerSquareInch", 0.00014695948782266708)]
    public void AtmosphereConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Atmosphere", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 0.9869232667160128)]
    [InlineData("Bar", 1)]
    [InlineData("Centibar", 100)]
    [InlineData("Decibar", 10)]
    [InlineData("Kilobar", 0.001)]
    [InlineData("Megabar", 1E-06)]
    [InlineData("Microbar", 1000000)]
    [InlineData("Millibar", 1000)]
    [InlineData("Decapascal", 10000)]
    [InlineData("Gigapascal", 0.0001)]
    [InlineData("Hectopascal", 1000)]
    [InlineData("Kilopascal", 100)]
    [InlineData("Megapascal", 0.1)]
    [InlineData("Pascal", 100000)]
    [InlineData("PoundForcePerSquareFoot", 0.0020885434224572593)]
    [InlineData("PoundForcePerSquareInch", 0.0001450377377968587)]
    public void BarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Bar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 0.009869232667160128)]
    [InlineData("Bar", 0.01)]
    [InlineData("Centibar", 1)]
    [InlineData("Decibar", 0.1)]
    [InlineData("Kilobar", 1E-05)]
    [InlineData("Megabar", 1E-08)]
    [InlineData("Microbar", 10000)]
    [InlineData("Millibar", 10)]
    [InlineData("Decapascal", 100)]
    [InlineData("Gigapascal", 1E-06)]
    [InlineData("Hectopascal", 10)]
    [InlineData("Kilopascal", 1)]
    [InlineData("Megapascal", 0.001)]
    [InlineData("Pascal", 1000)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572596E-05)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587E-06)]
    public void CentibarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Centibar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 0.09869232667160129)]
    [InlineData("Bar", 0.1)]
    [InlineData("Centibar", 10)]
    [InlineData("Decibar", 1)]
    [InlineData("Kilobar", 0.0001)]
    [InlineData("Megabar", 1E-07)]
    [InlineData("Microbar", 100000)]
    [InlineData("Millibar", 100)]
    [InlineData("Decapascal", 1000)]
    [InlineData("Gigapascal", 1E-05)]
    [InlineData("Hectopascal", 100)]
    [InlineData("Kilopascal", 10)]
    [InlineData("Megapascal", 0.01)]
    [InlineData("Pascal", 10000)]
    [InlineData("PoundForcePerSquareFoot", 0.00020885434224572594)]
    [InlineData("PoundForcePerSquareInch", 1.4503773779685869E-05)]
    public void DecibarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Decibar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 986.9232667160128)]
    [InlineData("Bar", 1000)]
    [InlineData("Centibar", 100000)]
    [InlineData("Decibar", 10000)]
    [InlineData("Kilobar", 1)]
    [InlineData("Megabar", 0.001)]
    [InlineData("Microbar", 1000000000)]
    [InlineData("Millibar", 1000000)]
    [InlineData("Decapascal", 10000000)]
    [InlineData("Gigapascal", 0.1)]
    [InlineData("Hectopascal", 1000000)]
    [InlineData("Kilopascal", 100000)]
    [InlineData("Megapascal", 100)]
    [InlineData("Pascal", 100000000)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572594)]
    [InlineData("PoundForcePerSquareInch", 0.1450377377968587)]
    public void KilobarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilobar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 986923.2667160128)]
    [InlineData("Bar", 1000000)]
    [InlineData("Centibar", 100000000)]
    [InlineData("Decibar", 10000000)]
    [InlineData("Kilobar", 1000)]
    [InlineData("Megabar", 1)]
    [InlineData("Microbar", 1000000000000)]
    [InlineData("Millibar", 1000000000)]
    [InlineData("Decapascal", 10000000000)]
    [InlineData("Gigapascal", 100)]
    [InlineData("Hectopascal", 1000000000)]
    [InlineData("Kilopascal", 100000000)]
    [InlineData("Megapascal", 100000)]
    [InlineData("Pascal", 100000000000)]
    [InlineData("PoundForcePerSquareFoot", 2088.5434224572596)]
    [InlineData("PoundForcePerSquareInch", 145.0377377968587)]
    public void MegabarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Megabar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 0.0009869232667160128)]
    [InlineData("Bar", 0.001)]
    [InlineData("Centibar", 0.1)]
    [InlineData("Decibar", 0.01)]
    [InlineData("Kilobar", 1E-06)]
    [InlineData("Megabar", 1E-09)]
    [InlineData("Microbar", 1000)]
    [InlineData("Millibar", 1)]
    [InlineData("Decapascal", 10)]
    [InlineData("Gigapascal", 1E-07)]
    [InlineData("Hectopascal", 1)]
    [InlineData("Kilopascal", 0.1)]
    [InlineData("Megapascal", 0.0001)]
    [InlineData("Pascal", 100)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572595E-06)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587E-07)]
    public void MillibarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Millibar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 9.86923266716013E-07)]
    [InlineData("Bar", 1E-06)]
    [InlineData("Centibar", 0.0001)]
    [InlineData("Decibar", 1E-05)]
    [InlineData("Kilobar", 1E-09)]
    [InlineData("Megabar", 1E-12)]
    [InlineData("Microbar", 1)]
    [InlineData("Millibar", 0.001)]
    [InlineData("Decapascal", 0.01)]
    [InlineData("Gigapascal", 1E-10)]
    [InlineData("Hectopascal", 0.001)]
    [InlineData("Kilopascal", 0.0001)]
    [InlineData("Megapascal", 1.0000000000000001E-07)]
    [InlineData("Pascal", 0.1)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572598E-09)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587E-10)]
    public void MicrobarConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Microbar", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 9.869232667160128E-05)]
    [InlineData("Bar", 0.0001)]
    [InlineData("Centibar", 0.01)]
    [InlineData("Decibar", 0.001)]
    [InlineData("Kilobar", 1E-07)]
    [InlineData("Megabar", 1E-10)]
    [InlineData("Microbar", 100)]
    [InlineData("Millibar", 0.1)]
    [InlineData("Decapascal", 1)]
    [InlineData("Gigapascal", 1E-08)]
    [InlineData("Hectopascal", 0.1)]
    [InlineData("Kilopascal", 0.01)]
    [InlineData("Megapascal", 1E-05)]
    [InlineData("Pascal", 10)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572595E-07)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587E-08)]
    public void DecapascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Decapascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 9869.232667160128)]
    [InlineData("Bar", 10000)]
    [InlineData("Centibar", 1000000)]
    [InlineData("Decibar", 100000)]
    [InlineData("Kilobar", 10)]
    [InlineData("Megabar", 0.01)]
    [InlineData("Microbar", 10000000000)]
    [InlineData("Millibar", 10000000)]
    [InlineData("Decapascal", 100000000)]
    [InlineData("Gigapascal", 1)]
    [InlineData("Hectopascal", 10000000)]
    [InlineData("Kilopascal", 1000000)]
    [InlineData("Megapascal", 1000)]
    [InlineData("Pascal", 1000000000)]
    [InlineData("PoundForcePerSquareFoot", 20.885434224572595)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587)]
    public void GigapascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Gigapascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 0.0009869232667160128)]
    [InlineData("Bar", 0.001)]
    [InlineData("Centibar", 0.1)]
    [InlineData("Decibar", 0.01)]
    [InlineData("Kilobar", 1E-06)]
    [InlineData("Megabar", 1E-09)]
    [InlineData("Microbar", 1000)]
    [InlineData("Millibar", 1)]
    [InlineData("Decapascal", 10)]
    [InlineData("Gigapascal", 1E-07)]
    [InlineData("Hectopascal", 1)]
    [InlineData("Kilopascal", 0.1)]
    [InlineData("Megapascal", 0.0001)]
    [InlineData("Pascal", 100)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572595E-06)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587E-07)]
    public void HectopascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectopascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 0.009869232667160128)]
    [InlineData("Bar", 0.01)]
    [InlineData("Centibar", 1)]
    [InlineData("Decibar", 0.1)]
    [InlineData("Kilobar", 1E-05)]
    [InlineData("Megabar", 1E-08)]
    [InlineData("Microbar", 10000)]
    [InlineData("Millibar", 10)]
    [InlineData("Decapascal", 100)]
    [InlineData("Gigapascal", 1E-06)]
    [InlineData("Hectopascal", 10)]
    [InlineData("Kilopascal", 1)]
    [InlineData("Megapascal", 0.001)]
    [InlineData("Pascal", 1000)]
    [InlineData("PoundForcePerSquareFoot", 2.0885434224572596E-05)]
    [InlineData("PoundForcePerSquareInch", 1.450377377968587E-06)]
    public void KilopascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Kilopascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 9.869232667160128)]
    [InlineData("Bar", 10)]
    [InlineData("Centibar", 1000)]
    [InlineData("Decibar", 100)]
    [InlineData("Kilobar", 0.01)]
    [InlineData("Megabar", 1E-05)]
    [InlineData("Microbar", 10000000)]
    [InlineData("Millibar", 10000)]
    [InlineData("Decapascal", 100000)]
    [InlineData("Gigapascal", 0.001)]
    [InlineData("Hectopascal", 10000)]
    [InlineData("Kilopascal", 1000)]
    [InlineData("Megapascal", 1)]
    [InlineData("Pascal", 1000000)]
    [InlineData("PoundForcePerSquareFoot", 0.020885434224572594)]
    [InlineData("PoundForcePerSquareInch", 0.0014503773779685869)]
    public void MegapascalConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Megapascal", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 6804.596387860844)]
    [InlineData("Bar", 6894.75729)]
    [InlineData("Centibar", 689475.729)]
    [InlineData("Decibar", 68947.5729)]
    [InlineData("Kilobar", 6.89475729)]
    [InlineData("Megabar", 0.00689475729)]
    [InlineData("Microbar", 6894757290)]
    [InlineData("Millibar", 6894757.29)]
    [InlineData("Decapascal", 68947572.9)]
    [InlineData("Gigapascal", 0.689475729)]
    [InlineData("Hectopascal", 6894757.29)]
    [InlineData("Kilopascal", 689475.729)]
    [InlineData("Megapascal", 689.475729)]
    [InlineData("Pascal", 689475729)]
    [InlineData("PoundForcePerSquareFoot", 14.399999987468739)]
    [InlineData("PoundForcePerSquareInch", 1)]
    public void PoundForcePerSquareInchConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("PoundForcePerSquareInch", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Atmosphere", 472.5414162348877)]
    [InlineData("Bar", 478.80259)]
    [InlineData("Centibar", 47880.259)]
    [InlineData("Decibar", 4788.0259)]
    [InlineData("Kilobar", 0.47880259)]
    [InlineData("Megabar", 0.00047880259)]
    [InlineData("Microbar", 478802590)]
    [InlineData("Millibar", 478802.59)]
    [InlineData("Decapascal", 4788025.9)]
    [InlineData("Gigapascal", 0.047880259)]
    [InlineData("Hectopascal", 478802.59)]
    [InlineData("Kilopascal", 47880.259)]
    [InlineData("Megapascal", 47.880259)]
    [InlineData("Pascal", 47880259)]
    [InlineData("PoundForcePerSquareFoot", 1)]
    [InlineData("PoundForcePerSquareInch", 0.06944444450487683)]
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