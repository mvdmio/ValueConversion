using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.Interfaces;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Angle
{
    [TestClass]
    public class AngleConversionTests : ConversionTestBase
    {
        private readonly IUnit _degreeUnit = Quantity.Angle.GetUnit(AngleType.Degree);
        private readonly IUnit _radianUnit = Quantity.Angle.GetUnit(AngleType.Radian);

        [TestMethod]
        public async Task DegreeToDegree()
        {
            await TestConversion(1, _degreeUnit, 1, _degreeUnit);
        }

        [DataTestMethod]
        [DataRow(1, Math.PI / 180)]
        [DataRow(2, (Math.PI / 180) * 2)]
        public async Task DegreeToRadian(double degreesInput, double expectedRadian)
        {
            await TestConversion(degreesInput, _degreeUnit, expectedRadian, _radianUnit);
        }

        [TestMethod]
        public async Task RadianToRadian()
        {
            await TestConversion(1, _radianUnit, 1, _radianUnit);
        }

        [DataTestMethod]
        [DataRow(1, 180 / Math.PI)]
        [DataRow(2, (180 / Math.PI) * 2)]
        public async Task RadianToDegree(double radianInput, double expectedDegrees)
        {
            await TestConversion(radianInput, _radianUnit, expectedDegrees, _degreeUnit);
        }
    }
}
