using System;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Units.Temperature
{
    /// <summary>
    /// Unit for representing temperature as Kelvin.
    /// </summary>
    public class KelvinUnit : TemperatureUnit
    {
        internal KelvinUnit()
            : base(TemperatureType.Kelvin)
        {
        }

        /// <inheritdoc/>
        public override double FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value + 273.15;
        }

        /// <inheritdoc/>
        public override double ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return value - 273.15;
        }
    }
}