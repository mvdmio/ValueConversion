using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In geometry, the area can be defined as the space occupied by a flat shape or the surface of an object. 
/// The area of a figure is the number of unit squares that cover the surface of a closed figure. 
/// Area is measured in square units such as square centimteres, square feet, square inches, etc.
/// </summary>
public sealed class Area : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Square Meter unit on <see cref="Area"/>. This is the standard unit of <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareMeter => Quantity.Known.Area().GetUnit("SquareMeter");

   /// <summary>
   /// The Square Centimeter unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareCentimeter => Quantity.Known.Area().GetUnit("SquareCentimeter");

   /// <summary>
   /// The Square Centimeter unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareDecimeter => Quantity.Known.Area().GetUnit("SquareDecimeter");

   /// <summary>
   /// The Are unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit Are => Quantity.Known.Area().GetUnit("Are");

   /// <summary>
   /// The Hectare unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit Hectare => Quantity.Known.Area().GetUnit("Hectare");

   /// <summary>
   /// The Square Kilometer unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareKilometer => Quantity.Known.Area().GetUnit("SquareKilometer");

   /// <summary>
   /// The Acre unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit Acre => Quantity.Known.Area().GetUnit("Acre");

   /// <summary>
   /// The Square Foot unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareFoot => Quantity.Known.Area().GetUnit("SquareFoot");

   /// <summary>
   /// The Square Inch unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareInch => Quantity.Known.Area().GetUnit("SquareInch");

   /// <summary>
   /// The Square Mile unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareMile => Quantity.Known.Area().GetUnit("SquareMile");

   /// <summary>
   /// The Square Yard unit on <see cref="Area"/>.
   /// </summary>
   public static IUnit SquareYard => Quantity.Known.Area().GetUnit("SquareYard");

   internal Area()
       : base("Area", "SquareMeter")
   {
   }

   /// <inheritdoc/>     
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("SquareMeter", 1),
                
            //Metric
            ("SquareCentimeter", 0.0001),
            ("SquareDecimeter", 0.01),
            ("Are", 100),
            ("Hectare", 10000),
            ("SquareKilometer", 1000000),
                
            //Imperial
            ("Acre", 4046.8564224),
            ("SquareFoot", 0.09290304),
            ("SquareInch", 0.00064516),
            ("SquareMile", 2589988.11),
            ("SquareYard", 0.83612736)
        };
   }
}