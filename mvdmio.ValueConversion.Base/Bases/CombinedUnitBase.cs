using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for combined units.
/// </summary>
public abstract class CombinedUnitBase : ICombinedUnit
{
    private readonly ICombinedQuantity _quantity;

    /// <inheritdoc />
    public abstract string Identifier { get; }

    /// <inheritdoc />
    public IUnit NumeratorUnit { get; }

    /// <inheritdoc />
    public IUnit DenominatorUnit { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="numeratorUnit">The numerator unit.</param>
    /// <param name="denominatorUnit">The denominator unit.</param>
    /// <param name="quantity">The quantity of this unit.</param>
    protected CombinedUnitBase(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
    {
        _quantity = quantity;

        NumeratorUnit = numeratorUnit;
        DenominatorUnit = denominatorUnit;
    }

    /// <inheritdoc />
    public abstract double FromStandardUnit(double value, DateTimeOffset timestamp);

    /// <inheritdoc />
    public abstract double ToStandardUnit(double value, DateTimeOffset timestamp);

    /// <inheritdoc />
    public abstract string GetSymbol(CultureInfo cultureInfo);
        
    IQuantity IUnit.GetQuantity()
    {
        return GetQuantity();
    }

    /// <inheritdoc />
    public ICombinedQuantity GetQuantity()
    {
        return _quantity;
    }

    /// <inheritdoc />
    public string GetFormattedValue(double value, CultureInfo cultureInfo)
    {
        var symbol = GetSymbol(cultureInfo);
        return $"{value} {symbol}";
    }   
}