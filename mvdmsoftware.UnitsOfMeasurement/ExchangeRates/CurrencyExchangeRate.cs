using System;
using System.Net.Http;
using System.Threading.Tasks;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.CachedExchangeRateProvider;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.StaticProvider;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider;

namespace mvdmsoftware.UnitsOfMeasurement.ExchangeRates
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