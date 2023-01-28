using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// The amount of elapsed time between two events.
    /// In the SI system, it is specified in units of s (seconds). 
    /// </summary>
    public sealed class DurationQuantity : ConversionFactorQuantityBase<DurationType>
    {
        internal DurationQuantity() 
            : base(QuantityType.Duration, DurationType.Second)
        {
        }

        /// <inheritdoc/>     
        protected override IEnumerable<(DurationType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (DurationType.Second, 1),
                
                //Conversions
                (DurationType.Nanosecond, 1e-9),
                (DurationType.Millisecond, 0.001),
                (DurationType.Minute, 60),
                (DurationType.Hour, 3600),
                (DurationType.Day, 86400),
                (DurationType.Week, 604800),
                (DurationType.Month, 2629743.83),
                (DurationType.Quarter, 7889231.49),
                (DurationType.Year, 31556926),
                (DurationType.Decade, 315569260),
                (DurationType.Century, 3155692600)
            };
        }
    }
}
