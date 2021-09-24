using System;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Units.Temperature
{
    /// <summary>
    /// Unit for representing temperature as degrees Fahrenheit.
    /// </summary>
    public class DegreeFahrenheitUnit : TemperatureUnit
    {
        internal DegreeFahrenheitUnit()
            : base(TemperatureType.DegreeFahrenheit)
        {
        }

        /// <inheritdoc/>
        public override double FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return (value * 1.8) + 32;
        }

        /// <inheritdoc/>
        public override double ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return (value - 32) / 1.8;
        }
    }
}