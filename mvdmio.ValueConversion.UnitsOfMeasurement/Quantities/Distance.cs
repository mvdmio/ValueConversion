using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Distance is a numerical measurement of how far apart objects or points are. 
/// In physics or everyday usage, distance may refer to a physical length or an estimation based on other criteria (e.g. "two counties over").
/// In the SI system, it is specified in units of 'm' (meters). 
/// </summary>
public sealed class Distance : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Meter unit on <see cref="Distance"/>. This is the standard unit of <see cref="Distance"/>.
   /// </summary>
   public static IUnit Meter => Quantity.Known.Distance().GetUnit("Meter");

   /// <summary>
   /// The Millimeter unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Millimeter => Quantity.Known.Distance().GetUnit("Millimeter");

   /// <summary>
   /// The Centimeter unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Centimeter => Quantity.Known.Distance().GetUnit("Centimeter");

   /// <summary>
   /// The Hectometer unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Hectometer => Quantity.Known.Distance().GetUnit("Hectometer");

   /// <summary>
   /// The Kilometer unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Kilometer => Quantity.Known.Distance().GetUnit("Kilometer");

   /// <summary>
   /// The Inch unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Inch => Quantity.Known.Distance().GetUnit("Inch");

   /// <summary>
   /// The Feet unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Feet => Quantity.Known.Distance().GetUnit("Feet");

   /// <summary>
   /// The Yard unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Yard => Quantity.Known.Distance().GetUnit("Yard");

   /// <summary>
   /// The Mile unit on <see cref="Distance"/>.
   /// </summary>
   public static IUnit Mile => Quantity.Known.Distance().GetUnit("Mile");

   internal Distance()
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