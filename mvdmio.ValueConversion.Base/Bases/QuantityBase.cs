using System;
using System.Collections.Generic;
using System.Linq;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for quantity implementations.
/// </summary>
public abstract class QuantityBase : IQuantity
{
    private readonly string _standardUnitIdentifier;

    /// <inheritdoc />
    public string Identifier { get; }

    /// <inheritdoc />
    public IUnit StandardUnit => GetUnit(_standardUnitIdentifier);
        
    /// <summary>
    /// Base constructor.
    /// </summary>
    /// <param name="identifier">The identifier of this quantity.</param>
    /// <param name="standardUnitIdentifier">The identifier of the standard unit for this quantity.</param>
    protected QuantityBase(string identifier, string standardUnitIdentifier)
    {
        _standardUnitIdentifier = standardUnitIdentifier;

        Identifier = identifier;
    }

    /// <inheritdoc />
    public abstract IEnumerable<IUnit> GetUnits();

    /// <inheritdoc />
    public IUnit GetUnit(string unitIdentifier)
    {
        var unit = GetUnits().SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

        if(unit == null)
            throw new KeyNotFoundException($"Unit '{unitIdentifier}' could not be found for quantity {GetType().Name}");

        return unit;
    }

    /// <inheritdoc />
    public IQuantityValue Convert(IQuantityValue quantityValue, string toUnitIdentifier)
    {
       var unit = GetUnit(toUnitIdentifier);
       return Convert(quantityValue, unit);
    }

    /// <inheritdoc />
    public IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit)
    {
        if (quantityValue.GetQuantity().Identifier != Identifier)
            throw new InvalidCastException($"{GetType().FullName} cannot convert quantity of type {quantityValue.GetQuantity().Identifier}");

        var standardValue = quantityValue.GetStandardValue();
        var convertedValue = toUnit.FromStandardUnit(standardValue, quantityValue.Timestamp);

        return new QuantityValue(quantityValue.Timestamp, convertedValue, toUnit);
    }

    /// <inheritdoc />
    public IQuantityValue CreateValue(double value, string unitIdentifier)
    {
       var unit = GetUnit(unitIdentifier);
       return CreateValue(value, unit);
    }

    /// <inheritdoc />
    public IQuantityValue CreateValue(double value, IUnit unit)
    {
       return CreateValue(DateTime.UtcNow, value, unit);
    }

    /// <inheritdoc />
    public IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit)
    {

        return new QuantityValue(timestamp, value, unit);
    }
}