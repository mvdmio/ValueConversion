using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.StaticProvider;

/// <summary>
/// An exchange rate provider that uses static, pre-defined exchange rates.
/// </summary>
public class StaticExchangeRateProvider : IExchangeRateProvider
{
    private readonly IDictionary<string, double> _conversionDictionary = new Dictionary<string, double> {
        { "UnitedStatesDollar", 1 },
        { "Euro", 0.896688083 },
        { "MexicanPeso", 19.0363785 },
        { "CanadianDollar", 1.41 }
    };

    /// <inheritdoc />
    public CurrencyExchangeRateValue GetExchangeRate(string fromIdentifier, string toIdentifier, DateTimeOffset _)
    {
        if(!_conversionDictionary.TryGetValue(fromIdentifier, out var fromValue))
            throw new InvalidOperationException($"No exchange rate could be found for {fromIdentifier}");

        if(!_conversionDictionary.TryGetValue(toIdentifier, out var toValue))
            throw new InvalidOperationException($"No exchange rate could be found for {toIdentifier}");

        var exchangeRate = toValue / fromValue;
        var result = new CurrencyExchangeRateValue(fromIdentifier, toIdentifier, exchangeRate);

        return result;
    }
}