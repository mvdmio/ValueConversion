using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using mvdmsoftware.UnitsOfMeasurement.Bases;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;

namespace mvdmsoftware.UnitsOfMeasurement
{
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
        /// Retrieve all known base units.
        /// </summary>
        /// <returns>All known base units.</returns>
        public static IEnumerable<IUnit> GetAllBaseUnits()
        {
            return Quantity.GetBaseQuantities().SelectMany(x => x.GetUnits());
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
            var unit = GetAllBaseUnits().SingleOrDefault(x => x.Identifier.Equals(unitIdentifier, StringComparison.InvariantCultureIgnoreCase));

            if (unit == null)
                throw new KeyNotFoundException($"Could not find unit for identifier ${unitIdentifier}");

            return unit;
        }

        public static IUnit<AngleType> OfAngle(AngleType angleType)
        {
            return Quantity.Angle.GetUnit(angleType);
        }

        public static IUnit<AreaType> OfArea(AreaType areaType)
        {
            return Quantity.Area.GetUnit(areaType);
        }

        public static IUnit<CurrencyType> OfCurrency(CurrencyType currencyType)
        {
            return Quantity.Currency.GetUnit(currencyType);
        }

        public static IUnit<DistanceType> OfDistance(DistanceType distanceType)
        {
            return Quantity.Distance.GetUnit(distanceType);
        }

        public static IUnit<DurationType> OfDuration(DurationType durationType)
        {
            return Quantity.Duration.GetUnit(durationType);
        }

        public static IUnit<ElectricConductanceType> OfElectricConductance(ElectricConductanceType electricConductanceType)
        {
            return Quantity.ElectricConductance.GetUnit(electricConductanceType);
        }

        public static IUnit<EnergyType> OfEnergy(EnergyType energyType)
        {
            return Quantity.Energy.GetUnit(energyType);
        }

        public static ICombinedUnit OfIrradiance(PowerType powerType, AreaType areaType)
        {
            var powerUnit = OfPower(powerType);
            var areaUnit = OfArea(areaType);

            return Quantity.Irradiance.GetUnit(powerUnit, areaUnit);
        }

        public static IUnit<MassType> OfMass(MassType massType)
        {
            return Quantity.Mass.GetUnit(massType);
        }

        public static IUnit<PowerType> OfPower(PowerType powerType)
        {
            return Quantity.Power.GetUnit(powerType);
        }

        public static IUnit<RatioType> OfRatio(RatioType ratioType)
        {
            return Quantity.Ratio.GetUnit(ratioType);
        }

        public static IUnit OfScalar()
        {
            return Quantity.Scalar.StandardUnit;
        }

        public static IUnit<TemperatureType> OfTemperature(TemperatureType temperatureType)
        {
            return Quantity.Temperature.GetUnit(temperatureType);
        }

        public static ICombinedUnit OfVelocity(DistanceType distance, DurationType duration)
        {
            var distanceUnit = OfDistance(distance);
            var durationUnit = OfDuration(duration);

            return Quantity.Velocity.GetUnit(distanceUnit, durationUnit);
        }

        public static IUnit<VolumeType> OfVolume(VolumeType volumeType)
        {
            return Quantity.Volume.GetUnit(volumeType);
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
}
