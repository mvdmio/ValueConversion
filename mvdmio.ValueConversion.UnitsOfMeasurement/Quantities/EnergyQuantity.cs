using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In physics, energy is the quantitative property that must be transferred to an object in order to perform work on, or to heat, the object.
/// Energy is a conserved quantity; the law of conservation of energy states that energy can be converted in form, but not created or destroyed.
/// The SI unit of energy is the joule, which is the energy transferred to an object by the work of moving it a distance of 1 metre against a force of 1 newton. 
/// </summary>
public sealed class EnergyQuantity : ConversionFactorQuantityBase
{
    internal EnergyQuantity() 
        : base("Energy", "Joule")
    {
    }

    /// <inheritdoc/>     
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("Joule", 1),
                
            //Conversions
            ("Calorie", 4.18400),
            ("Kilocalorie", 4184),
            ("Kilojoule", 1000),
            ("KilowattHour", 3600000),
            ("MegaJoule", 1000000),
            ("MegawattHour", 3600000000),
            ("WattHour", 3600)
        };
    }
}