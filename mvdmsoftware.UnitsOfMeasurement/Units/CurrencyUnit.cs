using System;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums.Quantities;
using Ridder.UnitsOfMeasurement.ExchangeRates;

namespace Ridder.UnitsOfMeasurement.Units
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
        public override async Task<double> FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            var exchangerate = await CurrencyExchangeRate.Get(Quantity.Currency.StandardUnit.Type, _currency, timestamp.DateTime);
            return value * exchangerate;
        }

        /// <inheritdoc/>
        public override async Task<double> ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            var exchangerate = await CurrencyExchangeRate.Get(Quantity.Currency.StandardUnit.Type, _currency, timestamp.DateTime);
            return value / exchangerate;
        }
    }
}