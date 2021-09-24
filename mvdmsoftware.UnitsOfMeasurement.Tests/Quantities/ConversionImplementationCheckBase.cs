using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities
{
    public class ConversionImplementationCheckBase
    {
        protected void TestQuantityConversionImplementation<T>(IQuantity<T> quantity) where T : Enum
        {
            foreach (T fromEnumType in Enum.GetValues(typeof(T)))
            {
                var fromValue = quantity.CreateValue(DateTime.Now, 1, fromEnumType);

                foreach (T toEnumType in Enum.GetValues(typeof(T)))
                {
                    var toUnit = quantity.GetUnit(toEnumType);
                    var toValue = fromValue.As(toUnit);

                    Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromEnumType} to {toEnumType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}