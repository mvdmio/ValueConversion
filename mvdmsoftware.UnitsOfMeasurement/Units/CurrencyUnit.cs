using System;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates;

namespace mvdmsoftware.UnitsOfMeasurement.Units
{
    /// <summary>
    /// Base class for currency units.
    /// </summary>
    public class CurrencyUnit : UnitBase<CurrencyType>
    {
        private readonly CurrencyType _currency;
        
        internal CurrencyUnit(CurrencyType currency)
            : base(Quantity.Currency, currency)
        {
            _currency = currency;
        }

        /// <inheritdoc/>
        public override double FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            var exchangeRate = CurrencyExchangeRate.Get(Quantity.Currency.StandardUnit.Type, _currency, timestamp.DateTime);
            return value * exchangeRate;
        }

        /// <inheritdoc/>
        public override double ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            var exchangeRate = CurrencyExchangeRate.Get(Quantity.Currency.StandardUnit.Type, _currency, timestamp.DateTime);
            return value / exchangeRate;
        }
    }
}