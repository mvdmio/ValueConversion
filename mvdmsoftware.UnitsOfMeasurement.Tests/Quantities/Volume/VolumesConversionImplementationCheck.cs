using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Volume
{
    [TestClass]
    public class VolumeConversionImplementationCheck
    {
        [TestMethod]
        public void ShouldConvertAllVolumeCombinationsIntoAllOtherVolumeCombinations()
        {
            foreach (VolumeType fromVolumeType in Enum.GetValues(typeof(VolumeType)))
            {
                var fromValue = Quantity.Volume.CreateValue(DateTime.Now, value: 1, fromVolumeType);

                foreach (VolumeType toVolumeType in Enum.GetValues(typeof(VolumeType)))
                {
                    var toUnit = Quantity.Volume.GetUnit(toVolumeType);
                    var toValue = fromValue.As(toUnit);

                    Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromVolumeType} to {toVolumeType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}