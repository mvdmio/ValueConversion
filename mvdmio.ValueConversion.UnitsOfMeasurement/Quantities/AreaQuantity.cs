using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// In geometry, the area can be defined as the space occupied by a flat shape or the surface of an object. 
    /// The area of a figure is the number of unit squares that cover the surface of a closed figure. 
    /// Area is measured in square units such as square centimteres, square feet, square inches, etc.
    /// </summary>
    public sealed class AreaQuantity : ConversionFactorQuantityBase<AreaType>
    {
        internal AreaQuantity()
            : base(QuantityType.Area, AreaType.SquareMeter)
        {
            
        }

        /// <inheritdoc/>     
        protected override IEnumerable<(AreaType type, double conversionFactor)> GetConversionFactors()
        {
            var meter = Quantity.Distance.CreateValue(1, DistanceType.Meter);

            return new[] {
                //Standard Unit
                (AreaType.SquareMeter, 1),
                
                //Metric
                (AreaType.SquareCentimeter, 0.0001),
                (AreaType.SquareDecimeter, 0.01),
                (AreaType.Hectare, 10000),
                (AreaType.SquareKilometer, 1000000),
                
                //Imperial
                (AreaType.Acre, 4046.8564224),
                (AreaType.SquareFoot, 0.09290304),
                (AreaType.SquareInch, 0.00064516),
                (AreaType.SquareMile, 2589988.11),
                (AreaType.SquareYard, 0.83612736)
            };
        }
    }
}
