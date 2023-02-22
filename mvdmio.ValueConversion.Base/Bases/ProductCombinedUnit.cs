using System;
using System.Globalization;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// The base class for product combined units.
/// </summary>
public class ProductCombinedUnit : CombinedUnitBase
{
    private const string _combinerCharacter = "*";

    /// <inheritdoc />
    public override string Identifier { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="numeratorUnit">The numerator unit.</param>
    /// <param name="denominatorUnit">The denominator unit.</param>
    /// <param name="quantity">The quantity of this combined unit.</param>
    public ProductCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
        :base(numeratorUnit, denominatorUnit, quantity)
    {
        Identifier = $"{numeratorUnit.Identifier}*{denominatorUnit.Identifier}";
    }

    /// <inheritdoc />
    public override double FromStandardUnit(double value, DateTimeOffset timestamp)
    {
        var numeratorUnitConversionFactor = NumeratorUnit.FromStandardUnit(1, timestamp);
        var denominatorUnitConversionFactor = DenominatorUnit.FromStandardUnit(1, timestamp);

        return value * (numeratorUnitConversionFactor / denominatorUnitConversionFactor);
    }

    /// <inheritdoc />
    public override double ToStandardUnit(double value, DateTimeOffset timestamp)
    {
        var numeratorUnitConversionFactor = NumeratorUnit.ToStandardUnit(1, timestamp);
        var denominatorUnitConversionFactor = DenominatorUnit.ToStandardUnit(1, timestamp);

        return value * (numeratorUnitConversionFactor / denominatorUnitConversionFactor);
    }

    /// <inheritdoc />
    public override string GetSymbol(CultureInfo cultureInfo)
    {
        var numeratorSymbol = NumeratorUnit.GetSymbol(cultureInfo);
        var denominatorSymbol = DenominatorUnit.GetSymbol(cultureInfo);

        return $"{numeratorSymbol}{_combinerCharacter}{denominatorSymbol}";
    }
}