using System;
using System.Globalization;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces
{
    public interface IQuantityValue
    {
        DateTimeOffset Timestamp { get; }

        IQuantity GetQuantity();
        IUnit GetUnit();

        double GetValue();
        double GetStandardValue();

        IQuantityValue As(IUnit unit);
        bool IsEqualTo(IQuantityValue other);

        string GetFormattedValue(CultureInfo cultureInfo);
    }

    public interface IQuantityValue<TEnum> : IQuantityValue where TEnum : Enum
    {
        new IQuantity<TEnum> GetQuantity();
        new IUnit<TEnum> GetUnit();
        IQuantityValue As(TEnum unitEnum);
    }
}