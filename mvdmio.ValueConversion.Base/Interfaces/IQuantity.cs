using System;
using System.Collections.Generic;

namespace mvdmio.ValueConversion.Base.Interfaces;

public interface IQuantity
{
    IUnit StandardUnit { get; }
    string Identifier { get; }
        
    IEnumerable<IUnit> GetUnits();
    IUnit GetUnit(string unitIdentifier);

    IQuantityValue Convert(IQuantityValue quantityValue, IUnit toUnit);
    IQuantityValue CreateValue(double value, IUnit unit);
    IQuantityValue CreateValue(DateTime timestamp, double value, IUnit unit);
}