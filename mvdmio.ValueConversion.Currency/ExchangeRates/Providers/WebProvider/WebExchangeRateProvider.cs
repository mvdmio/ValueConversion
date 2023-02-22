using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider.Responses;
using Newtonsoft.Json;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider;

public class WebExchangeRateProvider : IExchangeRateProvider
{
    private readonly IDictionary<string, string> _currencyTypeDictionary = new Dictionary<string, string> {
        { "Euro", "EUR" },
        { "MexicanPeso", "MXN" },
        { "UnitedStatesDollar", "USD" },
        { "CanadianDollar", "CAD" },
    };

    private readonly HttpClient _httpClient;

    public WebExchangeRateProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public CurrencyExchangeRateValue GetLatestExchangeRate(string fromIdentifier, string toIdentifier)
    {
        // TODO: This is async over sync, bad practice!
        var asyncRequest = _httpClient.GetAsync($"https://api.exchangeratesapi.io/latest?base={GetApiCurrencySymbol(fromIdentifier)}&symbols={GetApiCurrencySymbol(toIdentifier)}");
        using (var response = asyncRequest.Result)
        {
            if(!response.IsSuccessStatusCode)
                throw new InvalidOperationException("An error occurred while retrieving the exchange rate");

            var asyncResponseContent = response.Content.ReadAsStringAsync();
            var responseString = asyncResponseContent.Result; // TODO: This is async over sync, bad practice!
            var exchangeRateResponse = JsonConvert.DeserializeObject<SingleCurrencyExchangeRateApiResponse>(responseString);
            var apiCurrencySymbol = GetApiCurrencySymbol(toIdentifier);

            if(!exchangeRateResponse.Rates.ContainsKey(apiCurrencySymbol))
                throw new InvalidOperationException($"Exchange rate {toIdentifier} not found.");

            return new CurrencyExchangeRateValue(fromIdentifier, toIdentifier, exchangeRateResponse.Rates[apiCurrencySymbol]);
        }
    }

    public CurrencyExchangeRateValue GetExchangeRate(string fromIdentifier, string toIdentifier, DateTime utcDate)
    {
            
        var utcStartDay = utcDate.Date;
        var utcEndDay = GetCorrectedEndDay(utcStartDay);

        if (utcStartDay >= DateTime.UtcNow.Date || utcEndDay >= DateTime.UtcNow)
        {
            // If the requested utcDate is in the future, return the latest known exchange rate.
            return GetLatestExchangeRate(fromIdentifier, toIdentifier);
        }

        // TODO: This is async over sync, bad practice!
        var asyncRequest = _httpClient.GetAsync($"https://api.exchangeratesapi.io/history?base={GetApiCurrencySymbol(fromIdentifier)}&symbols={GetApiCurrencySymbol(toIdentifier)}&start_at={FormatDate(utcStartDay)}&end_at={FormatDate(utcEndDay)}");
        using (var response = asyncRequest.Result)
        {
            if(!response.IsSuccessStatusCode)
                throw new InvalidOperationException("An error occurred while retrieving the exchange rate");

            var asyncResponseContent = response.Content.ReadAsStringAsync(); // TODO: This is async over sync, bad practice!
            var responseString = asyncResponseContent.Result;
            var exchangeRateResponse = JsonConvert.DeserializeObject<MultipleCurrencyExchangeRatesApiResponse>(responseString);

            if(!exchangeRateResponse.Rates.Any())
            {
                // If no exchange rates are available for today for any reason, try retrieving exchange rates for tomorrow.
                return GetExchangeRate(fromIdentifier, toIdentifier, utcDate.AddDays(1));
            }

            var exchangeRates = exchangeRateResponse.Rates.First().Value;
            var apiCurrencySymbol = GetApiCurrencySymbol(toIdentifier);

            if(!exchangeRates.ContainsKey(apiCurrencySymbol))
                throw new InvalidOperationException($"Exchange rate {toIdentifier} not found.");

            return new CurrencyExchangeRateValue(fromIdentifier, toIdentifier, exchangeRates[apiCurrencySymbol]);
        }
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string fromIdentifier, string toIdentifier, DateTime start)
    {
        return GetExchangeRates(fromIdentifier, toIdentifier, start, DateTime.Now);
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string fromIdentifier, string toIdentifier, DateTime start, DateTime end)
    {
        var startDay = start.Date;
        var endDay = GetCorrectedEndDay(end);
        var totalDays = (endDay - startDay).TotalDays;

        // TODO: This is async over sync, bad practice!
        var asyncRequest = _httpClient.GetAsync($"https://api.exchangeratesapi.io/history?base={GetApiCurrencySymbol(fromIdentifier)}&symbols={GetApiCurrencySymbol(toIdentifier)}&start_at={FormatDate(startDay)}&end_at={FormatDate(endDay)}");
        using (var response = asyncRequest.Result)
        {
            if(!response.IsSuccessStatusCode)
                throw new InvalidOperationException("An error occurred while retrieving the exchange rate");

            var asyncResponseContent = response.Content.ReadAsStringAsync();
            var responseString = asyncResponseContent.Result; // TODO: This is async over sync, bad practice!
            var exchangeRateResponse = JsonConvert.DeserializeObject<MultipleCurrencyExchangeRatesApiResponse>(responseString);

            if(!exchangeRateResponse.Rates.Values.Any(x => x.ContainsKey(GetApiCurrencySymbol(toIdentifier))))
                throw new InvalidOperationException($"Exchange rate {toIdentifier} not found.");

            var result = new SortedDictionary<DateTime, CurrencyExchangeRateValue>();
            for(var i = 0; i <= totalDays; i++)
            {
                var day = startDay.AddDays(i);

                if (day > end)
                    break;

                var exchangeRate = LookupExchangeRate(toIdentifier, day, exchangeRateResponse.Rates);
                result.Add(day, new CurrencyExchangeRateValue(fromIdentifier, toIdentifier, exchangeRate));
            }

            return result;
        }
    }

    private double LookupExchangeRate(string identifier, DateTime day, SortedDictionary<DateTime, IDictionary<string, double>> rates)
    {
        /*
         * The rates dictionary has gaps on weekend days, because no exchange rates are available for weekend days.
         * This method determines the most correct exchange rate for any given day using the given rates dictionary.
         * Future exchange rates are picked if there are any gaps, so the exchange rate from monday is always picked to fill gaps on Saturday or Sunday.
         */

        var apiCurrencySymbol = GetApiCurrencySymbol(identifier);
        var dayRates = rates.LastOrDefault(x => x.Key <= day).Value;

        if(dayRates == null || !dayRates.ContainsKey(apiCurrencySymbol))
        {
            // Fallback to forward-lookup if you can't find a value
            dayRates = rates.FirstOrDefault(x => x.Key >= day).Value;

            if (dayRates == null || !dayRates.ContainsKey(apiCurrencySymbol))
            {
                throw new InvalidOperationException($"Exchange rate for {identifier} could not be found for {FormatDate(day)}");
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

    private string GetApiCurrencySymbol(string identifier)
    {
        if (!_currencyTypeDictionary.ContainsKey(identifier))
        {
            throw new InvalidOperationException($"{nameof(_currencyTypeDictionary)} does not contain a translation for type '{identifier}'");
        }

        return _currencyTypeDictionary[identifier];
    }
}