using System;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Interfaces;

namespace Ridder.UnitsOfMeasurement.Bases
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

        public sealed override Task<double> FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value / _toStandardValueConversionFactor);
        }

        public sealed override Task<double> ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value * _toStandardValueConversionFactor);
        }
    }
}