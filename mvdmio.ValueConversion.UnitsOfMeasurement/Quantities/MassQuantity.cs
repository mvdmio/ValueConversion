using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Mass is both a property of a physical body and a measure of its resistance to acceleration (a change in its state of motion) when a net force is applied.
/// An object's mass also determines the strength of its gravitational attraction to other bodies. 
/// The basic SI unit of mass is the kilogram (kg).
/// 
/// In physics, mass is not the same as weight, even though mass is often determined by measuring the object's weight using a spring scale, 
/// rather than balance scale comparing it directly with known masses. An object on the Moon would weigh less than it does on Earth because of the lower gravity, 
/// but it would still have the same mass. This is because weight is a force, while mass is the property that (along with gravity) determines the strength of this force. 
/// </summary>
public class MassQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Kilogram unit of <see cref="MassQuantity"/>. This is the standard unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Kilogram => GetUnit("Kilogram");

   /// <summary>
   /// The Microgram unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Microgram => GetUnit("Microgram");

   /// <summary>
   /// The Milligram unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Milligram => GetUnit("Milligram");

   /// <summary>
   /// The Gram unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Gram => GetUnit("Gram");

   /// <summary>
   /// The Tonne unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Tonne => GetUnit("Tonne");

   /// <summary>
   /// The Kilotonne unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Kilotonne => GetUnit("Kilotonne");

   /// <summary>
   /// The Ounce unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Ounce => GetUnit("Ounce");

   /// <summary>
   /// The Pound unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Pound => GetUnit("Pound");

   /// <summary>
   /// The Stone unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Stone => GetUnit("Stone");

   /// <summary>
   /// The Kilopound unit of <see cref="MassQuantity"/>.
   /// </summary>
   public IUnit Kilopound => GetUnit("Kilopound");

   internal MassQuantity()
       : base("Mass", "Kilogram")
   {
   }

   /// <inheritdoc/>     
   protected sealed override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Kilogram", 1),
                
            //Metric
            ("Microgram", 1e-9),
            ("Milligram", 1e-6),
            ("Gram", 0.001),
            ("Tonne", 1000),
            ("Kilotonne", 1000000),
                
            //Imperial
            ("Ounce", 0.0283495231),
            ("Pound", 0.45359237),
            ("Stone", 6.35029318),
            ("Kilopound", 453.59237),
        };
   }
}