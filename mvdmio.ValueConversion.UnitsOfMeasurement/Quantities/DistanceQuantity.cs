using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Distance is a numerical measurement of how far apart objects or points are. 
/// In physics or everyday usage, distance may refer to a physical length or an estimation based on other criteria (e.g. "two counties over").
/// In the SI system, it is specified in units of m (meters). 
/// </summary>
public sealed class DistanceQuantity : ConversionFactorQuantityBase
{
    internal DistanceQuantity()
        : base("Distance", "Meter")
    {
    }

    /// <inheritdoc/>        
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("Meter", 1),
                
            //Metric
            ("Millimeter", 0.001),
            ("Centimeter", 0.01),
            ("Hectometer", 100),
            ("Kilometer", 1000),
                
            //Imperial
            ("Inch", 0.0254),
            ("Feet", 0.3048),
            ("Yard", 0.9144),
            ("Mile", 1609.344)
        };
    }
}