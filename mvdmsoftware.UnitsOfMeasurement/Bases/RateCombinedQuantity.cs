using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Interfaces;

namespace Ridder.UnitsOfMeasurement.Bases
{
    public class RateCombinedQuantity : CombinedQuantityBase
    {
        private const string CombinerCharacter = "/";

        public override string Identifier { get; }
        
        public RateCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity) 
            : this(numeratorQuantity, denominatorQuantity, GetCombinedQuantityIdentifier(numeratorQuantity, denominatorQuantity), false)
        {
        }

        public RateCombinedQuantity(QuantityType quantityType, IQuantity numeratorQuantity, IQuantity denominatorQuantity) 
            : this(numeratorQuantity, denominatorQuantity, quantityType.ToString(), true)
        {
        }

        private RateCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity, string identifier, bool isNamed)
            : base(numeratorQuantity, denominatorQuantity, isNamed)
        {
            Identifier = identifier;
        }

        protected override ICombinedUnit GetCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit)
        {
            return new RateCombinedUnit(numeratorUnit, denominatorUnit, this);
        }

        private static string GetCombinedQuantityIdentifier(IQuantity numerator, IQuantity denominator)
        {
            static string GetIdentifier(IQuantity quantity) => quantity is ICombinedQuantity combinedQuantity && !combinedQuantity.IsNamed ? $"({quantity.Identifier})" : quantity.Identifier;
            return $"{GetIdentifier(numerator)}{CombinerCharacter}{GetIdentifier(denominator)}";
        }
    }
}