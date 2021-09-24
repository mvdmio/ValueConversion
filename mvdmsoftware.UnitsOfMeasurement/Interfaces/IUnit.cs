using System;
using System.Globalization;

namespace mvdmsoftware.UnitsOfMeasurement.Interfaces
{
    /// <summary>
    /// Interface for defining units.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// The unit identifier. Can be used to retrieve a unit object using the <see cref="Unit.GetUnit(string)"/> method on the <see cref="Unit" /> static class.
        /// The main purpose of this identifier is serialization over application boundries.
        /// </summary>
        string Identifier { get; }

        /// <summary>
        /// Retrieves the quantity of this unit.
        /// </summary>
        /// <returns>The quantity of this unit.</returns>
        IQuantity GetQuantity();

        /// <summary>
        /// Converts the given value from the standard unit of this quantity into this unit.
        /// </summary>
        /// <param name="value">The value that should be converted.</param>
        /// <param name="timestamp">The timestamp when this value was recorded. Mainly used by time-dependent conversions like Currency.</param>
        /// <returns>The value converted to this unit.</returns>
        double FromStandardUnit(double value, DateTimeOffset timestamp);

        /// <summary>
        /// Converts the given value from this unit to standard unit.
        /// </summary>
        /// <param name="value">The value that should be converted.</param>
        /// <param name="timestamp">The timestamp when this value was recorded. Mainly used by time-dependent conversions like Currency.</param>
        /// <returns>The value converted to the standard unit of this quantity.</returns>
        double ToStandardUnit(double value, DateTimeOffset timestamp);

        /// <summary>
        /// Retrieves the symbol that corresponds to this unit.
        /// Can be used to display this value with the correct symbol.
        /// </summary>
        /// <param name="cultureInfo">The cultureInfo that should be used to determine the correct symbol.</param>
        /// <returns>The symbol that corresponds to this unit and the given CultureInfo.</returns>
        string GetSymbol(CultureInfo cultureInfo);

        /// <summary>
        /// Formats the given value into a string with the correct symbol.
        /// Can be used to display the value as a string with the correct symbol and correct symbol placement.
        /// </summary>
        /// <param name="value">The value that should be formatted</param>
        /// <param name="cultureInfo">The CultureInfo that should be used to determine the correct formatting.</param>
        /// <returns>The value formatted with the correct symbol and correct symbol placement for the given Culture Info</returns>
        string GetFormattedValue(double value, CultureInfo cultureInfo);
    }

    /// <summary>
    /// Interface for defining units of a certain enum type.
    /// </summary>
    /// <typeparam name="TEnum">The enum type of the unit.</typeparam>
    public interface IUnit<TEnum> : IUnit
        where TEnum : Enum
    {
        /// <summary>
        /// The enum type of the unit.
        /// </summary>
        TEnum Type { get; }

        /// <summary>
        /// Retrieves the typed quantity for this unit.
        /// </summary>
        /// <returns>The typed quantity for this unit.</returns>
        new IQuantity<TEnum> GetQuantity();
    }
}
