using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In mathematics, a ratio indicates how many times one number contains another.
/// </summary>
public class RatioQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Percent unit of <see cref="RatioQuantity"/>. This is the standard unit of <see cref="RatioQuantity"/>.
   /// </summary>
   public IUnit Percent => GetUnit("Percent");

   /// <summary>
   /// The Permille unit of <see cref="RatioQuantity"/>.
   /// </summary>
   public IUnit Permille => GetUnit("Permille");

   /// <summary>
   /// The PartsPerMillion unit of <see cref="RatioQuantity"/>.
   /// </summary>
   public IUnit PartsPerMillion => GetUnit("PartsPerMillion");

   /// <summary>
   /// The PartsPerBillion unit of <see cref="RatioQuantity"/>.
   /// </summary>
   public IUnit PartsPerBillion => GetUnit("PartsPerBillion");

   internal RatioQuantity()
       : base("Ratio", "Percent")
   {
   }

   /// <inheritdoc/>
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            ("Percent", 1),
            ("Permille", 0.1),
            ("PartsPerMillion", 0.0001),
            ("PartsPerBillion", 0.0000001)
        };
   }
}