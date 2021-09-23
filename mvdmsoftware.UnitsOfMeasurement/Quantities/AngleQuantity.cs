using System.Collections.Generic;
using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// In plane geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle.
    /// </summary>
    public sealed class AngleQuantity : ConversionFactorQuantityBase<AngleType>
    {
        internal AngleQuantity()
            : base(QuantityType.Angle, AngleType.Degree)
        {
        }

        /// <inheritdoc/>     
        protected override IEnumerable<(AngleType type, double conversionFactor)> GetConversionFactors()
        {
            return new (AngleType, double)[] {
                (AngleType.Degree, 1),
                (AngleType.Radian, 57.2957795),
            };
        }
    }
}
