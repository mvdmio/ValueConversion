using System;
using System.Collections.Generic;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers
{
    public interface IExchangeRateProvider
    {
        CurrencyExchangeRateValue GetExchangeRate(CurrencyType from, CurrencyType to, DateTime utcDate);
        IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start);
        IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start, DateTime end);
        CurrencyExchangeRateValue GetLatestExchangeRate(CurrencyType from, CurrencyType to);
    }
}