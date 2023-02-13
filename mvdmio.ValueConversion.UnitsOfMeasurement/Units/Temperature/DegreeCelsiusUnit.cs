using System;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Units.Temperature;

/// <summary>
/// Unit for representing temperature as degrees Celsius.
/// </summary>
public class DegreeCelsiusUnit : TemperatureUnit
{
    internal DegreeCelsiusUnit()
        : base("DegreeCelsius")
    {
    }

    /// <inheritdoc/>
    public override double FromStandardUnit(double value, DateTimeOffset timestamp)
    {
        return value;
    }

    /// <inheritdoc/>
    public override double ToStandardUnit(double value, DateTimeOffset timestamp)
    {
        return value;
    }
}