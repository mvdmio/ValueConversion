using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;
using mvdmsoftware.UnitsOfMeasurement.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Quantities.Products;
using mvdmsoftware.UnitsOfMeasurement.Quantities.Rates;

namespace mvdmsoftware.UnitsOfMeasurement
{
    public static class Quantity
    {
        // DO NOT use auto properties here, IGNORE IDE0032 code analysis warning.
        private static readonly AngleQuantity _angle = new AngleQuantity();
        private static readonly AreaQuantity _area = new AreaQuantity();
        private static readonly CurrencyQuantity _currency = new CurrencyQuantity();
        private static readonly DistanceQuantity _distance = new DistanceQuantity();
        private static readonly DurationQuantity _duration = new DurationQuantity();
        private static readonly ElectricConductanceQuantity _electricConductance = new ElectricConductanceQuantity();
        private static readonly EnergyQuantity _energy = new EnergyQuantity();
        private static readonly MassQuantity _mass = new MassQuantity();
        private static readonly PowerQuantity _power = new PowerQuantity();
        private static readonly RatioQuantity _ratio = new RatioQuantity();
        private static readonly SubstanceQuantity _substance = new SubstanceQuantity();
        private static readonly TemperatureQuantity _temperature = new TemperatureQuantity();
        private static readonly VolumeQuantity _volume = new VolumeQuantity();

        private static readonly ScalarQuantity _scalar = new ScalarQuantity();
        private static readonly ElectricConductivityQuantity _electricConductivity = new ElectricConductivityQuantity();
        private static readonly EcVolumeQuantity _ecVolume = new EcVolumeQuantity();
        private static readonly IrradianceQuantity _irradiance = new IrradianceQuantity();
        private static readonly PPFDQuantity _ppfd = new PPFDQuantity();
        private static readonly VelocityQuantity _velocity = new VelocityQuantity();
        private static readonly PressureQuantity _pressure = new PressureQuantity();
        private static readonly PHQuantity _ph = new PHQuantity();
        
        private static readonly IDictionary<QuantityType, IQuantity> _quantities = new Dictionary<QuantityType, IQuantity> {
            // Do NOT add named combined quantities to this list. See the Of(QuantityType type) method.
            { QuantityType.Angle, _angle },
            { QuantityType.Area, _area },
            { QuantityType.Currency, _currency },
            { QuantityType.Distance, _distance },
            { QuantityType.Duration, _duration },
            { QuantityType.ElectricConductance, _electricConductance },
            { QuantityType.Energy, _energy },
            { QuantityType.Mass, _mass },
            { QuantityType.Power, _power },
            { QuantityType.Ratio, _ratio },
            { QuantityType.Substance, _substance },
            { QuantityType.Temperature, _temperature },
            { QuantityType.Volume, _volume },
            { QuantityType.Pressure, _pressure},

            // Special Quantities and named combinations
            { QuantityType.Scalar, _scalar },
            { QuantityType.pH, _ph },
            { QuantityType.EcVolume, _ecVolume },
            { QuantityType.ElectricConductivity, _electricConductivity },
            { QuantityType.Irradiance, _irradiance },
            { QuantityType.Velocity, _velocity },
            { QuantityType.PPFD, _ppfd }
        };

        private static readonly IEnumerable<ICombinedQuantity> _allPossibleRatios = (from numeratorQuantity in _quantities.Values from denominatorQuantity in _quantities.Values select Rate(numeratorQuantity, denominatorQuantity)).ToList();
        private static readonly IEnumerable<ICombinedQuantity> _allPossibleProducts = (from numeratorQuantity in _quantities.Values from denominatorQuantity in _quantities.Values select Product(numeratorQuantity, denominatorQuantity)).ToList();
        private static readonly IEnumerable<IQuantity> _allKnownQuantities = Enumerable.Empty<IQuantity>().Concat(_quantities.Values).Concat(_allPossibleRatios).Concat(_allPossibleProducts).ToList();

        public static AngleQuantity Angle => _angle; 
        public static AreaQuantity Area => _area;
        public static CurrencyQuantity Currency => _currency;
        public static DistanceQuantity Distance => _distance;
        public static DurationQuantity Duration => _duration;
        public static EcVolumeQuantity EcVolume => _ecVolume;
        public static ElectricConductanceQuantity ElectricConductance => _electricConductance;
        public static ElectricConductivityQuantity ElectricConductivity => _electricConductivity;
        public static EnergyQuantity Energy => _energy;
        public static IrradianceQuantity Irradiance => _irradiance;
        public static MassQuantity Mass => _mass;
        public static PPFDQuantity PPFD => _ppfd;
        public static PowerQuantity Power => _power;
        public static RatioQuantity Ratio => _ratio;
        public static ScalarQuantity Scalar => _scalar;
        public static SubstanceQuantity Substance => _substance;
        public static TemperatureQuantity Temperature => _temperature;
        public static VelocityQuantity Velocity => _velocity;
        public static VolumeQuantity Volume => _volume;

        public static PressureQuantity Pressure => _pressure;

        public static PHQuantity PH => _ph;
        
        public static IEnumerable<IQuantity> GetAll()
        {
            return _allKnownQuantities;
        }

        public static IEnumerable<IQuantity> GetAllRates()
        {
            return _allPossibleRatios;
        }

        public static IEnumerable<IQuantity> GetAllProducts()
        {
            return _allPossibleProducts;
        }

        public static IEnumerable<IQuantity> GetBaseQuantities()
        {
            return _quantities.Values;
        }

        public static IQuantity Of(string identifier)
        {
            Guard.Against.NullOrWhiteSpace(identifier, nameof(identifier));

            var matches = Regex.Match(identifier, @"(.*)([\/*])(?![^(]*\))(.*)");

            if (matches.Success)
            {
                var numeratorString = matches.Groups[1].Value.Trim('(', ')');
                var operatorCharacter = matches.Groups[2].Value;
                var denominatorString = matches.Groups[3].Value.Trim('(', ')');

                if (operatorCharacter == "/")
                    return Rate(Of(numeratorString), Of(denominatorString));
                    
                if(operatorCharacter == "*")
                    return Product(Of(numeratorString), Of(denominatorString));

                throw new KeyNotFoundException($"Could not find quantity with identifier {identifier}.");
            }

            // At this point, the identifier must be a base-quantity, so check the base quantities for a match
            var quantity = _quantities.Values.SingleOrDefault(x => x.Identifier.Equals(identifier, StringComparison.InvariantCultureIgnoreCase));

            if (quantity == null)
                throw new KeyNotFoundException($"Could not find quantity with identifier {identifier}.");

            return quantity;
        }

        public static IQuantity Of(QuantityType quantityType)
        {
            if (!_quantities.TryGetValue(quantityType, out var quantity))
                throw new KeyNotFoundException($"Could not find quantity with type {quantityType}.");

            return quantity;    
        }

        public static RateCombinedQuantity Rate(QuantityType numeratorType, QuantityType denominatorType)
        {
            var numeratorQuantity = Of(numeratorType);
            var denominatorQuantity = Of(denominatorType);

            return Rate(numeratorQuantity, denominatorQuantity);
        }

        public static RateCombinedQuantity Rate(params QuantityType[] types)
        {
            Guard.Against.NullOrEmpty(types, nameof(types));

            var quantities = types.Select(Of).ToArray();
            return Rate(quantities);
        }

        public static RateCombinedQuantity Rate(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
        {
            Guard.Against.Null(numeratorQuantity, nameof(numeratorQuantity));
            Guard.Against.Null(denominatorQuantity, nameof(denominatorQuantity));

            return new RateCombinedQuantity(numeratorQuantity, denominatorQuantity);
        }

        public static RateCombinedQuantity Rate(params IQuantity[] quantities)
        {
            Guard.Against.NullOrEmpty(quantities, nameof(quantities));

            if(quantities.Length < 2)
                throw new NotSupportedException("A rate must have at least two quantities");

            if(quantities.Length == 2)
                return Rate(quantities[0], quantities[1]);
            
            return Rate(quantities[0], Rate(quantities.Skip(1).ToArray()));
        }

        public static ProductCombinedQuantity Product(QuantityType numeratorType, QuantityType denominatorType)
        {
            var numeratorQuantity = Of(numeratorType);
            var denominatorQuantity = Of(denominatorType);

            return Product(numeratorQuantity, denominatorQuantity);
        }

        public static ProductCombinedQuantity Product(params QuantityType[] quantityTypes)
        {
            Guard.Against.NullOrEmpty(quantityTypes, nameof(quantityTypes));

            var quantities = quantityTypes.Select(x => Of(x)).ToArray();
            return Product(quantities);
        }

        public static ProductCombinedQuantity Product(IQuantity numeratorQuantity, IQuantity denominatorQuantity)
        {
            Guard.Against.Null(numeratorQuantity, nameof(numeratorQuantity));
            Guard.Against.Null(denominatorQuantity, nameof(denominatorQuantity));

            return new ProductCombinedQuantity(numeratorQuantity, denominatorQuantity);
        }

        public static ProductCombinedQuantity Product(params IQuantity[] quantities)
        {
            Guard.Against.Null(quantities, nameof(quantities));

            if(quantities.Length < 2)
                throw new NotSupportedException("A product must have at least two quantities");

            if(quantities.Length == 2)
                return Product(quantities[0], quantities[1]);
            
            return Product(quantities[0], Product(quantities.Skip(1).ToArray()));
        }
    }
}