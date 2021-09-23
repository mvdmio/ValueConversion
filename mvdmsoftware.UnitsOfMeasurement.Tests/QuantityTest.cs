﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.UnitsOfMeasurement.Enums;
using Ridder.UnitsOfMeasurement.Interfaces;

namespace Ridder.UnitsOfMeasurement.Tests
{
    [TestClass]
    public class QuantityTest
    {
        [TestMethod]
        public void OfEnum_ShouldSupportAllQuantityTypes()
        {
            foreach (QuantityType type in Enum.GetValues(typeof(QuantityType)))
            {
                try
                {
                    var quantity = Quantity.Of(type);
                    Assert.IsNotNull(quantity, $"No quantity returned for type {type}");

                    var expectedIdentifier = GetExpectedIdentifier(type);

                    Assert.AreEqual(expectedIdentifier, quantity.Identifier, $"Returned quantity type {quantity.Identifier} does not mach requested quantity type {expectedIdentifier}");
                }
                catch (KeyNotFoundException)
                {
                    Assert.Fail($"No quantity found for type {type}");
                }
            }
        }

        [TestMethod]
        public void OfIdentifier_ShouldSupportAllQuantitiyIdentifiers()
        {
            var allQuantities = Quantity.GetAll();

            foreach (var quantity in allQuantities)
            {
                try
                {
                    var retrievedQuantity = Quantity.Of(quantity.Identifier);
                    Assert.AreEqual(quantity.Identifier, retrievedQuantity.Identifier);
                }
                catch (KeyNotFoundException)
                {
                    Assert.Fail($"No quantity found for identifier {quantity.Identifier}");
                }
            }
        }

        [TestMethod]
        public void OfIdentifier_ShouldSupportAllNamedQuantities()
        {
            foreach (QuantityType quantityType in Enum.GetValues(typeof(QuantityType)))
            {
                var identifier = quantityType.ToString();
                var expectedIdentifier = GetExpectedIdentifier(quantityType);

                try
                {
                    var retrievedQuantity = Quantity.Of(identifier);
                    Assert.AreEqual(expectedIdentifier, retrievedQuantity.Identifier);
                }
                catch (KeyNotFoundException)
                {
                    Assert.Fail($"No quantity found for identifier {identifier}");
                }
            }
        }

        [TestMethod]
        public void Rate_ShouldSupportAllPossibleRatios()
        {
            foreach (var numeratorType in Quantity.GetBaseQuantities())
            {
                foreach (var denominatorType in Quantity.GetBaseQuantities())
                {
                    IQuantity typedQuantity;

                    try
                    {
                        typedQuantity = Quantity.Rate(numeratorType, denominatorType);
                        
                        Assert.IsNotNull(typedQuantity, $"No ratio quantity returned for type {numeratorType.Identifier}/{denominatorType.Identifier}");
                        Assert.AreEqual($"{numeratorType.Identifier}/{denominatorType.Identifier}", typedQuantity.Identifier, $"Returned quantity type {typedQuantity.Identifier} does not mach requested quantity type {numeratorType.Identifier}/{denominatorType.Identifier}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Assert.Fail($"No quantity found for type {numeratorType.Identifier}/{denominatorType.Identifier}");
                        return;
                    }

                    try
                    {
                        var identifiedQuantity = Quantity.Of(typedQuantity.Identifier);
                        Assert.IsNotNull(identifiedQuantity, $"No ratio quantity returned for identifier {typedQuantity.Identifier}");
                        Assert.AreEqual($"{numeratorType.Identifier}/{denominatorType.Identifier}", typedQuantity.Identifier, $"Returned quantity type {typedQuantity.Identifier} does not mach requested quantity type {numeratorType.Identifier}/{denominatorType.Identifier}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Assert.Fail($"No quantity found for identifier {typedQuantity.Identifier}");
                    }
                }
            }
        }

        [TestMethod]
        public void Product_ShouldSupportAllPossibleProducts()
        {
            foreach (var numeratorType in Quantity.GetBaseQuantities())
            {
                foreach (var denominatorType in Quantity.GetBaseQuantities())
                {
                    IQuantity typedQuantity;

                    try
                    {
                        typedQuantity = Quantity.Product(numeratorType, denominatorType);
                        
                        Assert.IsNotNull(typedQuantity, $"No ratio quantity returned for type {numeratorType.Identifier}*{denominatorType.Identifier}");
                        Assert.AreEqual($"{numeratorType.Identifier}*{denominatorType.Identifier}", typedQuantity.Identifier, $"Returned quantity type {typedQuantity.Identifier} does not mach requested quantity type {numeratorType.Identifier}*{denominatorType.Identifier}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Assert.Fail($"No quantity found for type {numeratorType.Identifier}*{denominatorType.Identifier}");
                        return;
                    }

                    try
                    {
                        var identifiedQuantity = Quantity.Of(typedQuantity.Identifier);
                        Assert.IsNotNull(identifiedQuantity, $"No ratio quantity returned for identifier {typedQuantity.Identifier}");
                        Assert.AreEqual($"{numeratorType.Identifier}*{denominatorType.Identifier}", typedQuantity.Identifier, $"Returned quantity type {typedQuantity.Identifier} does not mach requested quantity type {numeratorType.Identifier}*{denominatorType.Identifier}");
                    }
                    catch (KeyNotFoundException)
                    {
                        Assert.Fail($"No quantity found for identifier {typedQuantity.Identifier}");
                    }
                }
            }
        }

        [TestMethod]
        public void Of_ShouldSupportCombinedQuantities()
        {
            var quantitiesToTest = new List<(string identifier, IQuantity quantity)> {
                ("(Energy/Area)/Temperature", Quantity.Rate(Quantity.Rate(Quantity.Energy, Quantity.Area), Quantity.Temperature)),
                ("Energy/(Area/Temperature)", Quantity.Rate(Quantity.Energy, Quantity.Rate(Quantity.Area, Quantity.Temperature))),
                ("(Energy/Area)/(Area/Temperature)", Quantity.Rate(Quantity.Rate(Quantity.Energy, Quantity.Area), Quantity.Rate(Quantity.Area, Quantity.Temperature))),
                ("(Energy*Area)*Temperature", Quantity.Product(Quantity.Product(Quantity.Energy, Quantity.Area), Quantity.Temperature)),
                ("Energy*(Area*Temperature)", Quantity.Product(Quantity.Energy, Quantity.Product(Quantity.Area, Quantity.Temperature))),
                ("(Energy*Area)*(Area*Temperature)", Quantity.Product(Quantity.Product(Quantity.Energy, Quantity.Area), Quantity.Product(Quantity.Area, Quantity.Temperature))),
                ("(Energy*Area)/(Area*Temperature)", Quantity.Rate(Quantity.Product(Quantity.Energy, Quantity.Area), Quantity.Product(Quantity.Area, Quantity.Temperature))),
                ("((Energy*Area)/Temperature)/Area", Quantity.Rate(Quantity.Rate(Quantity.Product(Quantity.Energy, Quantity.Area), Quantity.Temperature), Quantity.Area))
            };

            foreach (var (identifier, quantity) in quantitiesToTest)
            {
                var result = Quantity.Of(identifier);
                AssertEqualQuantity(quantity, result);
            }

            static void AssertEqualQuantity(IQuantity expected, IQuantity actual)
            {
                Assert.AreEqual(expected.Identifier, actual.Identifier);

                if (expected is ICombinedQuantity expectedCombinedQuantity)
                {
                    var actualCombinedQuantity = actual as ICombinedQuantity;

                    if (actualCombinedQuantity == null)
                        Assert.Fail($"Expected combined quantity, was {actual.GetType().Name}");

                    AssertEqualQuantity(expectedCombinedQuantity.NumeratorQuantity, actualCombinedQuantity.NumeratorQuantity);
                    AssertEqualQuantity(expectedCombinedQuantity.DenominatorQuantity, actualCombinedQuantity.DenominatorQuantity);
                }
            }
        }

        [DataTestMethod]
        [DataRow("Energy/(Area/Temperature)", QuantityType.Energy, QuantityType.Area, QuantityType.Temperature, DisplayName = "Radiation Temperature Ratio")]
        [DataRow("Volume/(Energy/Area)", QuantityType.Volume, QuantityType.Energy, QuantityType.Area, DisplayName = "Irrigation Volume Radiation Sum Ratio")]
        public void Rate_ShouldSupportMulticombinedQuantities(string expectedIdentifier, params QuantityType[] quantityTypes)
        {
            var result = Quantity.Rate(quantityTypes);
            Assert.AreEqual(expectedIdentifier, result.Identifier);
        }
        
        [DataTestMethod]
        [DataRow("Energy*(Area*Temperature)", QuantityType.Energy, QuantityType.Area, QuantityType.Temperature, DisplayName = "Random combination 1")]
        [DataRow("Volume*(Energy*Area)", QuantityType.Volume, QuantityType.Energy, QuantityType.Area, DisplayName = "Random combination 2")]
        public void Product_ShouldSupportMulticombinedQuantities(string expectedIdentifier, params QuantityType[] quantityTypes)
        {
            var result = Quantity.Product(quantityTypes);
            Assert.AreEqual(expectedIdentifier, result.Identifier);
        }
        
        [TestMethod]
        public void GetAll_ShouldReturnAllKnownQuantitiesAndCombinations()
        {
            var retrievedQuantities = Quantity.GetAll().ToList();

            var allValuesAreUnique = retrievedQuantities.Select(x => x.Identifier).Distinct().Count() == retrievedQuantities.Count;
            Assert.IsTrue(allValuesAreUnique, message: "There are duplicate values in the retrievedQuantities. This is not allowed.");

            foreach (QuantityType quantityType in Enum.GetValues(typeof(QuantityType)))
            {
                Assert.IsTrue(retrievedQuantities.Any(x => x.Identifier == quantityType.ToString()), $"Missing base- or named quantity {quantityType.ToString()}");
            }

            var allRates = Quantity.GetAllRates();
            
            foreach (var rate in allRates)
            {
                Assert.IsTrue(retrievedQuantities.Any(x => x.Identifier == rate.Identifier), $"Missing rate quantity {rate.Identifier}");
            }

            var allProducts = Quantity.GetAllProducts();
            foreach (var product in allProducts)
            {
                Assert.IsTrue(retrievedQuantities.Any(x => x.Identifier == product.Identifier), $"Missing product quantity {product.Identifier}");
            }
        }

        private static string GetExpectedIdentifier(QuantityType type)
        {
            string expectedIdentifier;

            switch (type)
            {
                case QuantityType.EcVolume:
                    expectedIdentifier = Quantity.EcVolume.Identifier;

                    break;
                case QuantityType.ElectricConductivity:
                    expectedIdentifier = Quantity.ElectricConductivity.Identifier;

                    break;
                case QuantityType.Irradiance:
                    expectedIdentifier = Quantity.Irradiance.Identifier;

                    break;
                case QuantityType.Velocity:
                    expectedIdentifier = Quantity.Velocity.Identifier;

                    break;
                default:
                    expectedIdentifier = type.ToString();

                    break;
            }

            return expectedIdentifier;
        }
    }
}