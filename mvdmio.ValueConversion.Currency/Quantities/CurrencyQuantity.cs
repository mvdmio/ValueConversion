using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
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
    /// The UnitedStatesDollar unit of <see cref="CurrencyQuantity"/>. This is the standard unit of <see cref="CurrencyQuantity"/>.
    /// </summary>
    public static IUnit UnitedStatsDollar => Quantity.Known.Currency().GetUnit("UnitedStatesDollar");
    
    /// <summary>
    /// The Euro unit of <see cref="CurrencyQuantity"/>.
    /// </summary>
    public static IUnit Euro => Quantity.Known.Currency().GetUnit("Euro");
    
    /// <summary>
    /// The MexicanPeso unit of <see cref="CurrencyQuantity"/>.
    /// </summary>
    public static IUnit MexicanPeso => Quantity.Known.Currency().GetUnit("MexicanPeso");
    
    /// <summary>
    /// The CanadianDollar unit of <see cref="CurrencyQuantity"/>.
    /// </summary>
    public static IUnit CanadianDollar => Quantity.Known.Currency().GetUnit("CanadianDollar");
    
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