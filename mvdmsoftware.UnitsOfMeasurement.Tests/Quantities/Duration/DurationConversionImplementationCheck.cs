using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Duration
{
    [TestClass]
    public class DurationConversionImplementationCheck
    {
        [TestMethod]
        public async Task ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
        {
            foreach (AreaType fromAreaType in Enum.GetValues(typeof(AreaType)))
            {
                var fromValue = Quantity.Area.CreateValue(DateTime.Now, 1, fromAreaType);

                foreach (AreaType toAreaType in Enum.GetValues(typeof(AreaType)))
                {
                    var toUnit = Quantity.Area.GetUnit(toAreaType);
                    var toValue = await fromValue.As(toUnit);

                    Assert.IsTrue(await fromValue.IsEqualTo(toValue), $"Conversion from {fromAreaType} to {toAreaType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}