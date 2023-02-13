using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

public class ProductCombinedQuantity : CombinedQuantityBase
{
    private const string CombinerCharacter = "*";

    /// <inheritdoc />
    public override string Identifier { get; }

    public ProductCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity) 
        : this(GetCombinedQuantityIdentifier(numeratorQuantity, denominatorQuantity), numeratorQuantity, denominatorQuantity)
    {
    }

    public ProductCombinedQuantity(string identifier, IQuantity numeratorQuantity, IQuantity denominatorQuantity)
        : base(numeratorQuantity, denominatorQuantity)
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
        return $"{numerator.Identifier}{CombinerCharacter}{denominator.Identifier}";
    }
}