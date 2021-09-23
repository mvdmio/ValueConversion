using System.Collections.Generic;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Quantities
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