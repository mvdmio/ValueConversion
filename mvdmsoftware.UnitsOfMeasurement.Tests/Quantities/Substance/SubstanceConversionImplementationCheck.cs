using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Substance
{
    [TestClass]
    public class SubstanceConversionImplementationCheck
    {
        [TestMethod]
        public async Task ShouldConvertAllSubstanceCombinationsIntoAllOtherSubstanceCombinations()
        {
            foreach (SubstanceType fromSubstanceType in Enum.GetValues(typeof(SubstanceType)))
            {
                var fromValue = Quantity.Substance.CreateValue(DateTime.Now, value: 1, fromSubstanceType);

                foreach (SubstanceType toSubstanceType in Enum.GetValues(typeof(SubstanceType)))
                {
                    var toUnit = Quantity.Substance.GetUnit(toSubstanceType);
                    var toValue = await fromValue.As(toUnit);

                    Assert.IsTrue(await fromValue.IsEqualTo(toValue), $"Conversion from {fromSubstanceType} to {toSubstanceType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}