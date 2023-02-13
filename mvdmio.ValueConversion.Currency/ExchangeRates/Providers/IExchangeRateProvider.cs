using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers;

public interface IExchangeRateProvider
{
    CurrencyExchangeRateValue GetExchangeRate(string fromIdentifier, string toIdentifier, DateTime utcDate);
    IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string fromIdentifier, string toIdentifier, DateTime start);
    IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string fromIdentifier, string toIdentifier, DateTime start, DateTime end);
    CurrencyExchangeRateValue GetLatestExchangeRate(string fromIdentifier, string toIdentifier);
}