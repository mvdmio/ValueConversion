using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

public sealed class SubstanceQuantity : ConversionFactorQuantityBase
{
    public SubstanceQuantity() 
        : base("Substance", "Mole")
    {
    }

    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("Mole", 1),
            
            ("Millimole", 0.001),
            ("Micromole", 0.000001)
        };
    }
}