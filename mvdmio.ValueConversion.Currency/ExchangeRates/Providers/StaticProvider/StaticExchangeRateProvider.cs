using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.StaticProvider;

public class StaticExchangeRateProvider : IExchangeRateProvider
{
    private readonly IDictionary<string, double> conversionDictionary = new Dictionary<string, double> {
        { "UnitedStatesDollar", 1 },
        { "Euro", 0.896688083 },
        { "MexicanPeso", 19.0363785 },
        { "CanadianDollar", 1.41 }
    };

    public CurrencyExchangeRateValue GetLatestExchangeRate(string fromIdentifier, string toIdentifier)
    {
        return GetExchangeRate(fromIdentifier, toIdentifier, DateTime.Now);
    }

    public CurrencyExchangeRateValue GetExchangeRate(string fromIdentifier, string toIdentifier, DateTime utcDate)
    {
        if(!conversionDictionary.TryGetValue(fromIdentifier, out var fromValue))
            throw new InvalidOperationException($"No exchange rate could be found for {fromIdentifier}");

        if(!conversionDictionary.TryGetValue(toIdentifier, out var toValue))
            throw new InvalidOperationException($"No exchange rate could be found for {toIdentifier}");

        var exchangeRate = toValue / fromValue;
        var result = new CurrencyExchangeRateValue(fromIdentifier, toIdentifier, exchangeRate);

        return result;
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string fromIdentifier, string toIdentifier, DateTime start)
    {
        return GetExchangeRates(fromIdentifier, toIdentifier, start, DateTime.Now);
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string fromIdentifier, string toIdentifier, DateTime start, DateTime end)
    {
        var totalDays = (start.Date - end.Date).TotalDays;
        var exchangeRate = GetLatestExchangeRate(fromIdentifier, toIdentifier);

        var result = new Dictionary<DateTime, CurrencyExchangeRateValue>();
        for(var i = 0; i < totalDays; i++)
        {
            result.Add(start.Date.AddDays(i), exchangeRate);
        }

        return result;
    }
}