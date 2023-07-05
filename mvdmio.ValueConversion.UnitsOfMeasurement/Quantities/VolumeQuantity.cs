using System.Collections.Generic;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Bases;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

/// <summary>
/// Volume is the quantity of three-dimensional space enclosed by a closed surface, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.
/// Volume is often quantified numerically using the SI derived unit, the cubic metre.
/// </summary>
public sealed class VolumeQuantity : ConversionFactorQuantityBase
{
   /// <summary>
   /// The CubicMeter unit of <see cref="VolumeQuantity"/>. This is the standard unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicMeter => GetUnit("CubicMeter");

   /// <summary>
   /// The CubicMillimeter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicMillimeter => GetUnit("CubicMillimeter");

   /// <summary>
   /// The CubicCentimeter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicCentimeter => GetUnit("CubicCentimeter");

   /// <summary>
   /// The FluidCubicCentimeter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit FluidCubicCentimeter => GetUnit("FluidCubicCentimeter");

   /// <summary>
   /// The Milliliter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit Milliliter => GetUnit("Milliliter");

   /// <summary>
   /// The Centiliter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit Centiliter => GetUnit("Centiliter");

   /// <summary>
   /// The Deciliter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit Deciliter => GetUnit("Deciliter");

   /// <summary>
   /// The CubicDecimeter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicDecimeter => GetUnit("CubicDecimeter");

   /// <summary>
   /// The Liter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit Liter => GetUnit("Liter");

   /// <summary>
   /// The Hectoliter unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit Hectoliter => GetUnit("Hectoliter");

   /// <summary>
   /// The CubicHectometer unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicHectometer => GetUnit("CubicHectometer");

   /// <summary>
   /// The CubicKilometer unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicKilometer => GetUnit("CubicKilometer");

   /// <summary>
   /// The CubicInch unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicInch => GetUnit("CubicInch");

   /// <summary>
   /// The CubicFoot unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicFoot => GetUnit("CubicFoot");

   /// <summary>
   /// The UsGallon unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit UsGallon => GetUnit("UsGallon");

   /// <summary>
   /// The ImperialGallon unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit ImperialGallon => GetUnit("ImperialGallon");

   /// <summary>
   /// The CubicYard unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicYard => GetUnit("CubicYard");

   /// <summary>
   /// The CubicMile unit of <see cref="VolumeQuantity"/>.
   /// </summary>
   public IUnit CubicMile => GetUnit("CubicMile");
   
   internal VolumeQuantity()
       : base("Volume", "CubicMeter")
   {
   }

   /// <inheritdoc/>     
   protected override IEnumerable<(string identifier, double conversionFactor)> GetConversionFactors()
   {
      return new[] {
            //Standard Unit
            ("CubicMeter", 1),
                
            //Metric
            ("CubicMillimeter", 1e-9),
            ("CubicCentimeter", 1e-6),
            ("FluidCubicCentimeter", 1e-6),
            ("Milliliter", 1e-6),
            ("Centiliter", 1e-5),
            ("Deciliter", 0.0001),
            ("CubicDecimeter", 0.001),
            ("Liter", 0.001),
            ("Hectoliter", 0.1),
            ("CubicHectometer", 1000000),
            ("CubicKilometer", 1e9),
                
            //Imperial
            ("CubicInch", 1.6387064e-5),
            ("CubicFoot", 0.0283168466),
            ("UsGallon", 0.00378541178),
            ("ImperialGallon", 0.00454609188),
            ("CubicYard", 0.764554858),
            ("CubicMile", 4.16818183e9)
        };
   }
}