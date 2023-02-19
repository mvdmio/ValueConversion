using mvdmio.ValueConversion.Base.Quantities;

namespace mvdmio.ValueConversion.Base;

/// <summary>
/// Extendible class for configuring known quantities.
/// </summary>
public class KnownQuantities
{
   /// <inheritdoc cref="ScalarQuantity" />
   public ScalarQuantity Scalar() => new();
}