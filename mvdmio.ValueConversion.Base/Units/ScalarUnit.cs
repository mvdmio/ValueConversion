using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Base.Quantities;

namespace mvdmio.ValueConversion.Base.Units;

/// <summary>
/// This unit is used for values that do not have a quantity.
/// We've created a <see cref="Scalar"/> and <see cref="ScalarUnit"/> for these cases.
/// </summary>
public class ScalarUnit : IUnit
{
    private readonly IQuantity _quantity;

    internal ScalarUnit(IQuantity quantity)
    {
        _quantity = quantity;
    }

    /// <inheritdoc/>
    public string Identifier { get; } = "Scalar";

    /// <inheritdoc/>
    public IQuantity GetQuantity()
    {
        return _quantity;
    }

    /// <inheritdoc/>
    public double FromStandardUnit(double value, DateTimeOffset timestamp)
    {
        return value;
    }

    /// <inheritdoc/>
    public double ToStandardUnit(double value, DateTimeOffset timestamp)
    {
        return value;
    }

    /// <inheritdoc/>
    public string GetSymbol(CultureInfo cultureInfo)
    {
        return string.Empty;
    }

    /// <inheritdoc/>
    public string GetFormattedValue(double value, CultureInfo cultureInfo)
    {
        return value.ToString(cultureInfo);
    }

    /// <inheritdoc />
    public string GetFormattedValue(double value, CultureInfo cultureInfo, int decimalPoints)
    {
       return Math.Round(value, decimalPoints).ToString(cultureInfo);
    }
}