using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Angle
{
    [TestClass]
    public class AngleConversionImplementationCheck : ConversionImplementationCheckBase
    {
        [TestMethod]
        public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
        {
            TestQuantityConversionImplementation(Quantity.Angle);
        }
    }
}