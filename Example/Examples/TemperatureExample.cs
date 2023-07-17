using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

namespace Example.Examples;

public static class TemperatureExample
{
    public static void CelsiusToFahrenheit()
    {
        var temperatureInCelsius = new QuantityValue(10, Temperature.DegreeCelsius);         // 10 °C
        var temperatureInFahrenheit = temperatureInCelsius.As(Temperature.DegreeFahrenheit); // 50 °F

        var formattedCelsius = temperatureInCelsius.GetFormattedValue(decimalPoints: 2);
        var formattedFahrenheit = temperatureInFahrenheit.GetFormattedValue(decimalPoints: 2);
        Console.WriteLine($@"{formattedCelsius} = {formattedFahrenheit}"); 
    }

    public static void FahrenheitToKelvin()
    {
        var temperatureInFahrenheit = new QuantityValue(93, Temperature.DegreeCelsius); // 93 °F
        var temperatureInKelvin = temperatureInFahrenheit.As(Temperature.Kelvin);       // 366.15 K

        var formattedFahrenheit = temperatureInFahrenheit.GetFormattedValue(decimalPoints: 2);
        var formattedKelvin = temperatureInKelvin.GetFormattedValue(decimalPoints: 2);
        Console.WriteLine($@"{formattedFahrenheit} = {formattedKelvin}"); 
    }
}