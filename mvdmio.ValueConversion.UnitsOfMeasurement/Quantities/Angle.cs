using System;
using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In plane geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle.
/// </summary>
public sealed class Angle : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Degree unit of <see cref="Angle"/>. This is the standard unit of <see cref="Angle"/>.
   /// </summary>
   public static IUnit Degree => Quantity.Known.Angle().GetUnit("Degree");

   /// <summary>
   /// The Radian unit of <see cref="Angle"/>.
   /// </summary>
   public static IUnit Radian => Quantity.Known.Angle().GetUnit("Radian");

   internal Angle()
       : base("Angle", "Degree")
   {
   }
   
   /// <inheritdoc/>     
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            ("Degree", 1),
            ("Radian", 180 / Math.PI),
        };
   }
}