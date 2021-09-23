using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;

namespace mvdmsoftware.UnitsOfMeasurement.Quantities.Rates
{
    public class PPFDQuantity : RateCombinedQuantity
    {
        public PPFDQuantity()
            : base(QuantityType.PPFD, Quantity.Substance, Quantity.Product( Quantity.Duration, Quantity.Area))
        {
        }
    }
}
