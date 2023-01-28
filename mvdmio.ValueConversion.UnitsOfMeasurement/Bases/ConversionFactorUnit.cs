using System;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    public class ConversionFactorUnit<TEnum> : UnitBase<TEnum>
        where TEnum : Enum
    {
        private readonly double _toStandardValueConversionFactor;

        internal ConversionFactorUnit(IQuantity<TEnum> quantity, TEnum type, double toStandardValueConversionFactor)
            : base(quantity, type)
        {
            _toStandardValueConversionFactor = toStandardValueConversionFactor;
        }

        public sealed override double FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value / _toStandardValueConversionFactor;
        }

        public sealed override double ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value * _toStandardValueConversionFactor;
        }
    }
}