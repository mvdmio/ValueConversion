using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.Test.Common;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Tests.Quantities.Area
{
    [TestClass]
    public class AreaConversionFactorTests
    {
        [DataTestMethod]
        [DataRow(AreaType.Acre, 1)]
        [DataRow(AreaType.Hectare, 0.404685642)]
        [DataRow(AreaType.SquareCentimeter, 40468564.2)]
        [DataRow(AreaType.SquareDecimeter, 404685.642)]
        [DataRow(AreaType.SquareFoot, 43559.9999741666)]
        [DataRow(AreaType.SquareInch, 6272639.99627999)]
        [DataRow(AreaType.SquareKilometer, 0.00404685642)]
        [DataRow(AreaType.SquareMeter, 4046.85642)]
        [DataRow(AreaType.SquareMile, 0.00156249999927606)]
        [DataRow(AreaType.SquareYard, 4839.99999712962)]
        public async Task AcreConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.Acre, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 2.47105381613712)]
        [DataRow(AreaType.Hectare, 1)]
        [DataRow(AreaType.SquareCentimeter, 100000000)]
        [DataRow(AreaType.SquareDecimeter, 1000000)]
        [DataRow(AreaType.SquareFoot, 107639.104167097)]
        [DataRow(AreaType.SquareInch, 15500031.000062)]
        [DataRow(AreaType.SquareKilometer, 0.01)]
        [DataRow(AreaType.SquareMeter, 10000)]
        [DataRow(AreaType.SquareMile, 0.00386102158592535)]
        [DataRow(AreaType.SquareYard, 11959.9004630108)]
        public async Task HectareConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.Hectare, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 2.47105381613712e-08)]
        [DataRow(AreaType.Hectare, 1e-08)]
        [DataRow(AreaType.SquareCentimeter, 1)]
        [DataRow(AreaType.SquareDecimeter, 0.01)]
        [DataRow(AreaType.SquareFoot, 0.00107639104167097)]
        [DataRow(AreaType.SquareInch, 0.15500031000062)]
        [DataRow(AreaType.SquareKilometer, 1e-10)]
        [DataRow(AreaType.SquareMeter, 0.0001)]
        [DataRow(AreaType.SquareMile, 3.86102158592535e-11)]
        [DataRow(AreaType.SquareYard, 0.000119599004630108)]
        public async Task SquareCentimeterConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareCentimeter, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 2.47105381613712e-06)]
        [DataRow(AreaType.Hectare, 1e-06)]
        [DataRow(AreaType.SquareCentimeter, 100)]
        [DataRow(AreaType.SquareDecimeter, 1)]
        [DataRow(AreaType.SquareFoot, 0.107639104167097)]
        [DataRow(AreaType.SquareInch, 15.500031000062)]
        [DataRow(AreaType.SquareKilometer, 1e-08)]
        [DataRow(AreaType.SquareMeter, 0.01)]
        [DataRow(AreaType.SquareMile, 3.86102158592535e-09)]
        [DataRow(AreaType.SquareYard, 0.0119599004630108)]
        public async Task SquareDecimeterConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareDecimeter, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 2.29568411522739E-05)]
        [DataRow(AreaType.Hectare, 9.290304E-06)]
        [DataRow(AreaType.SquareCentimeter, 929.0304)]
        [DataRow(AreaType.SquareDecimeter, 9.290304)]
        [DataRow(AreaType.SquareFoot, 1)]
        [DataRow(AreaType.SquareInch, 144)]
        [DataRow(AreaType.SquareKilometer, 9.290304E-08)]
        [DataRow(AreaType.SquareMeter, 0.09290304)]
        [DataRow(AreaType.SquareMile, 3.58700642838086E-08)]
        [DataRow(AreaType.SquareYard, 0.111111111111111)]
        public async Task SquareFootConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareFoot, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 1.59422508001902e-07)]
        [DataRow(AreaType.Hectare, 6.4516e-08)]
        [DataRow(AreaType.SquareCentimeter, 6.4516)]
        [DataRow(AreaType.SquareDecimeter, 0.064516)]
        [DataRow(AreaType.SquareFoot, 0.00694444444444444)]
        [DataRow(AreaType.SquareInch, 1)]
        [DataRow(AreaType.SquareKilometer, 6.4516E-10)]
        [DataRow(AreaType.SquareMeter, 0.00064516)]
        [DataRow(AreaType.SquareMile, 2.4909766863756E-10)]
        [DataRow(AreaType.SquareYard, 0.000771604938271605)]
        public async Task SquareInchConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareInch, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 247.105381613712)]
        [DataRow(AreaType.Hectare, 100)]
        [DataRow(AreaType.SquareCentimeter, 10000000000)]
        [DataRow(AreaType.SquareDecimeter, 100000000)]
        [DataRow(AreaType.SquareFoot, 10763910.4167097)]
        [DataRow(AreaType.SquareInch, 1550003100.0062)]
        [DataRow(AreaType.SquareKilometer, 1)]
        [DataRow(AreaType.SquareMeter, 1000000)]
        [DataRow(AreaType.SquareMile, 0.386102158592535)]
        [DataRow(AreaType.SquareYard, 1195990.04630108)]
        public async Task SquareKilometerConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareKilometer, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 0.000247105381613712)]
        [DataRow(AreaType.Hectare, 0.0001)]
        [DataRow(AreaType.SquareCentimeter, 10000)]
        [DataRow(AreaType.SquareDecimeter, 100)]
        [DataRow(AreaType.SquareFoot, 10.7639104167097)]
        [DataRow(AreaType.SquareInch, 1550.0031000062)]
        [DataRow(AreaType.SquareKilometer, 0.000001)]
        [DataRow(AreaType.SquareMeter, 1)]
        [DataRow(AreaType.SquareMile, 0.000000386102158592535)]
        [DataRow(AreaType.SquareYard, 1.19599004630108)]
        public async Task SquareMeterConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareMeter, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 640.000000296526)]
        [DataRow(AreaType.Hectare, 258.998811)]
        [DataRow(AreaType.SquareCentimeter, 25899881100)]
        [DataRow(AreaType.SquareDecimeter, 258998811)]
        [DataRow(AreaType.SquareFoot, 27878399.9963833)]
        [DataRow(AreaType.SquareInch, 4014489599.4792)]
        [DataRow(AreaType.SquareKilometer, 2.58998811)]
        [DataRow(AreaType.SquareMeter, 2589988.11)]
        [DataRow(AreaType.SquareMile, 1)]
        [DataRow(AreaType.SquareYard, 3097599.99959815)]
        public async Task SquareMileConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareMile, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(AreaType.Acre, 0.000206611570370465)]
        [DataRow(AreaType.Hectare, 8.3612736e-05)]
        [DataRow(AreaType.SquareCentimeter, 8361.2736)]
        [DataRow(AreaType.SquareDecimeter, 83.612736)]
        [DataRow(AreaType.SquareFoot, 9)]
        [DataRow(AreaType.SquareInch, 1296)]
        [DataRow(AreaType.SquareKilometer, 8.3612736E-07)]
        [DataRow(AreaType.SquareMeter, 0.83612736)]
        [DataRow(AreaType.SquareMile, 3.22830578554278E-07)]
        [DataRow(AreaType.SquareYard, 1)]
        public async Task SquareYardConversions(AreaType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(AreaType.SquareYard, to);
            AssertEx.WithinTolerance(expected, conversionFactor);
        }

        private static async Task<double> GetConversionFactor(AreaType from, AreaType to)
        {
            var quantityValue = Quantity.Area.CreateValue(value: 1, from);
            var convertedValue = await Quantity.Area.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
