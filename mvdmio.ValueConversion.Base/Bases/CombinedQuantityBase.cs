using System;
using System.Collections.Generic;
using System.Linq;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

public abstract class CombinedQuantityBase : ICombinedQuantity
{
    private readonly object _lockObject = new();
    private IList<ICombinedUnit> _units;

    IUnit IQuantity.StandardUnit => StandardUnit;
        
    public abstract string Identifier { get; }
    public IQuantity NumeratorQuantity { get; }
    public IQuantity DenominatorQuantity { get; }

    public ICombinedUnit StandardUnit
    {
        get
        {
            return GetUnits().Single(x => x.NumeratorUnit.Identifier == NumeratorQuantity.StandardUnit.Identifier && x.DenominatorUnit.Identifier == DenominatorQuantity.StandardUnit.Identifier);
        }
    }
        
    protected CombinedQuantityBase(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
    {
        NumeratorQuantity = numeratorQuantity;
        DenominatorQuantity = denominatorQuantity;
    }

    public ICombinedUnit GetUnit(IUnit numeratorUnit, IUnit denominatorUnit)
    {
        return GetUnits().First(x => x.NumeratorUnit.Identifier == numeratorUnit.Identifier && x.DenominatorUnit.Identifier == denominatorUnit.Identifier);
    }

    IEnumerable<IUnit> IQuantity.GetUnits()
    {
        return GetUnits();
    }

    public IUnit GetUnit(string unitIdentifier)
    {
        var unit = GetUnits().SingleOrDefault(x => x.Identifier == unitIdentifier);

        if(unit == null)
            throw new KeyNotFoundException($"Unit {unitIdentifier} could not be found for quantity {GetType().Name}");

        return unit;
    }

    public IQuantityValue CreateValue(double value, IUnit unit)
    {
        return CreateValue(DateTime.UtcNow, value, unit);
    }

    public IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit)
    {
        if (unit is not ICombinedUnit typedUnit || GetUnits().All(x => x.Identifier != unit.Identifier))
            throw new InvalidCastException($"Cannot create value of unit {unit.Identifier} from quantity {GetType().FullName}");

        return CreateValue(timestamp, value, typedUnit);
    }

    public IEnumerable<ICombinedUnit> GetUnits()
    {
        if (_units != null)
            return _units;

        lock (_lockObject)
        {
            if (_units != null)
                return _units;

            _units = CalculateUnits(NumeratorQuantity, DenominatorQuantity);
        }

        return _units;
    }
        
    public IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit)
    {
        if (toUnit is not ICombinedUnit typedUnit)
            throw new InvalidCastException($"Cannot convert to unit {toUnit.Identifier} from quantity {GetType().FullName}");

        return Convert(quantityValue, typedUnit);
    }

    public IQuantityValue Convert(IQuantityValue quantityValue, ICombinedUnit toUnit)
    {
        if (quantityValue.GetQuantity().Identifier != this.Identifier)
            throw new InvalidCastException($"{GetType().FullName} cannot convert quantity values of quantity type {quantityValue.GetQuantity().Identifier}");

        var value = quantityValue.GetStandardValue();
        var convertedValue = toUnit.FromStandardUnit(value, quantityValue.Timestamp);
            
        return new CombinedQuantityValue(quantityValue.Timestamp, convertedValue, toUnit);
    }

    public IQuantityValue CreateValue(DateTime timestamp, double value, ICombinedUnit unit)
    {
        return new CombinedQuantityValue(timestamp, value, unit);
    }

    protected abstract ICombinedUnit GetCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit);
        
    private IList<ICombinedUnit> CalculateUnits(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
    {
        var numeratorUnits = numeratorQuantity.GetUnits().ToList();
        var denominatorUnits = denominatorQuantity.GetUnits().ToList();

        var result = new List<ICombinedUnit>();
        foreach (var numeratorUnit in numeratorUnits)
        {
            foreach (var denominatorUnit in denominatorUnits)
            {
                result.Add(GetCombinedUnit(numeratorUnit, denominatorUnit));
            }
        }

        return result;
    }
}