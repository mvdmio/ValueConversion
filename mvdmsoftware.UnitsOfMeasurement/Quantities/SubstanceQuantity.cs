using System.Collections.Generic;
using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Quantities
{
    public sealed class SubstanceQuantity : ConversionFactorQuantityBase<SubstanceType>
    {
        public SubstanceQuantity() 
            : base(QuantityType.Substance, SubstanceType.Mole)
        {
        }

        protected override IEnumerable<(SubstanceType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (SubstanceType.Mole, 1),
                (SubstanceType.Millimole, 0.001),
                (SubstanceType.Micromole, 0.000001)
            };
        }
    }
}
