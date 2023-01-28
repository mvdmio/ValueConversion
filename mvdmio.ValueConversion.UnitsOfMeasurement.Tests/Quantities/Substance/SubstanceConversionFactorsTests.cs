using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Substance
{
    [TestClass]
    public class SubstanceConversionFactorsTests
    {
        [DataTestMethod]
        [DataRow(SubstanceType.Mole, 1)]
        [DataRow(SubstanceType.Micromole, 1000000)]
        [DataRow(SubstanceType.Millimole, 1000)]
        public void MoleConversions(SubstanceType type, double expected)
        {
            var conversionFactor = GetConversionFactor(SubstanceType.Mole, type);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(SubstanceType.Mole, 0.001)]
        [DataRow(SubstanceType.Micromole, 1000)]
        [DataRow(SubstanceType.Millimole, 1)]
        public void MillimoleConversions(SubstanceType type, double expected)
        {
            var conversionFactor = GetConversionFactor(SubstanceType.Millimole, type);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(SubstanceType.Mole, 0.000001)]
        [DataRow(SubstanceType.Micromole, 1)]
        [DataRow(SubstanceType.Millimole, 0.001)]
        public void MicromoleConversions(SubstanceType type, double expected)
        {
            var conversionFactor = GetConversionFactor(SubstanceType.Micromole, type);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        private static double GetConversionFactor(SubstanceType from, SubstanceType to)
        {
            var quantityValue = Quantity.Substance.CreateValue(value: 1, from);
            var convertedValue = Quantity.Substance.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
