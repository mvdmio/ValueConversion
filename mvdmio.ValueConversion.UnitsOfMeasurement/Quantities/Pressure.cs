using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Pressure units class
/// </summary>
public class Pressure : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Pascal unit of <see cref="Pressure"/>. This is the standard unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Pascal => Quantity.Known.Pressure().GetUnit("Pascal");

   /// <summary>
   /// The Atmosphere unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Atmosphere => Quantity.Known.Pressure().GetUnit("Atmosphere");

   /// <summary>
   /// The Bar unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Bar => Quantity.Known.Pressure().GetUnit("Bar");

   /// <summary>
   /// The Centibar unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Centibar => Quantity.Known.Pressure().GetUnit("Centibar");

   /// <summary>
   /// The Decibar unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Decibar => Quantity.Known.Pressure().GetUnit("Decibar");

   /// <summary>
   /// The Kilobar unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Kilobar => Quantity.Known.Pressure().GetUnit("Kilobar");

   /// <summary>
   /// The Megabar unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Megabar => Quantity.Known.Pressure().GetUnit("Megabar");

   /// <summary>
   /// The Millibar unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Millibar => Quantity.Known.Pressure().GetUnit("Millibar");

   /// <summary>
   /// The Microbar unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Microbar => Quantity.Known.Pressure().GetUnit("Microbar");

   /// <summary>
   /// The Decapascal unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Decapascal => Quantity.Known.Pressure().GetUnit("Decapascal");

   /// <summary>
   /// The Gigapascal unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Gigapascal => Quantity.Known.Pressure().GetUnit("Gigapascal");

   /// <summary>
   /// The Hectopascal unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Hectopascal => Quantity.Known.Pressure().GetUnit("Hectopascal");

   /// <summary>
   /// The Kilopascal unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Kilopascal => Quantity.Known.Pressure().GetUnit("Kilopascal");

   /// <summary>
   /// The Megapascal unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit Megapascal => Quantity.Known.Pressure().GetUnit("Megapascal");

   /// <summary>
   /// The PoundForcePerSquareInch unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit PoundForcePerSquareInch => Quantity.Known.Pressure().GetUnit("PoundForcePerSquareInch");

   /// <summary>
   /// The PoundForcePerSquareFoot unit of <see cref="Pressure"/>.
   /// </summary>
   public static IUnit PoundForcePerSquareFoot => Quantity.Known.Pressure().GetUnit("PoundForcePerSquareFoot");

   internal Pressure()
       : base("Pressure", "Pascal")
   {
   }

   /// <inheritdoc />
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Pascal", 1),
                
            //Metric
            ("Atmosphere", 101325),
            ("Bar", 1e+5),
            ("Centibar", 1000),
            ("Decibar", 10000),
            ("Kilobar", 1e+8),
            ("Megabar", 1e+11),
            ("Millibar", 100),
            ("Microbar", 0.1),
            ("Decapascal", 10),
            ("Gigapascal", 1e+9),
            ("Hectopascal", 100),
            ("Kilopascal", 1000),
            ("Megapascal", 1e+6),
                
            //Imperial
            ("PoundForcePerSquareInch", 689475729),
            ("PoundForcePerSquareFoot", 47880259)
        };
   }
}