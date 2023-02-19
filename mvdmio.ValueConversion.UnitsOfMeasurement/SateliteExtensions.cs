using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates;

namespace mvdmio.ValueConversion.UnitsOfMeasurement;

/// <summary>
/// Extension class for providing easy access to Known Quantities on <see cref="KnownQuantities" />.
/// </summary>
public static class SatelliteExtensions
{
   private static readonly AngleQuantity _angle;
   private static readonly AreaQuantity _area;
   private static readonly DistanceQuantity _distance;
   private static readonly DurationQuantity _duration;
   private static readonly EnergyQuantity _energy;
   private static readonly ElectricConductanceQuantity _electricConductance;
   private static readonly ElectricConductivityQuantity _electricConductivity;
   private static readonly MassQuantity _mass;
   private static readonly PressureQuantity _pressure;
   private static readonly TemperatureQuantity _temperature;
   private static readonly VolumeQuantity _volume;
   private static readonly PowerQuantity _power;
   private static readonly SubstanceQuantity _substance;
   private static readonly IrradianceQuantity _irradiance;
   private static readonly VelocityQuantity _velocity;

   static SatelliteExtensions()
   {
      _angle = Quantity.Add(new AngleQuantity());
      _area = Quantity.Add(new AreaQuantity());
      _distance = Quantity.Add(new DistanceQuantity());
      _duration = Quantity.Add(new DurationQuantity());
      _energy = Quantity.Add(new EnergyQuantity());
      _electricConductance = Quantity.Add(new ElectricConductanceQuantity());
      _electricConductivity= Quantity.Add(new ElectricConductivityQuantity());
      _mass = Quantity.Add(new MassQuantity());
      _pressure = Quantity.Add(new PressureQuantity());
      _temperature = Quantity.Add(new TemperatureQuantity());
      _volume = Quantity.Add(new VolumeQuantity());
      _power = Quantity.Add(new PowerQuantity());
      _substance = Quantity.Add(new SubstanceQuantity());
      _irradiance = Quantity.Add(new IrradianceQuantity());
      _velocity = Quantity.Add(new VelocityQuantity());
   }

   /// <summary>
   /// Sets up the quantity library with Units of Measurement quantities.
   /// </summary>
   /// <param name="_">The extension class</param>
   public static void WithUnitsOfMeasurement(this QuantitySetup _)
   {
      // Calling this method will run the static constructor, setting up the quantities.
   }

   /// <inheritdoc cref="AngleQuantity" />
   public static AngleQuantity Angle(this KnownQuantities _) => _angle;

   /// <inheritdoc cref="AreaQuantity" />
   public static AreaQuantity Area(this KnownQuantities _) => _area;

   /// <inheritdoc cref="DistanceQuantity" />
   public static DistanceQuantity Distance(this KnownQuantities _) => _distance;

   /// <inheritdoc cref="DurationQuantity" />
   public static DurationQuantity Duration(this KnownQuantities _) => _duration;

   /// <inheritdoc cref="EnergyQuantity" />
   public static EnergyQuantity Energy(this KnownQuantities _) => _energy;

   /// <inheritdoc cref="ElectricConductanceQuantity" />
   public static ElectricConductanceQuantity ElectricConductance(this KnownQuantities _) => _electricConductance;

   /// <inheritdoc cref="ElectricConductivityQuantity" />
   public static ElectricConductivityQuantity ElectricConductivity(this KnownQuantities _) => _electricConductivity;

   /// <inheritdoc cref="MassQuantity" />
   public static MassQuantity Mass(this KnownQuantities _) => _mass;

   /// <inheritdoc cref="PressureQuantity" />
   public static PressureQuantity Pressure(this KnownQuantities _) => _pressure;

   /// <inheritdoc cref="TemperatureQuantity" />
   public static TemperatureQuantity Temperature(this KnownQuantities _) => _temperature;

   /// <inheritdoc cref="VolumeQuantity" />
   public static VolumeQuantity Volume(this KnownQuantities _) => _volume;

   /// <inheritdoc cref="PowerQuantity" />
   public static PowerQuantity Power(this KnownQuantities _) => _power;

   /// <inheritdoc cref="SubstanceQuantity" />
   public static SubstanceQuantity Substance(this KnownQuantities _) => _substance;

   /// <inheritdoc cref="IrradianceQuantity" />
   public static IrradianceQuantity Irradiance(this KnownQuantities _) => _irradiance;

   /// <inheritdoc cref="VelocityQuantity" />
   public static VelocityQuantity Velocity(this KnownQuantities _) => _velocity;
}