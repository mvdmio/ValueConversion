using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Area
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