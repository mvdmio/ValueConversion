using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests;

[TestClass]
public class QuantityTest
{
   [AssemblyInitialize]
   public static void SetupAssembly(TestContext _)
   {
      Quantity.Setup.WithUnitsOfMeasurement();
   }

   [TestMethod]
   public void OfIdentifier_ShouldSupportAllQuantityIdentifiers()
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
   public void Rate_ShouldSupportAllPossibleRatios()
   {
      foreach (var numeratorType in Quantity.GetAll())
      {
         foreach (var denominatorType in Quantity.GetAll())
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
      foreach (var numeratorType in Quantity.GetAll())
      {
         foreach (var denominatorType in Quantity.GetAll())
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
            ("(Energy/Area)/Temperature", Quantity.Rate(Quantity.Rate("Energy", "Area").Identifier, "Temperature")),
            ("Energy/(Area/Temperature)", Quantity.Rate("Energy", Quantity.Rate("Area", "Temperature").Identifier)),
            ("(Energy/Area)/(Area/Temperature)", Quantity.Rate(Quantity.Rate("Energy", "Area"), Quantity.Rate("Area", "Temperature"))),
            ("(Energy*Area)*Temperature", Quantity.Product(Quantity.Product("Energy", "Area").Identifier, "Temperature")),
            ("Energy*(Area*Temperature)", Quantity.Product("Energy", Quantity.Product("Area", "Temperature").Identifier)),
            ("(Energy*Area)*(Area*Temperature)", Quantity.Product(Quantity.Product("Energy", "Area"), Quantity.Product("Area", "Temperature"))),
            ("(Energy*Area)/(Area*Temperature)", Quantity.Rate(Quantity.Product("Energy", "Area"), Quantity.Product("Area", "Temperature"))),
            ("((Energy*Area)/Temperature)/Area", Quantity.Rate(Quantity.Rate(Quantity.Product("Energy", "Area").Identifier, "Temperature").Identifier, "Area"))
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
}