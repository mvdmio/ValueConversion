using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Pressure
{
    [TestClass]
    public class PressureConversionFactorTests
    {
        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 9.869232667160129E-06)]
        [DataRow(PressureType.Bar, 1E-05)]
        [DataRow(PressureType.Centibar, 0.001)]
        [DataRow(PressureType.Decibar, 0.0001)]
        [DataRow(PressureType.Kilobar, 1E-08)]
        [DataRow(PressureType.Megabar, 1E-11)]
        [DataRow(PressureType.Microbar, 10)]
        [DataRow(PressureType.Millibar, 0.01)]
        [DataRow(PressureType.Decapascal, 0.1)]
        [DataRow(PressureType.Gigapascal, 1E-09)]
        [DataRow(PressureType.Hectopascal, 0.01)]
        [DataRow(PressureType.Kilopascal, 0.001)]
        [DataRow(PressureType.Megapascal, 1E-06)]
        [DataRow(PressureType.Pascal, 1)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572595E-08)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587E-09)]
        public void PascalConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Pascal, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 1)]
        [DataRow(PressureType.Bar, 1.01325)]
        [DataRow(PressureType.Centibar, 101.325)]
        [DataRow(PressureType.Decibar, 10.1325)]
        [DataRow(PressureType.Kilobar, 0.00101325)]
        [DataRow(PressureType.Megabar, 1.01325E-06)]
        [DataRow(PressureType.Microbar, 1013250)]
        [DataRow(PressureType.Millibar, 1013.25)]
        [DataRow(PressureType.Decapascal, 10132.5)]
        [DataRow(PressureType.Gigapascal, 0.000101325)]
        [DataRow(PressureType.Hectopascal, 1013.25)]
        [DataRow(PressureType.Kilopascal, 101.325)]
        [DataRow(PressureType.Megapascal, 0.101325)]
        [DataRow(PressureType.Pascal, 101325)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 0.0021162166228048183)]
        [DataRow(PressureType.PoundForcePerSquareInch, 0.00014695948782266708)]
        public void AtmosphereConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Atmosphere, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 0.9869232667160128)]
        [DataRow(PressureType.Bar, 1)]
        [DataRow(PressureType.Centibar, 100)]
        [DataRow(PressureType.Decibar, 10)]
        [DataRow(PressureType.Kilobar, 0.001)]
        [DataRow(PressureType.Megabar, 1E-06)]
        [DataRow(PressureType.Microbar, 1000000)]
        [DataRow(PressureType.Millibar, 1000)]
        [DataRow(PressureType.Decapascal, 10000)]
        [DataRow(PressureType.Gigapascal, 0.0001)]
        [DataRow(PressureType.Hectopascal, 1000)]
        [DataRow(PressureType.Kilopascal, 100)]
        [DataRow(PressureType.Megapascal, 0.1)]
        [DataRow(PressureType.Pascal, 100000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 0.0020885434224572593)]
        [DataRow(PressureType.PoundForcePerSquareInch, 0.0001450377377968587)]
        public void BarConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Bar, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 0.009869232667160128)]
        [DataRow(PressureType.Bar, 0.01)]
        [DataRow(PressureType.Centibar, 1)]
        [DataRow(PressureType.Decibar, 0.1)]
        [DataRow(PressureType.Kilobar, 1E-05)]
        [DataRow(PressureType.Megabar, 1E-08)]
        [DataRow(PressureType.Microbar, 10000)]
        [DataRow(PressureType.Millibar, 10)]
        [DataRow(PressureType.Decapascal, 100)]
        [DataRow(PressureType.Gigapascal, 1E-06)]
        [DataRow(PressureType.Hectopascal, 10)]
        [DataRow(PressureType.Kilopascal, 1)]
        [DataRow(PressureType.Megapascal, 0.001)]
        [DataRow(PressureType.Pascal, 1000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572596E-05)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587E-06)]
        public void CentibarConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Centibar, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 0.09869232667160129)]
        [DataRow(PressureType.Bar, 0.1)]
        [DataRow(PressureType.Centibar, 10)]
        [DataRow(PressureType.Decibar, 1)]
        [DataRow(PressureType.Kilobar, 0.0001)]
        [DataRow(PressureType.Megabar, 1E-07)]
        [DataRow(PressureType.Microbar, 100000)]
        [DataRow(PressureType.Millibar, 100)]
        [DataRow(PressureType.Decapascal, 1000)]
        [DataRow(PressureType.Gigapascal, 1E-05)]
        [DataRow(PressureType.Hectopascal, 100)]
        [DataRow(PressureType.Kilopascal, 10)]
        [DataRow(PressureType.Megapascal, 0.01)]
        [DataRow(PressureType.Pascal, 10000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 0.00020885434224572594)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.4503773779685869E-05)]
        public void DecibarConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Decibar, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 986.9232667160128)]
        [DataRow(PressureType.Bar, 1000)]
        [DataRow(PressureType.Centibar, 100000)]
        [DataRow(PressureType.Decibar, 10000)]
        [DataRow(PressureType.Kilobar, 1)]
        [DataRow(PressureType.Megabar, 0.001)]
        [DataRow(PressureType.Microbar, 1000000000)]
        [DataRow(PressureType.Millibar, 1000000)]
        [DataRow(PressureType.Decapascal, 10000000)]
        [DataRow(PressureType.Gigapascal, 0.1)]
        [DataRow(PressureType.Hectopascal, 1000000)]
        [DataRow(PressureType.Kilopascal, 100000)]
        [DataRow(PressureType.Megapascal, 100)]
        [DataRow(PressureType.Pascal, 100000000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572594)]
        [DataRow(PressureType.PoundForcePerSquareInch, 0.1450377377968587)]
        public void KilobarConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Kilobar, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 986923.2667160128)]
        [DataRow(PressureType.Bar, 1000000)]
        [DataRow(PressureType.Centibar, 100000000)]
        [DataRow(PressureType.Decibar, 10000000)]
        [DataRow(PressureType.Kilobar, 1000)]
        [DataRow(PressureType.Megabar, 1)]
        [DataRow(PressureType.Microbar, 1000000000000)]
        [DataRow(PressureType.Millibar, 1000000000)]
        [DataRow(PressureType.Decapascal, 10000000000)]
        [DataRow(PressureType.Gigapascal, 100)]
        [DataRow(PressureType.Hectopascal, 1000000000)]
        [DataRow(PressureType.Kilopascal, 100000000)]
        [DataRow(PressureType.Megapascal, 100000)]
        [DataRow(PressureType.Pascal, 100000000000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2088.5434224572596)]
        [DataRow(PressureType.PoundForcePerSquareInch, 145.0377377968587)]
        public void MegabarConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Megabar, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 0.0009869232667160128)]
        [DataRow(PressureType.Bar, 0.001)]
        [DataRow(PressureType.Centibar, 0.1)]
        [DataRow(PressureType.Decibar, 0.01)]
        [DataRow(PressureType.Kilobar, 1E-06)]
        [DataRow(PressureType.Megabar, 1E-09)]
        [DataRow(PressureType.Microbar, 1000)]
        [DataRow(PressureType.Millibar, 1)]
        [DataRow(PressureType.Decapascal, 10)]
        [DataRow(PressureType.Gigapascal, 1E-07)]
        [DataRow(PressureType.Hectopascal, 1)]
        [DataRow(PressureType.Kilopascal, 0.1)]
        [DataRow(PressureType.Megapascal, 0.0001)]
        [DataRow(PressureType.Pascal, 100)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572595E-06)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587E-07)]
        public void MillibarConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Millibar, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 9.86923266716013E-07)]
        [DataRow(PressureType.Bar, 1E-06)]
        [DataRow(PressureType.Centibar, 0.0001)]
        [DataRow(PressureType.Decibar, 1E-05)]
        [DataRow(PressureType.Kilobar, 1E-09)]
        [DataRow(PressureType.Megabar, 1E-12)]
        [DataRow(PressureType.Microbar, 1)]
        [DataRow(PressureType.Millibar, 0.001)]
        [DataRow(PressureType.Decapascal, 0.01)]
        [DataRow(PressureType.Gigapascal, 1E-10)]
        [DataRow(PressureType.Hectopascal, 0.001)]
        [DataRow(PressureType.Kilopascal, 0.0001)]
        [DataRow(PressureType.Megapascal, 1.0000000000000001E-07)]
        [DataRow(PressureType.Pascal, 0.1)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572598E-09)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587E-10)]
        public void MicrobarConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Microbar, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 9.869232667160128E-05)]
        [DataRow(PressureType.Bar, 0.0001)]
        [DataRow(PressureType.Centibar, 0.01)]
        [DataRow(PressureType.Decibar, 0.001)]
        [DataRow(PressureType.Kilobar, 1E-07)]
        [DataRow(PressureType.Megabar, 1E-10)]
        [DataRow(PressureType.Microbar, 100)]
        [DataRow(PressureType.Millibar, 0.1)]
        [DataRow(PressureType.Decapascal, 1)]
        [DataRow(PressureType.Gigapascal, 1E-08)]
        [DataRow(PressureType.Hectopascal, 0.1)]
        [DataRow(PressureType.Kilopascal, 0.01)]
        [DataRow(PressureType.Megapascal, 1E-05)]
        [DataRow(PressureType.Pascal, 10)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572595E-07)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587E-08)]
        public void DecapascalConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Decapascal, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 9869.232667160128)]
        [DataRow(PressureType.Bar, 10000)]
        [DataRow(PressureType.Centibar, 1000000)]
        [DataRow(PressureType.Decibar, 100000)]
        [DataRow(PressureType.Kilobar, 10)]
        [DataRow(PressureType.Megabar, 0.01)]
        [DataRow(PressureType.Microbar, 10000000000)]
        [DataRow(PressureType.Millibar, 10000000)]
        [DataRow(PressureType.Decapascal, 100000000)]
        [DataRow(PressureType.Gigapascal, 1)]
        [DataRow(PressureType.Hectopascal, 10000000)]
        [DataRow(PressureType.Kilopascal, 1000000)]
        [DataRow(PressureType.Megapascal, 1000)]
        [DataRow(PressureType.Pascal, 1000000000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 20.885434224572595)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587)]
        public void GigapascalConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Gigapascal, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 0.0009869232667160128)]
        [DataRow(PressureType.Bar, 0.001)]
        [DataRow(PressureType.Centibar, 0.1)]
        [DataRow(PressureType.Decibar, 0.01)]
        [DataRow(PressureType.Kilobar, 1E-06)]
        [DataRow(PressureType.Megabar, 1E-09)]
        [DataRow(PressureType.Microbar, 1000)]
        [DataRow(PressureType.Millibar, 1)]
        [DataRow(PressureType.Decapascal, 10)]
        [DataRow(PressureType.Gigapascal, 1E-07)]
        [DataRow(PressureType.Hectopascal, 1)]
        [DataRow(PressureType.Kilopascal, 0.1)]
        [DataRow(PressureType.Megapascal, 0.0001)]
        [DataRow(PressureType.Pascal, 100)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572595E-06)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587E-07)]
        public void HectopascalConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Hectopascal, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 0.009869232667160128)]
        [DataRow(PressureType.Bar, 0.01)]
        [DataRow(PressureType.Centibar, 1)]
        [DataRow(PressureType.Decibar, 0.1)]
        [DataRow(PressureType.Kilobar, 1E-05)]
        [DataRow(PressureType.Megabar, 1E-08)]
        [DataRow(PressureType.Microbar, 10000)]
        [DataRow(PressureType.Millibar, 10)]
        [DataRow(PressureType.Decapascal, 100)]
        [DataRow(PressureType.Gigapascal, 1E-06)]
        [DataRow(PressureType.Hectopascal, 10)]
        [DataRow(PressureType.Kilopascal, 1)]
        [DataRow(PressureType.Megapascal, 0.001)]
        [DataRow(PressureType.Pascal, 1000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 2.0885434224572596E-05)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1.450377377968587E-06)]
        public void KilopascalConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Kilopascal, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 9.869232667160128)]
        [DataRow(PressureType.Bar, 10)]
        [DataRow(PressureType.Centibar, 1000)]
        [DataRow(PressureType.Decibar, 100)]
        [DataRow(PressureType.Kilobar, 0.01)]
        [DataRow(PressureType.Megabar, 1E-05)]
        [DataRow(PressureType.Microbar, 10000000)]
        [DataRow(PressureType.Millibar, 10000)]
        [DataRow(PressureType.Decapascal, 100000)]
        [DataRow(PressureType.Gigapascal, 0.001)]
        [DataRow(PressureType.Hectopascal, 10000)]
        [DataRow(PressureType.Kilopascal, 1000)]
        [DataRow(PressureType.Megapascal, 1)]
        [DataRow(PressureType.Pascal, 1000000)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 0.020885434224572594)]
        [DataRow(PressureType.PoundForcePerSquareInch, 0.0014503773779685869)]
        public void MegapascalConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.Megapascal, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 6804.596387860844)]
        [DataRow(PressureType.Bar, 6894.75729)]
        [DataRow(PressureType.Centibar, 689475.729)]
        [DataRow(PressureType.Decibar, 68947.5729)]
        [DataRow(PressureType.Kilobar, 6.89475729)]
        [DataRow(PressureType.Megabar, 0.00689475729)]
        [DataRow(PressureType.Microbar, 6894757290)]
        [DataRow(PressureType.Millibar, 6894757.29)]
        [DataRow(PressureType.Decapascal, 68947572.9)]
        [DataRow(PressureType.Gigapascal, 0.689475729)]
        [DataRow(PressureType.Hectopascal, 6894757.29)]
        [DataRow(PressureType.Kilopascal, 689475.729)]
        [DataRow(PressureType.Megapascal, 689.475729)]
        [DataRow(PressureType.Pascal, 689475729)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 14.399999987468739)]
        [DataRow(PressureType.PoundForcePerSquareInch, 1)]
        public void PoundForcePerSquareInchConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.PoundForcePerSquareInch, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(PressureType.Atmosphere, 472.5414162348877)]
        [DataRow(PressureType.Bar, 478.80259)]
        [DataRow(PressureType.Centibar, 47880.259)]
        [DataRow(PressureType.Decibar, 4788.0259)]
        [DataRow(PressureType.Kilobar, 0.47880259)]
        [DataRow(PressureType.Megabar, 0.00047880259)]
        [DataRow(PressureType.Microbar, 478802590)]
        [DataRow(PressureType.Millibar, 478802.59)]
        [DataRow(PressureType.Decapascal, 4788025.9)]
        [DataRow(PressureType.Gigapascal, 0.047880259)]
        [DataRow(PressureType.Hectopascal, 478802.59)]
        [DataRow(PressureType.Kilopascal, 47880.259)]
        [DataRow(PressureType.Megapascal, 47.880259)]
        [DataRow(PressureType.Pascal, 47880259)]
        [DataRow(PressureType.PoundForcePerSquareFoot, 1)]
        [DataRow(PressureType.PoundForcePerSquareInch, 0.06944444450487683)]
        public void PoundForcePerSquareFootConversions(PressureType to, double expected)
        {
            var conversionFactor = GetConversionFactor(PressureType.PoundForcePerSquareFoot, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        private static double GetConversionFactor(PressureType from, PressureType to)
        {
            var quantityValue = Quantity.Pressure.CreateValue(value: 1, from);
            var convertedValue = Quantity.Pressure.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}

