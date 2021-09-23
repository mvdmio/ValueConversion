using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mvdmsoftware.UnitsOfMeasurement.Interfaces
{
    public interface ICombinedQuantity : IQuantity
    {
        bool IsNamed { get; }
        new ICombinedUnit StandardUnit { get; }
        
        IQuantity NumeratorQuantity { get; }
        IQuantity DenominatorQuantity { get; }
        
        new IEnumerable<ICombinedUnit> GetUnits();

        ICombinedUnit GetUnit(IUnit numeratorUnit, IUnit denominatorUnit);
        Task<IQuantityValue> Convert(IQuantityValue quantityValue, ICombinedUnit toUnit);
        IQuantityValue CreateValue(DateTime timestamp, double value, ICombinedUnit unit);
    }
}
