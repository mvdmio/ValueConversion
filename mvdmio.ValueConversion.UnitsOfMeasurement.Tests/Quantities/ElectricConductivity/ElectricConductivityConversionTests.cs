using mvdmio.ValueConversion.Base;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.ElectricConductivity;


public class ElectricConductivityConversionTests
{
    [Fact]
    public void ShouldConvertToStandardUnitCorrectly()
    {
        var milliSiemensPerCentimeter = Quantity.Known.ElectricConductivity().GetUnit(Quantity.Known.ElectricConductance().GetUnit("Millisiemens").Identifier, Quantity.Known.Distance().GetUnit("Centimeter").Identifier);
            
        var value = Quantity.Known.ElectricConductivity().CreateValue(5, milliSiemensPerCentimeter);
        var standardUnitValue = value.GetStandardValue();

        Assert.Equal(0.5d, standardUnitValue);
    }

    [Fact]
    public void ShouldConvertFromStandardUnitCorrectly()
    {
        var milliSiemensPerCentimeter = Quantity.Known.ElectricConductivity().GetUnit(Quantity.Known.ElectricConductance().GetUnit("Millisiemens").Identifier, Quantity.Known.Distance().GetUnit("Centimeter").Identifier);
            
        var value = Quantity.Known.ElectricConductivity().CreateValue(0.5, Quantity.Known.ElectricConductivity().StandardUnit);
        var milliSiemensPerCentimeterValue = value.As(milliSiemensPerCentimeter);

        Assert.Equal(5, milliSiemensPerCentimeterValue.GetValue());
    }
}