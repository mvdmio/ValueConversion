using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities
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
