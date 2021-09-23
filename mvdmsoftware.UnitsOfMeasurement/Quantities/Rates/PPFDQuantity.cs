using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;

namespace Ridder.UnitsOfMeasurement.Quantities.Rates
{
    public class PPFDQuantity : RateCombinedQuantity
    {
        public PPFDQuantity()
            : base(QuantityType.PPFD, Quantity.Substance, Quantity.Product( Quantity.Duration, Quantity.Area))
        {
        }
    }
}
