﻿using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates;

/// <summary>
/// Electrical conductivity is the measure of a material's ability to allow the transport of an electric charge. 
/// Its SI is the siemens per meter, (A2s3m−3kg−1) (named after Werner von Siemens) or, more simply, Sm−1. 
/// It is the ratio of the current density to the electric field strength.
/// </summary>
public class ElectricConductivityQuantity : RateCombinedQuantity
{
    internal ElectricConductivityQuantity() 
        : base("ElectricConductivity", Quantity.Known.ElectricConductance(), Quantity.Known.Distance())
    {
    }
}