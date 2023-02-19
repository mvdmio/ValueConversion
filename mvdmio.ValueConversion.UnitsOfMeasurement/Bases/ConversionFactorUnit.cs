using System;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
   public class ConversionFactorUnit : UnitOfMeasurementUnitBase
    {
        private readonly double _toStandardValueConversionFactor;

        internal ConversionFactorUnit(IQuantity quantity, string identifier, double toStandardValueConversionFactor)
            : base(identifier, quantity)
        {
            _toStandardValueConversionFactor = toStandardValueConversionFactor;
        }

        /// <inheritdoc />
        public sealed override double FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value / _toStandardValueConversionFactor;
        }

        /// <inheritdoc />
        public sealed override double ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value * _toStandardValueConversionFactor;
        }
    }
}