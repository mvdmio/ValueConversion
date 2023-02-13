using System;
using System.Net.Http;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers.StaticProvider;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider;

namespace mvdmio.ValueConversion.Currency.ExchangeRates;

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

    public static void UseStaticProvider()
    {
        if (exchangeRateProvider is StaticExchangeRateProvider)
            return;

        exchangeRateProvider = new StaticExchangeRateProvider();
    }

    public static double Get(string fromIdentifier, string toIdentifier, DateTime dateTime)
    {
        if (fromIdentifier == toIdentifier)
            return 1;

        var exchangeRate = exchangeRateProvider.GetExchangeRate(fromIdentifier, toIdentifier, dateTime);
        return exchangeRate.Value;
    }
}