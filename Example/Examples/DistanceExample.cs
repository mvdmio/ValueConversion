using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.UnitsOfMeasurement.Quantities;

namespace Example.Examples;

public static class DistanceExample
{
   public static void MetersToYards()
   {
      var distanceInMeters = new QuantityValue(10, Distance.Meter); // 10 meter
      var distanceInYards = distanceInMeters.As(Distance.Yard);     // 10.94 yd
         
      var formattedMeters = distanceInMeters.GetFormattedValue(decimalPoints: 2);
      var formattedYards = distanceInYards.GetFormattedValue(decimalPoints: 2);
      Console.WriteLine($@"{formattedMeters} = {formattedYards}"); 
   }

   public static void KilometersToMiles()
   {
      var distanceInMeters = new QuantityValue(100, Distance.Kilometer); // 100 km
      var distanceInMiles = distanceInMeters.As(Distance.Mile);          // 62.14 mi

      var formattedMeters = distanceInMeters.GetFormattedValue(decimalPoints: 2);
      var formattedMiles = distanceInMiles.GetFormattedValue(decimalPoints: 2);
      Console.WriteLine($@"{formattedMeters} = {formattedMiles}");
   }
}