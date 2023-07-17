using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In chemistry, the amount of substance n in a given sample of matter is defined as the quantity or number of discrete atomic-scale particles in it
/// divided by the Avogadro constant NA. The particles or entities may be molecules, atoms, ions, electrons, or other, depending on the context.
/// </summary>
public sealed class Substance : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Mole unit of <see cref="Substance"/>. This is the standard unit of <see cref="Substance"/>.
   /// </summary>
   public static IUnit Mole => Quantity.Known.Substance().GetUnit("Mole");

   /// <summary>
   /// The Millimole unit of <see cref="Substance"/>.
   /// </summary>
   public static IUnit Millimole => Quantity.Known.Substance().GetUnit("Millimole");

   /// <summary>
   /// The Micromole unit of <see cref="Substance"/>.
   /// </summary>
   public static IUnit Micromole => Quantity.Known.Substance().GetUnit("Micromole");

   internal Substance()
       : base("Substance", "Mole")
   {
   }

   /// <inheritdoc />
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Mole", 1),

            ("Millimole", 0.001),
            ("Micromole", 0.000001)
        };
   }
}