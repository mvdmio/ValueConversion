using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In physics, energy is the quantitative property that must be transferred to an object in order to perform work on, or to heat, the object.
/// Energy is a conserved quantity; the law of conservation of energy states that energy can be converted in form, but not created or destroyed.
/// The SI unit of energy is the joule, which is the energy transferred to an object by the work of moving it a distance of 1 metre against a force of 1 newton. 
/// </summary>
public sealed class EnergyQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The Joule unit of <see cref="EnergyQuantity"/>. This is the standard unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit Joule => GetUnit("Joule");

   /// <summary>
   /// The Calorie unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit Calorie => GetUnit("Calorie");

   /// <summary>
   /// The Kilocalorie unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit Kilocalorie => GetUnit("Kilocalorie");

   /// <summary>
   /// The Kilojoule unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit Kilojoule => GetUnit("Kilojoule");

   /// <summary>
   /// The KilowattHour unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit KilowattHour => GetUnit("KilowattHour");

   /// <summary>
   /// The MegaJoule unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit MegaJoule => GetUnit("MegaJoule");

   /// <summary>
   /// The MegawattHour unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit MegawattHour => GetUnit("MegawattHour");

   /// <summary>
   /// The WattHour unit of <see cref="EnergyQuantity"/>.
   /// </summary>
   public IUnit WattHour => GetUnit("WattHour");

   internal EnergyQuantity()
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