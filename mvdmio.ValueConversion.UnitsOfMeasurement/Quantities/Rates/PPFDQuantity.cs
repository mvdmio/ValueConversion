using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates;

public class PPFDQuantity : RateCombinedQuantity
{
    public PPFDQuantity()
        : base("PPFD", Quantity.Known.Substance(), Quantity.Product(Quantity.Known.Duration(), Quantity.Known.Area()))
    {
    }
}