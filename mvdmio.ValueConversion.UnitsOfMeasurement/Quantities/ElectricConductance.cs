using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In electronics and electromagnetism, electronical conducance is the reciproclal quantity of electric resistance.
/// In the SI system, it is specified in units S (Siemens).
/// The resistance, and thus conductance of an object depends in large part on the material it is made of.
/// </summary>
public sealed class ElectricConductance : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Siemens unit of <see cref="ElectricConductance"/>. This is the standard unit of <see cref="ElectricConductance"/>.
   /// </summary>
   public static IUnit Siemens => Quantity.Known.ElectricConductance().GetUnit("Siemens");

   /// <summary>
   /// The Microsiemens unit of <see cref="ElectricConductance"/>.
   /// </summary>
   public static IUnit Microsiemens => Quantity.Known.ElectricConductance().GetUnit("Microsiemens");

   /// <summary>
   /// The Millisiemens unit of <see cref="ElectricConductance"/>.
   /// </summary>
   public static IUnit Millisiemens => Quantity.Known.ElectricConductance().GetUnit("Millisiemens");

   internal ElectricConductance()
       : base("ElectricConductance", "Siemens")
   {
   }

   /// <inheritdoc/>     
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Siemens", 1),
                
            //Conversions
            ("Microsiemens", 0.0000001),
            ("Millisiemens", 0.001)
        };
   }
}