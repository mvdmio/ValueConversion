using System;
using System.Collections.Generic;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Base.Resources.UnitsFormatting;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for units.
/// </summary>
public abstract class UnitBase : IUnit
{
   private readonly IQuantity _quantity;

   /// <inheritdoc />
   public string Identifier { get; }

   /// <summary>
   /// Constructor.
   /// </summary>
   /// <param name="identifier">The identifier of the unit.</param>
   /// <param name="quantity">The quantity of the unit.</param>
   protected UnitBase(string identifier, IQuantity quantity)
   {
      Identifier = identifier;

      _quantity = quantity;
   }

   /// <inheritdoc />
   public abstract double FromStandardUnit(double value, DateTimeOffset timestamp);

   /// <inheritdoc />
   public abstract double ToStandardUnit(double value, DateTimeOffset timestamp);

   /// <inheritdoc />
   public IQuantity GetQuantity()
   {
      return _quantity;
   }

   /// <inheritdoc />
   public string GetSymbol(CultureInfo cultureInfo)
   {
      var symbol = GetSymbolInternal(cultureInfo);

      if (symbol is null)
         throw new KeyNotFoundException($"No symbol found for Unit {Identifier}");

      return symbol;
   }

   /// <inheritdoc />
   public string GetFormattedValue(double value, CultureInfo cultureInfo)
   {
      var format = GetFormatInternal(cultureInfo) ?? UnitsFormatting._Default;
      var result = format;

      var symbol = GetSymbol(cultureInfo);
      result = result.Replace("{v}", value.ToString(cultureInfo));
      result = result.Replace("{sym}", symbol);

      return result;
   }

   /// <summary>
   /// Retrieve the symbol for this unit.
   /// </summary>
   /// <param name="cultureInfo">The culture info to use.</param>
   /// <returns>The symbol for this unit.</returns>
   protected abstract string? GetSymbolInternal(CultureInfo cultureInfo);

   /// <summary>
   /// Retrieve the value format for this unit..
   /// </summary>
   /// <param name="cultureInfo">The culture info to use.</param>
   /// <returns>The value format for this unit, or null when the default format should be used.</returns>
   protected abstract string? GetFormatInternal(CultureInfo cultureInfo);
}