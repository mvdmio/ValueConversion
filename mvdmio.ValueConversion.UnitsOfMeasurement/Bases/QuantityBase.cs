using System;
using System.Collections.Generic;
using System.Linq;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    public abstract class QuantityBase<TEnum> : IQuantity<TEnum>
        where TEnum : Enum
    {
        private readonly TEnum _standardUnitType;

        IUnit IQuantity.StandardUnit => StandardUnit;
        public string Identifier { get; }

        public IUnit<TEnum> StandardUnit => GetUnit(_standardUnitType);
        
        protected QuantityBase(QuantityType type, TEnum standardUnitType)
        {
            _standardUnitType = standardUnitType;

            Identifier = type.ToString();
        }

        public abstract IDictionary<TEnum, IUnit<TEnum>> GetUnits();

        IEnumerable<IUnit> IQuantity.GetUnits()
        {
            return GetUnits().Values;
        }

        public IUnit GetUnit(string unitIdentifier)
        {
            var unit = GetUnits().Values.SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

            if(unit == null)
                throw new KeyNotFoundException($"Unit '{unitIdentifier}' could not be found for quantity {GetType().Name}");

            return unit;
        }

        public IQuantityValue Convert(IQuantityValue quantityValue, TEnum toUnitType)
        {
            var toUnit = GetUnit(toUnitType);
            return Convert(quantityValue, toUnit);
        }

        public IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit)
        {
            if (toUnit is not IUnit<TEnum> typedUnit)
                throw new InvalidCastException($"Cannot use {toUnit.GetType().FullName} as {typeof(IUnit<TEnum>).FullName}");

            return Convert(quantityValue, typedUnit);
        }

        public IQuantityValue Convert(IQuantityValue quantityValue, IUnit<TEnum> toUnit)
        {
            if (quantityValue.GetQuantity().Identifier != Identifier)
                throw new InvalidCastException($"{GetType().FullName} cannot convert quantity of type {quantityValue.GetQuantity().Identifier}");

            var standardValue = quantityValue.GetStandardValue();
            var convertedValue = toUnit.FromStandardUnit(standardValue, quantityValue.Timestamp);

            return new QuantityValue(quantityValue.Timestamp, convertedValue, toUnit);
        }

        public IUnit<TEnum> GetUnit(TEnum unit)
        {
            var units = GetUnits();

            if (!units.ContainsKey(_standardUnitType))
                throw new KeyNotFoundException($"{GetType().Name} does not contain a unit of type {_standardUnitType}.");

            return units[unit];
        }

        public IQuantityValue<TEnum> CreateValue(double value, TEnum unitType)
        {
            return CreateValue(value, GetUnit(unitType));
        }

        public IQuantityValue CreateValue(double value, IUnit unit)
        {
            return CreateValue(DateTime.UtcNow, value, unit);
        }

        public IQuantityValue<TEnum> CreateValue(double value, IUnit<TEnum> unit)
        {
            return CreateValue(DateTime.UtcNow, value, unit);
        }

        public IQuantityValue<TEnum> CreateValue(DateTime timestamp, double value, TEnum unitType)
        {
            return CreateValue(timestamp, value, GetUnit(unitType));
        }

        public IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit)
        {
            if (unit is IUnit<TEnum> typedUnit)
            {
                return CreateValue(timestamp, value, typedUnit);
            }

            throw new InvalidCastException($"Cannot use {unit.GetType().FullName} as typed unit {typeof(IUnit<TEnum>).FullName}");
        }

        public IQuantityValue<TEnum> CreateValue(DateTime timestamp, double value, IUnit<TEnum> unit)
        {
            return new QuantityValue<TEnum>(timestamp, value, unit);
        }
    }
}