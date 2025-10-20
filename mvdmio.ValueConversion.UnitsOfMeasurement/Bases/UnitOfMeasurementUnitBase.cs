using System.Globalization;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Resources.UnitsFormatting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Resources.UnitSymbols;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

/// <summary>
/// Base class for units in the UnitsOfMeasurement package.
/// </summary>
public abstract class UnitOfMeasurementUnitBase : UnitBase
{
   /// <inheritdoc />
   protected UnitOfMeasurementUnitBase(string identifier, IQuantity quantity)
      : base(identifier, quantity)
   {
   }

   /// <inheritdoc />
   protected override string? GetSymbolInternal(CultureInfo? cultureInfo = null)
   {
      return UnitSymbols.ResourceManager.GetString(Identifier, cultureInfo ?? CultureInfo.CurrentCulture);
   }

   /// <inheritdoc />
   protected override string? GetFormatInternal(CultureInfo? cultureInfo = null)
   {
      return UnitsFormatting.ResourceManager.GetString(Identifier, cultureInfo ?? CultureInfo.CurrentCulture);
   }
}