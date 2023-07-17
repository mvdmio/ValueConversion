using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// The amount of elapsed time between two events.
/// In the SI system, it is specified in units of s (seconds). 
/// </summary>
public sealed class Duration : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Second unit of <see cref="Duration"/>. This is the standard unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Second => Quantity.Known.Duration().GetUnit("Second");

   /// <summary>
   /// The Nanosecond unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Nanosecond => Quantity.Known.Duration().GetUnit("Nanosecond");

   /// <summary>
   /// The Millisecond unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Millisecond => Quantity.Known.Duration().GetUnit("Millisecond");

   /// <summary>
   /// The Minute unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Minute => Quantity.Known.Duration().GetUnit("Minute");

   /// <summary>
   /// The Hour unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Hour => Quantity.Known.Duration().GetUnit("Hour");

   /// <summary>
   /// The Day unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Day => Quantity.Known.Duration().GetUnit("Day");

   /// <summary>
   /// The Week unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Week => Quantity.Known.Duration().GetUnit("Week");

   /// <summary>
   /// The Month unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Month => Quantity.Known.Duration().GetUnit("Month");

   /// <summary>
   /// The Quarter unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Quarter => Quantity.Known.Duration().GetUnit("Quarter");

   /// <summary>
   /// The Year unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Year => Quantity.Known.Duration().GetUnit("Year");

   /// <summary>
   /// The Decade unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Decade => Quantity.Known.Duration().GetUnit("Decade");

   /// <summary>
   /// The Century unit of <see cref="Duration"/>.
   /// </summary>
   public static IUnit Century => Quantity.Known.Duration().GetUnit("Century");
   
   internal Duration()
       : base("Duration", "Second")
   {
   }

   /// <inheritdoc/>     
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Second", 1),
                
            //Conversions
            ("Nanosecond", 1e-9),
            ("Millisecond", 0.001),
            ("Minute", 60),
            ("Hour", 3600),
            ("Day", 86400),
            ("Week", 604800),
            ("Month", 2629743.83),
            ("Quarter", 7889231.49),
            ("Year", 31556926),
            ("Decade", 315569260),
            ("Century", 3155692600)
        };
   }
}