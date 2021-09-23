using System.Collections.Generic;
using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// In physics, power is the amount of energy transferred or converted per unit time. 
    /// In the SI system, the unit of power is the watt, equal to one joule per second.
    /// </summary>
    public sealed class PowerQuantity : ConversionFactorQuantityBase<PowerType>
    {
        internal PowerQuantity() 
            : base(QuantityType.Power, PowerType.Watt)
        {
        }

        /// <inheritdoc/>     
        protected override IEnumerable<(PowerType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (PowerType.Watt, 1),
                
                //Conversions
                (PowerType.MetricHorsepower, 735.49875),
                (PowerType.MechanicalHorsepower, 745.69987158227022),
                (PowerType.HydraulicHorsepower, 745.7),
                (PowerType.ElectricalHorsepower, 746),
                (PowerType.Kilowatt, 1000),
                (PowerType.Megawatt, 1000000),
                (PowerType.Gigawatt, 1000000000)
            };
        }
    }
}