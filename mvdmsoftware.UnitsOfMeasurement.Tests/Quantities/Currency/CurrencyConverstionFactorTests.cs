using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridder.Test.Common;
using Ridder.UnitsOfMeasurement.Enums.Quantities;
using Ridder.UnitsOfMeasurement.ExchangeRates;
using Ridder.UnitsOfMeasurement.Tests.Mocks;

namespace Ridder.UnitsOfMeasurement.Tests.Quantities.Currency
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
        public async Task UnitedStatesDollarConversions(CurrencyType type, double expected)
        {
            var exchangeRate = await GetConversionFactor(CurrencyType.UnitedStatesDollar, type);

            AssertEx.WithinTolerance(expected, exchangeRate);
        }

        [DataTestMethod]
        [DataRow(CurrencyType.UnitedStatesDollar, 1.11521499946152)]
        [DataRow(CurrencyType.Euro, 1)]
        [DataRow(CurrencyType.MexicanPeso, 21.2296548386269)]
        [DataRow(CurrencyType.CanadianDollar, 1.572453149240749)]
        public async Task EuroConversions(CurrencyType type, double expected)
        {
            var exchangeRate = await GetConversionFactor(CurrencyType.Euro, type);

            AssertEx.WithinTolerance(expected, exchangeRate);
        }

        [DataTestMethod]
        [DataRow(CurrencyType.UnitedStatesDollar, 0.0525310000533978)]
        [DataRow(CurrencyType.Euro, 0.0471039217359541)]
        [DataRow(CurrencyType.MexicanPeso, 1)]
        [DataRow(CurrencyType.CanadianDollar, 0.0740687100752908)]
        public async Task MexicanPesoConversions(CurrencyType type, double expected)
        {
            var exchangeRate = await GetConversionFactor(CurrencyType.MexicanPeso, type);

            AssertEx.WithinTolerance(expected, exchangeRate);
        }

        [DataTestMethod]
        [DataRow(CurrencyType.UnitedStatesDollar, 0.7092198581560284)]
        [DataRow(CurrencyType.Euro, 0.635948995035461)]
        [DataRow(CurrencyType.MexicanPeso, 13.50097765957447)]
        [DataRow(CurrencyType.CanadianDollar, 1)]
        public async Task CanadianDollarConversions(CurrencyType type, double expected)
        {
            var exchangeRate = await GetConversionFactor(CurrencyType.CanadianDollar, type);

            AssertEx.WithinTolerance(expected, exchangeRate);
        }

        private static async Task<double> GetConversionFactor(CurrencyType from, CurrencyType to)
        {
            var quantityValue = Quantity.Currency.CreateValue(value: 1, from);
            var convertedValue = await Quantity.Currency.Convert(quantityValue, to);
            var conversionFactor = convertedValue.GetValue();

            return conversionFactor;
        }
    }
}
