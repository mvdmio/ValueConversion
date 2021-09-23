using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.ExchangeRates.Providers.StaticProvider
{
    public class StaticExchangeRateProvider : IExchangeRateProvider
    {
        private readonly IDictionary<CurrencyType, double> conversionDictionary = new Dictionary<CurrencyType, double> {
            { CurrencyType.UnitedStatesDollar, 1 },
            { CurrencyType.Euro, 0.896688083 },
            { CurrencyType.MexicanPeso, 19.0363785 },
            { CurrencyType.CanadianDollar, 1.41 }
        };

        public Task<CurrencyExchangeRateValue> GetLatestExchangeRate(CurrencyType from, CurrencyType to)
        {
            return GetExchangeRate(from, to, DateTime.Now);
        }

        public Task<CurrencyExchangeRateValue> GetExchangeRate(CurrencyType from, CurrencyType to, DateTime utcDate)
        {
            if(!conversionDictionary.TryGetValue(from, out var fromValue))
                throw new InvalidOperationException($"No exchange rate could be found for {from}");

            if(!conversionDictionary.TryGetValue(to, out var toValue))
                throw new InvalidOperationException($"No exchange rate could be found for {from}");

            var exchangeRate = toValue / fromValue;
            var result = new CurrencyExchangeRateValue(from, to, exchangeRate);

            return Task.FromResult(result);
        }

        public Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start)
        {
            return GetExchangeRates(from, to, start, DateTime.Now);
        }

        public async Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start, DateTime end)
        {
            var totalDays = (start.Date - end.Date).TotalDays;
            var exchangeRate = await GetLatestExchangeRate(from, to);

            var result = new Dictionary<DateTime, CurrencyExchangeRateValue>();
            for(var i = 0; i < totalDays; i++)
            {
                result.Add(start.Date.AddDays(i), exchangeRate);
            }

            return result;
        }
    }
}