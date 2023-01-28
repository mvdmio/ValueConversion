using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates
{
    /// <summary>
    /// The velocity of an object is the rate of change of its position with respect to a frame of reference, and is a function of time. 
    /// In the SI system, it is specified in units of m/s (meters per second). 
    /// Velocity is equivalent to a specification of an object's speed and direction of motion (e.g. 60 km/h to the north).
    /// </summary>
    public class VelocityQuantity : RateCombinedQuantity
    {
        internal VelocityQuantity()
            : base(QuantityType.Velocity, Quantity.Distance, Quantity.Duration)
        {
        }
    }
}
