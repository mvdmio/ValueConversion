using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Currency.Quantities;

namespace mvdmio.ValueConversion.Currency;

/// <summary>
/// Extension class for providing easy access to Known Quantities on <see cref="KnownQuantities" />.
/// </summary>
public static class SatelliteExtensions
{
   /// <inheritdoc cref="CurrencyQuantity"/>
   public static CurrencyQuantity Currency(this KnownQuantities _)
   {
      return new CurrencyQuantity();
   }
}