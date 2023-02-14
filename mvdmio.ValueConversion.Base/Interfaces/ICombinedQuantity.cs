using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.Base.Interfaces;

/// <summary>
/// Interface for defining combined quantities.
/// </summary>
public interface ICombinedQuantity : IQuantity
{
    /// <inheritdoc cref="IQuantity.StandardUnit" />
    new ICombinedUnit StandardUnit { get; }
        
    /// <summary>
    /// The numerator <see cref="IQuantity"/>.
    /// </summary>
    IQuantity NumeratorQuantity { get; }

    /// <summary>
    /// The denominator <see cref="IQuantity"/>.
    /// </summary>
    IQuantity DenominatorQuantity { get; }
    
    /// <inheritdoc cref="IQuantity.GetUnits" />
    new IEnumerable<ICombinedUnit> GetUnits();

    /// <summary>
    /// Retrieve a unit with a given identifier for this quantity.
    /// </summary>
    /// <param name="numeratorUnitIdentifier">The numerator identifier of the unit to retrieve.</param>
    /// <param name="denominatorUnitIdentifier">The denominator identifier of the unit to retrieve.</param>
    /// <returns>The unit for this quantity with the given identifier.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when no unit with the given identifier is found for this quantity.</exception>
    ICombinedUnit GetUnit(string numeratorUnitIdentifier, string denominatorUnitIdentifier);

    /// <inheritdoc cref="IQuantity.Convert(IQuantityValue, IUnit)" />
    IQuantityValue Convert(IQuantityValue quantityValue, ICombinedUnit toUnit);
    
    /// <inheritdoc cref="IQuantity.CreateValue(DateTime, double, IUnit)" />
    IQuantityValue CreateValue(DateTime timestamp, double value, ICombinedUnit unit);
}