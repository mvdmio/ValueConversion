using System;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Currency.ExchangeRates;
using mvdmio.ValueConversion.Currency.Quantities;

namespace mvdmio.ValueConversion.Currency.Units;

/// <summary>
/// Base class for currency units.
/// </summary>
public class CurrencyUnit : UnitBase
{
    internal CurrencyUnit(string identifier)
        : base(new CurrencyQuantity(), identifier)
    {
    }

    /// <inheritdoc />
    public override double FromStandardUnit(double value, DateTimeOffset timestamp)
    {
        var exchangeRate = CurrencyExchangeRate.Get(new CurrencyQuantity().StandardUnit.Identifier, Identifier, timestamp.DateTime);
        return value * exchangeRate;
    }

    /// <inheritdoc />
    public override double ToStandardUnit(double value, DateTimeOffset timestamp)
    {
        var exchangeRate = CurrencyExchangeRate.Get(new CurrencyQuantity().StandardUnit.Identifier, Identifier, timestamp.DateTime);
        return value / exchangeRate;
    }
}