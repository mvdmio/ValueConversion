using Ardalis.GuardClauses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

public static class AssertExtensions
{
    public static void AreWithinTolerance(double expected, double actual, double tolerance = Comparer.DefaultTolerance)
    {
        var diff = Math.Abs(expected - actual);
        Assert.IsTrue(diff < tolerance, $"Expected {expected} to be within {tolerance} of {actual}, but was {diff}.");
    }

    public static void AreWithinPercentTolerance(double expected, double actual, double toleranceFraction = 1E-5)
    {
        Guard.Against.Zero(expected, nameof(expected));

        var diffPercent = Math.Abs((expected - actual) / expected);
        Assert.IsTrue(diffPercent < toleranceFraction, $"Expected {expected} to be within {toleranceFraction}% of {actual}, but was {diffPercent}%");
    }
}