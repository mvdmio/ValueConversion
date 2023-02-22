using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Currency.ExchangeRates;
using mvdmio.ValueConversion.Currency.Quantities;
using mvdmio.ValueConversion.Currency.Resources.UnitSymbols;

namespace mvdmio.ValueConversion.Currency.Units;

/// <summary>
/// Base class for currency units.
/// </summary>
public class CurrencyUnit : UnitBase
{
   private readonly CurrencyQuantity _quantity;

   internal CurrencyUnit(string identifier, CurrencyQuantity quantity)
        : base(identifier, quantity)
   {
      _quantity = quantity;
   }

    /// <inheritdoc />
    public override double FromStandardUnit(double value, DateTimeOffset timestamp)
    {
        var exchangeRate = CurrencyExchangeRate.Get(_quantity.StandardUnit.Identifier, Identifier, timestamp.DateTime);
        return value * exchangeRate;
    }

    /// <inheritdoc />
    public override double ToStandardUnit(double value, DateTimeOffset timestamp)
    {
        var exchangeRate = CurrencyExchangeRate.Get(_quantity.StandardUnit.Identifier, Identifier, timestamp.DateTime);
        return value / exchangeRate;
    }

    /// <inheritdoc />
    protected override string? GetSymbolInternal(CultureInfo cultureInfo)
    {
       return UnitSymbols.ResourceManager.GetString(Identifier, cultureInfo);
    }

    /// <inheritdoc />
    protected override string? GetFormatInternal(CultureInfo cultureInfo)
    {
       return null;
    }
}