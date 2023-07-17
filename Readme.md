# mvdmio.ValueConversion
mvdmio.ValueConversion can be used to create values for a specific unit, and convert those values to another unit of the same quantity at run-time.
Based on examples of [UnitsNet](https://github.com/angularsen/UnitsNet).

## Base package
This package contains the entry point for working with values of a given unit or quantity. Make sure to include the child packages with the specific types you need for your project.

The child packages are:
- `mvdmio.ValueConversion.Currency`
- `mvdmio.ValueConversion.UnitsOfMeasurement`

## Currency
The Currency package contains Quantity definitions for Currency.

The following currency units are defined:
- `UnitedStatesDollar`
- `Euro`
- `MexicanPeso`
- `CanadianDollar`

## Units of Measurement
The UnitsOfMeasurement package contains Quantity definitions for a wide range of [SI quantities](https://en.wikipedia.org/wiki/International_System_of_Units).

The following UnitsOfMeasurement quantities are defined:
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
For all examples, see the Example project in this repository.

## Temperature: Celsius to Fahrenheit.
``` csharp
var temperatureInCelsius = new QuantityValue(10, Temperature.DegreeCelsius);         // 10 °C
var temperatureInFahrenheit = temperatureInCelsius.As(Temperature.DegreeFahrenheit); // 50 °F

var formattedCelsius = temperatureInCelsius.GetFormattedValue(decimalPoints: 2);
var formattedFahrenheit = temperatureInFahrenheit.GetFormattedValue(decimalPoints: 2);
Console.WriteLine($@"{formattedCelsius} = {formattedFahrenheit}"); 
```

## Temperature: Fahrenheit to Kelvin
``` csharp
var temperatureInFahrenheit = new QuantityValue(93, Temperature.DegreeCelsius); // 93 °F
var temperatureInKelvin = temperatureInFahrenheit.As(Temperature.Kelvin);       // 366.15 K

var formattedFahrenheit = temperatureInFahrenheit.GetFormattedValue(decimalPoints: 2);
var formattedKelvin = temperatureInKelvin.GetFormattedValue(decimalPoints: 2);
Console.WriteLine($@"{formattedFahrenheit} = {formattedKelvin}"); 
```

## Distance: Meters to Yards
``` csharp
var distanceInMeters = new QuantityValue(10, Distance.Meter); // 10 meter
var distanceInYards = distanceInMeters.As(Distance.Yard);     // 10.94 yd
 
var formattedMeters = distanceInMeters.GetFormattedValue(decimalPoints: 2);
var formattedYards = distanceInYards.GetFormattedValue(decimalPoints: 2);
Console.WriteLine($@"{formattedMeters} = {formattedYards}"); 
```

## Distance: Kilometers to Miles
``` csharp
var distanceInMeters = new QuantityValue(100, Distance.Kilometer); // 100 km
var distanceInMiles = distanceInMeters.As(Distance.Mile);          // 62.14 mi

var formattedMeters = distanceInMeters.GetFormattedValue(decimalPoints: 2);
var formattedMiles = distanceInMiles.GetFormattedValue(decimalPoints: 2);
Console.WriteLine($@"{formattedMeters} = {formattedMiles}");
```