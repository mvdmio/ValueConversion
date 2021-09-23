using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ridder.UnitsOfMeasurement.ExchangeRates.Providers.WebProvider.Responses
{
    public class SingleCurrencyExchangeRateApiResponse
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public IDictionary<string, double> Rates { get; set; }
    }
}