using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Area
{
    [TestClass]
    public class AreaConversionImplementationCheck : ConversionImplementationCheckBase
    {
        [TestMethod]
        public async Task ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
        {
            await TestQuantityConversionImplementation(Quantity.Area);
        }
    }
}