using System.Collections.Generic;
using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// Volume is the quantity of three-dimensional space enclosed by a closed surface, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.
    /// Volume is often quantified numerically using the SI derived unit, the cubic metre.
    /// </summary>
    public sealed class VolumeQuantity : ConversionFactorQuantityBase<VolumeType>
    {
        internal VolumeQuantity()
            : base(QuantityType.Volume, VolumeType.CubicMeter)
        {
        }

        /// <inheritdoc/>     
        protected override IEnumerable<(VolumeType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (VolumeType.CubicMeter, 1),
                
                //Metric
                (VolumeType.CubicMillimeter, 1e-9),
                (VolumeType.CubicCentimeter, 1e-6),
                (VolumeType.FluidCubicCentimeter, 1e-6),
                (VolumeType.Milliliter, 1e-6),
                (VolumeType.Centiliter, 1e-5),
                (VolumeType.Deciliter, 0.0001),
                (VolumeType.CubicDecimeter, 0.001),
                (VolumeType.Liter, 0.001),
                (VolumeType.Hectoliter, 0.1),
                (VolumeType.CubicHectometer, 1000000),
                (VolumeType.CubicKilometer, 1e9),
                
                //Imperial
                (VolumeType.CubicInch, 1.6387064e-5),
                (VolumeType.CubicFoot, 0.0283168466),
                (VolumeType.UsGallon, 0.00378541178),
                (VolumeType.ImperialGallon, 0.00454609188),
                (VolumeType.CubicYard, 0.764554858),
                (VolumeType.CubicMile, 4.16818183e9)
            };
        }
    }
}