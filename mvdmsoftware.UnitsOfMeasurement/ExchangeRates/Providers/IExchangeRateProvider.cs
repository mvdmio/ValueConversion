using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.ExchangeRates.Providers
{
    public interface IExchangeRateProvider
    {
        Task<CurrencyExchangeRateValue> GetExchangeRate(CurrencyType from, CurrencyType to, DateTime utcDate);
        Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start);
        Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start, DateTime end);
        Task<CurrencyExchangeRateValue> GetLatestExchangeRate(CurrencyType from, CurrencyType to);
    }
}