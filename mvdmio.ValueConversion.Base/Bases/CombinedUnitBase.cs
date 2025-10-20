using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for combined units.
/// </summary>
public abstract class CombinedUnitBase : ICombinedUnit
{
   private readonly ICombinedQuantity _quantity;

   /// <inheritdoc />
   public abstract string Identifier { get; }

   /// <inheritdoc />
   public IUnit NumeratorUnit { get; }

   /// <inheritdoc />
   public IUnit DenominatorUnit { get; }

   /// <summary>
   /// Constructor.
   /// </summary>
   /// <param name="numeratorUnit">The numerator unit.</param>
   /// <param name="denominatorUnit">The denominator unit.</param>
   /// <param name="quantity">The quantity of this unit.</param>
   protected CombinedUnitBase(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
   {
      _quantity = quantity;

      NumeratorUnit = numeratorUnit;
      DenominatorUnit = denominatorUnit;
   }

   /// <inheritdoc />
   public abstract double FromStandardUnit(double value);

   /// <inheritdoc />
   public abstract double ToStandardUnit(double value);

   /// <inheritdoc />
   public abstract string GetSymbol(CultureInfo cultureInfo);

   IQuantity IUnit.GetQuantity()
   {
      return GetQuantity();
   }

   /// <inheritdoc />
   public ICombinedQuantity GetQuantity()
   {
      return _quantity;
   }

   /// <inheritdoc />
   public string GetFormattedValue(double value, [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null, CultureInfo? cultureInfo = null)
   {
      var symbol = GetSymbol(cultureInfo ?? CultureInfo.CurrentCulture);
      return $"{value.ToString(format, cultureInfo)} {symbol}";
   }
}