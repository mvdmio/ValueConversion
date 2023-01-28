using System;
using System.Globalization;
using FormatWith;
using mvdmio.ValueConversion.UnitsOfMeasurement.Interfaces;
using mvdmio.ValueConversion.UnitsOfMeasurement.Resources.UnitsFormatting;

namespace mvdmio.ValueConversion.UnitsOfMeasurement.Bases
{
    public abstract class CombinedUnitBase : ICombinedUnit
    {
        private readonly ICombinedQuantity _quantity;

        public abstract string Identifier { get; }

        public IUnit NumeratorUnit { get; }
        public IUnit DenominatorUnit { get; }

        protected CombinedUnitBase(IUnit numeratorUnit, IUnit denominatorUnit, ICombinedQuantity quantity)
        {
            _quantity = quantity;

            NumeratorUnit = numeratorUnit;
            DenominatorUnit = denominatorUnit;
        }

        public abstract double FromStandardUnit(double value, DateTimeOffset timestamp);
        public abstract double ToStandardUnit(double value, DateTimeOffset timestamp);
        public abstract string GetSymbol(CultureInfo cultureInfo);
        
        IQuantity IUnit.GetQuantity()
        {
            return GetQuantity();
        }

        public ICombinedQuantity GetQuantity()
        {
            return _quantity;
        }

        public string GetFormattedValue(double value, CultureInfo cultureInfo)
        {
            var symbol = GetSymbol(cultureInfo);
            var format = UnitsFormatting.ResourceManager.GetString(Identifier, cultureInfo);

            if (format == null)
                format = UnitsFormatting.ResourceManager.GetString(name: "_Default", cultureInfo);

            var formattedValue = format.FormatWith(new {
                v = value,
                sym = symbol
            });

            return formattedValue;
        }   
    }
}