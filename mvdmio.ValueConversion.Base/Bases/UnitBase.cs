using System;
using System.Collections.Generic;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.Base.Resources.UnitSymbols;

namespace mvdmio.ValueConversion.Base.Bases;

public abstract class UnitBase : IUnit
{
    private readonly IQuantity _quantity;

    /// <inheritdoc />
    public string Identifier { get; }
    
    protected UnitBase(IQuantity quantity, string identifier)
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
        return GetQuantity();
    }

    /// <inheritdoc />
    public string GetSymbol(CultureInfo cultureInfo)
    {
        var symbol = UnitSymbols.ResourceManager.GetString(Identifier, cultureInfo);

        if (symbol == null)
            throw new KeyNotFoundException($"No symbol found for unit {Identifier}");

        return symbol;
    }

    public string GetFormattedValue(double value, CultureInfo cultureInfo)
    {
        var symbol = GetSymbol(cultureInfo);
        return $"{value} {symbol}";
    }
}