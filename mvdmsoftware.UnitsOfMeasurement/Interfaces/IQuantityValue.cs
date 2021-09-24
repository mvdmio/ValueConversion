using System;
using System.Globalization;
using System.Threading.Tasks;

namespace mvdmsoftware.UnitsOfMeasurement.Interfaces
{
    public interface IQuantityValue
    {
        DateTimeOffset Timestamp { get; }

        IQuantity GetQuantity();
        IUnit GetUnit();

        double GetValue();
        Task<double> GetStandardValue();

        Task<IQuantityValue> As(IUnit unit);
        Task<bool> IsEqualTo(IQuantityValue other);

        string GetFormattedValue(CultureInfo cultureInfo);
    }

    public interface IQuantityValue<TEnum> : IQuantityValue where TEnum : Enum
    {
        new IQuantity<TEnum> GetQuantity();
        new IUnit<TEnum> GetUnit();
        Task<IQuantityValue> As(TEnum unitEnum);
    }
}