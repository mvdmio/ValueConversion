using System;
using System.Globalization;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Units
{
    /// <summary>
    /// This unit is used for values that do not have a quantity.
    /// We've created a <see cref="ScalarQuantity"/> and <see cref="ScalarUnit"/> for these cases.
    /// </summary>
    public class ScalarUnit : IUnit
    {
        private readonly IQuantity _quantity;

        internal ScalarUnit(IQuantity quantity)
        {
            _quantity = quantity;
        }

        /// <inheritdoc/>
        public string Identifier { get; } = "Scalar";

        /// <inheritdoc/>
        public IQuantity GetQuantity()
        {
            return _quantity;
        }

        /// <inheritdoc/>
        public double FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value;
        }

        /// <inheritdoc/>
        public double ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value;
        }

        /// <inheritdoc/>
        public string GetSymbol(CultureInfo cultureInfo)
        {
            return string.Empty;
        }

        /// <inheritdoc/>
        public string GetFormattedValue(double value, CultureInfo cultureInfo)
        {
            return value.ToString(cultureInfo);
        }
    }
}