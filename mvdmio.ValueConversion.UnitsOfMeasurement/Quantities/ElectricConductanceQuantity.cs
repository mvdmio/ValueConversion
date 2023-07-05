using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In electronics and electromagnetism, electronical conducance is the reciproclal quantity of electric resistance.
/// In the SI system, it is specified in units S (Siemens).
/// The resistance, and thus conductance of an object depends in large part on the material it is made of.
/// </summary>
public sealed class ElectricConductanceQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Siemens unit of <see cref="ElectricConductanceQuantity"/>. This is the standard unit of <see cref="ElectricConductanceQuantity"/>.
   /// </summary>
   public IUnit Siemens => GetUnit("Siemens");

   /// <summary>
   /// The Microsiemens unit of <see cref="ElectricConductanceQuantity"/>.
   /// </summary>
   public IUnit Microsiemens => GetUnit("Microsiemens");

   /// <summary>
   /// The Millisiemens unit of <see cref="ElectricConductanceQuantity"/>.
   /// </summary>
   public IUnit Millisiemens => GetUnit("Millisiemens");

   internal ElectricConductanceQuantity()
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