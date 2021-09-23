using System.Collections.Generic;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// In physics, energy is the quantitative property that must be transferred to an object in order to perform work on, or to heat, the object.
    /// Energy is a conserved quantity; the law of conservation of energy states that energy can be converted in form, but not created or destroyed.
    /// The SI unit of energy is the joule, which is the energy transferred to an object by the work of moving it a distance of 1 metre against a force of 1 newton. 
    /// </summary>
    public sealed class EnergyQuantity : ConversionFactorQuantityBase<EnergyType>
    {
        internal EnergyQuantity() 
            : base(QuantityType.Energy, EnergyType.Joule)
        {
        }

        /// <inheritdoc/>     
        protected override IEnumerable<(EnergyType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (EnergyType.Joule, 1),
                
                //Conversions
                (EnergyType.Calorie, 4.18400),
                (EnergyType.Kilocalorie, 4184),
                (EnergyType.Kilojoule, 1000),
                (EnergyType.KilowattHour, 3600000),
                (EnergyType.MegaJoule, 1000000),
                (EnergyType.MegawattHour, 3600000000),
                (EnergyType.WattHour, 3600)
            };
        }
    }
}
