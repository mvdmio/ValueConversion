using System;
using System.Globalization;
using FormatWith;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Resources.UnitsFormatting;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    public class ProductCombinedUnit : CombinedUnitBase
    {
        private const string CombinerCharacter = "*";

        public override string Identifier { get; }

        public ProductCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
            :base(numeratorUnit, denominatorUnit, quantity)
        {
            Identifier = $"{numeratorUnit.Identifier}*{denominatorUnit.Identifier}";
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

            var symbolCombinationFormat = UnitsFormatting.ResourceManager.GetString(name: "_ProductUnitCominationDefault", cultureInfo);

            return symbolCombinationFormat.FormatWith(new {
                numSym = numeratorSymbol,
                denSym = denominatorSymbol
            });
        }

        private static string GetCombinedUnitIdentifier(IUnit numerator, IUnit denominator)
        {
            static string GetIdentifier(IUnit unit) => unit is ICombinedUnit ? $"({unit.Identifier})" : unit.Identifier;
            return $"{GetIdentifier(numerator)}{CombinerCharacter}{GetIdentifier(denominator)}";
        }
    }
}