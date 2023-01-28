using System;
using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers
{
    public interface IExchangeRateProvider
    {
        CurrencyExchangeRateValue GetExchangeRate(CurrencyType from, CurrencyType to, DateTime utcDate);
        IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start);
        IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start, DateTime end);
        CurrencyExchangeRateValue GetLatestExchangeRate(CurrencyType from, CurrencyType to);
    }
}