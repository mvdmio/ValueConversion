namespace mvdmio.ValueConversion.Base.Interfaces;

/// <summary>
/// Interface for combined units
/// </summary>
public interface ICombinedUnit : IUnit
{
    /// <summary>
    /// The numerator unit.
    /// </summary>
    IUnit NumeratorUnit { get; }

    /// <summary>
    /// The denominator unit.
    /// </summary>
    IUnit DenominatorUnit { get; }

    /// <summary>
    /// Retrieve the quantity for this unit.
    /// </summary>
    /// <returns>The quantity for this unit.</returns>
    new ICombinedQuantity GetQuantity();
}