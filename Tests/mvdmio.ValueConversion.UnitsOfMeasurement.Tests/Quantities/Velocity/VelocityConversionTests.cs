using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Velocity;


public class VelocityConversionTests
{
    [Fact]
    public void ShouldConvertCentimeterPerWeekToStandardUnitCorrectly()
    {
        var centimeterPerWeek = Quantity.Known.Velocity().GetUnit(Quantity.Known.Distance().GetUnit("Centimeter").Identifier, Quantity.Known.Duration().GetUnit("Week").Identifier);
            
        var value = Quantity.Known.Velocity().CreateValue(12, centimeterPerWeek);
        var standardUnitValue = value.GetStandardValue();

        Assert.Equal(1.9841269841269841E-07, standardUnitValue);
    }

    [Fact]
    public void ShouldConvertKilometerPerHourToStandardUnitCorrectly()
    {
        var kilometerPerHour = Quantity.Known.Velocity().GetUnit(Quantity.Known.Distance().GetUnit("Kilometer").Identifier, Quantity.Known.Duration().GetUnit("Hour").Identifier);
            
        var value = Quantity.Known.Velocity().CreateValue(100, kilometerPerHour);
        var standardUnitValue = value.GetStandardValue();

        Assert.Equal(27.77777777777778, standardUnitValue);
    }

    [Fact]
    public void ShouldConvertStandardUnitToKilometerPerHourCorrectly()
    {
        var standardUnit = Quantity.Known.Velocity().StandardUnit;
        var kilometerPerHour = Quantity.Known.Velocity().GetUnit(Quantity.Known.Distance().GetUnit("Kilometer").Identifier, Quantity.Known.Duration().GetUnit("Hour").Identifier);
            
        var value = Quantity.Known.Velocity().CreateValue(27.77777777777778, standardUnit);
        var kilometerPerHourValue = value.As(kilometerPerHour);

        Assert.Equal(100, kilometerPerHourValue.GetValue());
    }
}