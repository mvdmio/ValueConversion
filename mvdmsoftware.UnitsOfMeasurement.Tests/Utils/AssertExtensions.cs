using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Utils
{
    public static class AssertExtensions
    {
        public static void AreEqual(double expected, double actual, double tolerance = Comparer.DefaultTolerance)
        {
            var diff = Math.Abs(expected - actual);
            Assert.IsTrue(diff < tolerance, $"Expected {expected} to be within {tolerance} of {actual}, but was {diff}.");
        }
    }
}