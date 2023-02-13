using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// In geometry, the area can be defined as the space occupied by a flat shape or the surface of an object. 
/// The area of a figure is the number of unit squares that cover the surface of a closed figure. 
/// Area is measured in square units such as square centimteres, square feet, square inches, etc.
/// </summary>
public sealed class AreaQuantity : ConversionFactorQuantityBase
{
    internal AreaQuantity()
        : base("Area", "SquareMeter")
    {
            
    }

    /// <inheritdoc/>     
    protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
    {
        return new[] {
            //Standard Unit
            ("SquareMeter", 1),
                
            //Metric
            ("SquareCentimeter", 0.0001),
            ("SquareDecimeter", 0.01),
            ("Hectare", 10000),
            ("SquareKilometer", 1000000),
                
            //Imperial
            ("Acre", 4046.8564224),
            ("SquareFoot", 0.09290304),
            ("SquareInch", 0.00064516),
            ("SquareMile", 2589988.11),
            ("SquareYard", 0.83612736)
        };
    }
}