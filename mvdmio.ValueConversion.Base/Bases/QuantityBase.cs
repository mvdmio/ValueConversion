using System;
using System.Collections.Generic;
using System.Linq;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

public abstract class QuantityBase : IQuantity
{
    private readonly string _standardUnitIdentifier;

    public string Identifier { get; }

    public IUnit StandardUnit => GetUnit(_standardUnitIdentifier);
        
    protected QuantityBase(string identifier, string standardUnitIdentifier)
    {
        _standardUnitIdentifier = standardUnitIdentifier;

        Identifier = identifier;
    }

    public abstract IEnumerable<IUnit> GetUnits();

    public IUnit GetUnit(string unitIdentifier)
    {
        var unit = GetUnits().SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

        if(unit == null)
            throw new KeyNotFoundException($"Unit '{unitIdentifier}' could not be found for quantity {GetType().Name}");

        return unit;
    }

    public IQuantityValue Convert(IQuantityValue quantityValue, string unitIdentifier)
    {
        var unit = GetUnit(unitIdentifier);
        return Convert(quantityValue, unit);
    }
    
    public IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit)
    {
        if (quantityValue.GetQuantity().Identifier != Identifier)
            throw new InvalidCastException($"{GetType().FullName} cannot convert quantity of type {quantityValue.GetQuantity().Identifier}");

        var standardValue = quantityValue.GetStandardValue();
        var convertedValue = toUnit.FromStandardUnit(standardValue, quantityValue.Timestamp);

        return new QuantityValue(quantityValue.Timestamp, convertedValue, toUnit);
    }

    public IQuantityValue CreateValue(double value, string unitIdentifier)
    {
        var unit = GetUnit(unitIdentifier);
        return CreateValue(value, unit);
    }
    
    public IQuantityValue CreateValue(double value, IUnit unit)
    {
        return CreateValue(DateTime.UtcNow, value, unit);
    }

    public IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit)
    {
        return new QuantityValue(timestamp, value, unit);
    }
}