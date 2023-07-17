using System.Collections.Generic;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In physics, energy is the quantitative property that must be transferred to an object in order to perform work on, or to heat, the object.
/// Energy is a conserved quantity; the law of conservation of energy states that energy can be converted in form, but not created or destroyed.
/// The SI unit of energy is the joule, which is the energy transferred to an object by the work of moving it a distance of 1 metre against a force of 1 newton. 
/// </summary>
public sealed class Energy : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Joule unit of <see cref="Energy"/>. This is the standard unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit Joule => Quantity.Known.Energy().GetUnit("Joule");

   /// <summary>
   /// The Calorie unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit Calorie => Quantity.Known.Energy().GetUnit("Calorie");

   /// <summary>
   /// The Kilocalorie unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit Kilocalorie => Quantity.Known.Energy().GetUnit("Kilocalorie");

   /// <summary>
   /// The Kilojoule unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit Kilojoule => Quantity.Known.Energy().GetUnit("Kilojoule");

   /// <summary>
   /// The KilowattHour unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit KilowattHour => Quantity.Known.Energy().GetUnit("KilowattHour");

   /// <summary>
   /// The MegaJoule unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit MegaJoule => Quantity.Known.Energy().GetUnit("MegaJoule");

   /// <summary>
   /// The MegawattHour unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit MegawattHour => Quantity.Known.Energy().GetUnit("MegawattHour");

   /// <summary>
   /// The WattHour unit of <see cref="Energy"/>.
   /// </summary>
   public static IUnit WattHour => Quantity.Known.Energy().GetUnit("WattHour");

   internal Energy()
       : base("Energy", "Joule")
   {
   }

   /// <inheritdoc/>     
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("Joule", 1),
                
            //Conversions
            ("Calorie", 4.18400),
            ("Kilocalorie", 4184),
            ("Kilojoule", 1000),
            ("KilowattHour", 3600000),
            ("MegaJoule", 1000000),
            ("MegawattHour", 3600000000),
            ("WattHour", 3600)
        };
   }
}