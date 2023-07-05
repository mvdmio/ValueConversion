// ReSharper disable UnusedMember.Global | Public Interface type. Members are used by users of this library.

using System;
using System.Globalization;

namespace mvdmio.ValueConversion.Base.Interfaces;

/// <summary>
/// Interface for quantity values.
/// </summary>
public interface IQuantityValue
{
    /// <summary>
    /// The timestamp when the value was recorded.
    /// </summary>
    DateTimeOffset Timestamp { get; }

    /// <summary>
    /// Retrieve the <see cref="IQuantity"/> of the value.
    /// </summary>
    /// <returns>The <see cref="IQuantity"/> of the value.</returns>
    IQuantity GetQuantity();

    /// <summary>
    /// Retrieve the <see cref="IUnit"/> of the value.
    /// </summary>
    /// <returns>The <see cref="IUnit"/> of the value.</returns>
    IUnit GetUnit();

    /// <summary>
    /// Retrieve the numeric value in the current <see cref="IUnit"/>.
    /// </summary>
    /// <returns></returns>
    double GetValue();

    /// <summary>
    /// Retrieve the numeric value in the standard unit of the quantity.
    /// </summary>
    /// <returns>The numeric value in the standard unit of the quantity.</returns>
    double GetStandardValue();

    /// <summary>
    /// Convert this <see cref="IQuantityValue"/> into a <see cref="IQuantityValue"/> of the given <see cref="IUnit"/>.
    /// </summary>
    /// <param name="unit">The <see cref="IUnit"/> to convert this <see cref="IQuantityValue"/> into.</param>
    /// <returns>A <see cref="IQuantityValue"/> of the given <see cref="IUnit"/></returns>
    IQuantityValue As(IUnit unit);

    /// <summary>
    /// Compares this <see cref="IQuantityValue"/> with the given <see cref="IQuantityValue"/>. Returns true when the value in standard unit of both are equal. False otherwise.
    /// </summary>
    /// <param name="other">The <see cref="IQuantityValue"/> to compare this <see cref="IQuantityValue"/> with.</param>
    /// <returns>True when the value in standard unit of both are equal. False otherwise.</returns>
    bool IsEqualTo(IQuantityValue other);

    /// <summary>
    /// Retrieve the formatted string representation of this <see cref="IQuantityValue"/>.
    /// </summary>
    /// <param name="cultureInfo">The culture info to use to format the value.</param>
    /// <returns>The formatted string representation of this <see cref="IQuantityValue"/>.</returns>
    string GetFormattedValue(CultureInfo cultureInfo);

    string GetFormattedValue(CultureInfo cultureInfo,int decimalPoints);

}