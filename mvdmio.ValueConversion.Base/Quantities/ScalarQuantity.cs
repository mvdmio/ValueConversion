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
public class ScalarQuantity : IQuantity
{
    private readonly object _lockObject = new();
    private IList<IUnit> _units;

    /// <inheritdoc/>
    public IUnit StandardUnit => GetUnits().First();
        
    /// <inheritdoc/>
    public virtual string Identifier => "Scalar";

    internal ScalarQuantity()
    {
    }

    /// <inheritdoc/>
    public IUnit GetUnit(string unitIdentifier)
    {
        var unit = GetUnits().SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

        if(unit == null)
            throw new KeyNotFoundException($"Unit {unitIdentifier} could not be found for quantity {GetType().Name}");

        return unit;
    }

    /// <inheritdoc/>
    public IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit)
    {
        return quantityValue; // Scalar values don't support conversions, just return the original.
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

        return new QuantityValue(timestamp, value, unit);
    }

    /// <inheritdoc/>
    public IEnumerable<IUnit> GetUnits()
    {
        if (_units == null)
        {
            lock (_lockObject)
            {
                if (_units == null)
                {
                    var units = new List<IUnit> {
                        new ScalarUnit(this)
                    };
                    _units = units;
                }
            }
        }

        return _units;
    }
}