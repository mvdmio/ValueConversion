using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    /// <summary>
    /// Base class for all quantities that use a conversion factor to convert from and to standard unit.
    /// </summary>
    public abstract class ConversionFactorQuantityBase : QuantityBase
    {
        private readonly object _lockObject = new();
        private IDictionary<string, IUnit>? _units;

        /// <summary>
        /// Initializes a new object for this type.
        /// </summary>
        /// <param name="identifier">The identifier for this quantity.</param>
        /// <param name="standardUnitIdentifier">The unit enum value for the standard unit of this quantity.</param>
        protected ConversionFactorQuantityBase(string identifier, string standardUnitIdentifier) 
            : base(identifier, standardUnitIdentifier)
        {
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<IUnit> GetUnits()
        {
            if (_units != null)
                return _units.Values;

            lock (_lockObject)
            {
                if (_units != null)
                    return _units.Values;

                var conversionFactors = GetConversionFactors();

                var units = new Dictionary<string, IUnit>();
                foreach (var (type, conversionFactor) in conversionFactors)
                {
                    units.Add(type, new ConversionFactorUnit(this, type, conversionFactor));
                }

                _units = units;
            }

            return _units.Values;
        }

        /// <summary>
        /// Used to retrieve the conversion factors for this quantity. 
        /// This method is called once during the objects lifetime, when the units are requested for the first time.
        /// </summary>
        /// <returns>The conversion factors for this quantity.</returns>
        protected abstract IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors();
    }
}