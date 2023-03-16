using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Currency.Quantities;

namespace mvdmio.ValueConversion.Currency;

/// <summary>
/// Extension class for providing easy access to Known Quantities on <see cref="KnownQuantities" />.
/// </summary>
public static class SatelliteExtensions
{
   private static readonly CurrencyQuantity _currency;

   static SatelliteExtensions()
   {
      _currency = new CurrencyQuantity();
   }

   /// <summary>
   /// Sets up the quantity library with Units of Measurement quantities.
   /// </summary>
   /// <param name="_">The extension class</param>
   public static void WithCurrencies(this QuantitySetup _)
   {
      // Calling this method will run the static constructor, setting up the quantities.
   }

   /// <inheritdoc cref="CurrencyQuantity"/>
   public static CurrencyQuantity Currency(this KnownQuantities _) => _currency;
}