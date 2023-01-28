using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers.CachedProvider
{
    internal class CachedExchangeRate
    {
        public CurrencyType From { get; }
        public CurrencyType To { get; }
        public double Value { get; }

        public CachedExchangeRate(CurrencyType from, CurrencyType to, double value)
        {
            From = from;
            To = to;
            Value = value;
        }
    }
}