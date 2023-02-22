// ReSharper disable MemberCanBePrivate.Global -- This is a public interface class. Members are used by those who have this library as a dependency.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base;

/// <summary>
/// Starting point for working with quantities.
/// </summary>
public static class Quantity
{
   private static readonly IDictionary<string, IQuantity> _quantities = new Dictionary<string, IQuantity>();

   /// <summary>
   /// Retrieve all known quantities.
   /// </summary>
   /// <returns>All known quantities.</returns>
   public static IEnumerable<IQuantity> GetAll() => _quantities.Values;

   /// <inheritdoc cref="KnownQuantities"/>
   public static KnownQuantities Known { get; } = new();

   /// <inheritdoc cref="QuantitySetup"/>
   public static QuantitySetup Setup { get; } = new();

   /// <summary>
   /// Adds a quantity to the known quantities list.
   /// Only quantities added through this method are returned by the <see cref="GetAll"/> method.
   /// </summary>
   /// <param name="quantity">The quantity to add.</param>
   /// <typeparam name="T">The quantity type.</typeparam>
   /// <returns>The quantity that was added, or the existing quantity if one was added already.</returns>
   public static T Add<T>(T quantity)
      where T : IQuantity
   {
      if (_quantities.TryGetValue(quantity.Identifier, out var existing))
         return (T)existing;

      _quantities.Add(quantity.Identifier, quantity);
      return quantity;
   }

   /// <summary>
   /// Retrieves the <see cref="IQuantity"/> for the given identifier.
   /// </summary>
   /// <param name="identifier">The identifier.</param>
   /// <returns>The <see cref="IQuantity"/> for the given identifier.</returns>
   /// <exception cref="ArgumentNullException">Thrown when null is given as the identifier.</exception>
   /// <exception cref="KeyNotFoundException">Thrown when no quantity for the given identifier can be found.</exception>
   public static IQuantity Of(string identifier)
   {
      if (identifier == null)
         throw new ArgumentNullException(nameof(identifier));

      var matches = Regex.Match(identifier, @"(.*)([\/*])(?![^(]*\))(.*)");

      if (matches.Success)
      {
         var numeratorString = matches.Groups[1].Value.Trim('(', ')');
         var operatorCharacter = matches.Groups[2].Value;
         var denominatorString = matches.Groups[3].Value.Trim('(', ')');

         if (operatorCharacter == "/")
            return Rate(Of(numeratorString), Of(denominatorString));

         if (operatorCharacter == "*")
            return Product(Of(numeratorString), Of(denominatorString));

         throw new KeyNotFoundException($"Could not find quantity with identifier {identifier}.");
      }

      // At this point, the identifier must be a base-quantity, so check the base quantities for a match
      var quantity = _quantities.Values.SingleOrDefault(x => x.Identifier.Equals(identifier, StringComparison.InvariantCultureIgnoreCase));

      if (quantity == null)
         throw new KeyNotFoundException($"Could not find quantity with identifier {identifier}.");

      return quantity;
   }

   /// <summary>
   /// Creates a <see cref="RateCombinedQuantity"/> for the given quantity identifiers.
   /// </summary>
   /// <param name="numeratorIdentifier">The numerator quantity identifier.</param>
   /// <param name="denominatorIdentifier">The denominator quantity identifier.</param>
   /// <returns>A <see cref="RateCombinedQuantity"/> for the given identifiers.</returns>
   public static RateCombinedQuantity Rate(string numeratorIdentifier, string denominatorIdentifier)
   {
      var numeratorQuantity = Of(numeratorIdentifier);
      var denominatorQuantity = Of(denominatorIdentifier);
      return Rate(numeratorQuantity, denominatorQuantity);
   }

   /// <summary>
   /// Creates a <see cref="RateCombinedQuantity"/> for the given quantities.
   /// </summary>
   /// <param name="numeratorQuantity">The numerator quantity.</param>
   /// <param name="denominatorQuantity">The denominator quantity.</param>
   /// <returns>A <see cref="RateCombinedQuantity"/> for the given quantities.</returns>
   public static RateCombinedQuantity Rate(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
   {
      if (numeratorQuantity == null)
         throw new ArgumentNullException(nameof(numeratorQuantity));

      if (denominatorQuantity == null)
         throw new ArgumentNullException(nameof(denominatorQuantity));

      return new RateCombinedQuantity(numeratorQuantity, denominatorQuantity);
   }

   /// <summary>
   /// Creates a <see cref="ProductCombinedQuantity"/> for the given quantity identifiers.
   /// </summary>
   /// <param name="numeratorIdentifier">The numerator quantity identifier.</param>
   /// <param name="denominatorIdentifier">The denominator quantity identifier.</param>
   /// <returns>A <see cref="ProductCombinedQuantity"/> for the given identifiers.</returns>
   public static ProductCombinedQuantity Product(string numeratorIdentifier, string denominatorIdentifier)
   {
      var numeratorQuantity = Of(numeratorIdentifier);
      var denominatorQuantity = Of(denominatorIdentifier);
      return Product(numeratorQuantity, denominatorQuantity);
   }

   /// <summary>
   /// Creates a <see cref="ProductCombinedQuantity"/> for the given quantities.
   /// </summary>
   /// <param name="numeratorQuantity">The numerator quantity.</param>
   /// <param name="denominatorQuantity">The denominator quantity.</param>
   /// <returns>A <see cref="ProductCombinedQuantity"/> for the given quantities.</returns>
   public static ProductCombinedQuantity Product(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
   {
      if (numeratorQuantity == null)
         throw new ArgumentNullException(nameof(numeratorQuantity));

      if (denominatorQuantity == null)
         throw new ArgumentNullException(nameof(denominatorQuantity));

      return new ProductCombinedQuantity(numeratorQuantity, denominatorQuantity);
   }
}