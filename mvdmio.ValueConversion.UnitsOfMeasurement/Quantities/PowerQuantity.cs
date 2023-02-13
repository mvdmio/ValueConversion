using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In physics, power is the amount of energy transferred or converted per unit time. 
/// In the SI system, the unit of power is the watt, equal to one joule per second.
/// </summary>
public sealed class PowerQuantity : ConversionFactorQuantityBase
{
    internal PowerQuantity() 
        : base("Power", "Watt")
    {
    }

    /// <inheritdoc/>     
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("Watt", 1),
                
            //Conversions
            ("MetricHorsepower", 735.49875),
            ("MechanicalHorsepower", 745.69987158227022),
            ("HydraulicHorsepower", 745.7),
            ("ElectricalHorsepower", 746),
            ("Kilowatt", 1000),
            ("Megawatt", 1000000),
            ("Gigawatt", 1000000000)
        };
    }
}