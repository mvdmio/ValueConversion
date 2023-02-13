using System;

namespace mvdmio.ValueConversion.Base.Utils;

public static class Comparer
{
    public const double DefaultTolerance = 0.1;

    public static bool IsWithinTolerance(double first, double second, double tolerance = DefaultTolerance)
    {
        return Math.Abs(first - second) < tolerance;
    }
}