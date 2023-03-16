using System.Globalization;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Resources.UnitsFormatting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Resources.UnitSymbols;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

public abstract class UnitOfMeasurementUnitBase : UnitBase
{
   /// <inheritdoc />
   protected UnitOfMeasurementUnitBase(string identifier, IQuantity quantity)
      : base(identifier, quantity)
   {
   }

   /// <inheritdoc />
   protected override string? GetSymbolInternal(CultureInfo cultureInfo)
   {
      return UnitSymbols.ResourceManager.GetString(Identifier, cultureInfo);
   }

   /// <inheritdoc />
   protected override string? GetFormatInternal(CultureInfo cultureInfo)
   {
      return UnitsFormatting.ResourceManager.GetString(Identifier, cultureInfo);
   }
}