using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Formatting
{
    [TestClass]
    public class UnitFormattingTest
    {
        [TestMethod]
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
                        var symbol = unit.GetSymbol(CultureInfo.InvariantCulture);

                        if (symbol == null)
                        {
                            Console.WriteLine($"Symbol for unit {unit.Identifier} is not explicitly defined");
                            missingFormats.Add(unit.Identifier);
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine($"No format was defined for {unit.Identifier}");
                        missingFormats.Add(unit.Identifier);
                    }
                }
            }

            if(missingFormats.Any())
                Assert.Fail($"Missing {missingFormats.Count} formats");
        }

        [TestMethod]
        public void AllUnitsShouldBeFormattable()
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
                        var formattedValue = unit.GetFormattedValue(value: 1, CultureInfo.InvariantCulture);

                        if (string.IsNullOrWhiteSpace(formattedValue))
                        {
                            Console.WriteLine($"Formatted Value for unit {unit.Identifier} is empty");
                            missingFormats.Add(unit.Identifier);
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine($"No format was defined for {unit.Identifier}");
                        missingFormats.Add(unit.Identifier);
                    }
                }
            }

            if(missingFormats.Any())
                Assert.Fail($"Missing {missingFormats.Count} formats");
        }
    }
}
