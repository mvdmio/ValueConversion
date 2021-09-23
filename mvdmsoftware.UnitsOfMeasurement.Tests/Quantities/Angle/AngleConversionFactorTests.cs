using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.Test.Common;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Tests.Quantities.Angle
{
    [TestClass]
    public class AngleConversionFactorTests
    {
        [DataTestMethod]
        [DataRow(AngleType.Degree, 1)]
        [DataRow(AngleType.Radian, 0.01745329252392841)]
        public async Task DegreeConversions(AngleType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AngleType.Degree, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AngleType.Degree, 57.2957795)]
        [DataRow(AngleType.Radian, 1)]
        public async Task RadianConversions(AngleType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AngleType.Radian, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        private static async Task<double> GetConversionFactor(AngleType from, AngleType to)
        {
            var quantityValue = Quantity.Angle.CreateValue(value: 1, from);
            var convertedValue = await Quantity.Angle.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
