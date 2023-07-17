using System.Reflection;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests;

public class QuantityTest
{
   public QuantityTest()
   {
      Quantity.Setup.WithUnitsOfMeasurement();
   }

   [Fact]
   public void OfIdentifier_ShouldSupportAllQuantityIdentifiers()
   {
      var allQuantities = Quantity.GetAll();

      foreach (var quantity in allQuantities)
      {
         try
         {
            var retrievedQuantity = Quantity.Of(quantity.Identifier);
            Assert.Equal(quantity.Identifier, retrievedQuantity.Identifier);
            
         }
         catch (KeyNotFoundException)
         {
            Assert.Fail($"No quantity found for identifier {quantity.Identifier}");
         }
      }
   }

   [Fact]
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

               Assert.NotNull(typedQuantity);
               Assert.Equal($"{numeratorType.Identifier}/{denominatorType.Identifier}", typedQuantity.Identifier);
            }
            catch (KeyNotFoundException)
            {
               Assert.Fail($"No quantity found for type {numeratorType.Identifier}/{denominatorType.Identifier}");
               return;
            }

            try
            {
               var identifiedQuantity = Quantity.Of(typedQuantity.Identifier);
               Assert.NotNull(identifiedQuantity);
               Assert.Equal($"{numeratorType.Identifier}/{denominatorType.Identifier}", typedQuantity.Identifier);
            }
            catch (KeyNotFoundException)
            {
               Assert.Fail($"No quantity found for identifier {typedQuantity.Identifier}");
            }
         }
      }
   }

   [Fact]
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

               Assert.NotNull(typedQuantity);
               Assert.Equal($"{numeratorType.Identifier}*{denominatorType.Identifier}", typedQuantity.Identifier);
            }
            catch (KeyNotFoundException)
            {
               Assert.Fail($"No quantity found for type {numeratorType.Identifier}*{denominatorType.Identifier}");
               return;
            }

            try
            {
               var identifiedQuantity = Quantity.Of(typedQuantity.Identifier);
               Assert.NotNull(identifiedQuantity);
               Assert.Equal($"{numeratorType.Identifier}*{denominatorType.Identifier}", typedQuantity.Identifier);
            }
            catch (KeyNotFoundException)
            {
               Assert.Fail($"No quantity found for identifier {typedQuantity.Identifier}");
            }
         }
      }
   }

   [Fact]
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
         Assert.Equal(expected.Identifier, actual.Identifier);

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

   [Fact]
   public void AllQuantitiesShouldHaveTheirKnownUnitsDefinedAsStaticProperties()
   {
      var baseQuantities = Quantity.GetAll().Where(x => !x.GetType().IsAssignableTo(typeof(ICombinedQuantity)));
      var missingProperties = new List<string>();
      var misconfiguredProperties = new List<string>();

      foreach (var quantity in baseQuantities)
      {
         var quantityType = quantity.GetType();
         var knownUnits = quantity.GetUnits();
         foreach (var unit in knownUnits)
         {
            var unitPropertyInfo = quantityType.GetProperty(unit.Identifier, BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static |BindingFlags.GetProperty);
            if (unitPropertyInfo is null)
            {
               missingProperties.Add($"Missing: unit {unit.Identifier} on quantity {quantity.Identifier}");
            }
            else
            {
               var returnedUnit = (IUnit)unitPropertyInfo.GetGetMethod()!.Invoke(quantity, null);
               if (returnedUnit == null)
                  misconfiguredProperties.Add($"Misconfigured: Property {unit.Identifier} on quantity {quantity.Identifier} returned null");
               else if (returnedUnit.Identifier != unit.Identifier)
                  misconfiguredProperties.Add($"Misconfigured: Property {unit.Identifier} on quantity {quantity.Identifier} returned unit {returnedUnit.Identifier}");
            }
         }
      }
      
      if (missingProperties.Count > 0)
         Assert.Fail($"Missing {missingProperties.Count} unit properties:\n\t{string.Join("\n\t", missingProperties)}");

      if(misconfiguredProperties.Count > 0)
         Assert.Fail($"Misconfigured {misconfiguredProperties.Count} unit properties:\n\t{string.Join("\n\t", misconfiguredProperties)}");

   }
}