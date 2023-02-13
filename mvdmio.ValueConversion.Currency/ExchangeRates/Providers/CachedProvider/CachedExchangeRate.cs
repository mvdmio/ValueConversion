namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.CachedProvider;

internal class CachedExchangeRate
{
    public string FromIdentifier { get; }
    public string ToIdentifier { get; }
    public double Value { get; }

    public CachedExchangeRate(string fromIdentifier, string toIdentifier, double value)
    {
        FromIdentifier = fromIdentifier;
        ToIdentifier = toIdentifier;
        Value = value;
    }
}