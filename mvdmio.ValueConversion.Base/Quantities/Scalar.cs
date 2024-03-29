using System;
using System.Collections.Generic;
using System.Linq;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Base.Units;

namespace mvdmio.ValueConversion.Base.Quantities;

/// <summary>
/// Used for values that do not have a unit, like count.
/// </summary>
public class Scalar : IQuantity
{
    private readonly IList<IUnit> _units;

    /// <inheritdoc/>
    public IUnit StandardUnit => GetUnits().First();
        
    /// <inheritdoc/>
    public string Identifier => "Scalar";

    internal Scalar()
    {
       _units = new List<IUnit> {
          new ScalarUnit(this)
       };
    }

    /// <inheritdoc/>
    public IUnit GetUnit(string unitIdentifier)
    {
        var unit = GetUnits().SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

        if(unit == null)
            throw new KeyNotFoundException($"Unit {unitIdentifier} could not be found for quantity {GetType().Name}");

        return unit;
    }

    /// <inheritdoc />
    public IQuantityValue Convert(IQuantityValue quantityValue, string toUnitIdentifier)
    {
       var unit = GetUnit(toUnitIdentifier);
       return Convert(quantityValue, unit);
    }

    /// <inheritdoc/>
    public IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit)
    {
        return quantityValue; // Scalar values don't support conversions, just return the original.
    }

    /// <inheritdoc />
    public IQuantityValue CreateValue(double value, string unitIdentifier)
    {
       var unit = GetUnit(unitIdentifier);
       return CreateValue(value, unit);
    }

    /// <inheritdoc/>
    public IQuantityValue CreateValue(double value, IUnit unit)
    {
        return CreateValue(DateTime.UtcNow, value, unit);
    }

    /// <inheritdoc/>
    public IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit)
    {
        var supportedUnit = GetUnits().SingleOrDefault(x => x.Identifier == unit.Identifier);

        if (supportedUnit == null)
            throw new InvalidOperationException($"Cannot create Scalar Quantity value for unit {unit.Identifier}");

        return new QuantityValue(value, unit, timestamp);
    }

    /// <inheritdoc/>
    public IEnumerable<IUnit> GetUnits()
    {
       return _units;
    }
}