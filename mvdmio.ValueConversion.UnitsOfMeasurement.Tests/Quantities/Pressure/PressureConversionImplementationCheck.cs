using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;
using System;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Pressure
{
    [TestClass]
    public class PressureConversionImplementationCheck
    {
        [TestMethod]
        public void ShouldConvertAllPressureCombinationsIntoAllOtherPressureCombinations()
        {
            foreach (PressureType fromType in Enum.GetValues(typeof(PressureType)))
            {
                var fromValue = Quantity.Pressure.CreateValue(DateTime.Now, value: 1, fromType);

                foreach (PressureType toPressureType in Enum.GetValues(typeof(PressureType)))
                {
                    var toUnit = Quantity.Pressure.GetUnit(toPressureType);
                    var toValue = fromValue.As(toUnit);

                    Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromType} to {toPressureType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
