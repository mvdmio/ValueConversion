using System.Collections.Generic;
using mvdmio.ValueConversion.Currency.Units;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;

namespace mvdmio.ValueConversion.Currency.Quantities
{
    /// <summary>
    /// Currency is a medium of exchange for goods and services. 
    /// In short, it's money, in the form of paper or coins, usually issued by a government and generally accepted at its face value as a method of payment.
    /// </summary>
    public sealed class CurrencyQuantity : QuantityBase<CurrencyType>
    {
        private readonly object _lockObject = new object();
        private IDictionary<CurrencyType, IUnit<CurrencyType>> _units;

        public CurrencyQuantity()
            : base(QuantityType.Currency, CurrencyType.UnitedStatesDollar)
        {
        }

        /// <inheritdoc/>     
        public override IDictionary<CurrencyType, IUnit<CurrencyType>> GetUnits()
        {
            if (_units == null)
            {
                lock (_lockObject)
                {
                    if (_units == null)
                    {
                        var units =  new Dictionary<CurrencyType, IUnit<CurrencyType>>
                        {
                            {CurrencyType.UnitedStatesDollar, new CurrencyUnit(CurrencyType.UnitedStatesDollar)},
                            {CurrencyType.Euro, new CurrencyUnit(CurrencyType.Euro)},
                            {CurrencyType.MexicanPeso, new CurrencyUnit(CurrencyType.MexicanPeso)},
                            {CurrencyType.CanadianDollar, new CurrencyUnit(CurrencyType.CanadianDollar)}
                        };
                        _units = units;
                    }
                }
            }

            return _units;
        }
    }
}
