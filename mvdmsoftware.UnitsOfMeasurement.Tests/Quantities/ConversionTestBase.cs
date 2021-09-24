using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities
{
    public class ConversionTestBase
    {
        private async Task<double> GetConvertedValue(double input, IUnit originalUnit, IUnit convertedUnit)
        {
            var originalValue = new QuantityValue(DateTimeOffset.Now, input, originalUnit);
            var convertedValue = await originalValue.As(convertedUnit);

            return convertedValue.GetValue();
        }

        protected async Task TestConversion(double inputValue, IUnit inputUnit, double expectedConverted, IUnit convertedUnit)
        {
            var convertedValue = await GetConvertedValue(inputValue, inputUnit, convertedUnit);
            AssertExtensions.AreWithinTolerance(expectedConverted, convertedValue, 1e-10);
        }
    }
}