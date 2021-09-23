using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Volume
{
    [TestClass]
    public class VolumeConversionFactorTests
    {
        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 1)]
        [DataRow(VolumeType.CubicCentimeter, 10)]
        [DataRow(VolumeType.CubicDecimeter, 0.01)]
        [DataRow(VolumeType.CubicFoot, 0.000353146667115116)]
        [DataRow(VolumeType.CubicHectometer, 1E-11)]
        [DataRow(VolumeType.CubicInch, 0.610237440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-14)]
        [DataRow(VolumeType.CubicMeter, 1E-05)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-15)]
        [DataRow(VolumeType.CubicMillimeter, 10000)]
        [DataRow(VolumeType.CubicYard, 1.30795061928702E-05)]
        [DataRow(VolumeType.Deciliter, 0.1)]
        [DataRow(VolumeType.Hectoliter, 0.0001)]
        [DataRow(VolumeType.ImperialGallon, 0.00219969157332561)]
        [DataRow(VolumeType.Liter, 0.01)]
        [DataRow(VolumeType.Milliliter, 10)]
        [DataRow(VolumeType.UsGallon, 0.00264172052637296)]
        public async Task CentiliterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.Centiliter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 0.1)]
        [DataRow(VolumeType.CubicCentimeter, 1)]
        [DataRow(VolumeType.CubicDecimeter, 0.001)]
        [DataRow(VolumeType.CubicFoot, 3.53146667115116E-05)]
        [DataRow(VolumeType.CubicHectometer, 1E-12)]
        [DataRow(VolumeType.CubicInch, 0.0610237440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-15)]
        [DataRow(VolumeType.CubicMeter, 1E-06)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-16)]
        [DataRow(VolumeType.CubicMillimeter, 1000)]
        [DataRow(VolumeType.CubicYard, 1.30795061928702E-06)]
        [DataRow(VolumeType.Deciliter, 0.01)]
        [DataRow(VolumeType.Hectoliter, 1E-05)]
        [DataRow(VolumeType.ImperialGallon, 0.000219969157332561)]
        [DataRow(VolumeType.Liter, 0.001)]
        [DataRow(VolumeType.Milliliter, 1)]
        [DataRow(VolumeType.UsGallon, 0.000264172052637296)]
        public async Task CubicCentimeterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicCentimeter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 100)]
        [DataRow(VolumeType.CubicCentimeter, 1000)]
        [DataRow(VolumeType.CubicDecimeter, 1)]
        [DataRow(VolumeType.CubicFoot, 0.0353146667115116)]
        [DataRow(VolumeType.CubicHectometer, 1E-09)]
        [DataRow(VolumeType.CubicInch, 61.0237440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-12)]
        [DataRow(VolumeType.CubicMeter, 0.001)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-13)]
        [DataRow(VolumeType.CubicMillimeter, 1000000)]
        [DataRow(VolumeType.CubicYard, 0.00130795061928702)]
        [DataRow(VolumeType.Deciliter, 10)]
        [DataRow(VolumeType.Hectoliter, 0.01)]
        [DataRow(VolumeType.ImperialGallon, 0.219969157332561)]
        [DataRow(VolumeType.Liter, 1)]
        [DataRow(VolumeType.Milliliter, 1000)]
        [DataRow(VolumeType.UsGallon, 0.264172052637296)]
        public async Task CubicDecimeterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicDecimeter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 2831.68466)]
        [DataRow(VolumeType.CubicCentimeter, 28316.8466)]
        [DataRow(VolumeType.CubicDecimeter, 28.3168466)]
        [DataRow(VolumeType.CubicFoot, 1)]
        [DataRow(VolumeType.CubicHectometer, 2.83168466E-08)]
        [DataRow(VolumeType.CubicInch, 1728.00000048819)]
        [DataRow(VolumeType.CubicKilometer, 2.83168466E-11)]
        [DataRow(VolumeType.CubicMeter, 0.0283168466)]
        [DataRow(VolumeType.CubicMile, 6.79357277463109E-12)]
        [DataRow(VolumeType.CubicMillimeter, 28316846.6)]
        [DataRow(VolumeType.CubicYard, 0.0370370370467256)]
        [DataRow(VolumeType.Deciliter, 283.168466)]
        [DataRow(VolumeType.Hectoliter, 0.283168466)]
        [DataRow(VolumeType.ImperialGallon, 6.22883288491741)]
        [DataRow(VolumeType.Liter, 28.3168466)]
        [DataRow(VolumeType.Milliliter, 28316.8466)]
        [DataRow(VolumeType.UsGallon, 7.48051949053743)]
        public async Task CubicFootConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicFoot, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 100000000000)]
        [DataRow(VolumeType.CubicCentimeter, 1000000000000)]
        [DataRow(VolumeType.CubicDecimeter, 1000000000)]
        [DataRow(VolumeType.CubicFoot, 35314666.7115116)]
        [DataRow(VolumeType.CubicHectometer, 1)]
        [DataRow(VolumeType.CubicInch, 61023744094.7323)]
        [DataRow(VolumeType.CubicKilometer, 0.001)]
        [DataRow(VolumeType.CubicMeter, 1000000)]
        [DataRow(VolumeType.CubicMile, 0.000239912758316496)]
        [DataRow(VolumeType.CubicMillimeter, 1E+15)]
        [DataRow(VolumeType.CubicYard, 1307950.61928702)]
        [DataRow(VolumeType.Deciliter, 10000000000)]
        [DataRow(VolumeType.Hectoliter, 10000000)]
        [DataRow(VolumeType.ImperialGallon, 219969157.332561)]
        [DataRow(VolumeType.Liter, 1000000000)]
        [DataRow(VolumeType.Milliliter, 1000000000000)]
        [DataRow(VolumeType.UsGallon, 264172052.637296)]
        public async Task CubicHectometerConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicHectometer, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 1.6387064)]
        [DataRow(VolumeType.CubicCentimeter, 16.387064)]
        [DataRow(VolumeType.CubicDecimeter, 0.016387064)]
        [DataRow(VolumeType.CubicFoot, 0.00057870370354021)]
        [DataRow(VolumeType.CubicHectometer, 1.6387064E-11)]
        [DataRow(VolumeType.CubicInch, 1)]
        [DataRow(VolumeType.CubicKilometer, 1.6387064E-14)]
        [DataRow(VolumeType.CubicMeter, 1.6387064E-05)]
        [DataRow(VolumeType.CubicMile, 3.93146572494895E-15)]
        [DataRow(VolumeType.CubicMillimeter, 16387.064)]
        [DataRow(VolumeType.CubicYard, 2.1433470507096E-05)]
        [DataRow(VolumeType.Deciliter, 0.16387064)]
        [DataRow(VolumeType.Hectoliter, 0.00016387064)]
        [DataRow(VolumeType.ImperialGallon, 0.00360464865923475)]
        [DataRow(VolumeType.Liter, 0.016387064)]
        [DataRow(VolumeType.Milliliter, 16.387064)]
        [DataRow(VolumeType.UsGallon, 0.00432900433357874)]
        public async Task CubicInchConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicInch, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 100000000000000)]
        [DataRow(VolumeType.CubicCentimeter, 1E+15)]
        [DataRow(VolumeType.CubicDecimeter, 1000000000000)]
        [DataRow(VolumeType.CubicFoot, 35314666711.5116)]
        [DataRow(VolumeType.CubicHectometer, 1000)]
        [DataRow(VolumeType.CubicInch, 61023744094732.3)]
        [DataRow(VolumeType.CubicKilometer, 1)]
        [DataRow(VolumeType.CubicMeter, 1000000000)]
        [DataRow(VolumeType.CubicMile, 0.239912758316496)]
        [DataRow(VolumeType.CubicMillimeter, 1E+18)]
        [DataRow(VolumeType.CubicYard, 1307950619.28702)]
        [DataRow(VolumeType.Deciliter, 10000000000000)]
        [DataRow(VolumeType.Hectoliter, 10000000000)]
        [DataRow(VolumeType.ImperialGallon, 219969157332.561)]
        [DataRow(VolumeType.Liter, 1000000000000)]
        [DataRow(VolumeType.Milliliter, 1E+15)]
        [DataRow(VolumeType.UsGallon, 264172052637.296)]
        public async Task CubicKilometerConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicKilometer, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 100000)]
        [DataRow(VolumeType.CubicCentimeter, 1000000)]
        [DataRow(VolumeType.CubicDecimeter, 1000)]
        [DataRow(VolumeType.CubicFoot, 35.3146667115116)]
        [DataRow(VolumeType.CubicHectometer, 1E-06)]
        [DataRow(VolumeType.CubicInch, 61023.7440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-09)]
        [DataRow(VolumeType.CubicMeter, 1)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-10)]
        [DataRow(VolumeType.CubicMillimeter, 1000000000)]
        [DataRow(VolumeType.CubicYard, 1.30795061928702)]
        [DataRow(VolumeType.Deciliter, 10000)]
        [DataRow(VolumeType.Hectoliter, 10)]
        [DataRow(VolumeType.ImperialGallon, 219.969157332561)]
        [DataRow(VolumeType.Liter, 1000)]
        [DataRow(VolumeType.Milliliter, 1000000)]
        [DataRow(VolumeType.UsGallon, 264.172052637296)]
        public async Task CubicMeterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicMeter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 416818183000000)]
        [DataRow(VolumeType.CubicCentimeter, 4.16818183E+15)]
        [DataRow(VolumeType.CubicDecimeter, 4168181830000)]
        [DataRow(VolumeType.CubicFoot, 147197952119.428)]
        [DataRow(VolumeType.CubicHectometer, 4168.18183)]
        [DataRow(VolumeType.CubicInch, 254358061334233)]
        [DataRow(VolumeType.CubicKilometer, 4.16818183)]
        [DataRow(VolumeType.CubicMeter, 4168181830)]
        [DataRow(VolumeType.CubicMile, 1)]
        [DataRow(VolumeType.CubicMillimeter, 4.16818183E+18)]
        [DataRow(VolumeType.CubicYard, 5451776005.84941)]
        [DataRow(VolumeType.Deciliter, 41681818300000)]
        [DataRow(VolumeType.Hectoliter, 41681818300)]
        [DataRow(VolumeType.ImperialGallon, 916871444753.99)]
        [DataRow(VolumeType.Liter, 4168181830000)]
        [DataRow(VolumeType.Milliliter, 4.16818183E+15)]
        [DataRow(VolumeType.UsGallon, 1101117149796.58)]
        public async Task CubicMileConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicMile, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 0.0001)]
        [DataRow(VolumeType.CubicCentimeter, 0.001)]
        [DataRow(VolumeType.CubicDecimeter, 1E-06)]
        [DataRow(VolumeType.CubicFoot, 3.53146667115116E-08)]
        [DataRow(VolumeType.CubicHectometer, 1E-15)]
        [DataRow(VolumeType.CubicInch, 6.10237440947323E-05)]
        [DataRow(VolumeType.CubicKilometer, 1E-18)]
        [DataRow(VolumeType.CubicMeter, 1E-09)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-19)]
        [DataRow(VolumeType.CubicMillimeter, 1)]
        [DataRow(VolumeType.CubicYard, 1.30795061928702E-09)]
        [DataRow(VolumeType.Deciliter, 1E-05)]
        [DataRow(VolumeType.Hectoliter, 1E-08)]
        [DataRow(VolumeType.ImperialGallon, 2.19969157332561E-07)]
        [DataRow(VolumeType.Liter, 1E-06)]
        [DataRow(VolumeType.Milliliter, 0.001)]
        [DataRow(VolumeType.UsGallon, 2.64172052637296E-07)]
        public async Task CubicMillimeterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicMillimeter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 76455.4858)]
        [DataRow(VolumeType.CubicCentimeter, 764554.858)]
        [DataRow(VolumeType.CubicDecimeter, 764.554858)]
        [DataRow(VolumeType.CubicFoot, 26.9999999929371)]
        [DataRow(VolumeType.CubicHectometer, 7.64554858E-07)]
        [DataRow(VolumeType.CubicInch, 46656.0000009764)]
        [DataRow(VolumeType.CubicKilometer, 7.64554858E-10)]
        [DataRow(VolumeType.CubicMeter, 0.764554858)]
        [DataRow(VolumeType.CubicMile, 1.83426464867057E-10)]
        [DataRow(VolumeType.CubicMillimeter, 764554858)]
        [DataRow(VolumeType.CubicYard, 1)]
        [DataRow(VolumeType.Deciliter, 7645.54858)]
        [DataRow(VolumeType.Hectoliter, 7.64554858)]
        [DataRow(VolumeType.ImperialGallon, 168.178487848776)]
        [DataRow(VolumeType.Liter, 764.554858)]
        [DataRow(VolumeType.Milliliter, 764554.858)]
        [DataRow(VolumeType.UsGallon, 201.974026191676)]
        public async Task CubicYardConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.CubicYard, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 10)]
        [DataRow(VolumeType.CubicCentimeter, 100)]
        [DataRow(VolumeType.CubicDecimeter, 0.1)]
        [DataRow(VolumeType.CubicFoot, 0.00353146667115116)]
        [DataRow(VolumeType.CubicHectometer, 1E-10)]
        [DataRow(VolumeType.CubicInch, 6.10237440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-13)]
        [DataRow(VolumeType.CubicMeter, 0.0001)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-14)]
        [DataRow(VolumeType.CubicMillimeter, 100000)]
        [DataRow(VolumeType.CubicYard, 0.000130795061928702)]
        [DataRow(VolumeType.Deciliter, 1)]
        [DataRow(VolumeType.Hectoliter, 0.001)]
        [DataRow(VolumeType.ImperialGallon, 0.0219969157332561)]
        [DataRow(VolumeType.Liter, 0.1)]
        [DataRow(VolumeType.Milliliter, 100)]
        [DataRow(VolumeType.UsGallon, 0.0264172052637296)]
        public async Task DeciliterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.Deciliter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 10000)]
        [DataRow(VolumeType.CubicCentimeter, 100000)]
        [DataRow(VolumeType.CubicDecimeter, 100)]
        [DataRow(VolumeType.CubicFoot, 3.53146667115116)]
        [DataRow(VolumeType.CubicHectometer, 1E-07)]
        [DataRow(VolumeType.CubicInch, 6102.37440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-10)]
        [DataRow(VolumeType.CubicMeter, 0.1)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-11)]
        [DataRow(VolumeType.CubicMillimeter, 100000000)]
        [DataRow(VolumeType.CubicYard, 0.130795061928702)]
        [DataRow(VolumeType.Deciliter, 1000)]
        [DataRow(VolumeType.Hectoliter, 1)]
        [DataRow(VolumeType.ImperialGallon, 21.9969157332561)]
        [DataRow(VolumeType.Liter, 100)]
        [DataRow(VolumeType.Milliliter, 100000)]
        [DataRow(VolumeType.UsGallon, 26.4172052637296)]
        public async Task HectoliterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.Hectoliter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 454.609188)]
        [DataRow(VolumeType.CubicCentimeter, 4546.09188)]
        [DataRow(VolumeType.CubicDecimeter, 4.54609188)]
        [DataRow(VolumeType.CubicFoot, 0.160543719582109)]
        [DataRow(VolumeType.CubicHectometer, 4.54609188E-09)]
        [DataRow(VolumeType.CubicInch, 277.41954751626)]
        [DataRow(VolumeType.CubicKilometer, 4.54609188E-12)]
        [DataRow(VolumeType.CubicMeter, 0.00454609188)]
        [DataRow(VolumeType.CubicMile, 1.09066544249103E-12)]
        [DataRow(VolumeType.CubicMillimeter, 4546091.88)]
        [DataRow(VolumeType.CubicYard, 0.0059460636897817)]
        [DataRow(VolumeType.Deciliter, 45.4609188)]
        [DataRow(VolumeType.Hectoliter, 0.0454609188)]
        [DataRow(VolumeType.ImperialGallon, 1)]
        [DataRow(VolumeType.Liter, 4.54609188)]
        [DataRow(VolumeType.Milliliter, 4546.09188)]
        [DataRow(VolumeType.UsGallon, 1.20095042341734)]
        public async Task ImperialGallonConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.ImperialGallon, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 100)]
        [DataRow(VolumeType.CubicCentimeter, 1000)]
        [DataRow(VolumeType.CubicDecimeter, 1)]
        [DataRow(VolumeType.CubicFoot, 0.0353146667115116)]
        [DataRow(VolumeType.CubicHectometer, 1E-09)]
        [DataRow(VolumeType.CubicInch, 61.0237440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-12)]
        [DataRow(VolumeType.CubicMeter, 0.001)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-13)]
        [DataRow(VolumeType.CubicMillimeter, 1000000)]
        [DataRow(VolumeType.CubicYard, 0.00130795061928702)]
        [DataRow(VolumeType.Deciliter, 10)]
        [DataRow(VolumeType.Hectoliter, 0.01)]
        [DataRow(VolumeType.ImperialGallon, 0.219969157332561)]
        [DataRow(VolumeType.Liter, 1)]
        [DataRow(VolumeType.Milliliter, 1000)]
        [DataRow(VolumeType.UsGallon, 0.264172052637296)]
        public async Task LiterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.Liter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 0.1)]
        [DataRow(VolumeType.CubicCentimeter, 1)]
        [DataRow(VolumeType.CubicDecimeter, 0.001)]
        [DataRow(VolumeType.CubicFoot, 3.53146667115116E-05)]
        [DataRow(VolumeType.CubicHectometer, 1E-12)]
        [DataRow(VolumeType.CubicInch, 0.0610237440947323)]
        [DataRow(VolumeType.CubicKilometer, 1E-15)]
        [DataRow(VolumeType.CubicMeter, 1E-06)]
        [DataRow(VolumeType.CubicMile, 2.39912758316496E-16)]
        [DataRow(VolumeType.CubicMillimeter, 1000)]
        [DataRow(VolumeType.CubicYard, 1.30795061928702E-06)]
        [DataRow(VolumeType.Deciliter, 0.01)]
        [DataRow(VolumeType.Hectoliter, 1E-05)]
        [DataRow(VolumeType.ImperialGallon, 0.000219969157332561)]
        [DataRow(VolumeType.Liter, 0.001)]
        [DataRow(VolumeType.Milliliter, 1)]
        [DataRow(VolumeType.UsGallon, 0.000264172052637296)]
        public async Task MilliliterConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.Milliliter, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(VolumeType.Centiliter, 378.541178)]
        [DataRow(VolumeType.CubicCentimeter, 3785.41178)]
        [DataRow(VolumeType.CubicDecimeter, 3.78541178)]
        [DataRow(VolumeType.CubicFoot, 0.13368055537653)]
        [DataRow(VolumeType.CubicHectometer, 3.78541178E-09)]
        [DataRow(VolumeType.CubicInch, 230.999999755905)]
        [DataRow(VolumeType.CubicKilometer, 3.78541178E-12)]
        [DataRow(VolumeType.CubicMeter, 0.00378541178)]
        [DataRow(VolumeType.CubicMile, 9.08168581503557E-13)]
        [DataRow(VolumeType.CubicMillimeter, 3785411.78)]
        [DataRow(VolumeType.CubicYard, 0.00495113168190738)]
        [DataRow(VolumeType.Deciliter, 37.8541178)]
        [DataRow(VolumeType.Hectoliter, 0.0378541178)]
        [DataRow(VolumeType.ImperialGallon, 0.832673839403351)]
        [DataRow(VolumeType.Liter, 3.78541178)]
        [DataRow(VolumeType.Milliliter, 3785.41178)]
        [DataRow(VolumeType.UsGallon, 1)]
        public async Task UsGallonConversions(VolumeType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(VolumeType.UsGallon, to);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        private static async Task<double> GetConversionFactor(VolumeType from, VolumeType to)
        {
            var value = Quantity.Volume.CreateValue(value: 1, from);
            var convertedValue = await Quantity.Volume.Convert(value, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
