namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers;

public class CurrencyExchangeRateValue
{
    public string FromIdentifier { get; }
    public string ToIdentifier { get; }
    public double Value { get; }

    public CurrencyExchangeRateValue(string fromIdentifier, string toIdentifier, double value)
    {
        FromIdentifier = fromIdentifier;
        ToIdentifier = toIdentifier;
        Value = value;
    }
}