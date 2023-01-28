using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Currency.ExchangeRates;
using mvdmio.ValueConversion.Currency.Quantities;
using mvdmio.ValueConversion.Currency.Tests.Mocks;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.Currency.Tests.Quantities.Currency
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
        public void ShouldConvertAllCurrencyCombinationsIntoAllOtherCurrencyCombinations()
        {
            var currencyQuantity = new CurrencyQuantity();
            
            foreach (CurrencyType fromCurrencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                var fromValue = currencyQuantity.CreateValue(DateTime.Now, 1, fromCurrencyType);

                foreach (CurrencyType toCurrencyType in Enum.GetValues(typeof(CurrencyType)))
                {
                    var toUnit = currencyQuantity.GetUnit(toCurrencyType);
                    var toValue = fromValue.As(toUnit);

                    Assert.IsTrue(fromValue.IsEqualTo(toValue), $"Conversion from {fromCurrencyType} to {toCurrencyType} did not result in equal quantities.");

                    var conversionFactor = toValue.GetValue();
                    var expected = fromValue.GetValue() * conversionFactor;
                    var actual = toValue.GetValue();

                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}