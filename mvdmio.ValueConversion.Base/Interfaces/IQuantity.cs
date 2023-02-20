// ReSharper disable UnusedMemberInSuper.Global | Public Interface type. Members are used by users of this library.
// ReSharper disable UnusedMember.Global | Public Interface type. Members are used by users of this library.

using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.Base.Interfaces;

/// <summary>
/// Interface for defining quantities.
/// </summary>
public interface IQuantity
{
   /// <summary>
   /// The standard unit of the quantity.
   /// </summary>
   /// <example>
   /// The SI standard defines 'seconds' as the standard unit for the 'duration' quantity.
   /// </example>
   IUnit StandardUnit { get; }

   /// <summary>
   /// The identifier of the quantity.
   /// </summary>
   string Identifier { get; }

   /// <summary>
   /// Retrieve the units that can be used for this quantity.
   /// </summary>
   /// <returns>The units that can be used for this quantity.</returns>
   IEnumerable<IUnit> GetUnits();

   /// <summary>
   /// Retrieve a unit with a given identifier for this quantity.
   /// </summary>
   /// <param name="unitIdentifier">The identifier of the unit to retrieve.</param>
   /// <returns>The unit for this quantity with the given identifier.</returns>
   /// <exception cref="KeyNotFoundException">Thrown when no unit with the given identifier is found for this quantity.</exception>
   IUnit GetUnit(string unitIdentifier);

   /// <summary>
   /// Convert the given quantity value to the given unit.
   /// </summary>
   /// <param name="quantityValue">The value to convert.</param>
   /// <param name="toUnitIdentifier">The unit to convert the value into.</param>
   /// <returns>A new <see cref="IQuantityValue"/> object who's value has been converted into the given unit.</returns>
   IQuantityValue Convert(IQuantityValue quantityValue, string toUnitIdentifier);
   
   /// <summary>
   /// Convert the given quantity value to the given unit.
   /// </summary>
   /// <param name="quantityValue">The value to convert.</param>
   /// <param name="toUnit">The unit to convert the value into.</param>
   /// <returns>A new <see cref="IQuantityValue"/> object who's value has been converted into the given unit.</returns>
   IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit);

   /// <summary>
   /// Create a new <see cref="IQuantityValue"/> with the given unit.
   /// </summary>
   /// <param name="value">The value to use.</param>
   /// <param name="unitIdentifier">The unit identifier of the given value.</param>
   /// <returns>A new <see cref="IQuantityValue"/> with the given unit.</returns>
   IQuantityValue CreateValue(double value, string unitIdentifier);

   /// <summary>
   /// Create a new <see cref="IQuantityValue"/> with the given unit.
   /// </summary>
   /// <param name="value">The value to use.</param>
   /// <param name="unit">The unit of the given value.</param>
   /// <returns>A new <see cref="IQuantityValue"/> with the given unit.</returns>
   IQuantityValue CreateValue(double value, IUnit unit);

   /// <summary>
   /// Create a new <see cref="IQuantityValue"/> with the given unit.
   /// </summary>
   /// <param name="timestamp">The timestamp when the value was recorded.</param>
   /// <param name="value">The value to use.</param>
   /// <param name="unit">The unit of the given value.</param>
   /// <returns>A new <see cref="IQuantityValue"/> with the given unit.</returns>
   IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit);
}