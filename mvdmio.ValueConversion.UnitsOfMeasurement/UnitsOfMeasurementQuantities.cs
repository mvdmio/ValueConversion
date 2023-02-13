using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Products;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates;

namespace mvdmio.ValueConversion.UnitsOfMeasurement;

/// <summary>
/// Extension class for providing easy access to Known Quantities on <see cref="KnownQuantities" />.
/// </summary>
public static class UnitsOfMeasurementKnownQuantities
{
    /// <inheritdoc cref="AngleQuantity" />
    public static AngleQuantity Angle(this KnownQuantities _)
    {
        return new AngleQuantity();
    }

    /// <inheritdoc cref="AreaQuantity" />
    public static AreaQuantity Area(this KnownQuantities _)
    {
        return new AreaQuantity();
    }
    
    /// <inheritdoc cref="DistanceQuantity" />
    public static DistanceQuantity Distance(this KnownQuantities _)
    {
        return new DistanceQuantity();
    }
    
    /// <inheritdoc cref="DurationQuantity" />
    public static DurationQuantity Duration(this KnownQuantities _)
    {
        return new DurationQuantity();
    }
    
    /// <inheritdoc cref="ElectricConductanceQuantity" />
    public static ElectricConductanceQuantity ElectricConductance(this KnownQuantities _)
    {
        return new ElectricConductanceQuantity();
    }
    
    /// <inheritdoc cref="ElectricConductivityQuantity" />
    public static ElectricConductivityQuantity ElectricConductivity(this KnownQuantities _)
    {
        return new ElectricConductivityQuantity();
    }
    
    /// <inheritdoc cref="MassQuantity" />
    public static MassQuantity Mass(this KnownQuantities _)
    {
        return new MassQuantity();
    }
    
    /// <inheritdoc cref="PressureQuantity" />
    public static PressureQuantity Pressure(this KnownQuantities _)
    {
        return new PressureQuantity();
    }
    
    /// <inheritdoc cref="TemperatureQuantity" />
    public static TemperatureQuantity Temperature(this KnownQuantities _)
    {
        return new TemperatureQuantity();
    }
    
    /// <inheritdoc cref="VolumeQuantity" />
    public static VolumeQuantity Volume(this KnownQuantities _)
    {
        return new VolumeQuantity();
    }
    
    /// <inheritdoc cref="PowerQuantity" />
    public static PowerQuantity Power(this KnownQuantities _)
    {
        return new PowerQuantity();
    }
    
    /// <inheritdoc cref="SubstanceQuantity" />
    public static SubstanceQuantity Substance(this KnownQuantities _)
    {
        return new SubstanceQuantity();
    }
    
    /// <inheritdoc cref="EcVolumeQuantity" />
    public static EcVolumeQuantity EcVolume(this KnownQuantities _)
    {
        return new EcVolumeQuantity();
    }
    
    /// <inheritdoc cref="IrradianceQuantity" />
    public static IrradianceQuantity Irradiance(this KnownQuantities _)
    {
        return new IrradianceQuantity();
    }
    
    /// <inheritdoc cref="VelocityQuantity" />
    public static VelocityQuantity Velocity(this KnownQuantities _)
    {
        return new VelocityQuantity();
    }
}