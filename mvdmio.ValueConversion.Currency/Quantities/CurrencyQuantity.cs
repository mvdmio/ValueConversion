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
    private readonly IUnit[] _units;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CurrencyQuantity()
        : base("Currency", "UnitedStatesDollar")
    {
       _units = new IUnit[] {
          new CurrencyUnit("UnitedStatesDollar", this),
          new CurrencyUnit("Euro", this),
          new CurrencyUnit("MexicanPeso", this),
          new CurrencyUnit("CanadianDollar", this)
       };
    }

    /// <inheritdoc/>     
    public override IEnumerable<IUnit> GetUnits()
    {
        return _units;
    }
}