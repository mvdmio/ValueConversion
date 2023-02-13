using mvdmio.ValueConversion.Base.Bases;
using mvdmio.ValueConversion.Base.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Utils;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Tests.Quantities;

public class ConversionTestBase
{
    private double GetConvertedValue(double input, IUnit originalUnit, IUnit convertedUnit)
    {
        var originalValue = new QuantityValue(DateTimeOffset.Now, input, originalUnit);
        var convertedValue = originalValue.As(convertedUnit);

        return convertedValue.GetValue();
    }

    protected void TestConversion(double inputValue, IUnit inputUnit, double expectedConverted, IUnit convertedUnit)
    {
        var convertedValue = GetConvertedValue(inputValue, inputUnit, convertedUnit);
        AssertExtensions.AreWithinTolerance(expectedConverted, convertedValue, 1e-10);
    }
}