using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Distance is a numerical measurement of how far apart objects or points are. 
/// In physics or everyday usage, distance may refer to a physical length or an estimation based on other criteria (e.g. "two counties over").
/// In the SI system, it is specified in units of m (meters). 
/// </summary>
public sealed class DistanceQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Meter unit on <see cref="DistanceQuantity"/>. This is the standard unit of <see cref="DistanceQuantity"/>.
   /// </summary>
   public IUnit Meter => GetUnit("Meter");

   /// <summary>
   /// The Millimeter unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Millimeter => GetUnit("Millimeter");

   /// <summary>
   /// The Centimeter unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Centimeter => GetUnit("Centimeter");

   /// <summary>
   /// The Hectometer unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Hectometer => GetUnit("Hectometer");

   /// <summary>
   /// The Kilometer unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Kilometer => GetUnit("Kilometer");

   /// <summary>
   /// The Inch unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Inch => GetUnit("Inch");

   /// <summary>
   /// The Feet unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Feet => GetUnit("Feet");

   /// <summary>
   /// The Yard unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Yard => GetUnit("Yard");

   /// <summary>
   /// The Mile unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Mile => GetUnit("Mile");

   internal DistanceQuantity()
       : base("Distance", "Meter")
   {
   }

   /// <inheritdoc/>        
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Meter", 1),
                
            //Metric
            ("Millimeter", 0.001),
            ("Centimeter", 0.01),
            ("Hectometer", 100),
            ("Kilometer", 1000),
                
            //Imperial
            ("Inch", 0.0254),
            ("Feet", 0.3048),
            ("Yard", 0.9144),
            ("Mile", 1609.344)
        };
   }
}