using System;
using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities
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
                (AngleType.Radian, 180 / Math.PI),
            };
        }
    }
}
