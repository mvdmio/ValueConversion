using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Enums.Quantities;
using Ridder.UnitsOfMeasurement.ExchangeRates.Providers;
using Ridder.UnitsOfMeasurement.ExchangeRates.Providers.CachedExchangeRateProvider;
using Ridder.UnitsOfMeasurement.ExchangeRates.Providers.StaticProvider;
using Ridder.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider;

namespace Ridder.UnitsOfMeasurement.ExchangeRates
{
    public static class CurrencyExchangeRate
    {
        private static IExchangeRateProvider _exchangeRateProvider = new WebExchangeRateProvider(new HttpClient());

        public static void SetProvider(IExchangeRateProvider provider)
        {
            _exchangeRateProvider = provider;
        }

        public static void UseWebProvider()
        {
            if (_exchangeRateProvider is WebExchangeRateProvider)
                return;

            _exchangeRateProvider = new WebExchangeRateProvider(new HttpClient());
        }

        public static void UseCachedProvider()
        {
            if (_exchangeRateProvider is CachedExchangeRateProvider)
                return;

            _exchangeRateProvider = new CachedExchangeRateProvider(_exchangeRateProvider);
        }

        public static void UseStaticProvider()
        {
            if (_exchangeRateProvider is StaticExchangeRateProvider)
                return;

            _exchangeRateProvider = new StaticExchangeRateProvider();
        }

        public static async Task<double> Get(CurrencyType from, CurrencyType to, DateTime dateTime)
        {
            if (from == to)
                return 1;

            var exchangeRate = await _exchangeRateProvider.GetExchangeRate(from, to, dateTime);
            return exchangeRate.Value;
        }
    }
}