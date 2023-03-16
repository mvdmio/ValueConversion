using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Currency.ExchangeRates;
using mvdmio.ValueConversion.Currency.Quantities;
using mvdmio.ValueConversion.Currency.Tests.Mocks;
using Xunit;

namespace mvdmio.ValueConversion.Currency.Tests.Quantities.Currency;


public class CurrencyConversionImplementationCheck
{
   public CurrencyConversionImplementationCheck()
   {
      CurrencyExchangeRate.SetProvider(new MockExchangeRateProvider());
   }

   [Fact]
   public void ShouldConvertAllCurrencyCombinationsIntoAllOtherCurrencyCombinations()
   {
      var currencyQuantity = new CurrencyQuantity();

      foreach (var fromUnit in Quantity.Known.Currency().GetUnits())
      {
         var fromValue = currencyQuantity.CreateValue(DateTime.Now, 1, fromUnit);

         foreach (var toUnit in Quantity.Known.Currency().GetUnits())
         {
            var toValue = fromValue.As(toUnit);

            Assert.True(fromValue.IsEqualTo(toValue), $"Conversion from {fromUnit.Identifier} to {toUnit.Identifier} did not result in equal quantities.");

            var conversionFactor = toValue.GetValue();
            var expected = fromValue.GetValue() * conversionFactor;
            var actual = toValue.GetValue();

            Assert.Equal(expected, actual);
         }
      }
   }
}