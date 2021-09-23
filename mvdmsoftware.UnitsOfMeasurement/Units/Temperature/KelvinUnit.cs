using System;
using System.Threading.Tasks;
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
        public override Task<double> FromStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value + 273.15);
        }

        /// <inheritdoc/>
        public override Task<double> ToStandardUnit(double value, DateTimeOffset timestamp)
        {
            return Task.FromResult(value - 273.15);
        }
    }
}