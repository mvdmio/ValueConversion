using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Duration;


public class DurationConversionFactorTests
{
    [Theory]
    [InlineData("Nanosecond", 1)]
    [InlineData("Millisecond", 1E-06)]
    [InlineData("Second", 1E-09)]
    [InlineData("Minute", 1.66666666666667E-11)]
    [InlineData("Hour", 2.77777777777778E-13)]
    [InlineData("Day", 1.15740740740741E-14)]
    [InlineData("Week", 1.65343915343915E-15)]
    [InlineData("Month", 3.80265175866959E-16)]
    [InlineData("Quarter", 1.2675505862232E-16)]
    [InlineData("Year", 3.16887646154128E-17)]
    [InlineData("Decade", 3.16887646154128E-18)]
    [InlineData("Century", 3.16887646154128E-19)]
    public void NanosecondConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Nanosecond", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 1000000)]
    [InlineData("Millisecond", 1)]
    [InlineData("Second", 0.001)]
    [InlineData("Minute", 1.66666666666667E-05)]
    [InlineData("Hour", 2.77777777777778E-07)]
    [InlineData("Day", 1.15740740740741E-08)]
    [InlineData("Week", 1.65343915343915E-09)]
    [InlineData("Month", 3.80265175866959E-10)]
    [InlineData("Quarter", 1.2675505862232E-10)]
    [InlineData("Year", 3.16887646154128E-11)]
    [InlineData("Decade", 3.16887646154128E-12)]
    [InlineData("Century", 3.16887646154128E-13)]
    public void MillisecondConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Millisecond", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 1000000000)]
    [InlineData("Millisecond", 1000)]
    [InlineData("Second", 1)]
    [InlineData("Minute", 0.0166666666666667)]
    [InlineData("Hour", 0.000277777777777778)]
    [InlineData("Day", 1.15740740740741E-05)]
    [InlineData("Week", 1.65343915343915E-06)]
    [InlineData("Month", 3.80265175866959E-07)]
    [InlineData("Quarter", 1.2675505862232E-07)]
    [InlineData("Year", 3.16887646154128E-08)]
    [InlineData("Decade", 3.16887646154128E-09)]
    [InlineData("Century", 3.16887646154128E-10)]
    public void SecondConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Second", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 60000000000)]
    [InlineData("Millisecond", 60000)]
    [InlineData("Second", 60)]
    [InlineData("Minute", 1)]
    [InlineData("Hour", 0.0166666666666667)]
    [InlineData("Day", 0.000694444444444444)]
    [InlineData("Week", 9.92063492063492E-05)]
    [InlineData("Month", 2.28159105520175E-05)]
    [InlineData("Quarter", 7.60530351733918E-06)]
    [InlineData("Year", 1.90132587692477E-06)]
    [InlineData("Decade", 1.90132587692477E-07)]
    [InlineData("Century", 1.90132587692477E-08)]
    public void MinuteConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Minute", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 3600000000000)]
    [InlineData("Millisecond", 3600000)]
    [InlineData("Second", 3600)]
    [InlineData("Minute", 60)]
    [InlineData("Hour", 1)]
    [InlineData("Day", 0.0416666666666667)]
    [InlineData("Week", 0.00595238095238095)]
    [InlineData("Month", 0.00136895463312105)]
    [InlineData("Quarter", 0.000456318211040351)]
    [InlineData("Year", 0.000114079552615486)]
    [InlineData("Decade", 1.14079552615486E-05)]
    [InlineData("Century", 1.14079552615486E-06)]
    public void HourConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Hour", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 86400000000000)]
    [InlineData("Millisecond", 86400000)]
    [InlineData("Second", 86400)]
    [InlineData("Minute", 1440)]
    [InlineData("Hour", 24)]
    [InlineData("Day", 1)]
    [InlineData("Week", 0.142857142857143)]
    [InlineData("Month", 0.0328549111949052)]
    [InlineData("Quarter", 0.0109516370649684)]
    [InlineData("Year", 0.00273790926277167)]
    [InlineData("Decade", 0.000273790926277167)]
    [InlineData("Century", 2.73790926277167E-05)]
    public void DayConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Day", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 604800000000000)]
    [InlineData("Millisecond", 604800000)]
    [InlineData("Second", 604800)]
    [InlineData("Minute", 10080)]
    [InlineData("Hour", 168)]
    [InlineData("Day", 7)]
    [InlineData("Week", 1)]
    [InlineData("Month", 0.229984378364337)]
    [InlineData("Quarter", 0.0766614594547789)]
    [InlineData("Year", 0.0191653648394017)]
    [InlineData("Decade", 0.00191653648394017)]
    [InlineData("Century", 0.000191653648394017)]
    public void WeekConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Week", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 2.62974383E+15)]
    [InlineData("Millisecond", 2629743830)]
    [InlineData("Second", 2629743.83)]
    [InlineData("Minute", 43829.0638333333)]
    [InlineData("Hour", 730.484397222222)]
    [InlineData("Day", 30.4368498842593)]
    [InlineData("Week", 4.34812141203704)]
    [InlineData("Month", 1)]
    [InlineData("Quarter", 0.333333333333333)]
    [InlineData("Year", 0.0833333332277041)]
    [InlineData("Decade", 0.00833333332277041)]
    [InlineData("Century", 0.000833333332277041)]
    public void MonthConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Month", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 7.88923149E+15)]
    [InlineData("Millisecond", 7889231490)]
    [InlineData("Second", 7889231.49)]
    [InlineData("Minute", 131487.1915)]
    [InlineData("Hour", 2191.45319166667)]
    [InlineData("Day", 91.3105496527778)]
    [InlineData("Week", 13.0443642361111)]
    [InlineData("Month", 3)]
    [InlineData("Quarter", 1)]
    [InlineData("Year", 0.249999999683112)]
    [InlineData("Decade", 0.0249999999683112)]
    [InlineData("Century", 0.00249999999683112)]
    public void QuarterConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Quarter", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 3.1556926E+16)]
    [InlineData("Millisecond", 31556926000)]
    [InlineData("Second", 31556926)]
    [InlineData("Minute", 525948.766666667)]
    [InlineData("Hour", 8765.81277777778)]
    [InlineData("Day", 365.242199074074)]
    [InlineData("Week", 52.177457010582)]
    [InlineData("Month", 12.0000000152106)]
    [InlineData("Quarter", 4.0000000050702)]
    [InlineData("Year", 1)]
    [InlineData("Decade", 0.1)]
    [InlineData("Century", 0.01)]
    public void YearConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Year", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 3.1556926E+17)]
    [InlineData("Millisecond", 315569260000)]
    [InlineData("Second", 315569260)]
    [InlineData("Minute", 5259487.66666667)]
    [InlineData("Hour", 87658.1277777778)]
    [InlineData("Day", 3652.42199074074)]
    [InlineData("Week", 521.77457010582)]
    [InlineData("Month", 120.000000152106)]
    [InlineData("Quarter", 40.000000050702)]
    [InlineData("Year", 10)]
    [InlineData("Decade", 1)]
    [InlineData("Century", 0.1)]
    public void DecadeConversions(string to, double expected)
    {
        var conversionFactor = GetConversionFactor("Decade", to);
        AssertExtensions.AreWithinPercentTolerance(expected, conversionFactor);
    }

    [Theory]
    [InlineData("Nanosecond", 3.1556926E+18)]
    [InlineData("Millisecond", 3155692600000)]
    [InlineData("Second", 3155692600)]
    [InlineData("Minute", 52594876.6666667)]
    [InlineData("Hour", 876581.277777778)]
    [InlineData("Day", 36524.2199074074)]
    [InlineData("Week", 5217.7457010582)]
    [InlineData("Month", 1200.00000152106)]
    [InlineData("Quarter", 400.00000050702)]
    [InlineData("Year", 100)]
    [InlineData("Decade", 10)]
    [InlineData("Century", 1)]
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