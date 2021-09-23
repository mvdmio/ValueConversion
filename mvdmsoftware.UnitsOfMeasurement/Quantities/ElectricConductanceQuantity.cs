using System.Collections.Generic;
using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// In electronics and electromagnetism, electronical conducance is the reciproclal quantity of electric resistance.
    /// In the SI system, it is specified in units S (Siemens).
    /// The resistance, and thus conductance of an object depends in large part on the material it is made of.
    /// </summary>
    public sealed class ElectricConductanceQuantity : ConversionFactorQuantityBase<ElectricConductanceType>
    {
        internal ElectricConductanceQuantity() 
            : base(QuantityType.ElectricConductance, ElectricConductanceType.Siemens)
        {
        }

        /// <inheritdoc/>     
        protected override IEnumerable<(ElectricConductanceType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (ElectricConductanceType.Siemens, 1),
                
                //Conversions
                (ElectricConductanceType.Microsiemens, 0.0000001),
                (ElectricConductanceType.Millisiemens, 0.001)
            };
        }
    }
}