using System.Collections.Generic;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Quantities
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
