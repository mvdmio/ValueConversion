// ReSharper disable UnusedMember.Global

using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities.Rates;

namespace mvdmio.ValueConversion.UnitsOfMeasurement;

/// <summary>
/// Extension class for providing easy access to Known Quantities on <see cref="KnownQuantities" />.
/// </summary>
public static class SatelliteExtensions
{
   private static readonly Acidity _acidity;
   private static readonly Angle _angle;
   private static readonly Area _area;
   private static readonly Distance _distance;
   private static readonly Duration _duration;
   private static readonly Energy _energy;
   private static readonly ElectricConductance _electricConductance;
   private static readonly ElectricConductivityQuantity _electricConductivity;
   private static readonly Mass _mass;
   private static readonly Temperature _temperature;
   private static readonly Power _power;
   private static readonly Pressure _pressure;
   private static readonly Ratio _ratio;
   private static readonly Substance _substance;
   private static readonly IrradianceQuantity _irradiance;
   private static readonly VelocityQuantity _velocity;
   private static readonly Volume _volume;
   
   static SatelliteExtensions()
   {
      _acidity = Quantity.Add(new Acidity());
      _angle = Quantity.Add(new Angle());
      _area = Quantity.Add(new Area());
      _distance = Quantity.Add(new Distance());
      _duration = Quantity.Add(new Duration());
      _electricConductance = Quantity.Add(new ElectricConductance());
      _energy = Quantity.Add(new Energy());
      _mass = Quantity.Add(new Mass());
      _power = Quantity.Add(new Power());
      _pressure = Quantity.Add(new Pressure());
      _ratio = Quantity.Add(new Ratio());
      _substance = Quantity.Add(new Substance());
      _temperature = Quantity.Add(new Temperature());
      _volume = Quantity.Add(new Volume());
      
      _electricConductivity= Quantity.Add(new ElectricConductivityQuantity());
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

   /// <inheritdoc cref="Quantities.Angle" />
   public static Angle Angle(this KnownQuantities _) => _angle;

   /// <inheritdoc cref="Quantities.Area" />
   public static Area Area(this KnownQuantities _) => _area;

   /// <inheritdoc cref="Quantities.Distance" />
   public static Distance Distance(this KnownQuantities _) => _distance;

   /// <inheritdoc cref="Quantities.Duration" />
   public static Duration Duration(this KnownQuantities _) => _duration;

   /// <inheritdoc cref="Quantities.Energy" />
   public static Energy Energy(this KnownQuantities _) => _energy;

   /// <inheritdoc cref="Quantities.ElectricConductance" />
   public static ElectricConductance ElectricConductance(this KnownQuantities _) => _electricConductance;

   /// <inheritdoc cref="ElectricConductivityQuantity" />
   public static ElectricConductivityQuantity ElectricConductivity(this KnownQuantities _) => _electricConductivity;

   /// <inheritdoc cref="Quantities.Mass" />
   public static Mass Mass(this KnownQuantities _) => _mass;

   /// <inheritdoc cref="Quantities.Pressure" />
   public static Pressure Pressure(this KnownQuantities _) => _pressure;

   /// <inheritdoc cref="Quantities.Temperature" />
   public static Temperature Temperature(this KnownQuantities _) => _temperature;

   /// <inheritdoc cref="Quantities.Volume" />
   public static Volume Volume(this KnownQuantities _) => _volume;

   /// <inheritdoc cref="Quantities.Power" />
   public static Power Power(this KnownQuantities _) => _power;

   /// <inheritdoc cref="Quantities.Ratio" />
   public static Ratio Ratio(this KnownQuantities _) => _ratio;
   
   /// <inheritdoc cref="Quantities.Substance" />
   public static Substance Substance(this KnownQuantities _) => _substance;

   /// <inheritdoc cref="IrradianceQuantity" />
   public static IrradianceQuantity Irradiance(this KnownQuantities _) => _irradiance;

   /// <inheritdoc cref="VelocityQuantity" />
   public static VelocityQuantity Velocity(this KnownQuantities _) => _velocity;

   /// <inheritdoc cref="Quantities.Acidity" />
   public static Acidity Acidity(this KnownQuantities _) => _acidity;
}