using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// Mass is both a property of a physical body and a measure of its resistance to acceleration (a change in its state of motion) when a net force is applied.
    /// An object's mass also determines the strength of its gravitational attraction to other bodies. 
    /// The basic SI unit of mass is the kilogram (kg).
    /// 
    /// In physics, mass is not the same as weight, even though mass is often determined by measuring the object's weight using a spring scale, 
    /// rather than balance scale comparing it directly with known masses. An object on the Moon would weigh less than it does on Earth because of the lower gravity, 
    /// but it would still have the same mass. This is because weight is a force, while mass is the property that (along with gravity) determines the strength of this force. 
    /// </summary>
    public class MassQuantity : ConversionFactorQuantityBase<MassType>
    {
        internal MassQuantity() 
            : base(QuantityType.Mass, MassType.Kilogram)
        {
        }

        /// <inheritdoc/>     
        protected sealed override IEnumerable<(MassType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (MassType.Kilogram, 1),
                
                //Metric
                (MassType.Microgram, 1e-9),
                (MassType.Milligram, 1e-6),
                (MassType.Gram, 0.001),
                (MassType.Tonne, 1000),
                (MassType.Kilotonne, 1000000),
                
                //Imperial
                (MassType.Ounce, 0.0283495231),
                (MassType.Pound, 0.45359237),
                (MassType.Stone, 6.35029318),
                (MassType.Kilopound, 453.59237),
            };
        }
    }
}
