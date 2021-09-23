﻿using Ridder.UnitsOfMeasurement.Bases;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Interfaces;
using Ridder.UnitsOfMeasurement.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ridder.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// Defines the pH quantity
    /// </summary>
    public class PHQuantity : IQuantity
    {
        private readonly object _lockObject = new object();
        private IList<IUnit> _units;

        /// <inheritdoc/>
        public IUnit StandardUnit => GetUnits().First();
        
        /// <inheritdoc/>
        public virtual string Identifier { get; } = QuantityType.pH.ToString();

        internal PHQuantity()
        {
        }

        /// <inheritdoc/>
        public IUnit GetUnit(string unitIdentifier)
        {
            // Special case for systems that use an older version of UnitsOfMeasurement. In the past, the unit for pH was 'scalar', this should be handled as 'pH'
            if(unitIdentifier.Equals("Scalar", StringComparison.InvariantCultureIgnoreCase))
                return GetUnit("pH");

            var unit = GetUnits().SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

            if(unit == null)
                throw new KeyNotFoundException($"Unit {unitIdentifier} could not be found for quantity {GetType().Name}");

            return unit;
        }

        /// <inheritdoc/>
        public Task<IQuantityValue> Convert(IQuantityValue quantityValue, IUnit toUnit)
        {
            return Task.FromResult(quantityValue); // pH values don't support conversions, just return the original.
        }

        /// <inheritdoc/>
        public IQuantityValue CreateValue(double value, IUnit unit)
        {
            return CreateValue(DateTime.UtcNow, value, unit);
        }

        /// <inheritdoc/>
        public IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit)
        {
            var supportedUnit = GetUnits().SingleOrDefault(x => x.Identifier == unit.Identifier);

            if (supportedUnit == null)
                throw new InvalidOperationException($"Cannot create pH Quantity value for unit {unit.Identifier}");

            return new QuantityValue(timestamp, value, unit);
        }

        /// <inheritdoc/>
        public IEnumerable<IUnit> GetUnits()
        {
            if (_units == null)
            {
                lock (_lockObject)
                {
                    if (_units == null)
                    {
                        _units = new List<IUnit> {
                            new PHUnit(this)
                        };
                    }
                }
            }

            return _units;
        }
    }
}
