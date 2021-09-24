using System;
using System.Collections.Generic;

namespace mvdmsoftware.UnitsOfMeasurement.Interfaces
{
    public interface IQuantity
    {
        IUnit StandardUnit { get; }
        string Identifier { get; }
        
        IEnumerable<IUnit> GetUnits();
        IUnit GetUnit(string unitIdentifier);

        IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit);
        IQuantityValue CreateValue(double value, IUnit unit);
        IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit);
    }

    public interface IQuantity<TEnum> : IQuantity
        where TEnum : Enum
    {
        new IUnit<TEnum> StandardUnit { get; }
        IUnit<TEnum> GetUnit(TEnum unit);
        new IDictionary<TEnum, IUnit<TEnum>> GetUnits();
        IQuantityValue Convert(IQuantityValue quantityValue, TEnum toUnitType);
        IQuantityValue Convert(IQuantityValue quantityValue, IUnit<TEnum> toUnit);
        IQuantityValue<TEnum> CreateValue(double value, TEnum unitType);
        IQuantityValue<TEnum> CreateValue(double value, IUnit<TEnum> unit);
        IQuantityValue<TEnum> CreateValue(DateTime timestamp, double value, TEnum unitType);
        IQuantityValue<TEnum> CreateValue(DateTime timestamp, double value, IUnit<TEnum> unit);
    }
}
