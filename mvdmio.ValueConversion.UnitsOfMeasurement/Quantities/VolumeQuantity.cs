using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Volume is the quantity of three-dimensional space enclosed by a closed surface, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.
/// Volume is often quantified numerically using the SI derived unit, the cubic metre.
/// </summary>
public sealed class VolumeQuantity : ConversionFactorQuantityBase
{
    internal VolumeQuantity()
        : base("Volume", "CubicMeter")
    {
    }

    /// <inheritdoc/>     
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("CubicMeter", 1),
                
            //Metric
            ("CubicMillimeter", 1e-9),
            ("CubicCentimeter", 1e-6),
            ("FluidCubicCentimeter", 1e-6),
            ("Milliliter", 1e-6),
            ("Centiliter", 1e-5),
            ("Deciliter", 0.0001),
            ("CubicDecimeter", 0.001),
            ("Liter", 0.001),
            ("Hectoliter", 0.1),
            ("CubicHectometer", 1000000),
            ("CubicKilometer", 1e9),
                
            //Imperial
            ("CubicInch", 1.6387064e-5),
            ("CubicFoot", 0.0283168466),
            ("UsGallon", 0.00378541178),
            ("ImperialGallon", 0.00454609188),
            ("CubicYard", 0.764554858),
            ("CubicMile", 4.16818183e9)
        };
    }
}