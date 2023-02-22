using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for rate combined quantities.
/// </summary>
public class RateCombinedQuantity : CombinedQuantityBase
{
   private const string _combinerCharacter = "/";

   /// <inheritdoc />
   protected override string CombinerCharacter => _combinerCharacter;

   /// <inheritdoc />
   public RateCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
       : base(numeratorQuantity, denominatorQuantity)
   {
   }

   /// <inheritdoc />
   public RateCombinedQuantity(string identifier, IQuantity numeratorQuantity, IQuantity denominatorQuantity)
       : base(identifier, numeratorQuantity, denominatorQuantity)
   {
   }

   /// <inheritdoc />
   protected override ICombinedUnit GetCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit)
   {
      return new RateCombinedUnit(numeratorUnit, denominatorUnit, this);
   }
}