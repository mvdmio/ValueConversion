using System;
using System.Globalization;
using System.Threading.Tasks;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;
using mvdmsoftware.UnitsOfMeasurement.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Bases
{
    public class QuantityValue : IQuantityValue
    {
        private readonly double _value;
        private readonly IQuantity _quantity;
        private readonly IUnit _unit;

        public DateTimeOffset Timestamp { get; }

        public QuantityValue(DateTimeOffset timestamp, double value, IUnit unit)
        {
            _value = value;
            _quantity = unit.GetQuantity();
            _unit = unit;

            Timestamp = timestamp;
        }

        public IQuantity GetQuantity()
        {
            return _quantity;
        }

        public IUnit GetUnit()
        {
            return _unit;
        }

        public double GetValue()
        {
            return _value;
        }

        public Task<double> GetStandardValue()
        {
            return _unit.ToStandardUnit(_value, Timestamp);
        }

        public Task<IQuantityValue> As(IUnit unit)
        {
            return _quantity.Convert(this, unit);
        }

        public async Task<bool> IsEqualTo(IQuantityValue other)
        {
            var thisStandardValue = await GetStandardValue();
            var otherStandardValue = await other.GetStandardValue();

            return Comparer.IsWithinTolerance(thisStandardValue, otherStandardValue);
        }

        public string GetFormattedValue(CultureInfo cultureInfo)
        {
            return _unit.GetFormattedValue(_value, cultureInfo);
        }
    }

    public class QuantityValue<TEnum> : QuantityValue, IQuantityValue<TEnum> where TEnum : Enum
    {
        private readonly IQuantity<TEnum> _quantity;
        private readonly IUnit<TEnum> _unit;

        public QuantityValue(DateTimeOffset timestamp, double value, IUnit<TEnum> unit)
            : base(timestamp, value, unit)
        {
            _quantity = unit.GetQuantity();
            _unit = unit;
        }

        public new IQuantity<TEnum> GetQuantity()
        {
            return _quantity;
        }

        public new IUnit<TEnum> GetUnit()
        {
            return _unit;
        }

        public Task<IQuantityValue> As(TEnum unitEnum)
        {
            var unit = _quantity.GetUnit(unitEnum);
            return As(unit);
        }
    }
}