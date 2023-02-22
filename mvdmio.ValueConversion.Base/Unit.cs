using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.Base;

/// <summary>
/// Starting point for working with units.
/// </summary>
public static class Unit
{
    /// <summary>
    /// Retrieve all known units.
    /// </summary>
    /// <returns>All known units.</returns>
    public static IEnumerable<IUnit> GetAll()
    {
        return Quantity.GetAll().SelectMany(x => x.GetUnits());
    }

    /// <summary>
    /// Get the unit that matches the given unitIdentifier.
    /// </summary>
    /// <param name="unitIdentifier">The unitIdentifier of the unit.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the given unitIdentifier does not match any known unit.</exception>
    /// <returns>The unit that matches the given unitIdentifier.</returns>
    public static IUnit GetUnit(string unitIdentifier)
    {
        var matches = Regex.Match(unitIdentifier, @"(.*)([\/*])(?![^(]*\))(.*)");

        if (matches.Success)
        {
            var numeratorString = matches.Groups[1].Value.Trim('(', ')');
            var operatorCharacter = matches.Groups[2].Value;
            var denominatorString = matches.Groups[3].Value.Trim('(', ')');

            if (operatorCharacter == "/")
                return Rate(GetUnit(numeratorString), GetUnit(denominatorString));

            if (operatorCharacter == "*")
                return Product(GetUnit(numeratorString), GetUnit(denominatorString));

            throw new KeyNotFoundException($"Could not find quantity with identifier {unitIdentifier}.");
        }

        // At this point, the identifier must be a base-quantity, so check the base quantities for a match
        var unit = GetAll().SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

        if (unit == null)
            throw new KeyNotFoundException($"Could not find unit for identifier ${unitIdentifier}");

        return unit;
    }

    private static IUnit Rate(IUnit numeratorUnit, IUnit denominatorUnit)
    {
        return new RateCombinedUnit(numeratorUnit, denominatorUnit, Quantity.Rate(numeratorUnit.GetQuantity(), denominatorUnit.GetQuantity()));
    }

    private static IUnit Product(IUnit numeratorUnit, IUnit denominatorUnit)
    {
        return new ProductCombinedUnit(numeratorUnit, denominatorUnit, Quantity.Product(numeratorUnit.GetQuantity(), denominatorUnit.GetQuantity()));
    }
}