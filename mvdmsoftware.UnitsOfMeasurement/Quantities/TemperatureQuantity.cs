using System.Collections.Generic;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;
using mvdmsoftware.UnitsOfMeasurement.Units.Temperature;

namespace mvdmsoftware.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// Temperature is a physical quantity that expresses hot and cold. 
    /// It is the manifestation of thermal energy, present in all matter, which is the source of the occurrence of heat, a flow of energy, when a body is in contact with another that is colder.
    /// </summary>
    public sealed class TemperatureQuantity : QuantityBase<TemperatureType>
    {
        private readonly object _lockObject = new object();
        private IDictionary<TemperatureType, IUnit<TemperatureType>> _units;

        internal TemperatureQuantity() 
            : base(QuantityType.Temperature, TemperatureType.DegreeCelsius)
        {
        }

        /// <inheritdoc/>
        public override IDictionary<TemperatureType, IUnit<TemperatureType>> GetUnits()
        {
            if (_units == null)
            {
                lock (_lockObject)
                {
                    if (_units == null)
                    {
                        var units = new Dictionary<TemperatureType, IUnit<TemperatureType>>
                        {
                            {TemperatureType.DegreeCelsius, new DegreeCelsiusUnit()},
                            {TemperatureType.DegreeFahrenheit, new DegreeFahrenheitUnit()},
                            {TemperatureType.Kelvin, new KelvinUnit()},
                        };
                        _units = units;
                    }
                }
            }

            return _units;
        }
    }
}
