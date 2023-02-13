using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Area;

[TestClass]
public class AreaConversionImplementationCheck : ConversionImplementationCheckBase
{
    [TestMethod]
    public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
    {
        TestQuantityConversionImplementation(Quantity.Known.Area());
    }
}