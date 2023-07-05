using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// The amount of elapsed time between two events.
/// In the SI system, it is specified in units of s (seconds). 
/// </summary>
public sealed class DurationQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Second unit of <see cref="DurationQuantity"/>. This is the standard unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Second => GetUnit("Second");

   /// <summary>
   /// The Nanosecond unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Nanosecond => GetUnit("Nanosecond");

   /// <summary>
   /// The Millisecond unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Millisecond => GetUnit("Millisecond");

   /// <summary>
   /// The Minute unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Minute => GetUnit("Minute");

   /// <summary>
   /// The Hour unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Hour => GetUnit("Hour");

   /// <summary>
   /// The Day unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Day => GetUnit("Day");

   /// <summary>
   /// The Week unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Week => GetUnit("Week");

   /// <summary>
   /// The Month unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Month => GetUnit("Month");

   /// <summary>
   /// The Quarter unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Quarter => GetUnit("Quarter");

   /// <summary>
   /// The Year unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Year => GetUnit("Year");

   /// <summary>
   /// The Decade unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Decade => GetUnit("Decade");

   /// <summary>
   /// The Century unit of <see cref="DurationQuantity"/>.
   /// </summary>
   public IUnit Century => GetUnit("Century");
   
   internal DurationQuantity()
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