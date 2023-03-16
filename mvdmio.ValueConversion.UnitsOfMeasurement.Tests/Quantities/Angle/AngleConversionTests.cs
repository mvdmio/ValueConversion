using mvdmio.ValueConversion.Base;
using mvdmio.ValueConversion.Base.Interfaces;
using Xunit;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities.Angle;


public class AngleConversionTests : ConversionTestBase
{
    private readonly IUnit _degreeUnit = Quantity.Known.Angle().GetUnit("Degree");
    private readonly IUnit _radianUnit = Quantity.Known.Angle().GetUnit("Radian");

    [Fact]
    public void DegreeToDegree()
    {
        TestConversion(1, _degreeUnit, 1, _degreeUnit);
    }

    [Theory]
    [InlineData(1, Math.PI / 180)]
    [InlineData(2, (Math.PI / 180) * 2)]
    public void DegreeToRadian(double degreesInput, double expectedRadian)
    {
        TestConversion(degreesInput, _degreeUnit, expectedRadian, _radianUnit);
    }

    [Fact]
    public void RadianToRadian()
    {
        TestConversion(1, _radianUnit, 1, _radianUnit);
    }

    [Theory]
    [InlineData(1, 180 / Math.PI)]
    [InlineData(2, (180 / Math.PI) * 2)]
    public void RadianToDegree(double radianInput, double expectedDegrees)
    {
        TestConversion(radianInput, _radianUnit, expectedDegrees, _degreeUnit);
    }
}