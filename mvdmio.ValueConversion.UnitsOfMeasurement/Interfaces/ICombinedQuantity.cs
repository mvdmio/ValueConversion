using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces
{
    public interface ICombinedQuantity : IQuantity
    {
        bool IsNamed { get; }
        new ICombinedUnit StandardUnit { get; }
        
        IQuantity NumeratorQuantity { get; }
        IQuantity DenominatorQuantity { get; }
        
        new IEnumerable<ICombinedUnit> GetUnits();

        ICombinedUnit GetUnit(IUnit numeratorUnit, IUnit denominatorUnit);
        IQuantityValue Convert(IQuantityValue quantityValue, ICombinedUnit toUnit);
        IQuantityValue CreateValue(DateTime timestamp, double value, ICombinedUnit unit);
    }
}
