using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

public class RateCombinedUnit : CombinedUnitBase 
{
    private const string CombinerCharacter = "/";

    public override string Identifier { get; }

    public RateCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
        : base(numeratorUnit, denominatorUnit, quantity)
    {
        Identifier = GetCombinedUnitIdentifier(numeratorUnit, denominatorUnit);
    }

    public override double FromStandardUnit(double value, DateTimeOffset timestamp)
    {
        var numeratorUnitConversionFactor = NumeratorUnit.FromStandardUnit(1, timestamp);
        var denominatorUnitConversionFactor = DenominatorUnit.FromStandardUnit(1, timestamp);

        return value * (numeratorUnitConversionFactor / denominatorUnitConversionFactor);
    }

    public override double ToStandardUnit(double value, DateTimeOffset timestamp)
    {
        var numeratorUnitConversionFactor = NumeratorUnit.ToStandardUnit(1, timestamp);
        var denominatorUnitConversionFactor = DenominatorUnit.ToStandardUnit(1, timestamp);

        return value * (numeratorUnitConversionFactor / denominatorUnitConversionFactor);
    }

    public override string GetSymbol(CultureInfo cultureInfo)
    {
        var numeratorSymbol = NumeratorUnit.GetSymbol(cultureInfo);
        var denominatorSymbol = DenominatorUnit.GetSymbol(cultureInfo);

        return $"{numeratorSymbol}{CombinerCharacter}{denominatorSymbol}";
    }

    private static string GetCombinedUnitIdentifier(IUnit numerator, IUnit denominator)
    {
        static string GetIdentifier(IUnit unit) => unit is ICombinedUnit ? $"({unit.Identifier})" : unit.Identifier;
        return $"{GetIdentifier(numerator)}{CombinerCharacter}{GetIdentifier(denominator)}";
    }
}