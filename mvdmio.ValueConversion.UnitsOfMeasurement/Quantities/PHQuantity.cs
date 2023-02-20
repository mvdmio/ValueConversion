using System;
using System.Collections.Generic;
using System.Linq;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Units;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Defines the pH quantity
/// </summary>
public class PHQuantity : IQuantity
{
    private readonly IList<IUnit> _units;

    /// <inheritdoc/>
    public IUnit StandardUnit => GetUnits().First();
        
    /// <inheritdoc/>
    public virtual string Identifier { get; } = "pH";

    internal PHQuantity()
    {
       _units = new List<IUnit> {
          new PhUnit(this)
       };
    }

    /// <inheritdoc/>
    public IUnit GetUnit(string unitIdentifier)
    {
        // Special case for systems that use an older version of UnitsOfMeasurement. In the past, the unit for pH was 'scalar', this should be handled as 'pH'
        if(unitIdentifier.Equals("Scalar", StringComparison.InvariantCultureIgnoreCase))
            return GetUnit("pH");

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
        return quantityValue; // pH values don't support conversions, just return the original.
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
            throw new InvalidOperationException($"Cannot create pH Quantity value for unit {unit.Identifier}");

        return new QuantityValue(timestamp, value, unit);
    }

    /// <inheritdoc/>
    public IEnumerable<IUnit> GetUnits()
    {
        return _units;
    }
}