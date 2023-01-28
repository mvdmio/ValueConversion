using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.Currency.ExchangeRates.Providers
{
    public class CurrencyExchangeRateValue
    {
        public CurrencyType From { get; }
        public CurrencyType To { get; }
        public double Value { get; }

        public CurrencyExchangeRateValue(CurrencyType from, CurrencyType to, double value)
        {
            From = from;
            To = to;
            Value = value;
        }
    }
}