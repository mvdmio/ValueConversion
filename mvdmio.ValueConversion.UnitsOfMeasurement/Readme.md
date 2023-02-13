# mvdmsoftware.UnitsOfMeasurement
mvdmsoftware.UnitsOfMeasurement can be used to create values for a specific unit, and convert those values to another unit of the same quantity at run-time.
Based on examples of [UnitsNet](https://github.com/angularsen/UnitsNet).

## Examples

``` csharp
// Retrieve the 'Area' quantity
var areaQuantity = "Area";

// Retrieve a 'square meters' unit
var squareMetersUnit = areaQuantity.GetUnit(AreaType.SquareMeters);

// Retrieve the 'Currency' quantity
var currencyQuantity = Quantity.Currency;

// Create a ratio combined quantity between 'Currency' and 'Area'
var currencyPerAreaQuantity = Quantity.Rate(currencyQuantity, areaQuantity);

// Retrieve the 'USD' unit for currency
var usdUnit = Unit.OfCurrency(CurrencyType.UnitedStatesDollar);

// Retrieve the '$/m2' unit for CurrencyPerArea
var usdPerSquareMeterUnit = currencyPerAreaQuantity.GetUnit(usdUnit, squareMetersUnit);

// Create a value of 10 $/m2
var usdPerSquareMeterValue = currencyPerAreaQuantity.CreateValue(DateTime.Now, 10, usdPerSquareMeterUnit);

// Convert to Euros per square meter
var euroPerSquareMeterUnit = currencyPerArea.GetUnit(Unit.OfCurrency(CurrencyType.Euro), squareMetersUnit);
var euroPerSquareMeterValue = usdPerSquareMeterValue.As(euroPerSquareMeterUnit);
```