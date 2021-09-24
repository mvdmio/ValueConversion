using System;
using System.Net.Http;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.CachedProvider;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.StaticProvider;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider;

namespace mvdmsoftware.UnitsOfMeasurement.ExchangeRates
{
    public static class CurrencyExchangeRate
    {
        private static IExchangeRateProvider exchangeRateProvider = new WebExchangeRateProvider(new HttpClient());

        public static void SetProvider(IExchangeRateProvider provider)
        {
            exchangeRateProvider = provider;
        }

        public static void UseWebProvider()
        {
            if (exchangeRateProvider is WebExchangeRateProvider)
                return;

            exchangeRateProvider = new WebExchangeRateProvider(new HttpClient());
        }

        public static void UseCachedProvider()
        {
            if (exchangeRateProvider is CachedExchangeRateProvider)
                return;

            exchangeRateProvider = new CachedExchangeRateProvider(exchangeRateProvider);
        }

        public static void UseStaticProvider()
        {
            if (exchangeRateProvider is StaticExchangeRateProvider)
                return;

            exchangeRateProvider = new StaticExchangeRateProvider();
        }

        public static double Get(CurrencyType from, CurrencyType to, DateTime dateTime)
        {
            if (from == to)
                return 1;

            var exchangeRate = exchangeRateProvider.GetExchangeRate(from, to, dateTime);
            return exchangeRate.Value;
        }
    }
}