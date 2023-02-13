using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Currency.Units;

namespace mvdmio.ValueConversion.Currency.Quantities;

/// <summary>
/// Currency is a medium of exchange for goods and services. 
/// In short, it's money, in the form of paper or coins, usually issued by a government and generally accepted at its face value as a method of payment.
/// </summary>
public sealed class CurrencyQuantity : QuantityBase
{
    private readonly object _lockObject = new();
    private IUnit[] _units;

    public CurrencyQuantity()
        : base("Currency", "UnitedStatesDollar")
    {
    }

    /// <inheritdoc/>     
    public override IEnumerable<IUnit> GetUnits()
    {
        if (_units == null)
        {
            lock (_lockObject)
            {
                if (_units == null)
                {
                    var units =  new IUnit[] {
                        new CurrencyUnit("UnitedStatesDollar"),
                        new CurrencyUnit("Euro"),
                        new CurrencyUnit("MexicanPeso"),
                        new CurrencyUnit("CanadianDollar")
                    };
                    _units = units;
                }
            }
        }

        return _units;
    }
}