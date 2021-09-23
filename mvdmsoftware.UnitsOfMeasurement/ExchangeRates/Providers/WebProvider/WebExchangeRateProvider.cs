using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ridder.Common;
using Ridder.UnitsOfMeasurement.Enums.Quantities;
using Ridder.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider.Responses;

namespace Ridder.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider
{
    public class WebExchangeRateProvider : IExchangeRateProvider
    {
        private readonly IDictionary<CurrencyType, string> currencyTypeDictionary = new Dictionary<CurrencyType, string> {
            { CurrencyType.Euro, "EUR" },
            { CurrencyType.MexicanPeso, "MXN" },
            { CurrencyType.UnitedStatesDollar, "USD" },
            { CurrencyType.CanadianDollar, "CAD" },
        };

        private readonly HttpClient _httpClient;

        public WebExchangeRateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrencyExchangeRateValue> GetLatestExchangeRate(CurrencyType from, CurrencyType to)
        {
            using (var response = await _httpClient.GetAsync($"https://api.exchangeratesapi.io/latest?base={GetApiCurrencySymbol(from)}&symbols={GetApiCurrencySymbol(to)}"))
            {
                if(!response.IsSuccessStatusCode)
                    throw new InvalidOperationException("An error occurred while retrieving the exchange rate");

                var responseString = await response.Content.ReadAsStringAsync();
                var exchangeRateResponse = JsonConvert.DeserializeObject<SingleCurrencyExchangeRateApiResponse>(responseString);
                var apiCurrencySymbol = GetApiCurrencySymbol(to);

                if(!exchangeRateResponse.Rates.ContainsKey(apiCurrencySymbol))
                    throw new InvalidOperationException($"Exchange rate {to} not found.");

                return new CurrencyExchangeRateValue(from, to, exchangeRateResponse.Rates[apiCurrencySymbol]);
            }
        }

        public async Task<CurrencyExchangeRateValue> GetExchangeRate(CurrencyType from, CurrencyType to, DateTime utcDate)
        {
            
            var utcStartDay = utcDate.Date;
            var utcEndDay = GetCorrectedEndDay(utcStartDay);

            if (utcStartDay >= DateTime.UtcNow.Date || utcEndDay >= DateTime.UtcNow)
            {
                // If the requested utcDate is in the future, return the latest known exchange rate.
                return await GetLatestExchangeRate(from, to);
            }
            
            using (var response = await _httpClient.GetAsync($"https://api.exchangeratesapi.io/history?base={GetApiCurrencySymbol(from)}&symbols={GetApiCurrencySymbol(to)}&start_at={FormatDate(utcStartDay)}&end_at={FormatDate(utcEndDay)}"))
            {
                if(!response.IsSuccessStatusCode)
                    throw new InvalidOperationException("An error occurred while retrieving the exchange rate");

                var responseString = await response.Content.ReadAsStringAsync().ContinueOnAnyContext();
                var exchangeRateResponse = JsonConvert.DeserializeObject<MultipleCurrencyExchangeRatesApiResponse>(responseString);

                if(!exchangeRateResponse.Rates.Any())
                {
                    // If no exchange rates are available for today for any reason, try retrieving exchange rates for tomorrow.
                    return await GetExchangeRate(from, to, utcDate.AddDays(1));
                }

                var exchangeRates = exchangeRateResponse.Rates.First().Value;
                var apiCurrencySymbol = GetApiCurrencySymbol(to);

                if(!exchangeRates.ContainsKey(apiCurrencySymbol))
                    throw new InvalidOperationException($"Exchange rate {to} not found.");

                return new CurrencyExchangeRateValue(from, to, exchangeRates[apiCurrencySymbol]);
            }
        }

        public Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start)
        {
            return GetExchangeRates(from, to, start, DateTime.Now);
        }

        public async Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start, DateTime end)
        {
            var startDay = start.Date;
            var endDay = GetCorrectedEndDay(end);
            var totalDays = (endDay - startDay).TotalDays;

            using (var response = await _httpClient.GetAsync($"https://api.exchangeratesapi.io/history?base={GetApiCurrencySymbol(from)}&symbols={GetApiCurrencySymbol(to)}&start_at={FormatDate(startDay)}&end_at={FormatDate(endDay)}"))
            {
                if(!response.IsSuccessStatusCode)
                    throw new InvalidOperationException("An error occurred while retrieving the exchange rate");

                var responseString = await response.Content.ReadAsStringAsync();
                var exchangeRateResponse = JsonConvert.DeserializeObject<MultipleCurrencyExchangeRatesApiResponse>(responseString);

                if(!exchangeRateResponse.Rates.Values.Any(x => x.ContainsKey(GetApiCurrencySymbol(to))))
                    throw new InvalidOperationException($"Exchange rate {to} not found.");

                var result = new SortedDictionary<DateTime, CurrencyExchangeRateValue>();
                for(var i = 0; i <= totalDays; i++)
                {
                    var day = startDay.AddDays(i);

                    if (day > end)
                        break;

                    var exchangeRate = LookupExchangeRate(to, day, exchangeRateResponse.Rates);
                    result.Add(day, new CurrencyExchangeRateValue(from, to, exchangeRate));
                }

                return result;
            }
        }

        private double LookupExchangeRate(CurrencyType currencyType, DateTime day, SortedDictionary<DateTime, IDictionary<string, double>> rates)
        {
            /*
             * The rates dictionary has gaps on weekend days, because no exchange rates are available for weekend days.
             * This method determines the most correct exchange rate for any given day using the given rates dictionary.
             * Future exchange rates are picked if there are any gaps, so the exchange rate from monday is always picked to fill gaps on Saturday or Sunday.
             */

            var apiCurrencySymbol = GetApiCurrencySymbol(currencyType);
            var dayRates = rates.LastOrDefault(x => x.Key <= day).Value;

            if(dayRates == null || !dayRates.ContainsKey(apiCurrencySymbol))
            {
                // Fallback to forward-lookup if you can't find a value
                dayRates = rates.FirstOrDefault(x => x.Key >= day).Value;

                if (dayRates == null || !dayRates.ContainsKey(apiCurrencySymbol))
                {
                    throw new InvalidOperationException($"Exchange rate for {currencyType.ToString()} could not be found for {FormatDate(day)}");
                }
            }

            return dayRates[apiCurrencySymbol];
        }

        private static DateTime GetCorrectedEndDay(DateTime endDay)
        {
            var correctedEndDay = endDay.Date;
            if(correctedEndDay.DayOfWeek == DayOfWeek.Saturday)
                correctedEndDay = correctedEndDay.AddDays(2); // Exchange rates are only available on weekdays, the best estimate of the exchange rate on saturday is the next monday.
            else if(correctedEndDay.DayOfWeek == DayOfWeek.Sunday)
                correctedEndDay = correctedEndDay.AddDays(1); // Exchange rates are only available on weekdays, the best estimate of the exchange rate on sunday is the next monday.

            return correctedEndDay;
        }

        private static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        private string GetApiCurrencySymbol(CurrencyType currency)
        {
            if (!currencyTypeDictionary.ContainsKey(currency))
            {
                throw new InvalidOperationException($"{nameof(currencyTypeDictionary)} does not contain a translation for type '{currency.ToString()}'");
            }

            return currencyTypeDictionary[currency];
        }
    }
}