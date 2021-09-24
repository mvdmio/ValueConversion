using System;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities
{
    public class ConversionTestBase
    {
        private double GetConvertedValue(double input, IUnit originalUnit, IUnit convertedUnit)
        {
            var originalValue = new QuantityValue(DateTimeOffset.Now, input, originalUnit);
            var convertedValue = originalValue.As(convertedUnit);

            return convertedValue.GetValue();
        }

        protected void TestConversion(double inputValue, IUnit inputUnit, double expectedConverted, IUnit convertedUnit)
        {
            var convertedValue = GetConvertedValue(inputValue, inputUnit, convertedUnit);
            AssertExtensions.AreWithinTolerance(expectedConverted, convertedValue, 1e-10);
        }
    }
}