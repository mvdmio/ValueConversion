﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.ElectricConductivity;

[TestClass]
public class ElectricConductivityConversionTests
{
    [TestMethod]
    public void ShouldConvertToStandardUnitCorrectly()
    {
        var milliSiemensPerCentimeter = Quantity.ElectricConductivity.GetUnit(Quantity.ElectricConductance.GetUnit(ElectricConductanceType.Millisiemens), Quantity.Known.Distance().GetUnit(DistanceType.Centimeter));
            
        var value = Quantity.ElectricConductivity.CreateValue(5, milliSiemensPerCentimeter);
        var standardUnitValue = value.GetStandardValue();

        Assert.AreEqual(0.5, standardUnitValue);
    }

    [TestMethod]
    public void ShouldConvertFromStandardUnitCorrectly()
    {
        var milliSiemensPerCentimeter = Quantity.ElectricConductivity.GetUnit(Quantity.ElectricConductance.GetUnit(ElectricConductanceType.Millisiemens), Quantity.Known.Distance().GetUnit(DistanceType.Centimeter));
            
        var value = Quantity.ElectricConductivity.CreateValue(0.5, Quantity.ElectricConductivity.StandardUnit);
        var milliSiemensPerCentimeterValue = value.As(milliSiemensPerCentimeter);

        Assert.AreEqual(5, milliSiemensPerCentimeterValue.GetValue());
    }
}