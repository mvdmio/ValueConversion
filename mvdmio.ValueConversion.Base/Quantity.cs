// ReSharper disable MemberCanBePrivate.Global -- This is a public interface class. Members are used by those who have this library as a dependency.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base;

public static class Quantity
{
   private static readonly IDictionary<string, IQuantity> _quantities = new Dictionary<string, IQuantity>();

   public static IEnumerable<IQuantity> GetAll() => _quantities.Values;

   public static KnownQuantities Known { get; } = new();

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

   public static RateCombinedQuantity Rate(string numeratorIdentifier, string denominatorIdentifier)
   {
      var numeratorQuantity = Of(numeratorIdentifier);
      var denominatorQuantity = Of(denominatorIdentifier);
      return Rate(numeratorQuantity, denominatorQuantity);
   }

   public static RateCombinedQuantity Rate(IQuantity numeratorQuantity, string denominatorIdentifier)
   {
      var denominatorQuantity = Of(denominatorIdentifier);
      return Rate(numeratorQuantity, denominatorQuantity);
   }

   public static RateCombinedQuantity Rate(string numeratorIdentifier, IQuantity denominatorQuantity)
   {
      var numeratorQuantity = Of(numeratorIdentifier);
      return Rate(numeratorQuantity, denominatorQuantity);
   }

   public static RateCombinedQuantity Rate(params string[] identifiers)
   {
      if (identifiers == null)
         throw new ArgumentNullException(nameof(identifiers));

      var quantities = identifiers.Select(Of).ToArray();
      return Rate(quantities);
   }

   public static RateCombinedQuantity Rate(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
   {
      if (numeratorQuantity == null)
         throw new ArgumentNullException(nameof(numeratorQuantity));

      if (denominatorQuantity == null)
         throw new ArgumentNullException(nameof(denominatorQuantity));

      return new RateCombinedQuantity(numeratorQuantity, denominatorQuantity);
   }

   public static RateCombinedQuantity Rate(params IQuantity[] quantities)
   {
      if (quantities == null)
         throw new ArgumentNullException(nameof(quantities));

      if (quantities.Length < 2)
         throw new NotSupportedException("A rate must have at least two quantities");

      if (quantities.Length == 2)
         return Rate(quantities[0], quantities[1]);

      return Rate(quantities[0], Rate(quantities.Skip(1).ToArray()));
   }

   public static ProductCombinedQuantity Product(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
   {
      if (numeratorQuantity == null)
         throw new ArgumentNullException(nameof(numeratorQuantity));

      if (denominatorQuantity == null)
         throw new ArgumentNullException(nameof(denominatorQuantity));

      return new ProductCombinedQuantity(numeratorQuantity, denominatorQuantity);
   }

   public static ProductCombinedQuantity Product(IQuantity numeratorQuantity, string denominatorIdentifier)
   {
      return Product(numeratorQuantity, Of(denominatorIdentifier));
   }

   public static ProductCombinedQuantity Product(string numeratorIdentifier, IQuantity denominatorQuantity)
   {
      return Product(Of(numeratorIdentifier), denominatorQuantity);
   }

   public static ProductCombinedQuantity Product(params string[] quantityIdentifiers)
   {
      return Product(quantityIdentifiers.Select(Of).ToArray());
   }

   public static ProductCombinedQuantity Product(params IQuantity[] quantities)
   {
      if (quantities == null)
         throw new ArgumentNullException(nameof(quantities));

      if (quantities.Length < 2)
         throw new NotSupportedException("A product must have at least two quantities");

      if (quantities.Length == 2)
         return Product(quantities[0], quantities[1]);

      return Product(quantities[0], Product(quantities.Skip(1).ToArray()));
   }
}