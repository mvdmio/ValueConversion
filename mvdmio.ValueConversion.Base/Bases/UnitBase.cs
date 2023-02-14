using System;
using System.Collections.Generic;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Base.Resources.UnitSymbols;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for units.
/// </summary>
public abstract class UnitBase : IUnit
{
    private readonly IQuantity _quantity;

    /// <inheritdoc />
    public string Identifier { get; }

    /// <summary>
    /// Creates a new instance of <see cref="UnitBase"/>.
    /// </summary>
    /// <param name="identifier">The identifier of the unit.</param>
    /// <param name="quantity">The quantity of the unit.</param>
    protected UnitBase(string identifier, IQuantity quantity)
    {
        Identifier = identifier;
        
        _quantity = quantity;
    }

    /// <inheritdoc />
    public abstract double FromStandardUnit(double value, DateTimeOffset timestamp);

    /// <inheritdoc />
    public abstract double ToStandardUnit(double value, DateTimeOffset timestamp);

    /// <inheritdoc />
    public IQuantity GetQuantity()
    {
       return _quantity;
    }

    /// <inheritdoc />
    public string GetSymbol(CultureInfo cultureInfo)
    {
        var symbol = UnitSymbols.ResourceManager.GetString(Identifier, cultureInfo);

        if (symbol == null)
            throw new KeyNotFoundException($"No symbol found for unit {Identifier}");

        return symbol;
    }

    /// <inheritdoc />
    public string GetFormattedValue(double value, CultureInfo cultureInfo)
    {
        var symbol = GetSymbol(cultureInfo);
        return $"{value} {symbol}";
    }
}