using System;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Units.Temperature
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
        public override Task<double> FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult((value * 1.8) + 32);
        }

        /// <inheritdoc/>
        public override Task<double> ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult((value - 32) / 1.8);
        }
    }
}