using System.Collections.Generic;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;
using mvdmsoftware.UnitsOfMeasurement.Units;

namespace mvdmsoftware.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// Currency is a medium of exchange for goods and services. 
    /// In short, it's money, in the form of paper or coins, usually issued by a government and generally accepted at its face value as a method of payment.
    /// </summary>
    public sealed class CurrencyQuantity : QuantityBase<CurrencyType>
    {
        private readonly object _lockObject = new object();
        private IDictionary<CurrencyType, IUnit<CurrencyType>> _units;
        
        internal CurrencyQuantity()
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
