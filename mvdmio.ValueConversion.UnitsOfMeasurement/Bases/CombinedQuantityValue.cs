using System;
using System.Globalization;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    public class CombinedQuantityValue : IQuantityValue
    {
        private readonly double _value;
        private readonly ICombinedUnit _unit;
        private readonly ICombinedQuantity _quantity;

        public DateTimeOffset Timestamp { get; }

        public CombinedQuantityValue(DateTimeOffset timestamp, double value, ICombinedUnit unit)
        {
            _value = value;
            _unit = unit;
            _quantity = unit.GetQuantity();

            Timestamp = timestamp;
        }

        IQuantity IQuantityValue.GetQuantity()
        {
            return GetQuantity();
        }

        public ICombinedQuantity GetQuantity()
        {
            return _quantity;
        }

        IUnit IQuantityValue.GetUnit()
        {
            return GetUnit();
        }

        public ICombinedUnit GetUnit()
        {
            return _unit;
        }

        public double GetValue()
        {
            return _value;
        }

        public double GetStandardValue()
        {
            return _unit.ToStandardUnit(_value, Timestamp);
        }

        public IQuantityValue As(IUnit unit)
        {
            if (unit is ICombinedUnit typedUnit)
            {
                return As(typedUnit);
            }

            throw new InvalidCastException($"Cannot use {unit.GetType().FullName} as {typeof(ICombinedUnit).FullName}");
        }

        public IQuantityValue As(ICombinedUnit toUnit)
        {
            return _quantity.Convert(this, toUnit);
        }

        public bool IsEqualTo(IQuantityValue other)
        {
            var thisStandardValue = GetStandardValue();
            var otherStandardValue = other.GetStandardValue();

            return Comparer.IsWithinTolerance(thisStandardValue, otherStandardValue);
        }

        public string GetFormattedValue(CultureInfo cultureInfo)
        {
            return _unit.GetFormattedValue(_value, cultureInfo);
        }
    }
}