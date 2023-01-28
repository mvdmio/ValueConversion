using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Products
{
    /// <summary>
    /// ECVolume is an approximation of the amount of fertilizer distributed in a body of water.
    /// It is calculated by multiplying the average EC value of the irrigation cycle by the amount of water given in the irrigation cycle.
    /// </summary>
    public class EcVolumeQuantity : ProductCombinedQuantity
    {
        internal EcVolumeQuantity()
            : base(QuantityType.EcVolume, Quantity.ElectricConductivity, Quantity.Volume)
        {
        }
    }
}
