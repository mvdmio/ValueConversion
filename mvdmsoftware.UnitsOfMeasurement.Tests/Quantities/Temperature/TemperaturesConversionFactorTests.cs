using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Temperature
{
    [TestClass]
    public class TemperaturesConversionFactorTests
    {
        [DataTestMethod]
        [DataRow(1, TemperatureType.DegreeFahrenheit, 1)]
        [DataRow(10, TemperatureType.DegreeFahrenheit, 10)]
        [DataRow(-1, TemperatureType.DegreeFahrenheit, -1)]
        [DataRow(-10, TemperatureType.DegreeFahrenheit, -10)]
        [DataRow(1, TemperatureType.DegreeCelsius, -17.2222222222222)]
        [DataRow(10, TemperatureType.DegreeCelsius, -12.2222222222222)]
        [DataRow(-1, TemperatureType.DegreeCelsius, -18.3333333333333)]
        [DataRow(-10, TemperatureType.DegreeCelsius, -23.3333333333333)]
        [DataRow(1, TemperatureType.Kelvin, 255.927777777778)]
        [DataRow(10, TemperatureType.Kelvin, 260.927777777778)]
        [DataRow(-1, TemperatureType.Kelvin, 254.816666666667)]
        [DataRow(-10, TemperatureType.Kelvin, 249.816666666667)]
        
        public async Task DegreeFahrenheitConversions(double value, TemperatureType to, double expected)
        {
            var convertedTemperature = await GetConvertedValue(value, TemperatureType.DegreeFahrenheit, to);
            AssertExtensions.AreEqual(expected, convertedTemperature);
        }

        [DataTestMethod]
        [DataRow(1, TemperatureType.DegreeFahrenheit, 33.8)]
        [DataRow(10, TemperatureType.DegreeFahrenheit, 50)]
        [DataRow(-1, TemperatureType.DegreeFahrenheit, 30.2)]
        [DataRow(-10, TemperatureType.DegreeFahrenheit, 14)]
        [DataRow(1, TemperatureType.DegreeCelsius, 1)]
        [DataRow(10, TemperatureType.DegreeCelsius, 10)]
        [DataRow(-1, TemperatureType.DegreeCelsius, -1)]
        [DataRow(-10, TemperatureType.DegreeCelsius, -10)]
        [DataRow(1, TemperatureType.Kelvin, 274.15)]
        [DataRow(10, TemperatureType.Kelvin, 283.15)]
        [DataRow(-1, TemperatureType.Kelvin, 272.15)]
        [DataRow(-10, TemperatureType.Kelvin, 263.15)]
        public async Task DegreeCelsiusConversions(double value, TemperatureType to, double expected)
        {
            var convertedTemperature = await GetConvertedValue(value, TemperatureType.DegreeCelsius, to);
            AssertExtensions.AreEqual(expected, convertedTemperature);
        }

        [DataTestMethod]
        [DataRow(1, TemperatureType.DegreeFahrenheit, -457.87)]
        [DataRow(10, TemperatureType.DegreeFahrenheit, -441.67)]
        [DataRow(100, TemperatureType.DegreeFahrenheit, -279.67)]
        [DataRow(1000, TemperatureType.DegreeFahrenheit, 1340.33)]
        [DataRow(1, TemperatureType.DegreeCelsius, -272.15)]
        [DataRow(10, TemperatureType.DegreeCelsius, -263.15)]
        [DataRow(100, TemperatureType.DegreeCelsius, -173.15)]
        [DataRow(1000, TemperatureType.DegreeCelsius, 726.85)]
        [DataRow(1, TemperatureType.Kelvin, 1)]
        [DataRow(10, TemperatureType.Kelvin, 10)]
        [DataRow(100, TemperatureType.Kelvin, 100)]
        [DataRow(1000, TemperatureType.Kelvin, 1000)]
        public async Task KelvinConversions(double value, TemperatureType to, double expected)
        {
            var convertedTemperature = await GetConvertedValue(value, TemperatureType.Kelvin, to);
            AssertExtensions.AreEqual(expected, convertedTemperature);
        }

        private static async Task<double> GetConvertedValue(double value, TemperatureType from, TemperatureType to)
        {
            var quantityValue = Quantity.Temperature.CreateValue(value, from);
            var convertedValue = await Quantity.Temperature.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
