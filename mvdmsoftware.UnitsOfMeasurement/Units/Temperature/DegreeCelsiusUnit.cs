using System;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.Units.Temperature
{
    /// <summary>
    /// Unit for representing temperature as degrees Celsius.
    /// </summary>
    public class DegreeCelsiusUnit : TemperatureUnit
    {
        internal DegreeCelsiusUnit()
            : base(TemperatureType.DegreeCelsius)
        {
        }

        /// <inheritdoc/>
        public override Task<double> FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value);
        }

        /// <inheritdoc/>
        public override Task<double> ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value);
        }
    }
}