using System;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers.StaticProvider;
using mvdmio.ValueConversion.Currency.Units;

namespace mvdmio.ValueConversion.Currency.ExchangeRates;

/// <summary>
/// This class is the entrypoint for retrieving exchange rates for currencies.
/// Used by <see cref="CurrencyUnit"/> to retrieve the actual exchange rates when converting one currency value into another.
/// 
/// Uses the <see cref="StaticExchangeRateProvider"/> by default.  
/// </summary>
public static class CurrencyExchangeRate
{
    private static IExchangeRateProvider _exchangeRateProvider = new StaticExchangeRateProvider();

    /// <summary>
    /// Sets the Exchange Rate provider to use.
    /// </summary>
    /// <param name="provider">The Exchange Rate provider to use.</param>
    public static void SetProvider(IExchangeRateProvider provider)
    {
        _exchangeRateProvider = provider;
    }

    /// <summary>
    /// Retrieves the exchange rates for the given currencies.
    /// </summary>
    /// <param name="fromIdentifier">The initial currency.</param>
    /// <param name="toIdentifier">The desired currency.</param>
    /// <param name="dateTime">The date at which the exchange rate should be determined.</param>
    /// <returns>The exchange rate between the given currencies at the given date.</returns>
    public static double Get(string fromIdentifier, string toIdentifier, DateTimeOffset dateTime)
    {
        if (fromIdentifier == toIdentifier)
            return 1;

        var exchangeRate = _exchangeRateProvider.GetExchangeRate(fromIdentifier, toIdentifier, dateTime);
        return exchangeRate.Value;
    }
}