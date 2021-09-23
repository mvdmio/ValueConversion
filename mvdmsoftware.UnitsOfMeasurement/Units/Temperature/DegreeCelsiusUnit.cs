using System;
using System.Threading.Tasks;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmsoftware.UnitsOfMeasurement.Units.Temperature
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