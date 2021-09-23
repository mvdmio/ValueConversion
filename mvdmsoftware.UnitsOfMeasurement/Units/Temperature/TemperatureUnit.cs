using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Units.Temperature
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