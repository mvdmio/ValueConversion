using System.Collections.Generic;
using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// In mathematics, a ratio indicates how many times one number contains another.
    /// </summary>
    public class RatioQuantity : ConversionFactorQuantityBase<RatioType>
    {
        internal RatioQuantity()
            : base(QuantityType.Ratio, RatioType.Percent)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<(RatioType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                (RatioType.Percent, 1),
                (RatioType.Permille, 0.1),
                (RatioType.PartsPerMillion, 0.0001),
                (RatioType.PartsPerBillion, 0.0000001)
            };
        }
    }
}
