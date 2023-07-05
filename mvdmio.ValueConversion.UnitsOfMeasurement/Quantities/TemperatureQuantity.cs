using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Units.Temperature;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Temperature is a physical quantity that expresses hot and cold. 
/// It is the manifestation of thermal energy, present in all matter, which is the source of the occurrence of heat, a flow of energy, when a body is in contact with another that is colder.
/// </summary>
public sealed class TemperatureQuantity : QuantityBase
{
   private readonly object _lockObject = new();
   private IUnit[]? _units;

   /// <summary>
   /// The DegreeCelsius unit of <see cref="TemperatureQuantity"/>. This is the standard unit of <see cref="TemperatureQuantity"/>.
   /// </summary>
   public IUnit DegreeCelsius => GetUnit("DegreeCelsius");

   /// <summary>
   /// The DegreeFahrenheit unit of <see cref="TemperatureQuantity"/>.
   /// </summary>
   public IUnit DegreeFahrenheit => GetUnit("DegreeFahrenheit");

   /// <summary>
   /// The Kelvin unit of <see cref="TemperatureQuantity"/>.
   /// </summary>
   public IUnit Kelvin => GetUnit("Kelvin");

   internal TemperatureQuantity()
       : base("Temperature", "DegreeCelsius")
   {
   }

   /// <inheritdoc/>
   public override IEnumerable<IUnit> GetUnits()
   {
      if (_units == null)
      {
         lock (_lockObject)
         {
            if (_units == null)
            {
               var units = new IUnit[] {
                        new DegreeCelsiusUnit(),
                        new DegreeFahrenheitUnit(),
                        new KelvinUnit()
                    };
               _units = units;
            }
         }
      }

      return _units;
   }
}