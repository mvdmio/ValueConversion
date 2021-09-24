using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Angle
{
    [TestClass]
    public class AngleConversionImplementationCheck : ConversionImplementationCheckBase
    {
        [TestMethod]
        public async Task ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
        {
            await TestQuantityConversionImplementation(Quantity.Angle);
        }
    }
}