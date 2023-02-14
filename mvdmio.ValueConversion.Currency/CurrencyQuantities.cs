using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Currency.Quantities;

namespace mvdmio.ValueConversion.Currency;

public static class CurrencyQuantities
{
    public static CurrencyQuantity Currency(this KnownQuantities _)
    {
        return new CurrencyQuantity();
    }
}