using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Duration
{
    [TestClass]
    public class DurationConversionFactorTests
    {
        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 1)]
        [DataRow(DurationType.Millisecond, 1E-06)]
        [DataRow(DurationType.Second, 1E-09)]
        [DataRow(DurationType.Minute, 1.66666666666667E-11)]
        [DataRow(DurationType.Hour, 2.77777777777778E-13)]
        [DataRow(DurationType.Day, 1.15740740740741E-14)]
        [DataRow(DurationType.Week, 1.65343915343915E-15)]
        [DataRow(DurationType.Month, 3.80265175866959E-16)]
        [DataRow(DurationType.Quarter, 1.2675505862232E-16)]
        [DataRow(DurationType.Year, 3.16887646154128E-17)]
        [DataRow(DurationType.Decade, 3.16887646154128E-18)]
        [DataRow(DurationType.Century, 3.16887646154128E-19)]
        public async Task NanosecondConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Nanosecond, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 1000000)]
        [DataRow(DurationType.Millisecond, 1)]
        [DataRow(DurationType.Second, 0.001)]
        [DataRow(DurationType.Minute, 1.66666666666667E-05)]
        [DataRow(DurationType.Hour, 2.77777777777778E-07)]
        [DataRow(DurationType.Day, 1.15740740740741E-08)]
        [DataRow(DurationType.Week, 1.65343915343915E-09)]
        [DataRow(DurationType.Month, 3.80265175866959E-10)]
        [DataRow(DurationType.Quarter, 1.2675505862232E-10)]
        [DataRow(DurationType.Year, 3.16887646154128E-11)]
        [DataRow(DurationType.Decade, 3.16887646154128E-12)]
        [DataRow(DurationType.Century, 3.16887646154128E-13)]
        public async Task MillisecondConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Millisecond, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 1000000000)]
        [DataRow(DurationType.Millisecond, 1000)]
        [DataRow(DurationType.Second, 1)]
        [DataRow(DurationType.Minute, 0.0166666666666667)]
        [DataRow(DurationType.Hour, 0.000277777777777778)]
        [DataRow(DurationType.Day, 1.15740740740741E-05)]
        [DataRow(DurationType.Week, 1.65343915343915E-06)]
        [DataRow(DurationType.Month, 3.80265175866959E-07)]
        [DataRow(DurationType.Quarter, 1.2675505862232E-07)]
        [DataRow(DurationType.Year, 3.16887646154128E-08)]
        [DataRow(DurationType.Decade, 3.16887646154128E-09)]
        [DataRow(DurationType.Century, 3.16887646154128E-10)]
        public async Task SecondConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Second, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 60000000000)]
        [DataRow(DurationType.Millisecond, 60000)]
        [DataRow(DurationType.Second, 60)]
        [DataRow(DurationType.Minute, 1)]
        [DataRow(DurationType.Hour, 0.0166666666666667)]
        [DataRow(DurationType.Day, 0.000694444444444444)]
        [DataRow(DurationType.Week, 9.92063492063492E-05)]
        [DataRow(DurationType.Month, 2.28159105520175E-05)]
        [DataRow(DurationType.Quarter, 7.60530351733918E-06)]
        [DataRow(DurationType.Year, 1.90132587692477E-06)]
        [DataRow(DurationType.Decade, 1.90132587692477E-07)]
        [DataRow(DurationType.Century, 1.90132587692477E-08)]
        public async Task MinuteConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Minute, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 3600000000000)]
        [DataRow(DurationType.Millisecond, 3600000)]
        [DataRow(DurationType.Second, 3600)]
        [DataRow(DurationType.Minute, 60)]
        [DataRow(DurationType.Hour, 1)]
        [DataRow(DurationType.Day, 0.0416666666666667)]
        [DataRow(DurationType.Week, 0.00595238095238095)]
        [DataRow(DurationType.Month, 0.00136895463312105)]
        [DataRow(DurationType.Quarter, 0.000456318211040351)]
        [DataRow(DurationType.Year, 0.000114079552615486)]
        [DataRow(DurationType.Decade, 1.14079552615486E-05)]
        [DataRow(DurationType.Century, 1.14079552615486E-06)]
        public async Task HourConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Hour, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 86400000000000)]
        [DataRow(DurationType.Millisecond, 86400000)]
        [DataRow(DurationType.Second, 86400)]
        [DataRow(DurationType.Minute, 1440)]
        [DataRow(DurationType.Hour, 24)]
        [DataRow(DurationType.Day, 1)]
        [DataRow(DurationType.Week, 0.142857142857143)]
        [DataRow(DurationType.Month, 0.0328549111949052)]
        [DataRow(DurationType.Quarter, 0.0109516370649684)]
        [DataRow(DurationType.Year, 0.00273790926277167)]
        [DataRow(DurationType.Decade, 0.000273790926277167)]
        [DataRow(DurationType.Century, 2.73790926277167E-05)]
        public async Task DayConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Day, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 604800000000000)]
        [DataRow(DurationType.Millisecond, 604800000)]
        [DataRow(DurationType.Second, 604800)]
        [DataRow(DurationType.Minute, 10080)]
        [DataRow(DurationType.Hour, 168)]
        [DataRow(DurationType.Day, 7)]
        [DataRow(DurationType.Week, 1)]
        [DataRow(DurationType.Month, 0.229984378364337)]
        [DataRow(DurationType.Quarter, 0.0766614594547789)]
        [DataRow(DurationType.Year, 0.0191653648394017)]
        [DataRow(DurationType.Decade, 0.00191653648394017)]
        [DataRow(DurationType.Century, 0.000191653648394017)]
        public async Task WeekConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Week, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 2.62974383E+15)]
        [DataRow(DurationType.Millisecond, 2629743830)]
        [DataRow(DurationType.Second, 2629743.83)]
        [DataRow(DurationType.Minute, 43829.0638333333)]
        [DataRow(DurationType.Hour, 730.484397222222)]
        [DataRow(DurationType.Day, 30.4368498842593)]
        [DataRow(DurationType.Week, 4.34812141203704)]
        [DataRow(DurationType.Month, 1)]
        [DataRow(DurationType.Quarter, 0.333333333333333)]
        [DataRow(DurationType.Year, 0.0833333332277041)]
        [DataRow(DurationType.Decade, 0.00833333332277041)]
        [DataRow(DurationType.Century, 0.000833333332277041)]
        public async Task MonthConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Month, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 7.88923149E+15)]
        [DataRow(DurationType.Millisecond, 7889231490)]
        [DataRow(DurationType.Second, 7889231.49)]
        [DataRow(DurationType.Minute, 131487.1915)]
        [DataRow(DurationType.Hour, 2191.45319166667)]
        [DataRow(DurationType.Day, 91.3105496527778)]
        [DataRow(DurationType.Week, 13.0443642361111)]
        [DataRow(DurationType.Month, 3)]
        [DataRow(DurationType.Quarter, 1)]
        [DataRow(DurationType.Year, 0.249999999683112)]
        [DataRow(DurationType.Decade, 0.0249999999683112)]
        [DataRow(DurationType.Century, 0.00249999999683112)]
        public async Task QuarterConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Quarter, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 3.1556926E+16)]
        [DataRow(DurationType.Millisecond, 31556926000)]
        [DataRow(DurationType.Second, 31556926)]
        [DataRow(DurationType.Minute, 525948.766666667)]
        [DataRow(DurationType.Hour, 8765.81277777778)]
        [DataRow(DurationType.Day, 365.242199074074)]
        [DataRow(DurationType.Week, 52.177457010582)]
        [DataRow(DurationType.Month, 12.0000000152106)]
        [DataRow(DurationType.Quarter, 4.0000000050702)]
        [DataRow(DurationType.Year, 1)]
        [DataRow(DurationType.Decade, 0.1)]
        [DataRow(DurationType.Century, 0.01)]
        public async Task YearConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Year, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 3.1556926E+17)]
        [DataRow(DurationType.Millisecond, 315569260000)]
        [DataRow(DurationType.Second, 315569260)]
        [DataRow(DurationType.Minute, 5259487.66666667)]
        [DataRow(DurationType.Hour, 87658.1277777778)]
        [DataRow(DurationType.Day, 3652.42199074074)]
        [DataRow(DurationType.Week, 521.77457010582)]
        [DataRow(DurationType.Month, 120.000000152106)]
        [DataRow(DurationType.Quarter, 40.000000050702)]
        [DataRow(DurationType.Year, 10)]
        [DataRow(DurationType.Decade, 1)]
        [DataRow(DurationType.Century, 0.1)]
        public async Task DecadeConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Decade, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        [DataTestMethod]
        [DataRow(DurationType.Nanosecond, 3.1556926E+18)]
        [DataRow(DurationType.Millisecond, 3155692600000)]
        [DataRow(DurationType.Second, 3155692600)]
        [DataRow(DurationType.Minute, 52594876.6666667)]
        [DataRow(DurationType.Hour, 876581.277777778)]
        [DataRow(DurationType.Day, 36524.2199074074)]
        [DataRow(DurationType.Week, 5217.7457010582)]
        [DataRow(DurationType.Month, 1200.00000152106)]
        [DataRow(DurationType.Quarter, 400.00000050702)]
        [DataRow(DurationType.Year, 100)]
        [DataRow(DurationType.Decade, 10)]
        [DataRow(DurationType.Century, 1)]
        public async Task CenturyConversions(DurationType to, double expected)
        {
            var conversionFactor = await GetConversionFactor(DurationType.Century, to);
            AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
        }

        private static async Task<double> GetConversionFactor(DurationType from, DurationType to)
        {
            var quantityValue = Quantity.Duration.CreateValue(value: 1, from);
            var convertedValue = await Quantity.Duration.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
