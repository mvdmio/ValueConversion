using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities;

public class ConversionImplementationCheckBase
{
    protected void TestQuantityConversionImplementation(IQuantity quantity)
    {
        foreach (var fromUnit in quantity.GetUnits())
        {
            var fromValue = quantity.CreateValue(DateTime.Now, 1, fromUnit);

            foreach (var toUnit in quantity.GetUnits())
            {
                var toValue = fromValue.As(toUnit);

                Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromUnit.Identifier} to {toUnit.Identifier} did not result in equal quantities.");

                var conversionFactor = toValue.GetValue();
                var expected = fromValue.GetValue() * conversionFactor;
                var actual = toValue.GetValue();

                Assert.AreEqual(expected, actual);
            }
        }
    }
}