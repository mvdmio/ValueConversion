using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider.Responses
{
    public class MultipleCurrencyExchangeRatesApiResponse
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("start_at")]
        public DateTime StartAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime EndAt { get; set; }

        [JsonProperty("rates")]
        public SortedDictionary<DateTime, IDictionary<string, double>> Rates;
    }
}