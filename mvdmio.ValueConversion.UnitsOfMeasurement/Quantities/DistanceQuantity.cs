using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// Distance is a numerical measurement of how far apart objects or points are. 
    /// In physics or everyday usage, distance may refer to a physical length or an estimation based on other criteria (e.g. "two counties over").
    /// In the SI system, it is specified in units of m (meters). 
    /// </summary>
    public sealed class DistanceQuantity : ConversionFactorQuantityBase<DistanceType>
    {
        internal DistanceQuantity()
            : base(QuantityType.Distance, DistanceType.Meter)
        {
        }

        /// <inheritdoc/>        
        protected override IEnumerable<(DistanceType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (DistanceType.Meter, 1),
                
                //Metric
                (DistanceType.Millimeter, 0.001),
                (DistanceType.Centimeter, 0.01),
                (DistanceType.Hectometer, 100),
                (DistanceType.Kilometer, 1000),
                
                //Imperial
                (DistanceType.Inch, 0.0254),
                (DistanceType.Feet, 0.3048),
                (DistanceType.Yard, 0.9144),
                (DistanceType.Mile, 1609.344)
            };
        }
    }
}
