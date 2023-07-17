using System.Globalization;
using mvdmio.ValueConversion.Base;
using Xunit;
using Xunit.Abstractions;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Formatting;

public class UnitFormattingTest
{
   private readonly ITestOutputHelper _testOutput;

   public UnitFormattingTest(ITestOutputHelper testOutput)
   {
      _testOutput = testOutput;
   }

   [Fact]
    public void AllUnitsShouldHaveSymbols()
    {
        var allQuantities = Quantity.GetAll();

        var missingFormats = new List<string>();
        foreach (var quantity in allQuantities)
        {
            var units = quantity.GetUnits();

            foreach (var unit in units)
            {
                try
                {
                    _ = unit.GetSymbol(CultureInfo.InvariantCulture);
                }
                catch (KeyNotFoundException)
                {
                    _testOutput.WriteLine($"No format was defined for {unit.Identifier}");
                    missingFormats.Add(unit.Identifier);
                }
            }
        }

        if(missingFormats.Any())
            Assert.Fail($"Missing {missingFormats.Count} formats");
    }

    [Fact]
    public void AllUnitsShouldHaveDefinedFormat()
    {
        var allQuantities = Quantity.GetAll().ToArray();

        var missingFormats = new List<string>();
        foreach (var quantity in allQuantities)
        {
            var units = quantity.GetUnits();

            foreach (var unit in units)
            {
                try
                {
                    var formattedValue = unit.GetFormattedValue(value: 1, CultureInfo.InvariantCulture, 2);

                    if (!string.IsNullOrWhiteSpace(formattedValue))
                       continue;

                    _testOutput.WriteLine($"Formatted Value for unit {unit.Identifier} is empty");
                    missingFormats.Add(unit.Identifier);
                }
                catch (KeyNotFoundException)
                {
                    _testOutput.WriteLine($"No format was defined for {unit.Identifier}");
                    missingFormats.Add(unit.Identifier);
                }
            }
        }

        if(missingFormats.Any())
            Assert.Fail($"Missing {missingFormats.Count} formats");
    }
}