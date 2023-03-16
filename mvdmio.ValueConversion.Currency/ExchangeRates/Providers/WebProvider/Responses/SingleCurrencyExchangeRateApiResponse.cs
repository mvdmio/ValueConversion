using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider.Responses;

internal class SingleCurrencyExchangeRateApiResponse
{
    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("rates")]
    public IDictionary<string, double> Rates { get; set; } = new Dictionary<string, double>();
}