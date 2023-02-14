using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Velocity;

[TestClass]
public class VelocityConversionTests
{
    [TestMethod]
    public void ShouldConvertCentimeterPerWeekToStandardUnitCorrectly()
    {
        var centimeterPerWeek = Quantity.Known.Velocity().GetUnit(Quantity.Known.Distance().GetUnit("Centimeter").Identifier, Quantity.Known.Duration().GetUnit("Week").Identifier);
            
        var value = Quantity.Known.Velocity().CreateValue(12, centimeterPerWeek);
        var standardUnitValue = value.GetStandardValue();

        Assert.AreEqual(1.9841269841269841E-07, standardUnitValue);
    }

    [TestMethod]
    public void ShouldConvertKilometerPerHourToStandardUnitCorrectly()
    {
        var kilometerPerHour = Quantity.Known.Velocity().GetUnit(Quantity.Known.Distance().GetUnit("Kilometer").Identifier, Quantity.Known.Duration().GetUnit("Hour").Identifier);
            
        var value = Quantity.Known.Velocity().CreateValue(100, kilometerPerHour);
        var standardUnitValue = value.GetStandardValue();

        Assert.AreEqual(27.77777777777778, standardUnitValue);
    }

    [TestMethod]
    public void ShouldConvertStandardUnitToKilometerPerHourCorrectly()
    {
        var standardUnit = Quantity.Known.Velocity().StandardUnit;
        var kilometerPerHour = Quantity.Known.Velocity().GetUnit(Quantity.Known.Distance().GetUnit("Kilometer").Identifier, Quantity.Known.Duration().GetUnit("Hour").Identifier);
            
        var value = Quantity.Known.Velocity().CreateValue(27.77777777777778, standardUnit);
        var kilometerPerHourValue = value.As(kilometerPerHour);

        Assert.AreEqual(100, kilometerPerHourValue.GetValue());
    }
}