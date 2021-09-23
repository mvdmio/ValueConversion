using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Mass
{
    [TestClass]
    public class MassConversionImplementationCheck
    {
        [TestMethod]
        public async Task ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
        {
            foreach (MassType fromType in Enum.GetValues(typeof(MassType)))
            {
                var fromValue = Quantity.Mass.CreateValue(DateTime.Now, value: 1, fromType);

                foreach (MassType toAreaType in Enum.GetValues(typeof(MassType)))
                {
                    var toUnit = Quantity.Mass.GetUnit(toAreaType);
                    var toValue = await fromValue.As(toUnit);

                    Assert.IsTrue(await fromValue.IsEqualTo(toValue), $"Conversion from {fromType} to {toAreaType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}