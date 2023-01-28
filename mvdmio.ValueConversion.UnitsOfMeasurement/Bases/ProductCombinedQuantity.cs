using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    public class ProductCombinedQuantity : CombinedQuantityBase
    {
        private const string CombinerCharacter = "*";

        public override string Identifier { get; }

        public ProductCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity) 
            : this(numeratorQuantity, denominatorQuantity, GetCombinedQuantityIdentifier(numeratorQuantity, denominatorQuantity), false)
        {
        }

        public ProductCombinedQuantity(QuantityType quantityType, IQuantity numeratorQuantity, IQuantity denominatorQuantity) 
            : this(numeratorQuantity, denominatorQuantity, quantityType.ToString(), true)
        {
        }

        private ProductCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity, string identifier, bool isNamed)
            : base(numeratorQuantity, denominatorQuantity, isNamed)
        {
            Identifier = identifier;
        }

        /// <inheritdoc/>
        protected override ICombinedUnit GetCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit)
        {
            return new ProductCombinedUnit(numeratorUnit, denominatorUnit, this);
        }

        private static string GetCombinedQuantityIdentifier(IQuantity numerator, IQuantity denominator)
        {
            static string GetIdentifier(IQuantity quantity) => quantity is ICombinedQuantity combinedQuantity && !combinedQuantity.IsNamed ? $"({quantity.Identifier})" : quantity.Identifier;
            return $"{GetIdentifier(numerator)}{CombinerCharacter}{GetIdentifier(denominator)}";
        }
    }
}