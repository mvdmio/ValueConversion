using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Angle
{
    [TestClass]
    public class AngleConversionTests : ConversionTestBase
    {
        private readonly IUnit _degreeUnit = Quantity.Angle.GetUnit(AngleType.Degree);
        private readonly IUnit _radianUnit = Quantity.Angle.GetUnit(AngleType.Radian);

        [TestMethod]
        public void DegreeToDegree()
        {
            TestConversion(1, _degreeUnit, 1, _degreeUnit);
        }

        [DataTestMethod]
        [DataRow(1, Math.PI / 180)]
        [DataRow(2, (Math.PI / 180) * 2)]
        public void DegreeToRadian(double degreesInput, double expectedRadian)
        {
            TestConversion(degreesInput, _degreeUnit, expectedRadian, _radianUnit);
        }

        [TestMethod]
        public void RadianToRadian()
        {
            TestConversion(1, _radianUnit, 1, _radianUnit);
        }

        [DataTestMethod]
        [DataRow(1, 180 / Math.PI)]
        [DataRow(2, (180 / Math.PI) * 2)]
        public void RadianToDegree(double radianInput, double expectedDegrees)
        {
            TestConversion(radianInput, _radianUnit, expectedDegrees, _degreeUnit);
        }
    }
}
