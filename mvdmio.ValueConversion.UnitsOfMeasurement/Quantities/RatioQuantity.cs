using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In mathematics, a ratio indicates how many times one number contains another.
/// </summary>
public class RatioQuantity : ConversionFactorQuantityBase
{
    internal RatioQuantity()
        : base("Ratio", "Percent")
    {
    }

    /// <inheritdoc/>
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            ("Percent", 1),
            ("Permille", 0.1),
            ("PartsPerMillion", 0.0001),
            ("PartsPerBillion", 0.0000001)
        };
    }
}