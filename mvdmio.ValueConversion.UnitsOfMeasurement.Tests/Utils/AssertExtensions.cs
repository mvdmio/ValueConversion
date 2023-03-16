using mvdmio.ValueConversion.Base.Utils;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

public static class AssertExtensions
{
   public static void AreWithinTolerance(double expected, double actual, double tolerance = Comparer.DefaultTolerance)
   {
      var diff = Math.Abs(expected - actual);
      Assert.True(diff < tolerance, $"Expected {expected} to be within {tolerance} of {actual}, but was {diff}.");
   }

   public static void AreWithinPercentTolerance(double expected, double actual, double toleranceFraction = 1E-5)
   {
      if (Math.Abs(expected) < double.Epsilon)
         throw new ArgumentException("Must not be zero", nameof(expected));

      var diffPercent = Math.Abs((expected - actual) / expected);
      Assert.True(diffPercent < toleranceFraction, $"Expected {expected} to be within {toleranceFraction}% of {actual}, but was {diffPercent}%");
   }
}