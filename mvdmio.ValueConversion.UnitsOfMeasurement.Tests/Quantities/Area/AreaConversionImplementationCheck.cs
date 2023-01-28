using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Area
{
    [TestClass]
    public class AreaConversionImplementationCheck : ConversionImplementationCheckBase
    {
        [TestMethod]
        public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
        {
            TestQuantityConversionImplementation(Quantity.Area);
        }
    }
}