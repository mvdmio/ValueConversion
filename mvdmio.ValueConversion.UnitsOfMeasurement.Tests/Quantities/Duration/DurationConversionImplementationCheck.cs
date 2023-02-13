using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Duration;

[TestClass]
public class DurationConversionImplementationCheck
{
    [TestMethod]
    public void ShouldConvertAllAreaCombinationsIntoAllOtherAreaCombinations()
    {
        foreach (AreaType fromAreaType in Enum.GetValues(typeof(AreaType)))
        {
            var fromValue = "Area".CreateValue(DateTime.Now, 1, fromAreaType);

            foreach (AreaType toAreaType in Enum.GetValues(typeof(AreaType)))
            {
                var toUnit = "Area".GetUnit(toAreaType);
                var toValue = fromValue.As(toUnit);

                Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromAreaType} to {toAreaType} did not result in equal quantities.");

                var conversionFactor = toValue.GetValue();
                var expected = fromValue.GetValue() * conversionFactor;
                var actual = toValue.GetValue();

                Assert.AreEqual(expected, actual);
            }
        }
    }
}