using System;
using mvdmio.ValueConversion.Currency.ExchangeRates;
using mvdmio.ValueConversion.Currency.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.Currency.Units
{
    /// <summary>
    /// Base class for currency units.
    /// </summary>
    public class CurrencyUnit : UnitBase<CurrencyType>
    {
        private readonly CurrencyType _currency;
        
        internal CurrencyUnit(CurrencyType currency)
            : base(new CurrencyQuantity(), currency)
        {
            _currency = currency;
        }

        /// <inheritdoc/>
        public override double FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            var exchangeRate = CurrencyExchangeRate.Get(new CurrencyQuantity().StandardUnit.Type, _currency, timestamp.DateTime);
            return value * exchangeRate;
        }

        /// <inheritdoc/>
        public override double ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            var exchangeRate = CurrencyExchangeRate.Get(new CurrencyQuantity().StandardUnit.Type, _currency, timestamp.DateTime);
            return value / exchangeRate;
        }
    }
}