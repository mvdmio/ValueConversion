using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates;
using mvdmsoftware.UnitsOfMeasurement.Tests.Mocks;
using mvdmsoftware.UnitsOfMeasurement.Tests.Utils;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.Quantities.Currency
{
    [TestClass]
    public class CurrencyConverstionTests
    {
        [TestInitialize]
        public void Setup()
        {
            CurrencyExchangeRate.SetProvider(new MockExchangeRateProvider());
        }

        [DataTestMethod]
        [DataRow(CurrencyType.UnitedStatesDollar, 1)]
        [DataRow(CurrencyType.Euro, 0.896688083)]
        [DataRow(CurrencyType.MexicanPeso, 19.0363785)]
        [DataRow(CurrencyType.CanadianDollar, 1.41)]
        public void UnitedStatesDollarConversions(CurrencyType type, double expected)
        {
            var exchangeRate = GetConversionFactor(CurrencyType.UnitedStatesDollar, type);

            AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
        }

        [DataTestMethod]
        [DataRow(CurrencyType.UnitedStatesDollar, 1.11521499946152)]
        [DataRow(CurrencyType.Euro, 1)]
        [DataRow(CurrencyType.MexicanPeso, 21.2296548386269)]
        [DataRow(CurrencyType.CanadianDollar, 1.572453149240749)]
        public void EuroConversions(CurrencyType type, double expected)
        {
            var exchangeRate = GetConversionFactor(CurrencyType.Euro, type);

            AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
        }

        [DataTestMethod]
        [DataRow(CurrencyType.UnitedStatesDollar, 0.0525310000533978)]
        [DataRow(CurrencyType.Euro, 0.0471039217359541)]
        [DataRow(CurrencyType.MexicanPeso, 1)]
        [DataRow(CurrencyType.CanadianDollar, 0.0740687100752908)]
        public void MexicanPesoConversions(CurrencyType type, double expected)
        {
            var exchangeRate = GetConversionFactor(CurrencyType.MexicanPeso, type);

            AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
        }

        [DataTestMethod]
        [DataRow(CurrencyType.UnitedStatesDollar, 0.7092198581560284)]
        [DataRow(CurrencyType.Euro, 0.635948995035461)]
        [DataRow(CurrencyType.MexicanPeso, 13.50097765957447)]
        [DataRow(CurrencyType.CanadianDollar, 1)]
        public void CanadianDollarConversions(CurrencyType type, double expected)
        {
            var exchangeRate = GetConversionFactor(CurrencyType.CanadianDollar, type);

            AssertExtensions.AreWithinPercentTolerance(expected, exchangeRate);
        }

        private static double GetConversionFactor(CurrencyType from, CurrencyType to)
        {
            var quantityValue = Quantity.Currency.CreateValue(value: 1, from);
            var convertedValue = Quantity.Currency.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
