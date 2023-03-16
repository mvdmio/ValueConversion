# mvdmio.ValueConversion
mvdmio.ValueConversion can be used to create values for a specific unit, and convert those values to another unit of the same quantity at run-time.
Based on examples of [UnitsNet](https://github.com/angularsen/UnitsNet).

## Base package
This package contains the entry point for working with values of a given unit or quantity. Make sure to include the child packages with the specific types you need for your project.

Currently, the child packages are:
- `mvdmio.ValueConversion.Currency`
- `mvdmio.ValueConversion.UnitsOfMeasurement`

## Currency
The Currency package contains Quantity definitions for Currency.

Currently, the following currency units are defined:
- `UnitedStatesDollar`
- `Euro`
- `MexicanPeso`
- `CanadianDollar`

## Units of Measurement
The UnitsOfMeasurement package contains Quantity definitions for a wide range of [SI quantities](https://en.wikipedia.org/wiki/International_System_of_Units).

Currently, the following UnitsOfMeasurement quantites are defined:
- `Angle` (e.g. Degree or Radian)
- `Area` (e.g. SquareMeter, Hectare, or Acre)
- `Distance` (e.g. Meter, Kilometer, or Inch)
- `Duration` (e.g. Second, Day, or Decade)
- `ElectricConductance` (e.g. Siemens or Millisiemens)
- `Energy` (e.g. Joule, Calorie, or KilowattHour)
- `Mass` (e.g. Kilogram, Tonne, or Ounce)
- `pH`
- `Power` (e.g. Watt, MetricHorsePower, or Kilowatt)
- `Pressure` (e.g. Pascal, Bar, or PoundForcePerSquareInch)
- `Ratio` (e.g. Percent or PartsPerMillion)
- `Substance` (e.g. Mole or Micromole)
- `Temperature` (e.g. DegreeCelsius, DegreeFahrenheit, or Kelvin)
- `Volume` (e.g. CubicMeter, Liter, or CubicInch)

As well as a couple of pre-defined (named) combined quantities:
- `ElectricConductivity` (ElectricConductance / Distance)
- `Irradiance` (Power / Area)
- `Velocity` (Distance / Duration)

# Usage Examples

``` csharp
// Retrieve the 'Area' quantity
var areaQuantity = Quantity.Known.Area;

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
var euroPerSquareMeterUnit = currencyPerArea.GetUnit(Unit.OfCurrency("Euro"), squareMetersUnit);
var euroPerSquareMeterValue = usdPerSquareMeterValue.As(euroPerSquareMeterUnit);
```