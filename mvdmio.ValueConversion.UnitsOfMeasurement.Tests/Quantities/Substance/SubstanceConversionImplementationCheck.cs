using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Substance;

[TestClass]
public class SubstanceConversionImplementationCheck
{
    [TestMethod]
    public void ShouldConvertAllSubstanceCombinationsIntoAllOtherSubstanceCombinations()
    {
        foreach (var fromUnit in Quantity.Known.Substance().GetUnits())
        {
            var fromValue = Quantity.Known.Substance().CreateValue(DateTime.Now, value: 1, fromUnit);

            foreach (var toUnit in Quantity.Known.Substance().GetUnits())
            {
                var toValue = fromValue.As(toUnit);

                Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromUnit} to {toUnit} did not result in equal quantities.");

                var conversionFactor = toValue.GetValue();
                var expected = fromValue.GetValue() * conversionFactor;
                var actual = toValue.GetValue();

                Assert.AreEqual(expected, actual);
            }
        }
    }
}