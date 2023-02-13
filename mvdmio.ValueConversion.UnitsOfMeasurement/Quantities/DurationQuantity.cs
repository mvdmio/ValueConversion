using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// The amount of elapsed time between two events.
/// In the SI system, it is specified in units of s (seconds). 
/// </summary>
public sealed class DurationQuantity : ConversionFactorQuantityBase
{
    internal DurationQuantity() 
        : base("Duration", "Second")
    {
    }

    /// <inheritdoc/>     
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("Second", 1),
                
            //Conversions
            ("Nanosecond", 1e-9),
            ("Millisecond", 0.001),
            ("Minute", 60),
            ("Hour", 3600),
            ("Day", 86400),
            ("Week", 604800),
            ("Month", 2629743.83),
            ("Quarter", 7889231.49),
            ("Year", 31556926),
            ("Decade", 315569260),
            ("Century", 3155692600)
        };
    }
}