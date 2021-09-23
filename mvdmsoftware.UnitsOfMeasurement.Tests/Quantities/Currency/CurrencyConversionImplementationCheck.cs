using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates;
using mvdmsoftware.UnitsOfMeasurement.Tests.Mocks;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Currency
{
    [TestClass]
    public class CurrencyConversionImplementationCheck
    {
        [TestInitialize]
        public void Setup()
        {
            CurrencyExchangeRate.SetProvider(new MockExchangeRateProvider());
        }

        [TestMethod]
        public async Task ShouldConvertAllCurrencyCombinationsIntoAllOtherCurrencyCombinations()
        {
            foreach (CurrencyType fromCurrencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                var fromValue = Quantity.Currency.CreateValue(DateTime.Now, 1, fromCurrencyType);

                foreach (CurrencyType toCurrencyType in Enum.GetValues(typeof(CurrencyType)))
                {
                    var toUnit = Quantity.Currency.GetUnit(toCurrencyType);
                    var toValue = await fromValue.As(toUnit);

                    Assert.IsTrue(await fromValue.IsEqualTo(toValue), $"Conversion from {fromCurrencyType} to {toCurrencyType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}