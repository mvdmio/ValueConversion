using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.ElectricConductivity;

[TestClass]
public class ElectricConductivityConversionTests
{
    [TestMethod]
    public void ShouldConvertToStandardUnitCorrectly()
    {
        var milliSiemensPerCentimeter = Quantity.Known.ElectricConductivity().GetUnit(Quantity.Known.ElectricConductance().GetUnit("Millisiemens").Identifier, Quantity.Known.Distance().GetUnit("Centimeter").Identifier);
            
        var value = Quantity.Known.ElectricConductivity().CreateValue(5, milliSiemensPerCentimeter);
        var standardUnitValue = value.GetStandardValue();

        Assert.AreEqual(0.5d, standardUnitValue);
    }

    [TestMethod]
    public void ShouldConvertFromStandardUnitCorrectly()
    {
        var milliSiemensPerCentimeter = Quantity.Known.ElectricConductivity().GetUnit(Quantity.Known.ElectricConductance().GetUnit("Millisiemens").Identifier, Quantity.Known.Distance().GetUnit("Centimeter").Identifier);
            
        var value = Quantity.Known.ElectricConductivity().CreateValue(0.5, Quantity.Known.ElectricConductivity().StandardUnit);
        var milliSiemensPerCentimeterValue = value.As(milliSiemensPerCentimeter);

        Assert.AreEqual(5, milliSiemensPerCentimeterValue.GetValue());
    }
}