using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers;

/// <summary>
/// Interface for currency exchange rate providers.
/// </summary>
public interface IExchangeRateProvider
{
    /// <summary>
    /// Retrieve the exchange rate for the given currencies at the given date.
    /// </summary>
    /// <param name="fromIdentifier">The initial currency identifier.</param>
    /// <param name="toIdentifier">The desired currency identifier.</param>
    /// <param name="date">The date for which the exchange rate should be looked up.</param>
    /// <returns>The exchange rate for the given currencies at the given date.</returns>
    CurrencyExchangeRateValue GetExchangeRate(string fromIdentifier, string toIdentifier, DateTimeOffset date);
}