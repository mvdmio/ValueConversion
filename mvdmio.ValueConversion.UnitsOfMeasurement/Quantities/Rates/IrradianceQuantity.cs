﻿using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates
{
    /// <summary>
    /// Irradiance (or flux density) is a term of radiometry and is defined as the radiant flux received by some surface per unit area.
    /// In the SI system, it is specified in units of W/m2 (watts per square meter). 
    /// Irradiance may be applied to light or other kinds of radiation.
    /// </summary>
    public class IrradianceQuantity : RateCombinedQuantity
    {
        internal IrradianceQuantity() 
            : base(QuantityType.Irradiance, Quantity.Power, Quantity.Area)
        {
        }
    }
}