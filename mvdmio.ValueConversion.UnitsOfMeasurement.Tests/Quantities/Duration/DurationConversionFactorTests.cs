using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Duration;

[TestClass]
public class DurationConversionFactorTests
{
    [DataTestMethod]
    [DataRow("Nanosecond", 1)]
    [DataRow("Millisecond", 1E-06)]
    [DataRow("Second", 1E-09)]
    [DataRow("Minute", 1.66666666666667E-11)]
    [DataRow("Hour", 2.77777777777778E-13)]
    [DataRow("Day", 1.15740740740741E-14)]
    [DataRow("Week", 1.65343915343915E-15)]
    [DataRow("Month", 3.80265175866959E-16)]
    [DataRow("Quarter", 1.2675505862232E-16)]
    [DataRow("Year", 3.16887646154128E-17)]
    [DataRow("Decade", 3.16887646154128E-18)]
    [DataRow("Century", 3.16887646154128E-19)]
    public void NanosecondConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Nanosecond", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 1000000)]
    [DataRow("Millisecond", 1)]
    [DataRow("Second", 0.001)]
    [DataRow("Minute", 1.66666666666667E-05)]
    [DataRow("Hour", 2.77777777777778E-07)]
    [DataRow("Day", 1.15740740740741E-08)]
    [DataRow("Week", 1.65343915343915E-09)]
    [DataRow("Month", 3.80265175866959E-10)]
    [DataRow("Quarter", 1.2675505862232E-10)]
    [DataRow("Year", 3.16887646154128E-11)]
    [DataRow("Decade", 3.16887646154128E-12)]
    [DataRow("Century", 3.16887646154128E-13)]
    public void MillisecondConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Millisecond", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 1000000000)]
    [DataRow("Millisecond", 1000)]
    [DataRow("Second", 1)]
    [DataRow("Minute", 0.0166666666666667)]
    [DataRow("Hour", 0.000277777777777778)]
    [DataRow("Day", 1.15740740740741E-05)]
    [DataRow("Week", 1.65343915343915E-06)]
    [DataRow("Month", 3.80265175866959E-07)]
    [DataRow("Quarter", 1.2675505862232E-07)]
    [DataRow("Year", 3.16887646154128E-08)]
    [DataRow("Decade", 3.16887646154128E-09)]
    [DataRow("Century", 3.16887646154128E-10)]
    public void SecondConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Second", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 60000000000)]
    [DataRow("Millisecond", 60000)]
    [DataRow("Second", 60)]
    [DataRow("Minute", 1)]
    [DataRow("Hour", 0.0166666666666667)]
    [DataRow("Day", 0.000694444444444444)]
    [DataRow("Week", 9.92063492063492E-05)]
    [DataRow("Month", 2.28159105520175E-05)]
    [DataRow("Quarter", 7.60530351733918E-06)]
    [DataRow("Year", 1.90132587692477E-06)]
    [DataRow("Decade", 1.90132587692477E-07)]
    [DataRow("Century", 1.90132587692477E-08)]
    public void MinuteConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Minute", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 3600000000000)]
    [DataRow("Millisecond", 3600000)]
    [DataRow("Second", 3600)]
    [DataRow("Minute", 60)]
    [DataRow("Hour", 1)]
    [DataRow("Day", 0.0416666666666667)]
    [DataRow("Week", 0.00595238095238095)]
    [DataRow("Month", 0.00136895463312105)]
    [DataRow("Quarter", 0.000456318211040351)]
    [DataRow("Year", 0.000114079552615486)]
    [DataRow("Decade", 1.14079552615486E-05)]
    [DataRow("Century", 1.14079552615486E-06)]
    public void HourConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hour", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 86400000000000)]
    [DataRow("Millisecond", 86400000)]
    [DataRow("Second", 86400)]
    [DataRow("Minute", 1440)]
    [DataRow("Hour", 24)]
    [DataRow("Day", 1)]
    [DataRow("Week", 0.142857142857143)]
    [DataRow("Month", 0.0328549111949052)]
    [DataRow("Quarter", 0.0109516370649684)]
    [DataRow("Year", 0.00273790926277167)]
    [DataRow("Decade", 0.000273790926277167)]
    [DataRow("Century", 2.73790926277167E-05)]
    public void DayConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Day", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 604800000000000)]
    [DataRow("Millisecond", 604800000)]
    [DataRow("Second", 604800)]
    [DataRow("Minute", 10080)]
    [DataRow("Hour", 168)]
    [DataRow("Day", 7)]
    [DataRow("Week", 1)]
    [DataRow("Month", 0.229984378364337)]
    [DataRow("Quarter", 0.0766614594547789)]
    [DataRow("Year", 0.0191653648394017)]
    [DataRow("Decade", 0.00191653648394017)]
    [DataRow("Century", 0.000191653648394017)]
    public void WeekConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Week", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 2.62974383E+15)]
    [DataRow("Millisecond", 2629743830)]
    [DataRow("Second", 2629743.83)]
    [DataRow("Minute", 43829.0638333333)]
    [DataRow("Hour", 730.484397222222)]
    [DataRow("Day", 30.4368498842593)]
    [DataRow("Week", 4.34812141203704)]
    [DataRow("Month", 1)]
    [DataRow("Quarter", 0.333333333333333)]
    [DataRow("Year", 0.0833333332277041)]
    [DataRow("Decade", 0.00833333332277041)]
    [DataRow("Century", 0.000833333332277041)]
    public void MonthConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Month", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 7.88923149E+15)]
    [DataRow("Millisecond", 7889231490)]
    [DataRow("Second", 7889231.49)]
    [DataRow("Minute", 131487.1915)]
    [DataRow("Hour", 2191.45319166667)]
    [DataRow("Day", 91.3105496527778)]
    [DataRow("Week", 13.0443642361111)]
    [DataRow("Month", 3)]
    [DataRow("Quarter", 1)]
    [DataRow("Year", 0.249999999683112)]
    [DataRow("Decade", 0.0249999999683112)]
    [DataRow("Century", 0.00249999999683112)]
    public void QuarterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Quarter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 3.1556926E+16)]
    [DataRow("Millisecond", 31556926000)]
    [DataRow("Second", 31556926)]
    [DataRow("Minute", 525948.766666667)]
    [DataRow("Hour", 8765.81277777778)]
    [DataRow("Day", 365.242199074074)]
    [DataRow("Week", 52.177457010582)]
    [DataRow("Month", 12.0000000152106)]
    [DataRow("Quarter", 4.0000000050702)]
    [DataRow("Year", 1)]
    [DataRow("Decade", 0.1)]
    [DataRow("Century", 0.01)]
    public void YearConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Year", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 3.1556926E+17)]
    [DataRow("Millisecond", 315569260000)]
    [DataRow("Second", 315569260)]
    [DataRow("Minute", 5259487.66666667)]
    [DataRow("Hour", 87658.1277777778)]
    [DataRow("Day", 3652.42199074074)]
    [DataRow("Week", 521.77457010582)]
    [DataRow("Month", 120.000000152106)]
    [DataRow("Quarter", 40.000000050702)]
    [DataRow("Year", 10)]
    [DataRow("Decade", 1)]
    [DataRow("Century", 0.1)]
    public void DecadeConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Decade", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [DataTestMethod]
    [DataRow("Nanosecond", 3.1556926E+18)]
    [DataRow("Millisecond", 3155692600000)]
    [DataRow("Second", 3155692600)]
    [DataRow("Minute", 52594876.6666667)]
    [DataRow("Hour", 876581.277777778)]
    [DataRow("Day", 36524.2199074074)]
    [DataRow("Week", 5217.7457010582)]
    [DataRow("Month", 1200.00000152106)]
    [DataRow("Quarter", 400.00000050702)]
    [DataRow("Year", 100)]
    [DataRow("Decade", 10)]
    [DataRow("Century", 1)]
    public void CenturyConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Century", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    private static double GetConversionFactor(string from, string to)
    {
        var quantityValue = Quantity.Known.Duration().CreateValue(value: 1, from);
        var convertedValue = Quantity.Known.Duration().Convert(quantityValue, to);
        var conversionFactor = convertedValue.GetValue();

        return conversionFactor;
    }
}