using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Substance
{
    [TestClass]
    public class SubstanceConversionFactorsTests
    {
        [DataTestMethod]
        [DataRow(SubstanceType.Mole, 1)]
        [DataRow(SubstanceType.Micromole, 1000000)]
        [DataRow(SubstanceType.Millimole, 1000)]
        public async Task MoleConversions(SubstanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(SubstanceType.Mole, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(SubstanceType.Mole, 0.001)]
        [DataRow(SubstanceType.Micromole, 1000)]
        [DataRow(SubstanceType.Millimole, 1)]
        public async Task MillimoleConversions(SubstanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(SubstanceType.Millimole, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(SubstanceType.Mole, 0.000001)]
        [DataRow(SubstanceType.Micromole, 1)]
        [DataRow(SubstanceType.Millimole, 0.001)]
        public async Task MicromoleConversions(SubstanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(SubstanceType.Micromole, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        private static async Task<double> GetConversionFactor(SubstanceType from, SubstanceType to)
        {
            var quantityValue = Quantity.Substance.CreateValue(value: 1, from);
            var convertedValue = await Quantity.Substance.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
