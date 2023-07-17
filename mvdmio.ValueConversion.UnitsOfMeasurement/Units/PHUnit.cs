using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Units;

/// <summary>
/// Unit for <see cref="Acidity"/>.
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
   public double FromStandardUnit(double value, DateTimeOffset timestamp)
   {
      return value;
   }

   /// <inheritdoc/>
   public double ToStandardUnit(double value, DateTimeOffset timestamp)
   {
      return value;
   }

   /// <inheritdoc/>
   public string GetSymbol(CultureInfo cultureInfo)
   {
      return string.Empty;
   }

   /// <inheritdoc/>
   public string GetFormattedValue(double value, CultureInfo cultureInfo)
   {
      return value.ToString(cultureInfo);
   }

   /// <inheritdoc />
   public string GetFormattedValue(double value, CultureInfo cultureInfo, int decimalPoints)
   {
      return Math.Round(value,decimalPoints).ToString(cultureInfo);
   }
}