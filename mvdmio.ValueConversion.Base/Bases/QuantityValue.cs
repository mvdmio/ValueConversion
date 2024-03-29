﻿using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Base.Utils;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Class for holding values of a given quantity.
/// </summary>
public class QuantityValue : IQuantityValue
{
    private readonly double _value;
    private readonly IQuantity _quantity;
    private readonly IUnit _unit;

    /// <inheritdoc />
    public DateTimeOffset Timestamp { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">The numeric value.</param>
    /// <param name="unit">The unit of the numeric value.</param>
    public QuantityValue(double value, IUnit unit)
        : this(value, unit, DateTimeOffset.Now)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">The numeric value.</param>
    /// <param name="unit">The unit of the numeric value.</param>
    /// <param name="timestamp">The timestamp at which the value was recorded.</param>
    public QuantityValue(double value, IUnit unit, DateTimeOffset timestamp)
    {
        _value = value;
        _quantity = unit.GetQuantity();
        _unit = unit;

        Timestamp = timestamp;
    }

    /// <inheritdoc />
    public IQuantity GetQuantity()
    {
        return _quantity;
    }

    /// <inheritdoc />
    public IUnit GetUnit()
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
        return _quantity.Convert(this, unit);
    }

    /// <inheritdoc />
    public bool IsEqualTo(IQuantityValue other)
    {
        var thisStandardValue = GetStandardValue();
        var otherStandardValue = other.GetStandardValue();

        return Comparer.IsWithinTolerance(thisStandardValue, otherStandardValue);
    }

    /// <inheritdoc />
    public string GetFormattedValue() => GetFormattedValue(CultureInfo.CurrentCulture, decimalPoints: 0);

    /// <inheritdoc />
    public string GetFormattedValue(CultureInfo cultureInfo) => GetFormattedValue(cultureInfo, decimalPoints: 0);

    /// <inheritdoc />
    public string GetFormattedValue(int decimalPoints) => GetFormattedValue(CultureInfo.CurrentCulture, decimalPoints);

    /// <inheritdoc />
    public string GetFormattedValue(CultureInfo cultureInfo, int decimalPoints) 
    {
       return _unit.GetFormattedValue(_value, cultureInfo, decimalPoints);
    }
}