using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Mass
{
    [TestClass]
    public class MassConversionFactorTests
    {
        [DataTestMethod]
        [DataRow(MassType.Gram, 1)]
        [DataRow(MassType.Kilogram, 0.001)]
        [DataRow(MassType.Kilopound, 2.20462262184878E-06)]
        [DataRow(MassType.Kilotonne, 1E-09)]
        [DataRow(MassType.Microgram, 1000000)]
        [DataRow(MassType.Milligram, 1000)]
        [DataRow(MassType.Ounce, 0.0352739619806867)]
        [DataRow(MassType.Pound, 0.00220462262184878)]
        [DataRow(MassType.Tonne, 1E-06)]
        public void GramConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Gram, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 1000)]
        [DataRow(MassType.Kilogram, 1)]
        [DataRow(MassType.Kilopound, 0.00220462262184878)]
        [DataRow(MassType.Kilotonne, 1E-06)]
        [DataRow(MassType.Microgram, 1000000000)]
        [DataRow(MassType.Milligram, 1000000)]
        [DataRow(MassType.Ounce, 35.2739619806867)]
        [DataRow(MassType.Pound, 2.20462262184878)]
        [DataRow(MassType.Tonne, 0.001)]
        public void KilogramConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Kilogram, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 453592.37)]
        [DataRow(MassType.Kilogram, 453.59237)]
        [DataRow(MassType.Kilopound, 1)]
        [DataRow(MassType.Kilotonne, 0.00045359237)]
        [DataRow(MassType.Microgram, 453592370000)]
        [DataRow(MassType.Milligram, 453592370)]
        [DataRow(MassType.Ounce, 16000.0000141096)]
        [DataRow(MassType.Pound, 1000)]
        [DataRow(MassType.Tonne, 0.45359237)]
        public void KilopoundConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Kilopound, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 1000000000)]
        [DataRow(MassType.Kilogram, 1000000)]
        [DataRow(MassType.Kilopound, 2204.62262184878)]
        [DataRow(MassType.Kilotonne, 1)]
        [DataRow(MassType.Microgram, 1E+15)]
        [DataRow(MassType.Milligram, 1000000000000)]
        [DataRow(MassType.Ounce, 35273961.9806867)]
        [DataRow(MassType.Pound, 2204622.62184878)]
        [DataRow(MassType.Tonne, 1000)]
        public void KilotonneConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Kilotonne, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 1E-06)]
        [DataRow(MassType.Kilogram, 1E-09)]
        [DataRow(MassType.Kilopound, 2.20462262184878E-12)]
        [DataRow(MassType.Kilotonne, 1E-15)]
        [DataRow(MassType.Microgram, 1)]
        [DataRow(MassType.Milligram, 0.001)]
        [DataRow(MassType.Ounce, 3.52739619806867E-08)]
        [DataRow(MassType.Pound, 2.20462262184878E-09)]
        [DataRow(MassType.Tonne, 1E-12)]
        public void MicrogramConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Microgram, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 0.001)]
        [DataRow(MassType.Kilogram, 1E-06)]
        [DataRow(MassType.Kilopound, 2.20462262184878E-09)]
        [DataRow(MassType.Kilotonne, 1E-12)]
        [DataRow(MassType.Microgram, 1000)]
        [DataRow(MassType.Milligram, 1)]
        [DataRow(MassType.Ounce, 3.52739619806867E-05)]
        [DataRow(MassType.Pound, 2.20462262184878E-06)]
        [DataRow(MassType.Tonne, 1E-09)]
        public void MilligramConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Milligram, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 28.3495231)]
        [DataRow(MassType.Kilogram, 0.0283495231)]
        [DataRow(MassType.Kilopound, 6.24999999448844E-05)]
        [DataRow(MassType.Kilotonne, 2.83495231E-08)]
        [DataRow(MassType.Microgram, 28349523.1)]
        [DataRow(MassType.Milligram, 28349.5231)]
        [DataRow(MassType.Ounce, 1)]
        [DataRow(MassType.Pound, 0.0624999999448844)]
        [DataRow(MassType.Tonne, 2.83495231E-05)]
        public void OunceConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Ounce, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 453.59237)]
        [DataRow(MassType.Kilogram, 0.45359237)]
        [DataRow(MassType.Kilopound, 0.001)]
        [DataRow(MassType.Kilotonne, 4.5359237E-07)]
        [DataRow(MassType.Microgram, 453592370)]
        [DataRow(MassType.Milligram, 453592.37)]
        [DataRow(MassType.Ounce, 16.0000000141096)]
        [DataRow(MassType.Pound, 1)]
        [DataRow(MassType.Tonne, 0.00045359237)]
        public void PoundConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Pound, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(MassType.Gram, 1000000)]
        [DataRow(MassType.Kilogram, 1000)]
        [DataRow(MassType.Kilopound, 2.20462262184878)]
        [DataRow(MassType.Kilotonne, 0.001)]
        [DataRow(MassType.Microgram, 1000000000000)]
        [DataRow(MassType.Milligram, 1000000000)]
        [DataRow(MassType.Ounce, 35273.9619806867)]
        [DataRow(MassType.Pound, 2204.62262184878)]
        [DataRow(MassType.Tonne, 1)]
        public void TonneConversions(MassType to, double expected)
        {
            var conversionFactor = GetConversionFactor(MassType.Tonne, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        private static double GetConversionFactor(MassType from, MassType to)
        {
            var quantityValue = Quantity.Mass.CreateValue(value: 1, from);
            var convertedValue = Quantity.Mass.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
