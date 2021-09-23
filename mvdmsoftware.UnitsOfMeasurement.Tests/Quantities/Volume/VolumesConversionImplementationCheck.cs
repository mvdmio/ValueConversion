using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.Test.Common;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Tests.Quantities.Volume
{
    [TestClass]
    public class VolumeConversionImplementationCheck
    {
        [TestMethod]
        public async Task ShouldConvertAllVolumeCombinationsIntoAllOtherVolumeCombinations()
        {
            foreach (VolumeType fromVolumeType in Enum.GetValues(typeof(VolumeType)))
            {
                var fromValue = Quantity.Volume.CreateValue(DateTime.Now, value: 1, fromVolumeType);

                foreach (VolumeType toVolumeType in Enum.GetValues(typeof(VolumeType)))
                {
                    var toUnit = Quantity.Volume.GetUnit(toVolumeType);
                    var toValue = await fromValue.As(toUnit);

                    Assert.IsTrue(await fromValue.IsEqualTo(toValue), $"Conversion from {fromVolumeType} to {toVolumeType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    AssertEx.WithinTolerance(expected, actual);
                }
            }
        }
    }
}