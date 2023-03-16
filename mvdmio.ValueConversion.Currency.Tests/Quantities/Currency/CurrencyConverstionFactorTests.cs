using mvdmio.ValueConversion.Currency.ExchangeRates;
using mvdmio.ValueConversion.Currency.Quantities;
using mvdmio.ValueConversion.Currency.Tests.Mocks;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;
using Xunit;

namespace mvdmio.ValueConversion.Currency.Tests.Quantities.Currency;


public class CurrencyConversionTests
{
   public CurrencyConversionTests()
   {
      CurrencyExchangeRate.SetProvider(new MockExchangeRateProvider());
   }

   [Theory]
   [InlineData("UnitedStatesDollar", 1)]
   [InlineData("Euro", 0.896688083)]
   [InlineData("MexicanPeso", 19.0363785)]
   [InlineData("CanadianDollar", 1.41)]
   public void UnitedStatesDollarConversions(string identifier, double expected)
   {
      var exchangeRate = GetConversionFactor("UnitedStatesDollar", identifier);

      AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
   }

   [Theory]
   [InlineData("UnitedStatesDollar", 1.11521499946152)]
   [InlineData("Euro", 1)]
   [InlineData("MexicanPeso", 21.2296548386269)]
   [InlineData("CanadianDollar", 1.572453149240749)]
   public void EuroConversions(string identifier, double expected)
   {
      var exchangeRate = GetConversionFactor("Euro", identifier);

      AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
   }

   [Theory]
   [InlineData("UnitedStatesDollar", 0.0525310000533978)]
   [InlineData("Euro", 0.0471039217359541)]
   [InlineData("MexicanPeso", 1)]
   [InlineData("CanadianDollar", 0.0740687100752908)]
   public void MexicanPesoConversions(string identifier, double expected)
   {
      var exchangeRate = GetConversionFactor("MexicanPeso", identifier);

      AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
   }

   [Theory]
   [InlineData("UnitedStatesDollar", 0.7092198581560284)]
   [InlineData("Euro", 0.635948995035461)]
   [InlineData("MexicanPeso", 13.50097765957447)]
   [InlineData("CanadianDollar", 1)]
   public void CanadianDollarConversions(string identifier, double expected)
   {
      var exchangeRate = GetConversionFactor("CanadianDollar", identifier);

      AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
   }

   private static double GetConversionFactor(string from, string to)
   {
      var currencyQuantity = new CurrencyQuantity();

      var quantityValue = currencyQuantity.CreateValue(value: 1, from);
      var convertedValue = currencyQuantity.Convert(quantityValue, to);
      var conversionFactor = convertedValue.GetValue();

      return conversionFactor;
   }
}