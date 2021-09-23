using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ridder.UnitsOfMeasurement.Interfaces
{
    public interface IQuantity
    {
        IUnit StandardUnit { get; }
        string Identifier { get; }
        
        IEnumerable<IUnit> GetUnits();
        IUnit GetUnit(string unitIdentifier);

        Task<IQuantityValue> Convert(IQuantityValue quantityValue, IUnit toUnit);
        IQuantityValue CreateValue(double value, IUnit unit);
        IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit);
    }

    public interface IQuantity<TEnum> : IQuantity
        where TEnum : Enum
    {
        new IUnit<TEnum> StandardUnit { get; }
        IUnit<TEnum> GetUnit(TEnum unit);
        new IDictionary<TEnum, IUnit<TEnum>> GetUnits();
        Task<IQuantityValue> Convert(IQuantityValue quantityValue, TEnum toUnitType);
        Task<IQuantityValue> Convert(IQuantityValue quantityValue, IUnit<TEnum> toUnit);
        IQuantityValue CreateValue(double value, TEnum unitType);
        IQuantityValue CreateValue(double value, IUnit<TEnum> unit);
        IQuantityValue CreateValue(DateTime timestamp, double value, TEnum unitType);
        IQuantityValue CreateValue(DateTime timestamp, double value, IUnit<TEnum> unit);
    }
}
