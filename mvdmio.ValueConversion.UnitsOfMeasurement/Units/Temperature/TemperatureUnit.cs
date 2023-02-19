using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Units.Temperature;

/// <summary>
/// Base class for temperature units.
/// </summary>
public abstract class TemperatureUnit : UnitOfMeasurementUnitBase
{
    /// <summary>
    /// Creates a new Temperature Unit.
    /// </summary>
    /// <param name="identifier">The temperature unit identifier for this unit.</param>
    protected TemperatureUnit(string identifier)
        : base(identifier, Quantity.Known.Temperature())
    {
    }
}