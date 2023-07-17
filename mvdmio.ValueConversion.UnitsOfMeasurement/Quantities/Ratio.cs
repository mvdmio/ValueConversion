using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In mathematics, a ratio indicates how many times one number contains another.
/// </summary>
public class Ratio : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Percent unit of <see cref="Ratio"/>. This is the standard unit of <see cref="Ratio"/>.
   /// </summary>
   public static IUnit Percent => Quantity.Known.Ratio().GetUnit("Percent");

   /// <summary>
   /// The Permille unit of <see cref="Ratio"/>.
   /// </summary>
   public static IUnit Permille => Quantity.Known.Ratio().GetUnit("Permille");

   /// <summary>
   /// The PartsPerMillion unit of <see cref="Ratio"/>.
   /// </summary>
   public static IUnit PartsPerMillion => Quantity.Known.Ratio().GetUnit("PartsPerMillion");

   /// <summary>
   /// The PartsPerBillion unit of <see cref="Ratio"/>.
   /// </summary>
   public static IUnit PartsPerBillion => Quantity.Known.Ratio().GetUnit("PartsPerBillion");

   internal Ratio()
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