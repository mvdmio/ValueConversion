using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In physics, power is the amount of energy transferred or converted per unit time. 
/// In the SI system, the unit of power is the watt, equal to one joule per second.
/// </summary>
public sealed class PowerQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Watt unit of <see cref="PowerQuantity"/>. This is the standard unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit Watt => GetUnit("Watt");

   /// <summary>
   /// The MetricHorsepower unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit MetricHorsepower => GetUnit("MetricHorsepower");

   /// <summary>
   /// The MechanicalHorsepower unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit MechanicalHorsepower => GetUnit("MechanicalHorsepower");

   /// <summary>
   /// The HydraulicHorsepower unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit HydraulicHorsepower => GetUnit("HydraulicHorsepower");

   /// <summary>
   /// The ElectricalHorsepower unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit ElectricalHorsepower => GetUnit("ElectricalHorsepower");

   /// <summary>
   /// The Kilowatt unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit Kilowatt => GetUnit("Kilowatt");

   /// <summary>
   /// The Megawatt unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit Megawatt => GetUnit("Megawatt");

   /// <summary>
   /// The Gigawatt unit of <see cref="PowerQuantity"/>.
   /// </summary>
   public IUnit Gigawatt => GetUnit("Gigawatt");

   internal PowerQuantity()
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