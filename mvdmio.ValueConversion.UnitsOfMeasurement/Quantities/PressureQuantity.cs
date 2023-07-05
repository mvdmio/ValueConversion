using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Pressure units class
/// </summary>
public class PressureQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Pascal unit of <see cref="PressureQuantity"/>. This is the standard unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Pascal => GetUnit("Pascal");

   /// <summary>
   /// The Atmosphere unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Atmosphere => GetUnit("Atmosphere");

   /// <summary>
   /// The Bar unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Bar => GetUnit("Bar");

   /// <summary>
   /// The Centibar unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Centibar => GetUnit("Centibar");

   /// <summary>
   /// The Decibar unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Decibar => GetUnit("Decibar");

   /// <summary>
   /// The Kilobar unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Kilobar => GetUnit("Kilobar");

   /// <summary>
   /// The Megabar unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Megabar => GetUnit("Megabar");

   /// <summary>
   /// The Millibar unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Millibar => GetUnit("Millibar");

   /// <summary>
   /// The Microbar unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Microbar => GetUnit("Microbar");

   /// <summary>
   /// The Decapascal unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Decapascal => GetUnit("Decapascal");

   /// <summary>
   /// The Gigapascal unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Gigapascal => GetUnit("Gigapascal");

   /// <summary>
   /// The Hectopascal unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Hectopascal => GetUnit("Hectopascal");

   /// <summary>
   /// The Kilopascal unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Kilopascal => GetUnit("Kilopascal");

   /// <summary>
   /// The Megapascal unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit Megapascal => GetUnit("Megapascal");

   /// <summary>
   /// The PoundForcePerSquareInch unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit PoundForcePerSquareInch => GetUnit("PoundForcePerSquareInch");

   /// <summary>
   /// The PoundForcePerSquareFoot unit of <see cref="PressureQuantity"/>.
   /// </summary>
   public IUnit PoundForcePerSquareFoot => GetUnit("PoundForcePerSquareFoot");

   internal PressureQuantity()
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