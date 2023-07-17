using System;

namespace mvdmio.ValueConversion.Base.Utils;

internal static class Comparer
{
    internal const double DefaultTolerance = 0.1;

    public static bool IsWithinTolerance(double first, double second, double tolerance = DefaultTolerance)
    {
        return Math.Abs(first - second) < tolerance;
    }
}