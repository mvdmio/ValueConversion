using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Distance
{
    [TestClass]
    public class DistanceConversionFactorsTests
    {
        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 1)]
        [DataRow(DistanceType.Feet, 0.0328083989501312)]
        [DataRow(DistanceType.Hectometer, 0.0001)]
        [DataRow(DistanceType.Inch, 0.393700787401575)]
        [DataRow(DistanceType.Kilometer, 1E-05)]
        [DataRow(DistanceType.Meter, 0.01)]
        [DataRow(DistanceType.Mile, 6.21371192237334E-06)]
        [DataRow(DistanceType.Millimeter, 10)]
        [DataRow(DistanceType.Yard, 0.0109361329833771)]
        public async Task CentimeterConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Centimeter, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 30.48)]
        [DataRow(DistanceType.Feet, 1)]
        [DataRow(DistanceType.Hectometer, 0.003048)]
        [DataRow(DistanceType.Inch, 12)]
        [DataRow(DistanceType.Kilometer, 0.0003048)]
        [DataRow(DistanceType.Meter, 0.3048)]
        [DataRow(DistanceType.Mile, 0.000189393939393939)]
        [DataRow(DistanceType.Millimeter, 304.8)]
        [DataRow(DistanceType.Yard, 0.333333333333333)]
        public async Task FeetConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Feet, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 10000)]
        [DataRow(DistanceType.Feet, 328.083989501312)]
        [DataRow(DistanceType.Hectometer, 1)]
        [DataRow(DistanceType.Inch, 3937.00787401575)]
        [DataRow(DistanceType.Kilometer, 0.1)]
        [DataRow(DistanceType.Meter, 100)]
        [DataRow(DistanceType.Mile, 0.0621371192237334)]
        [DataRow(DistanceType.Millimeter, 100000)]
        [DataRow(DistanceType.Yard, 109.361329833771)]
        public async Task HectometerConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Hectometer, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 2.54)]
        [DataRow(DistanceType.Feet, 0.0833333333333333)]
        [DataRow(DistanceType.Hectometer, 0.000254)]
        [DataRow(DistanceType.Inch, 1)]
        [DataRow(DistanceType.Kilometer, 2.54E-05)]
        [DataRow(DistanceType.Meter, 0.0254)]
        [DataRow(DistanceType.Mile, 1.57828282828283E-05)]
        [DataRow(DistanceType.Millimeter, 25.4)]
        [DataRow(DistanceType.Yard, 0.0277777777777778)]
        public async Task InchConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Inch, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 100000)]
        [DataRow(DistanceType.Feet, 3280.83989501312)]
        [DataRow(DistanceType.Hectometer, 10)]
        [DataRow(DistanceType.Inch, 39370.0787401575)]
        [DataRow(DistanceType.Kilometer, 1)]
        [DataRow(DistanceType.Meter, 1000)]
        [DataRow(DistanceType.Mile, 0.621371192237334)]
        [DataRow(DistanceType.Millimeter, 1000000)]
        [DataRow(DistanceType.Yard, 1093.61329833771)]
        public async Task KilometerConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Kilometer, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 100)]
        [DataRow(DistanceType.Feet, 3.28083989501312)]
        [DataRow(DistanceType.Hectometer, 0.01)]
        [DataRow(DistanceType.Inch, 39.3700787401575)]
        [DataRow(DistanceType.Kilometer, 0.001)]
        [DataRow(DistanceType.Meter, 1)]
        [DataRow(DistanceType.Mile, 0.000621371192237334)]
        [DataRow(DistanceType.Millimeter, 1000)]
        [DataRow(DistanceType.Yard, 1.09361329833771)]
        public async Task MeterConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Meter, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 160934.4)]
        [DataRow(DistanceType.Feet, 5280)]
        [DataRow(DistanceType.Hectometer, 16.09344)]
        [DataRow(DistanceType.Inch, 63360)]
        [DataRow(DistanceType.Kilometer, 1.609344)]
        [DataRow(DistanceType.Meter, 1609.344)]
        [DataRow(DistanceType.Mile, 1)]
        [DataRow(DistanceType.Millimeter, 1609344)]
        [DataRow(DistanceType.Yard, 1760)]
        public async Task MileConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Mile, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 0.1)]
        [DataRow(DistanceType.Feet, 0.00328083989501312)]
        [DataRow(DistanceType.Hectometer, 1E-05)]
        [DataRow(DistanceType.Inch, 0.0393700787401575)]
        [DataRow(DistanceType.Kilometer, 1E-06)]
        [DataRow(DistanceType.Meter, 0.001)]
        [DataRow(DistanceType.Mile, 6.21371192237334E-07)]
        [DataRow(DistanceType.Millimeter, 1)]
        [DataRow(DistanceType.Yard, 0.00109361329833771)]
        public async Task MillimeterConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Millimeter, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DistanceType.Centimeter, 91.44)]
        [DataRow(DistanceType.Feet, 3)]
        [DataRow(DistanceType.Hectometer, 0.009144)]
        [DataRow(DistanceType.Inch, 36)]
        [DataRow(DistanceType.Kilometer, 0.0009144)]
        [DataRow(DistanceType.Meter, 0.9144)]
        [DataRow(DistanceType.Mile, 0.000568181818181818)]
        [DataRow(DistanceType.Millimeter, 914.4)]
        [DataRow(DistanceType.Yard, 1)]
        public async Task YardConversions(DistanceType type, double expected)
        {
            var conversionFactor = await GetConversionFactor(DistanceType.Yard, type);
            AssertExtensions.AreEqual(expected, conversionFactor);
        }

        private static async Task<double> GetConversionFactor(DistanceType from, DistanceType to)
        {
            var quantityValue = Quantity.Distance.CreateValue(value: 1, from);
            var convertedValue = await Quantity.Distance.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
