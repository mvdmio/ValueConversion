using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Distance
{
    [TestClass]
    public class DistanceConversionImplementationCheck
    {
        [TestMethod]
        public void ShouldConvertAllDistanceCombinationsIntoAllOtherDistanceCombinations()
        {
            foreach (DistanceType fromDistanceType in Enum.GetValues(typeof(DistanceType)))
            {
                var fromValue = Quantity.Distance.CreateValue(DateTime.Now, value: 1, fromDistanceType);

                foreach (DistanceType toDistanceType in Enum.GetValues(typeof(DistanceType)))
                {
                    var toUnit = Quantity.Distance.GetUnit(toDistanceType);
                    var toValue = fromValue.As(toUnit);

                    Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromDistanceType} to {toDistanceType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}