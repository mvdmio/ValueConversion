using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Volume;

[TestClass]
public class VolumeConversionFactorTests
{
    [DataTestMethod]
    [DataRow("Centiliter", 1)]
    [DataRow("CubicCentimeter", 10)]
    [DataRow("CubicDecimeter", 0.01)]
    [DataRow("CubicFoot", 0.000353146667115116)]
    [DataRow("CubicHectometer", 1E-11)]
    [DataRow("CubicInch", 0.610237440947323)]
    [DataRow("CubicKilometer", 1E-14)]
    [DataRow("CubicMeter", 1E-05)]
    [DataRow("CubicMile", 2.39912758316496E-15)]
    [DataRow("CubicMillimeter", 10000)]
    [DataRow("CubicYard", 1.30795061928702E-05)]
    [DataRow("Deciliter", 0.1)]
    [DataRow("Hectoliter", 0.0001)]
    [DataRow("ImperialGallon", 0.00219969157332561)]
    [DataRow("Liter", 0.01)]
    [DataRow("Milliliter", 10)]
    [DataRow("UsGallon", 0.00264172052637296)]
    public void CentiliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Centiliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 0.1)]
    [DataRow("CubicCentimeter", 1)]
    [DataRow("CubicDecimeter", 0.001)]
    [DataRow("CubicFoot", 3.53146667115116E-05)]
    [DataRow("CubicHectometer", 1E-12)]
    [DataRow("CubicInch", 0.0610237440947323)]
    [DataRow("CubicKilometer", 1E-15)]
    [DataRow("CubicMeter", 1E-06)]
    [DataRow("CubicMile", 2.39912758316496E-16)]
    [DataRow("CubicMillimeter", 1000)]
    [DataRow("CubicYard", 1.30795061928702E-06)]
    [DataRow("Deciliter", 0.01)]
    [DataRow("Hectoliter", 1E-05)]
    [DataRow("ImperialGallon", 0.000219969157332561)]
    [DataRow("Liter", 0.001)]
    [DataRow("Milliliter", 1)]
    [DataRow("UsGallon", 0.000264172052637296)]
    public void CubicCentimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicCentimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 100)]
    [DataRow("CubicCentimeter", 1000)]
    [DataRow("CubicDecimeter", 1)]
    [DataRow("CubicFoot", 0.0353146667115116)]
    [DataRow("CubicHectometer", 1E-09)]
    [DataRow("CubicInch", 61.0237440947323)]
    [DataRow("CubicKilometer", 1E-12)]
    [DataRow("CubicMeter", 0.001)]
    [DataRow("CubicMile", 2.39912758316496E-13)]
    [DataRow("CubicMillimeter", 1000000)]
    [DataRow("CubicYard", 0.00130795061928702)]
    [DataRow("Deciliter", 10)]
    [DataRow("Hectoliter", 0.01)]
    [DataRow("ImperialGallon", 0.219969157332561)]
    [DataRow("Liter", 1)]
    [DataRow("Milliliter", 1000)]
    [DataRow("UsGallon", 0.264172052637296)]
    public void CubicDecimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicDecimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 2831.68466)]
    [DataRow("CubicCentimeter", 28316.8466)]
    [DataRow("CubicDecimeter", 28.3168466)]
    [DataRow("CubicFoot", 1)]
    [DataRow("CubicHectometer", 2.83168466E-08)]
    [DataRow("CubicInch", 1728.00000048819)]
    [DataRow("CubicKilometer", 2.83168466E-11)]
    [DataRow("CubicMeter", 0.0283168466)]
    [DataRow("CubicMile", 6.79357277463109E-12)]
    [DataRow("CubicMillimeter", 28316846.6)]
    [DataRow("CubicYard", 0.0370370370467256)]
    [DataRow("Deciliter", 283.168466)]
    [DataRow("Hectoliter", 0.283168466)]
    [DataRow("ImperialGallon", 6.22883288491741)]
    [DataRow("Liter", 28.3168466)]
    [DataRow("Milliliter", 28316.8466)]
    [DataRow("UsGallon", 7.48051949053743)]
    public void CubicFootConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicFoot", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 100000000000)]
    [DataRow("CubicCentimeter", 1000000000000)]
    [DataRow("CubicDecimeter", 1000000000)]
    [DataRow("CubicFoot", 35314666.7115116)]
    [DataRow("CubicHectometer", 1)]
    [DataRow("CubicInch", 61023744094.7323)]
    [DataRow("CubicKilometer", 0.001)]
    [DataRow("CubicMeter", 1000000)]
    [DataRow("CubicMile", 0.000239912758316496)]
    [DataRow("CubicMillimeter", 1E+15)]
    [DataRow("CubicYard", 1307950.61928702)]
    [DataRow("Deciliter", 10000000000)]
    [DataRow("Hectoliter", 10000000)]
    [DataRow("ImperialGallon", 219969157.332561)]
    [DataRow("Liter", 1000000000)]
    [DataRow("Milliliter", 1000000000000)]
    [DataRow("UsGallon", 264172052.637296)]
    public void CubicHectometerConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicHectometer", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 1.6387064)]
    [DataRow("CubicCentimeter", 16.387064)]
    [DataRow("CubicDecimeter", 0.016387064)]
    [DataRow("CubicFoot", 0.00057870370354021)]
    [DataRow("CubicHectometer", 1.6387064E-11)]
    [DataRow("CubicInch", 1)]
    [DataRow("CubicKilometer", 1.6387064E-14)]
    [DataRow("CubicMeter", 1.6387064E-05)]
    [DataRow("CubicMile", 3.93146572494895E-15)]
    [DataRow("CubicMillimeter", 16387.064)]
    [DataRow("CubicYard", 2.1433470507096E-05)]
    [DataRow("Deciliter", 0.16387064)]
    [DataRow("Hectoliter", 0.00016387064)]
    [DataRow("ImperialGallon", 0.00360464865923475)]
    [DataRow("Liter", 0.016387064)]
    [DataRow("Milliliter", 16.387064)]
    [DataRow("UsGallon", 0.00432900433357874)]
    public void CubicInchConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicInch", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 100000000000000)]
    [DataRow("CubicCentimeter", 1E+15)]
    [DataRow("CubicDecimeter", 1000000000000)]
    [DataRow("CubicFoot", 35314666711.5116)]
    [DataRow("CubicHectometer", 1000)]
    [DataRow("CubicInch", 61023744094732.3)]
    [DataRow("CubicKilometer", 1)]
    [DataRow("CubicMeter", 1000000000)]
    [DataRow("CubicMile", 0.239912758316496)]
    [DataRow("CubicMillimeter", 1E+18)]
    [DataRow("CubicYard", 1307950619.28702)]
    [DataRow("Deciliter", 10000000000000)]
    [DataRow("Hectoliter", 10000000000)]
    [DataRow("ImperialGallon", 219969157332.561)]
    [DataRow("Liter", 1000000000000)]
    [DataRow("Milliliter", 1E+15)]
    [DataRow("UsGallon", 264172052637.296)]
    public void CubicKilometerConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicKilometer", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 100000)]
    [DataRow("CubicCentimeter", 1000000)]
    [DataRow("CubicDecimeter", 1000)]
    [DataRow("CubicFoot", 35.3146667115116)]
    [DataRow("CubicHectometer", 1E-06)]
    [DataRow("CubicInch", 61023.7440947323)]
    [DataRow("CubicKilometer", 1E-09)]
    [DataRow("CubicMeter", 1)]
    [DataRow("CubicMile", 2.39912758316496E-10)]
    [DataRow("CubicMillimeter", 1000000000)]
    [DataRow("CubicYard", 1.30795061928702)]
    [DataRow("Deciliter", 10000)]
    [DataRow("Hectoliter", 10)]
    [DataRow("ImperialGallon", 219.969157332561)]
    [DataRow("Liter", 1000)]
    [DataRow("Milliliter", 1000000)]
    [DataRow("UsGallon", 264.172052637296)]
    public void CubicMeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicMeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 416818183000000)]
    [DataRow("CubicCentimeter", 4.16818183E+15)]
    [DataRow("CubicDecimeter", 4168181830000)]
    [DataRow("CubicFoot", 147197952119.428)]
    [DataRow("CubicHectometer", 4168.18183)]
    [DataRow("CubicInch", 254358061334233)]
    [DataRow("CubicKilometer", 4.16818183)]
    [DataRow("CubicMeter", 4168181830)]
    [DataRow("CubicMile", 1)]
    [DataRow("CubicMillimeter", 4.16818183E+18)]
    [DataRow("CubicYard", 5451776005.84941)]
    [DataRow("Deciliter", 41681818300000)]
    [DataRow("Hectoliter", 41681818300)]
    [DataRow("ImperialGallon", 916871444753.99)]
    [DataRow("Liter", 4168181830000)]
    [DataRow("Milliliter", 4.16818183E+15)]
    [DataRow("UsGallon", 1101117149796.58)]
    public void CubicMileConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicMile", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 0.0001)]
    [DataRow("CubicCentimeter", 0.001)]
    [DataRow("CubicDecimeter", 1E-06)]
    [DataRow("CubicFoot", 3.53146667115116E-08)]
    [DataRow("CubicHectometer", 1E-15)]
    [DataRow("CubicInch", 6.10237440947323E-05)]
    [DataRow("CubicKilometer", 1E-18)]
    [DataRow("CubicMeter", 1E-09)]
    [DataRow("CubicMile", 2.39912758316496E-19)]
    [DataRow("CubicMillimeter", 1)]
    [DataRow("CubicYard", 1.30795061928702E-09)]
    [DataRow("Deciliter", 1E-05)]
    [DataRow("Hectoliter", 1E-08)]
    [DataRow("ImperialGallon", 2.19969157332561E-07)]
    [DataRow("Liter", 1E-06)]
    [DataRow("Milliliter", 0.001)]
    [DataRow("UsGallon", 2.64172052637296E-07)]
    public void CubicMillimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicMillimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 76455.4858)]
    [DataRow("CubicCentimeter", 764554.858)]
    [DataRow("CubicDecimeter", 764.554858)]
    [DataRow("CubicFoot", 26.9999999929371)]
    [DataRow("CubicHectometer", 7.64554858E-07)]
    [DataRow("CubicInch", 46656.0000009764)]
    [DataRow("CubicKilometer", 7.64554858E-10)]
    [DataRow("CubicMeter", 0.764554858)]
    [DataRow("CubicMile", 1.83426464867057E-10)]
    [DataRow("CubicMillimeter", 764554858)]
    [DataRow("CubicYard", 1)]
    [DataRow("Deciliter", 7645.54858)]
    [DataRow("Hectoliter", 7.64554858)]
    [DataRow("ImperialGallon", 168.178487848776)]
    [DataRow("Liter", 764.554858)]
    [DataRow("Milliliter", 764554.858)]
    [DataRow("UsGallon", 201.974026191676)]
    public void CubicYardConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicYard", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 10)]
    [DataRow("CubicCentimeter", 100)]
    [DataRow("CubicDecimeter", 0.1)]
    [DataRow("CubicFoot", 0.00353146667115116)]
    [DataRow("CubicHectometer", 1E-10)]
    [DataRow("CubicInch", 6.10237440947323)]
    [DataRow("CubicKilometer", 1E-13)]
    [DataRow("CubicMeter", 0.0001)]
    [DataRow("CubicMile", 2.39912758316496E-14)]
    [DataRow("CubicMillimeter", 100000)]
    [DataRow("CubicYard", 0.000130795061928702)]
    [DataRow("Deciliter", 1)]
    [DataRow("Hectoliter", 0.001)]
    [DataRow("ImperialGallon", 0.0219969157332561)]
    [DataRow("Liter", 0.1)]
    [DataRow("Milliliter", 100)]
    [DataRow("UsGallon", 0.0264172052637296)]
    public void DeciliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Deciliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 10000)]
    [DataRow("CubicCentimeter", 100000)]
    [DataRow("CubicDecimeter", 100)]
    [DataRow("CubicFoot", 3.53146667115116)]
    [DataRow("CubicHectometer", 1E-07)]
    [DataRow("CubicInch", 6102.37440947323)]
    [DataRow("CubicKilometer", 1E-10)]
    [DataRow("CubicMeter", 0.1)]
    [DataRow("CubicMile", 2.39912758316496E-11)]
    [DataRow("CubicMillimeter", 100000000)]
    [DataRow("CubicYard", 0.130795061928702)]
    [DataRow("Deciliter", 1000)]
    [DataRow("Hectoliter", 1)]
    [DataRow("ImperialGallon", 21.9969157332561)]
    [DataRow("Liter", 100)]
    [DataRow("Milliliter", 100000)]
    [DataRow("UsGallon", 26.4172052637296)]
    public void HectoliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectoliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 454.609188)]
    [DataRow("CubicCentimeter", 4546.09188)]
    [DataRow("CubicDecimeter", 4.54609188)]
    [DataRow("CubicFoot", 0.160543719582109)]
    [DataRow("CubicHectometer", 4.54609188E-09)]
    [DataRow("CubicInch", 277.41954751626)]
    [DataRow("CubicKilometer", 4.54609188E-12)]
    [DataRow("CubicMeter", 0.00454609188)]
    [DataRow("CubicMile", 1.09066544249103E-12)]
    [DataRow("CubicMillimeter", 4546091.88)]
    [DataRow("CubicYard", 0.0059460636897817)]
    [DataRow("Deciliter", 45.4609188)]
    [DataRow("Hectoliter", 0.0454609188)]
    [DataRow("ImperialGallon", 1)]
    [DataRow("Liter", 4.54609188)]
    [DataRow("Milliliter", 4546.09188)]
    [DataRow("UsGallon", 1.20095042341734)]
    public void ImperialGallonConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("ImperialGallon", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 100)]
    [DataRow("CubicCentimeter", 1000)]
    [DataRow("CubicDecimeter", 1)]
    [DataRow("CubicFoot", 0.0353146667115116)]
    [DataRow("CubicHectometer", 1E-09)]
    [DataRow("CubicInch", 61.0237440947323)]
    [DataRow("CubicKilometer", 1E-12)]
    [DataRow("CubicMeter", 0.001)]
    [DataRow("CubicMile", 2.39912758316496E-13)]
    [DataRow("CubicMillimeter", 1000000)]
    [DataRow("CubicYard", 0.00130795061928702)]
    [DataRow("Deciliter", 10)]
    [DataRow("Hectoliter", 0.01)]
    [DataRow("ImperialGallon", 0.219969157332561)]
    [DataRow("Liter", 1)]
    [DataRow("Milliliter", 1000)]
    [DataRow("UsGallon", 0.264172052637296)]
    public void LiterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Liter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 0.1)]
    [DataRow("CubicCentimeter", 1)]
    [DataRow("CubicDecimeter", 0.001)]
    [DataRow("CubicFoot", 3.53146667115116E-05)]
    [DataRow("CubicHectometer", 1E-12)]
    [DataRow("CubicInch", 0.0610237440947323)]
    [DataRow("CubicKilometer", 1E-15)]
    [DataRow("CubicMeter", 1E-06)]
    [DataRow("CubicMile", 2.39912758316496E-16)]
    [DataRow("CubicMillimeter", 1000)]
    [DataRow("CubicYard", 1.30795061928702E-06)]
    [DataRow("Deciliter", 0.01)]
    [DataRow("Hectoliter", 1E-05)]
    [DataRow("ImperialGallon", 0.000219969157332561)]
    [DataRow("Liter", 0.001)]
    [DataRow("Milliliter", 1)]
    [DataRow("UsGallon", 0.000264172052637296)]
    public void MilliliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Milliliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Centiliter", 378.541178)]
    [DataRow("CubicCentimeter", 3785.41178)]
    [DataRow("CubicDecimeter", 3.78541178)]
    [DataRow("CubicFoot", 0.13368055537653)]
    [DataRow("CubicHectometer", 3.78541178E-09)]
    [DataRow("CubicInch", 230.999999755905)]
    [DataRow("CubicKilometer", 3.78541178E-12)]
    [DataRow("CubicMeter", 0.00378541178)]
    [DataRow("CubicMile", 9.08168581503557E-13)]
    [DataRow("CubicMillimeter", 3785411.78)]
    [DataRow("CubicYard", 0.00495113168190738)]
    [DataRow("Deciliter", 37.8541178)]
    [DataRow("Hectoliter", 0.0378541178)]
    [DataRow("ImperialGallon", 0.832673839403351)]
    [DataRow("Liter", 3.78541178)]
    [DataRow("Milliliter", 3785.41178)]
    [DataRow("UsGallon", 1)]
    public void UsGallonConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("UsGallon", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    private static double GetConversionFactor(string from, string to)
    {
        var value = Quantity.Known.Volume().CreateValue(value: 1, from);
        var convertedValue = Quantity.Known.Volume().Convert(value, to);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}