using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;

namespace mvdmsoftware.UnitsOfMeasurement.Quantities.Rates
{
    /// <summary>
    /// Electrical conductivity is the measure of a material's ability to allow the transport of an electric charge. 
    /// Its SI is the siemens per meter, (A2s3m−3kg−1) (named after Werner von Siemens) or, more simply, Sm−1. 
    /// It is the ratio of the current density to the electric field strength.
    /// </summary>
    public class ElectricConductivityQuantity : RateCombinedQuantity
    {
        internal ElectricConductivityQuantity() 
            : base(QuantityType.ElectricConductivity, Quantity.ElectricConductance, Quantity.Distance)
        {
        }
    }
}