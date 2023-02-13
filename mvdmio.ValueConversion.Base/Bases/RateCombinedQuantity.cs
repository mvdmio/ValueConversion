using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

public class RateCombinedQuantity : CombinedQuantityBase
{
    private const string CombinerCharacter = "/";

    /// <inheritdoc />
    public override string Identifier { get; }
        
    public RateCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity) 
        : this(GetCombinedQuantityIdentifier(numeratorQuantity, denominatorQuantity), numeratorQuantity, denominatorQuantity)
    {
    }
    
    public RateCombinedQuantity(string identifier, IQuantity numeratorQuantity, IQuantity denominatorQuantity)
        : base(numeratorQuantity, denominatorQuantity)
    {
        Identifier = identifier;
    }

    protected override ICombinedUnit GetCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit)
    {
        return new RateCombinedUnit(numeratorUnit, denominatorUnit, this);
    }

    private static string GetCombinedQuantityIdentifier(IQuantity numerator, IQuantity denominator)
    {
        return $"{numerator.Identifier}{CombinerCharacter}{denominator.Identifier}";
    }
}