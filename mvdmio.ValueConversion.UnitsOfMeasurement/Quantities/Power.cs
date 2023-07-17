using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In physics, power is the amount of energy transferred or converted per unit time. 
/// In the SI system, the unit of power is the watt, equal to one joule per second.
/// </summary>
public sealed class Power : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Watt unit of <see cref="Power"/>. This is the standard unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit Watt => Quantity.Known.Power().GetUnit("Watt");

   /// <summary>
   /// The MetricHorsepower unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit MetricHorsepower => Quantity.Known.Power().GetUnit("MetricHorsepower");

   /// <summary>
   /// The MechanicalHorsepower unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit MechanicalHorsepower => Quantity.Known.Power().GetUnit("MechanicalHorsepower");

   /// <summary>
   /// The HydraulicHorsepower unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit HydraulicHorsepower => Quantity.Known.Power().GetUnit("HydraulicHorsepower");

   /// <summary>
   /// The ElectricalHorsepower unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit ElectricalHorsepower => Quantity.Known.Power().GetUnit("ElectricalHorsepower");

   /// <summary>
   /// The Kilowatt unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit Kilowatt => Quantity.Known.Power().GetUnit("Kilowatt");

   /// <summary>
   /// The Megawatt unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit Megawatt => Quantity.Known.Power().GetUnit("Megawatt");

   /// <summary>
   /// The Gigawatt unit of <see cref="Power"/>.
   /// </summary>
   public static IUnit Gigawatt => Quantity.Known.Power().GetUnit("Gigawatt");

   internal Power()
       : base("Power", "Watt")
   {
   }

   /// <inheritdoc/>     
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Watt", 1),
                
            //Conversions
            ("MetricHorsepower", 735.49875),
            ("MechanicalHorsepower", 745.69987158227022),
            ("HydraulicHorsepower", 745.7),
            ("ElectricalHorsepower", 746),
            ("Kilowatt", 1000),
            ("Megawatt", 1000000),
            ("Gigawatt", 1000000000)
        };
   }
}