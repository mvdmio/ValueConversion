using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Currency.ExchangeRates;
using mvdmio.ValueConversion.Currency.Quantities;
using mvdmio.ValueConversion.Currency.Tests.Mocks;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.Currency.Tests.Quantities.Currency;

[TestClass]
public class CurrencyConverstionTests
{
    [TestInitialize]
    public void Setup()
    {
        CurrencyExchangeRate.SetProvider(new MockExchangeRateProvider());
    }

    [DataTestMethod]
    [DataRow("UnitedStatesDollar", 1)]
    [DataRow("Euro", 0.896688083)]
    [DataRow("MexicanPeso", 19.0363785)]
    [DataRow("CanadianDollar", 1.41)]
    public void UnitedStatesDollarConversions(string identifier, double expected)
    {
        var exchangeRate = GetConversionFactor("UnitedStatesDollar", identifier);

        AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
    }

    [DataTestMethod]
    [DataRow("UnitedStatesDollar", 1.11521499946152)]
    [DataRow("Euro", 1)]
    [DataRow("MexicanPeso", 21.2296548386269)]
    [DataRow("CanadianDollar", 1.572453149240749)]
    public void EuroConversions(string identifier, double expected)
    {
        var exchangeRate = GetConversionFactor("Euro", identifier);

        AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
    }

    [DataTestMethod]
    [DataRow("UnitedStatesDollar", 0.0525310000533978)]
    [DataRow("Euro", 0.0471039217359541)]
    [DataRow("MexicanPeso", 1)]
    [DataRow("CanadianDollar", 0.0740687100752908)]
    public void MexicanPesoConversions(string identifier, double expected)
    {
        var exchangeRate = GetConversionFactor("MexicanPeso", identifier);

        AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
    }

    [DataTestMethod]
    [DataRow("UnitedStatesDollar", 0.7092198581560284)]
    [DataRow("Euro", 0.635948995035461)]
    [DataRow("MexicanPeso", 13.50097765957447)]
    [DataRow("CanadianDollar", 1)]
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