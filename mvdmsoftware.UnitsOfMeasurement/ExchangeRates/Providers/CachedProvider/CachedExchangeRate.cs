using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.CachedExchangeRateProvider
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