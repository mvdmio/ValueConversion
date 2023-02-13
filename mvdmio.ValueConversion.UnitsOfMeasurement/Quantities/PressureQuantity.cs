using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Pressure units class
/// </summary>
public class PressureQuantity : ConversionFactorQuantityBase
{
    internal PressureQuantity() 
        : base("Pressure", "Pascal")
    {
    }

    /// <inheritdoc />
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("Pascal", 1),
                
            //Metric
            ("Atmosphere", 101325),
            ("Bar", 1e+5),
            ("Centibar", 1000),
            ("Decibar", 10000),
            ("Kilobar", 1e+8),
            ("Megabar", 1e+11),
            ("Millibar", 100),
            ("Microbar", 0.1),
            ("Decapascal", 10),
            ("Gigapascal", 1e+9),
            ("Hectopascal", 100),
            ("Kilopascal", 1000),
            ("Megapascal", 1e+6),
                
            //Imperial
            ("PoundForcePerSquareInch", 689475729),
            ("PoundForcePerSquareFoot", 47880259)
        };
    }
}