using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.CachedProvider;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.ExchangeRateProvider.IntegrationTests
{
    [TestClass]
    [Ignore]
    public class CachedWebExchangeRateProviderTest
    {
        private static HttpClient httpClient;
        private static IExchangeRateProvider provider;

        [TestInitialize]
        public void Initialize()
        {
            httpClient = new HttpClient();
            provider = new CachedExchangeRateProvider(new WebExchangeRateProvider(httpClient));
        }

        [TestCleanup]
        public void Cleanup()
        {
            httpClient?.Dispose();
        }

        [TestMethod]
        public void ShouldReturnValueForToday()
        {
            var exchangeRate = provider.GetExchangeRate(CurrencyType.Euro, CurrencyType.UnitedStatesDollar, DateTime.Now);

            Assert.IsTrue(exchangeRate.Value > 0);
        }
    }
}
