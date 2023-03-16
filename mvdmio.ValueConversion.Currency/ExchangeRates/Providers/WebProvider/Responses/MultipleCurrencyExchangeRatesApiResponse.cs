using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider.Responses;

internal class MultipleCurrencyExchangeRatesApiResponse
{
    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("start_at")]
    public DateTime StartAt { get; set; }

    [JsonPropertyName("end_at")]
    public DateTime EndAt { get; set; }

    [JsonPropertyName("rates")]
    public SortedDictionary<DateTime, IDictionary<string, double>> Rates { get; set; } = new SortedDictionary<DateTime, IDictionary<string, double>>();
}