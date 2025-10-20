using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Units;

/// <summary>
///   Unit for <see cref="Acidity"/>.
/// </summary>
public class PhUnit : IUnit
{
   private readonly IQuantity _quantity;

   internal PhUnit(IQuantity quantity)
   {
      _quantity = quantity;
   }

   /// <inheritdoc/>
   public string Identifier { get; } = "pH";

   /// <inheritdoc/>
   public IQuantity GetQuantity()
   {
      return _quantity;
   }

   /// <inheritdoc/>
   public double FromStandardUnit(double value)
   {
      return value;
   }

   /// <inheritdoc/>
   public double ToStandardUnit(double value)
   {
      return value;
   }

   /// <inheritdoc/>
   public string GetSymbol(CultureInfo? cultureInfo = null)
   {
      return string.Empty;
   }

   /// <inheritdoc />
   public string GetFormattedValue(double value, [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null, CultureInfo? cultureInfo = null)
   {
      return value.ToString(format, cultureInfo);
   }
}