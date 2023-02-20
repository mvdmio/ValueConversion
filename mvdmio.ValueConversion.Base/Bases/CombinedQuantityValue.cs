using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Base.Utils;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Class for working with values of <see cref="ICombinedQuantity"/>.
/// </summary>
public class CombinedQuantityValue : IQuantityValue
{
    private readonly double _value;
    private readonly ICombinedUnit _unit;
    private readonly ICombinedQuantity _quantity;

    /// <inheritdoc />
    public DateTimeOffset Timestamp { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="timestamp">The timestamp of the value.</param>
    /// <param name="value">The numeric value.</param>
    /// <param name="unit">The unit of the numeric value.</param>
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

    /// <inheritdoc />
    public double GetValue()
    {
        return _value;
    }

    /// <inheritdoc />
    public double GetStandardValue()
    {
        return _unit.ToStandardUnit(_value, Timestamp);
    }

    /// <inheritdoc />
    public IQuantityValue As(IUnit unit)
    {
        if (unit is ICombinedUnit typedUnit)
        {
            return As(typedUnit);
        }

        throw new InvalidCastException($"Cannot use {unit.GetType().FullName} as {typeof(ICombinedUnit).FullName}");
    }

    public IQuantityValue As(ICombinedUnit toUnit)
    {
        return _quantity.Convert(this, toUnit);
    }

    /// <inheritdoc />
    public bool IsEqualTo(IQuantityValue other)
    {
        var thisStandardValue = GetStandardValue();
        var otherStandardValue = other.GetStandardValue();

        return Comparer.IsWithinTolerance(thisStandardValue, otherStandardValue);
    }

    /// <inheritdoc />
    public string GetFormattedValue(CultureInfo cultureInfo)
    {
        return _unit.GetFormattedValue(_value, cultureInfo);
    }
}