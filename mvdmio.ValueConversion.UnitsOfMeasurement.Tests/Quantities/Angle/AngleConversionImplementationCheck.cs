using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Angle;

[TestClass]
public class AngleConversionImplementationCheck : ConversionImplementationCheckBase
{
    [TestMethod]
    public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
    {
        TestQuantityConversionImplementation(Quantity.Known.Angle());
    }
}