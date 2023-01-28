using System.Collections.Generic;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities
{
    /// <summary>
    /// Pressure units class
    /// </summary>
    public class PressureQuantity : ConversionFactorQuantityBase<PressureType>
    {
        internal PressureQuantity() : base(QuantityType.Pressure, PressureType.Pascal)
        {
        }

        /// <inheritdoc />
        protected override IEnumerable<(PressureType type, double conversionFactor)> GetConversionFactors()
        {
            return new[] {
                //Standard Unit
                (PressureType.Pascal, 1),
                
                //Metric
                (PressureType.Atmosphere, 101325),
                (PressureType.Bar, 1e+5),
                (PressureType.Centibar, 1000),
                (PressureType.Decibar, 10000),
                (PressureType.Kilobar, 1e+8),
                (PressureType.Megabar, 1e+11),
                (PressureType.Millibar, 100),
                (PressureType.Microbar, 0.1),
                (PressureType.Decapascal, 10),
                (PressureType.Gigapascal, 1e+9),
                (PressureType.Hectopascal, 100),
                (PressureType.Kilopascal, 1000),
                (PressureType.Megapascal, 1e+6),
                
                //Imperial
                (PressureType.PoundForcePerSquareInch, 689475729),
                (PressureType.PoundForcePerSquareFoot, 47880259)
            };
        }
    }
}
