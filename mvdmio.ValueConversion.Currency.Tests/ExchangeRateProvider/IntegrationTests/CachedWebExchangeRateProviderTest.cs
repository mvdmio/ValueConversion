using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider;

namespace mvdmio.ValueConversion.Currency.Tests.ExchangeRateProvider.IntegrationTests;

[TestClass]
[Ignore]
public class CachedWebExchangeRateProviderTest
{
    private static HttpClient _httpClient = default!;
    private static IExchangeRateProvider _provider = default!;

    [TestInitialize]
    public void Initialize()
    {
        _httpClient = new HttpClient();
        _provider = new CachedExchangeRateProvider(new WebExchangeRateProvider(_httpClient));
    }

    [TestCleanup]
    public void Cleanup()
    {
        _httpClient.Dispose();
    }

    [TestMethod]
    public void ShouldReturnValueForToday()
    {
        var exchangeRate = _provider.GetExchangeRate(CurrencyType.Euro, CurrencyType.UnitedStatesDollar, DateTime.Now);

        Assert.IsTrue(exchangeRate.Value > 0);
    }
}