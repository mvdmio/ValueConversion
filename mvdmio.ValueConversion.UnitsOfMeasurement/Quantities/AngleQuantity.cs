using System;
using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In plane geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle.
/// </summary>
public sealed class AngleQuantity : ConversionFactorQuantityBase
{
    internal AngleQuantity()
        : base("Angle", "Degree")
    {
    }

    /// <inheritdoc/>     
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            ("Degree", 1),
            ("Radian", 180 / Math.PI),
        };
    }
}