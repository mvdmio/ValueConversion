using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for rate combined units.
/// </summary>
public class RateCombinedUnit : CombinedUnitBase 
{
    private const string COMBINER_CHARACTER = "/";

    /// <inheritdoc />
    public override string Identifier { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="numeratorUnit">The numerator unit.</param>
    /// <param name="denominatorUnit">The denominator unit.</param>
    /// <param name="quantity">The quantity of this combined unit.</param>
    public RateCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
        : base(numeratorUnit, denominatorUnit, quantity)
    {
        Identifier = GetCombinedUnitIdentifier(numeratorUnit, denominatorUnit);
    }

    /// <inheritdoc />
    public override double FromStandardUnit(double value)
    {
        var numeratorUnitConversionFactor = NumeratorUnit.FromStandardUnit(1);
        var denominatorUnitConversionFactor = DenominatorUnit.FromStandardUnit(1);

        return value * (numeratorUnitConversionFactor / denominatorUnitConversionFactor);
    }

    /// <inheritdoc />
    public override double ToStandardUnit(double value)
    {
        var numeratorUnitConversionFactor = NumeratorUnit.ToStandardUnit(1);
        var denominatorUnitConversionFactor = DenominatorUnit.ToStandardUnit(1);

        return value * (numeratorUnitConversionFactor / denominatorUnitConversionFactor);
    }

    /// <inheritdoc />
    public override string GetSymbol(CultureInfo cultureInfo)
    {
        var numeratorSymbol = NumeratorUnit.GetSymbol(cultureInfo);
        var denominatorSymbol = DenominatorUnit.GetSymbol(cultureInfo);

        return $"{numeratorSymbol}{COMBINER_CHARACTER}{denominatorSymbol}";
    }

    private static string GetCombinedUnitIdentifier(IUnit numerator, IUnit denominator)
    {
        static string GetIdentifier(IUnit unit) => unit is ICombinedUnit ? $"({unit.Identifier})" : unit.Identifier;
        return $"{GetIdentifier(numerator)}{COMBINER_CHARACTER}{GetIdentifier(denominator)}";
    }
}