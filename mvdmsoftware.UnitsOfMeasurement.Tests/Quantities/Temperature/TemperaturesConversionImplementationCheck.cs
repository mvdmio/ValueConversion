using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Temperature
{
    [TestClass]
    public class TemperaturesConversionImplementationCheck
    {
        [TestMethod]
        public void ShouldConvertAllVolumeCombinationsIntoAllOtherVolumeCombinations()
        {
            foreach (TemperatureType fromVolumeType in Enum.GetValues(typeof(TemperatureType)))
            {
                var fromValue = Quantity.Temperature.CreateValue(DateTime.Now, value: 1, fromVolumeType);

                foreach (TemperatureType toVolumeType in Enum.GetValues(typeof(TemperatureType)))
                {
                    var toUnit = Quantity.Temperature.GetUnit(toVolumeType);
                    var toValue = fromValue.As(toUnit);

                    Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromVolumeType} to {toVolumeType} did not result in equal quantities.");
                }
            }
        }
    }
}