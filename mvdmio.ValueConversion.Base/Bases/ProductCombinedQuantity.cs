using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

public class ProductCombinedQuantity : CombinedQuantityBase
{
   private const string _combinerCharacter = "*";

   /// <inheritdoc />
   protected override string CombinerCharacter => _combinerCharacter;

   /// <inheritdoc />
   public ProductCombinedQuantity(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
       : base(numeratorQuantity, denominatorQuantity)
   {
   }

   /// <inheritdoc />
   public ProductCombinedQuantity(string identifier, IQuantity numeratorQuantity, IQuantity denominatorQuantity)
       : base(identifier, numeratorQuantity, denominatorQuantity)
   {
   }

   /// <inheritdoc/>
   protected override ICombinedUnit GetCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit)
   {
      return new ProductCombinedUnit(numeratorUnit, denominatorUnit, this);
   }
}