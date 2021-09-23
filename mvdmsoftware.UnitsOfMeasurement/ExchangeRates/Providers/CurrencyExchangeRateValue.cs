using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.ExchangeRates.Providers
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