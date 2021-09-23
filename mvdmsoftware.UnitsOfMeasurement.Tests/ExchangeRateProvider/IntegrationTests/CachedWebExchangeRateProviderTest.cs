using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.CachedExchangeRateProvider;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.ExchangeRateProvider.IntegrationTests
{
    [TestClass]
    [Ignore]
    public class CachedWebExchangeRateProviderTest
    {
        private static HttpClient _httpClient;
        private static IExchangeRateProvider _provider;

        [TestInitialize]
        public void Initialize()
        {
            _httpClient = new HttpClient();
            _provider = new CachedExchangeRateProvider(new WebExchangeRateProvider(_httpClient));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _httpClient?.Dispose();
        }

        [TestMethod]
        public async Task ShouldReturnValueForToday()
        {
            var exchangeRate = await _provider.GetExchangeRate(CurrencyType.Euro, CurrencyType.UnitedStatesDollar, DateTime.Now);

            Assert.IsTrue(exchangeRate.Value > 0);
        }
    }
}
