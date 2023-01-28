using System;
using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    /// <summary>
    /// Base class for all quantities that use a conversion factor to convert from and to standard unit.
    /// </summary>
    /// <typeparam name="TEnum">The unit enum type for this quantity.</typeparam>
    public abstract class ConversionFactorQuantityBase<TEnum> : QuantityBase<TEnum>
        where TEnum : Enum
    {
        private readonly object _lockObject = new object();
        private IDictionary<TEnum, IUnit<TEnum>> _units;

        /// <summary>
        /// Initializes a new object for this type.
        /// </summary>
        /// <param name="type">The quantity enum value for this quantity.</param>
        /// <param name="standardUnitType">The unit enum value for the standard unit of this quantity.</param>
        protected ConversionFactorQuantityBase(QuantityType type, TEnum standardUnitType) 
            : base(type, standardUnitType)
        {
        }

        /// <inheritdoc/>
        public sealed override IDictionary<TEnum, IUnit<TEnum>> GetUnits()
        {
            if (_units != null)
                return _units;

            lock (_lockObject)
            {
                if (_units != null)
                    return _units;

                var conversionFactors = GetConversionFactors();

                var units = new Dictionary<TEnum, IUnit<TEnum>>();
                foreach (var (type, conversionFactor) in conversionFactors)
                {
                    units.Add(type, new ConversionFactorUnit<TEnum>(this, type, conversionFactor));
                }

                _units = units;
            }

            return _units;
        }

        /// <summary>
        /// Used to retrieve the conversion factors for this quantity. 
        /// This method is called once during the objects lifetime, when the units are requested for the first time.
        /// </summary>
        /// <returns>The conversion factors for this quantity.</returns>
        protected abstract IEnumerable<(TEnum type, double conversionFactor)> GetConversionFactors();
    }
}