using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Substance
{
    [TestClass]
    public class SubstanceConversionImplementationCheck
    {
        [TestMethod]
        public void ShouldConvertAllSubstanceCombinationsIntoAllOtherSubstanceCombinations()
        {
            foreach (SubstanceType fromSubstanceType in Enum.GetValues(typeof(SubstanceType)))
            {
                var fromValue = Quantity.Substance.CreateValue(DateTime.Now, value: 1, fromSubstanceType);

                foreach (SubstanceType toSubstanceType in Enum.GetValues(typeof(SubstanceType)))
                {
                    var toUnit = Quantity.Substance.GetUnit(toSubstanceType);
                    var toValue = fromValue.As(toUnit);

                    Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromSubstanceType} to {toSubstanceType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}