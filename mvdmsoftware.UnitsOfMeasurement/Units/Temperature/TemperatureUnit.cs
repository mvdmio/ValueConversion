using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Units.Temperature
{
    /// <summary>
    /// Base class for temperature units.
    /// </summary>
    public abstract class TemperatureUnit : UnitBase<TemperatureType>
    {
        /// <summary>
        /// Creates a new Temperature Unit.
        /// </summary>
        /// <param name="type">The temperature unit type for this unit.</param>
        /// 
        protected TemperatureUnit(TemperatureType type)
            : base(Quantity.Temperature, type)
        {
        }
    }
}