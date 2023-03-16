using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Volume;


public class VolumeConversionFactorTests
{
    [Theory]
    [InlineData("Centiliter", 1)]
    [InlineData("CubicCentimeter", 10)]
    [InlineData("CubicDecimeter", 0.01)]
    [InlineData("CubicFoot", 0.000353146667115116)]
    [InlineData("CubicHectometer", 1E-11)]
    [InlineData("CubicInch", 0.610237440947323)]
    [InlineData("CubicKilometer", 1E-14)]
    [InlineData("CubicMeter", 1E-05)]
    [InlineData("CubicMile", 2.39912758316496E-15)]
    [InlineData("CubicMillimeter", 10000)]
    [InlineData("CubicYard", 1.30795061928702E-05)]
    [InlineData("Deciliter", 0.1)]
    [InlineData("Hectoliter", 0.0001)]
    [InlineData("ImperialGallon", 0.00219969157332561)]
    [InlineData("Liter", 0.01)]
    [InlineData("Milliliter", 10)]
    [InlineData("UsGallon", 0.00264172052637296)]
    public void CentiliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Centiliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 0.1)]
    [InlineData("CubicCentimeter", 1)]
    [InlineData("CubicDecimeter", 0.001)]
    [InlineData("CubicFoot", 3.53146667115116E-05)]
    [InlineData("CubicHectometer", 1E-12)]
    [InlineData("CubicInch", 0.0610237440947323)]
    [InlineData("CubicKilometer", 1E-15)]
    [InlineData("CubicMeter", 1E-06)]
    [InlineData("CubicMile", 2.39912758316496E-16)]
    [InlineData("CubicMillimeter", 1000)]
    [InlineData("CubicYard", 1.30795061928702E-06)]
    [InlineData("Deciliter", 0.01)]
    [InlineData("Hectoliter", 1E-05)]
    [InlineData("ImperialGallon", 0.000219969157332561)]
    [InlineData("Liter", 0.001)]
    [InlineData("Milliliter", 1)]
    [InlineData("UsGallon", 0.000264172052637296)]
    public void CubicCentimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicCentimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 100)]
    [InlineData("CubicCentimeter", 1000)]
    [InlineData("CubicDecimeter", 1)]
    [InlineData("CubicFoot", 0.0353146667115116)]
    [InlineData("CubicHectometer", 1E-09)]
    [InlineData("CubicInch", 61.0237440947323)]
    [InlineData("CubicKilometer", 1E-12)]
    [InlineData("CubicMeter", 0.001)]
    [InlineData("CubicMile", 2.39912758316496E-13)]
    [InlineData("CubicMillimeter", 1000000)]
    [InlineData("CubicYard", 0.00130795061928702)]
    [InlineData("Deciliter", 10)]
    [InlineData("Hectoliter", 0.01)]
    [InlineData("ImperialGallon", 0.219969157332561)]
    [InlineData("Liter", 1)]
    [InlineData("Milliliter", 1000)]
    [InlineData("UsGallon", 0.264172052637296)]
    public void CubicDecimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicDecimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 2831.68466)]
    [InlineData("CubicCentimeter", 28316.8466)]
    [InlineData("CubicDecimeter", 28.3168466)]
    [InlineData("CubicFoot", 1)]
    [InlineData("CubicHectometer", 2.83168466E-08)]
    [InlineData("CubicInch", 1728.00000048819)]
    [InlineData("CubicKilometer", 2.83168466E-11)]
    [InlineData("CubicMeter", 0.0283168466)]
    [InlineData("CubicMile", 6.79357277463109E-12)]
    [InlineData("CubicMillimeter", 28316846.6)]
    [InlineData("CubicYard", 0.0370370370467256)]
    [InlineData("Deciliter", 283.168466)]
    [InlineData("Hectoliter", 0.283168466)]
    [InlineData("ImperialGallon", 6.22883288491741)]
    [InlineData("Liter", 28.3168466)]
    [InlineData("Milliliter", 28316.8466)]
    [InlineData("UsGallon", 7.48051949053743)]
    public void CubicFootConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicFoot", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 100000000000)]
    [InlineData("CubicCentimeter", 1000000000000)]
    [InlineData("CubicDecimeter", 1000000000)]
    [InlineData("CubicFoot", 35314666.7115116)]
    [InlineData("CubicHectometer", 1)]
    [InlineData("CubicInch", 61023744094.7323)]
    [InlineData("CubicKilometer", 0.001)]
    [InlineData("CubicMeter", 1000000)]
    [InlineData("CubicMile", 0.000239912758316496)]
    [InlineData("CubicMillimeter", 1E+15)]
    [InlineData("CubicYard", 1307950.61928702)]
    [InlineData("Deciliter", 10000000000)]
    [InlineData("Hectoliter", 10000000)]
    [InlineData("ImperialGallon", 219969157.332561)]
    [InlineData("Liter", 1000000000)]
    [InlineData("Milliliter", 1000000000000)]
    [InlineData("UsGallon", 264172052.637296)]
    public void CubicHectometerConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicHectometer", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 1.6387064)]
    [InlineData("CubicCentimeter", 16.387064)]
    [InlineData("CubicDecimeter", 0.016387064)]
    [InlineData("CubicFoot", 0.00057870370354021)]
    [InlineData("CubicHectometer", 1.6387064E-11)]
    [InlineData("CubicInch", 1)]
    [InlineData("CubicKilometer", 1.6387064E-14)]
    [InlineData("CubicMeter", 1.6387064E-05)]
    [InlineData("CubicMile", 3.93146572494895E-15)]
    [InlineData("CubicMillimeter", 16387.064)]
    [InlineData("CubicYard", 2.1433470507096E-05)]
    [InlineData("Deciliter", 0.16387064)]
    [InlineData("Hectoliter", 0.00016387064)]
    [InlineData("ImperialGallon", 0.00360464865923475)]
    [InlineData("Liter", 0.016387064)]
    [InlineData("Milliliter", 16.387064)]
    [InlineData("UsGallon", 0.00432900433357874)]
    public void CubicInchConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicInch", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 100000000000000)]
    [InlineData("CubicCentimeter", 1E+15)]
    [InlineData("CubicDecimeter", 1000000000000)]
    [InlineData("CubicFoot", 35314666711.5116)]
    [InlineData("CubicHectometer", 1000)]
    [InlineData("CubicInch", 61023744094732.3)]
    [InlineData("CubicKilometer", 1)]
    [InlineData("CubicMeter", 1000000000)]
    [InlineData("CubicMile", 0.239912758316496)]
    [InlineData("CubicMillimeter", 1E+18)]
    [InlineData("CubicYard", 1307950619.28702)]
    [InlineData("Deciliter", 10000000000000)]
    [InlineData("Hectoliter", 10000000000)]
    [InlineData("ImperialGallon", 219969157332.561)]
    [InlineData("Liter", 1000000000000)]
    [InlineData("Milliliter", 1E+15)]
    [InlineData("UsGallon", 264172052637.296)]
    public void CubicKilometerConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicKilometer", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 100000)]
    [InlineData("CubicCentimeter", 1000000)]
    [InlineData("CubicDecimeter", 1000)]
    [InlineData("CubicFoot", 35.3146667115116)]
    [InlineData("CubicHectometer", 1E-06)]
    [InlineData("CubicInch", 61023.7440947323)]
    [InlineData("CubicKilometer", 1E-09)]
    [InlineData("CubicMeter", 1)]
    [InlineData("CubicMile", 2.39912758316496E-10)]
    [InlineData("CubicMillimeter", 1000000000)]
    [InlineData("CubicYard", 1.30795061928702)]
    [InlineData("Deciliter", 10000)]
    [InlineData("Hectoliter", 10)]
    [InlineData("ImperialGallon", 219.969157332561)]
    [InlineData("Liter", 1000)]
    [InlineData("Milliliter", 1000000)]
    [InlineData("UsGallon", 264.172052637296)]
    public void CubicMeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicMeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 416818183000000)]
    [InlineData("CubicCentimeter", 4.16818183E+15)]
    [InlineData("CubicDecimeter", 4168181830000)]
    [InlineData("CubicFoot", 147197952119.428)]
    [InlineData("CubicHectometer", 4168.18183)]
    [InlineData("CubicInch", 254358061334233)]
    [InlineData("CubicKilometer", 4.16818183)]
    [InlineData("CubicMeter", 4168181830)]
    [InlineData("CubicMile", 1)]
    [InlineData("CubicMillimeter", 4.16818183E+18)]
    [InlineData("CubicYard", 5451776005.84941)]
    [InlineData("Deciliter", 41681818300000)]
    [InlineData("Hectoliter", 41681818300)]
    [InlineData("ImperialGallon", 916871444753.99)]
    [InlineData("Liter", 4168181830000)]
    [InlineData("Milliliter", 4.16818183E+15)]
    [InlineData("UsGallon", 1101117149796.58)]
    public void CubicMileConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicMile", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 0.0001)]
    [InlineData("CubicCentimeter", 0.001)]
    [InlineData("CubicDecimeter", 1E-06)]
    [InlineData("CubicFoot", 3.53146667115116E-08)]
    [InlineData("CubicHectometer", 1E-15)]
    [InlineData("CubicInch", 6.10237440947323E-05)]
    [InlineData("CubicKilometer", 1E-18)]
    [InlineData("CubicMeter", 1E-09)]
    [InlineData("CubicMile", 2.39912758316496E-19)]
    [InlineData("CubicMillimeter", 1)]
    [InlineData("CubicYard", 1.30795061928702E-09)]
    [InlineData("Deciliter", 1E-05)]
    [InlineData("Hectoliter", 1E-08)]
    [InlineData("ImperialGallon", 2.19969157332561E-07)]
    [InlineData("Liter", 1E-06)]
    [InlineData("Milliliter", 0.001)]
    [InlineData("UsGallon", 2.64172052637296E-07)]
    public void CubicMillimeterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicMillimeter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 76455.4858)]
    [InlineData("CubicCentimeter", 764554.858)]
    [InlineData("CubicDecimeter", 764.554858)]
    [InlineData("CubicFoot", 26.9999999929371)]
    [InlineData("CubicHectometer", 7.64554858E-07)]
    [InlineData("CubicInch", 46656.0000009764)]
    [InlineData("CubicKilometer", 7.64554858E-10)]
    [InlineData("CubicMeter", 0.764554858)]
    [InlineData("CubicMile", 1.83426464867057E-10)]
    [InlineData("CubicMillimeter", 764554858)]
    [InlineData("CubicYard", 1)]
    [InlineData("Deciliter", 7645.54858)]
    [InlineData("Hectoliter", 7.64554858)]
    [InlineData("ImperialGallon", 168.178487848776)]
    [InlineData("Liter", 764.554858)]
    [InlineData("Milliliter", 764554.858)]
    [InlineData("UsGallon", 201.974026191676)]
    public void CubicYardConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("CubicYard", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 10)]
    [InlineData("CubicCentimeter", 100)]
    [InlineData("CubicDecimeter", 0.1)]
    [InlineData("CubicFoot", 0.00353146667115116)]
    [InlineData("CubicHectometer", 1E-10)]
    [InlineData("CubicInch", 6.10237440947323)]
    [InlineData("CubicKilometer", 1E-13)]
    [InlineData("CubicMeter", 0.0001)]
    [InlineData("CubicMile", 2.39912758316496E-14)]
    [InlineData("CubicMillimeter", 100000)]
    [InlineData("CubicYard", 0.000130795061928702)]
    [InlineData("Deciliter", 1)]
    [InlineData("Hectoliter", 0.001)]
    [InlineData("ImperialGallon", 0.0219969157332561)]
    [InlineData("Liter", 0.1)]
    [InlineData("Milliliter", 100)]
    [InlineData("UsGallon", 0.0264172052637296)]
    public void DeciliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Deciliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 10000)]
    [InlineData("CubicCentimeter", 100000)]
    [InlineData("CubicDecimeter", 100)]
    [InlineData("CubicFoot", 3.53146667115116)]
    [InlineData("CubicHectometer", 1E-07)]
    [InlineData("CubicInch", 6102.37440947323)]
    [InlineData("CubicKilometer", 1E-10)]
    [InlineData("CubicMeter", 0.1)]
    [InlineData("CubicMile", 2.39912758316496E-11)]
    [InlineData("CubicMillimeter", 100000000)]
    [InlineData("CubicYard", 0.130795061928702)]
    [InlineData("Deciliter", 1000)]
    [InlineData("Hectoliter", 1)]
    [InlineData("ImperialGallon", 21.9969157332561)]
    [InlineData("Liter", 100)]
    [InlineData("Milliliter", 100000)]
    [InlineData("UsGallon", 26.4172052637296)]
    public void HectoliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hectoliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 454.609188)]
    [InlineData("CubicCentimeter", 4546.09188)]
    [InlineData("CubicDecimeter", 4.54609188)]
    [InlineData("CubicFoot", 0.160543719582109)]
    [InlineData("CubicHectometer", 4.54609188E-09)]
    [InlineData("CubicInch", 277.41954751626)]
    [InlineData("CubicKilometer", 4.54609188E-12)]
    [InlineData("CubicMeter", 0.00454609188)]
    [InlineData("CubicMile", 1.09066544249103E-12)]
    [InlineData("CubicMillimeter", 4546091.88)]
    [InlineData("CubicYard", 0.0059460636897817)]
    [InlineData("Deciliter", 45.4609188)]
    [InlineData("Hectoliter", 0.0454609188)]
    [InlineData("ImperialGallon", 1)]
    [InlineData("Liter", 4.54609188)]
    [InlineData("Milliliter", 4546.09188)]
    [InlineData("UsGallon", 1.20095042341734)]
    public void ImperialGallonConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("ImperialGallon", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 100)]
    [InlineData("CubicCentimeter", 1000)]
    [InlineData("CubicDecimeter", 1)]
    [InlineData("CubicFoot", 0.0353146667115116)]
    [InlineData("CubicHectometer", 1E-09)]
    [InlineData("CubicInch", 61.0237440947323)]
    [InlineData("CubicKilometer", 1E-12)]
    [InlineData("CubicMeter", 0.001)]
    [InlineData("CubicMile", 2.39912758316496E-13)]
    [InlineData("CubicMillimeter", 1000000)]
    [InlineData("CubicYard", 0.00130795061928702)]
    [InlineData("Deciliter", 10)]
    [InlineData("Hectoliter", 0.01)]
    [InlineData("ImperialGallon", 0.219969157332561)]
    [InlineData("Liter", 1)]
    [InlineData("Milliliter", 1000)]
    [InlineData("UsGallon", 0.264172052637296)]
    public void LiterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Liter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 0.1)]
    [InlineData("CubicCentimeter", 1)]
    [InlineData("CubicDecimeter", 0.001)]
    [InlineData("CubicFoot", 3.53146667115116E-05)]
    [InlineData("CubicHectometer", 1E-12)]
    [InlineData("CubicInch", 0.0610237440947323)]
    [InlineData("CubicKilometer", 1E-15)]
    [InlineData("CubicMeter", 1E-06)]
    [InlineData("CubicMile", 2.39912758316496E-16)]
    [InlineData("CubicMillimeter", 1000)]
    [InlineData("CubicYard", 1.30795061928702E-06)]
    [InlineData("Deciliter", 0.01)]
    [InlineData("Hectoliter", 1E-05)]
    [InlineData("ImperialGallon", 0.000219969157332561)]
    [InlineData("Liter", 0.001)]
    [InlineData("Milliliter", 1)]
    [InlineData("UsGallon", 0.000264172052637296)]
    public void MilliliterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Milliliter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Centiliter", 378.541178)]
    [InlineData("CubicCentimeter", 3785.41178)]
    [InlineData("CubicDecimeter", 3.78541178)]
    [InlineData("CubicFoot", 0.13368055537653)]
    [InlineData("CubicHectometer", 3.78541178E-09)]
    [InlineData("CubicInch", 230.999999755905)]
    [InlineData("CubicKilometer", 3.78541178E-12)]
    [InlineData("CubicMeter", 0.00378541178)]
    [InlineData("CubicMile", 9.08168581503557E-13)]
    [InlineData("CubicMillimeter", 3785411.78)]
    [InlineData("CubicYard", 0.00495113168190738)]
    [InlineData("Deciliter", 37.8541178)]
    [InlineData("Hectoliter", 0.0378541178)]
    [InlineData("ImperialGallon", 0.832673839403351)]
    [InlineData("Liter", 3.78541178)]
    [InlineData("Milliliter", 3785.41178)]
    [InlineData("UsGallon", 1)]
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