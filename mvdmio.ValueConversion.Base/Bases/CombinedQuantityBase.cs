using System;
using System.Collections.Generic;
using System.Linq;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base.Bases;

/// <summary>
/// Base class for Combined Quantities.
/// </summary>
public abstract class CombinedQuantityBase : ICombinedQuantity
{
   private readonly object _lockObject = new();
   private IList<ICombinedUnit>? _units;

   /// <inheritdoc />
   public bool IsNamed { get; }

   IUnit IQuantity.StandardUnit => StandardUnit;

   /// <inheritdoc />
   public string Identifier { get; }

   /// <inheritdoc />
   public IQuantity NumeratorQuantity { get; }

   /// <inheritdoc />
   public IQuantity DenominatorQuantity { get; }

   /// <inheritdoc />
   public ICombinedUnit StandardUnit
   {
      get
      {
         return GetUnits().Single(x => x.NumeratorUnit.Identifier == NumeratorQuantity.StandardUnit.Identifier && x.DenominatorUnit.Identifier == DenominatorQuantity.StandardUnit.Identifier);
      }
   }

   /// <summary>
   /// The character to use when combining the numerator and denominator identifiers into a single combined identifier.
   /// </summary>
   protected abstract string CombinerCharacter { get; }

   /// <summary>
   /// Creates a new unnamed <see cref="CombinedQuantityBase"/> instance.
   /// </summary>
   /// <param name="numeratorQuantity">The numerator quantity.</param>
   /// <param name="denominatorQuantity">The denominator quantity.</param>
   protected CombinedQuantityBase(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
   {
      Identifier = GetCombinedQuantityIdentifier(numeratorQuantity, denominatorQuantity);
      IsNamed = false;

      NumeratorQuantity = numeratorQuantity;
      DenominatorQuantity = denominatorQuantity;
   }

   /// <summary>
   /// Creates a new named <see cref="CombinedQuantityBase"/> instance.
   /// </summary>
   /// <param name="numeratorQuantity">The numerator quantity.</param>
   /// <param name="denominatorQuantity">The denominator quantity.</param>
   protected CombinedQuantityBase(string identifier, IQuantity numeratorQuantity, IQuantity denominatorQuantity)
   {
      Identifier = identifier;
      IsNamed = true;

      NumeratorQuantity = numeratorQuantity;
      DenominatorQuantity = denominatorQuantity;

      
   }

   /// <inheritdoc />
   public ICombinedUnit GetUnit(string numeratorUnitIdentifier, string denominatorUnitIdentifier)
   {
      return GetUnits().First(x => x.NumeratorUnit.Identifier == numeratorUnitIdentifier && x.DenominatorUnit.Identifier == denominatorUnitIdentifier);
   }

   IEnumerable<IUnit> IQuantity.GetUnits()
   {
      return GetUnits();
   }

   /// <inheritdoc />
   public IUnit GetUnit(string unitIdentifier)
   {
      var unit = GetUnits().SingleOrDefault(x => x.Identifier == unitIdentifier);

      if (unit == null)
         throw new KeyNotFoundException($"Unit {unitIdentifier} could not be found for quantity {GetType().Name}");

      return unit;
   }

   /// <inheritdoc />
   public IQuantityValue CreateValue(double value, string unitIdentifier)
   {
      var unit = GetUnit(unitIdentifier);
      return CreateValue(value, unit);
   }

   /// <inheritdoc />
   public IQuantityValue CreateValue(double value, IUnit unit)
   {
      return CreateValue(DateTime.UtcNow, value, unit);
   }

   /// <inheritdoc />
   public IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit)
   {
      if (unit is not ICombinedUnit typedUnit || GetUnits().All(x => x.Identifier != unit.Identifier))
         throw new InvalidCastException($"Cannot create value of unit {unit.Identifier} from quantity {GetType().FullName}");

      return CreateValue(timestamp, value, typedUnit);
   }

   /// <inheritdoc />
   public IEnumerable<ICombinedUnit> GetUnits()
   {
      if (_units != null)
         return _units;

      lock (_lockObject)
      {
         if (_units != null)
            return _units;

         _units = CalculateUnits(NumeratorQuantity, DenominatorQuantity);
      }

      return _units;
   }

   /// <inheritdoc />
   public IQuantityValue Convert(IQuantityValue quantityValue, string toUnitIdentifier)
   {
      var unit = GetUnit(toUnitIdentifier);
      return Convert(quantityValue, unit);
   }


   /// <inheritdoc />
   public IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit)
   {
      if (toUnit is not ICombinedUnit typedUnit)
         throw new InvalidCastException($"Cannot convert to unit {toUnit.Identifier} from quantity {GetType().FullName}");

      return Convert(quantityValue, typedUnit);
   }

   /// <inheritdoc />
   public IQuantityValue Convert(IQuantityValue quantityValue, ICombinedUnit toUnit)
   {
      if (quantityValue.GetQuantity().Identifier != this.Identifier)
         throw new InvalidCastException($"{GetType().FullName} cannot convert quantity values of quantity type {quantityValue.GetQuantity().Identifier}");

      var value = quantityValue.GetStandardValue();
      var convertedValue = toUnit.FromStandardUnit(value, quantityValue.Timestamp);

      return new CombinedQuantityValue(quantityValue.Timestamp, convertedValue, toUnit);
   }

   /// <inheritdoc />
   public IQuantityValue CreateValue(DateTime timestamp, double value, ICombinedUnit unit)
   {
      return new CombinedQuantityValue(timestamp, value, unit);
   }

   protected abstract ICombinedUnit GetCombinedUnit(IUnit numeratorUnit, IUnit denominatorUnit);

   private IList<ICombinedUnit> CalculateUnits(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
   {
      var numeratorUnits = numeratorQuantity.GetUnits().ToList();
      var denominatorUnits = denominatorQuantity.GetUnits().ToList();

      var result = new List<ICombinedUnit>();
      foreach (var numeratorUnit in numeratorUnits)
      {
         foreach (var denominatorUnit in denominatorUnits)
         {
            result.Add(GetCombinedUnit(numeratorUnit, denominatorUnit));
         }
      }

      return result;
   }

   private string GetCombinedQuantityIdentifier(IQuantity numerator, IQuantity denominator)
   {
      var numeratorIdentifier = numerator is ICombinedQuantity { IsNamed: false } ? $"({numerator.Identifier})" : numerator.Identifier;
      var denominatorIdentifier = denominator is ICombinedQuantity { IsNamed: false } ? $"({denominator.Identifier})" : denominator.Identifier;
      
      return $"{numeratorIdentifier}{CombinerCharacter}{denominatorIdentifier}";
   }
}