using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

public abstract class CombinedUnitBase : ICombinedUnit
{
    private readonly ICombinedQuantity _quantity;

    public abstract string Identifier { get; }

    public IUnit NumeratorUnit { get; }
    public IUnit DenominatorUnit { get; }

    protected CombinedUnitBase(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
    {
        _quantity = quantity;

        NumeratorUnit = numeratorUnit;
        DenominatorUnit = denominatorUnit;
    }

    public abstract double FromStandardUnit(double value, DateTimeOffset timestamp);
    public abstract double ToStandardUnit(double value, DateTimeOffset timestamp);
    public abstract string GetSymbol(CultureInfo cultureInfo);
        
    IQuantity IUnit.GetQuantity()
    {
        return GetQuantity();
    }

    public ICombinedQuantity GetQuantity()
    {
        return _quantity;
    }

    public string GetFormattedValue(double value, CultureInfo cultureInfo)
    {
        var symbol = GetSymbol(cultureInfo);
        return $"{value} {symbol}";
    }   
}