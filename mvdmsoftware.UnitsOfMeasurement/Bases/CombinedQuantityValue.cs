using System;
using System.Globalization;
using System.Threading.Tasks;
using Ridder.Common;
using Ridder.UnitsOfMeasurement.Interfaces;

namespace Ridder.UnitsOfMeasurement.Bases
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

        public Task<double> GetStandardValue()
        {
            return _unit.ToStandardUnit(_value, Timestamp);
        }

        public async Task<IQuantityValue> As(IUnit unit)
        {
            if (unit is ICombinedUnit typedUnit)
            {
                return await As(typedUnit);
            }

            throw new InvalidCastException($"Cannot use {unit.GetType().FullName} as {typeof(ICombinedUnit).FullName}");
        }

        public Task<IQuantityValue> As(ICombinedUnit toUnit)
        {
            return _quantity.Convert(this, toUnit);
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