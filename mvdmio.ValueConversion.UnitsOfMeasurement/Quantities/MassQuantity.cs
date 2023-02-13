using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Mass is both a property of a physical body and a measure of its resistance to acceleration (a change in its state of motion) when a net force is applied.
/// An object's mass also determines the strength of its gravitational attraction to other bodies. 
/// The basic SI unit of mass is the kilogram (kg).
/// 
/// In physics, mass is not the same as weight, even though mass is often determined by measuring the object's weight using a spring scale, 
/// rather than balance scale comparing it directly with known masses. An object on the Moon would weigh less than it does on Earth because of the lower gravity, 
/// but it would still have the same mass. This is because weight is a force, while mass is the property that (along with gravity) determines the strength of this force. 
/// </summary>
public class MassQuantity : ConversionFactorQuantityBase
{
    internal MassQuantity() 
        : base("Mass", "Kilogram")
    {
    }

    /// <inheritdoc/>     
    protected sealed override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("Kilogram", 1),
                
            //Metric
            ("Microgram", 1e-9),
            ("Milligram", 1e-6),
            ("Gram", 0.001),
            ("Tonne", 1000),
            ("Kilotonne", 1000000),
                
            //Imperial
            ("Ounce", 0.0283495231),
            ("Pound", 0.45359237),
            ("Stone", 6.35029318),
            ("Kilopound", 453.59237),
        };
    }
}