using System;
using System.Globalization;
using System.Threading.Tasks;
using Ridder.Common;
using Ridder.UnitsOfMeasurement.Interfaces;

namespace Ridder.UnitsOfMeasurement.Bases
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

            return Compare.IsRelativeEqual(thisStandardValue, otherStandardValue);
        }

        public string GetFormattedValue(CultureInfo cultureInfo)
        {
            return _unit.GetFormattedValue(_value, cultureInfo);
        }
    }
}