using System.Diagnostics.CodeAnalysis;
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
    public double FromStandardUnit(double value)
    {
        return value;
    }

    /// <inheritdoc/>
    public double ToStandardUnit(double value)
    {
        return value;
    }

    /// <inheritdoc/>
    public string GetSymbol(CultureInfo? cultureInfo = null)
    {
        return string.Empty;
    }

    /// <inheritdoc />
    public string GetFormattedValue(double value, [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null, CultureInfo? cultureInfo = null)
    {
       return value.ToString(format, cultureInfo);
    }
}