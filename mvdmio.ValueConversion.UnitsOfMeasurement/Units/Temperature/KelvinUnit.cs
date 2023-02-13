using System;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Units.Temperature;

/// <summary>
/// Unit for representing temperature as Kelvin.
/// </summary>
public class KelvinUnit : TemperatureUnit
{
    internal KelvinUnit()
        : base("Kelvin")
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