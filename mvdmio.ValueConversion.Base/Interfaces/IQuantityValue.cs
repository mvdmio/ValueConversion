using System;
using System.Globalization;

namespace mvdmio.ValueConversion.Base.Interfaces;

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