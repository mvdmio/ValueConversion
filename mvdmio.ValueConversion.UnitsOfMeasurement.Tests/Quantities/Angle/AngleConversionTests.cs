using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Angle;

[TestClass]
public class AngleConversionTests : ConversionTestBase
{
    private readonly IUnit _degreeUnit = Quantity.Known.Angle().GetUnit("Degree");
    private readonly IUnit _radianUnit = Quantity.Known.Angle().GetUnit("Radian");

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