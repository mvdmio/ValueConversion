using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates
{
    public class PPFDQuantity : RateCombinedQuantity
    {
        public PPFDQuantity()
            : base(QuantityType.PPFD, Quantity.Substance, Quantity.Product( Quantity.Duration, Quantity.Area))
        {
        }
    }
}
