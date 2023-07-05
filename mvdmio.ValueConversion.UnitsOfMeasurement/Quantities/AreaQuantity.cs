using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In geometry, the area can be defined as the space occupied by a flat shape or the surface of an object. 
/// The area of a figure is the number of unit squares that cover the surface of a closed figure. 
/// Area is measured in square units such as square centimteres, square feet, square inches, etc.
/// </summary>
public sealed class AreaQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Square Meter unit on <see cref="AreaQuantity"/>. This is the standard unit of <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareMeter => GetUnit("SquareMeter");

   /// <summary>
   /// The Square Centimeter unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareCentimeter => GetUnit("SquareCentimeter");

   /// <summary>
   /// The Square Centimeter unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareDecimeter => GetUnit("SquareDecimeter");

   /// <summary>
   /// The Are unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Are => GetUnit("Are");

   /// <summary>
   /// The Hectare unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Hectare => GetUnit("Hectare");

   /// <summary>
   /// The Square Kilometer unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareKilometer => GetUnit("SquareKilometer");

   /// <summary>
   /// The Acre unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit Acre => GetUnit("Acre");

   /// <summary>
   /// The Square Foot unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareFoot => GetUnit("SquareFoot");

   /// <summary>
   /// The Square Inch unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareInch => GetUnit("SquareInch");

   /// <summary>
   /// The Square Mile unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareMile => GetUnit("SquareMile");

   /// <summary>
   /// The Square Yard unit on <see cref="AreaQuantity"/>.
   /// </summary>
   public IUnit SquareYard => GetUnit("SquareYard");

   internal AreaQuantity()
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