using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using mvdmsoftware.UnitsOfMeasurement.Enums.Quantities;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers;
using mvdmsoftware.UnitsOfMeasurement.ExchangeRates.Providers.CachedProvider;
using mvdmsoftware.UnitsOfMeasurement.Tests.Extensions;

namespace mvdmsoftware.UnitsOfMeasurement.Tests.ExchangeRateProvider
{
    [TestClass]
    public class CachedExchangeRateProviderTest
    {
        private Mock<IExchangeRateProvider> _exchangeRateProviderMock;
        private CachedExchangeRateProvider _cachedExchangeRateProvider;

        [TestInitialize]
        public void Initialize()
        {
            _exchangeRateProviderMock = new Mock<IExchangeRateProvider>();

            _cachedExchangeRateProvider = new CachedExchangeRateProvider(_exchangeRateProviderMock.Object);

            SetupExchangeRateProvider();
        }

        [TestMethod]
        public void ShouldRetrieveExchangeRatesOnceForTheEntireYear()
        {
            var usedDate = DateTime.Now;

            _cachedExchangeRateProvider.GetExchangeRate(CurrencyType.Euro, CurrencyType.UnitedStatesDollar, usedDate);
            _cachedExchangeRateProvider.GetExchangeRate(CurrencyType.Euro, CurrencyType.UnitedStatesDollar, usedDate);

            VerifyCacheRebuildFromDate(new DateTime(usedDate.Year, month: 1, day: 1));
        }

        [TestMethod]
        public void ShouldRetrieveNewExchangeRatesIfValuesAreRetrieveForAPreviousYear()
        {
            var firstUsedDate = DateTime.Now;
            var secondUsedDate = new DateTime(firstUsedDate.Year - 1, firstUsedDate.Month, firstUsedDate.Day, firstUsedDate.Hour, firstUsedDate.Minute, firstUsedDate.Second);

            _cachedExchangeRateProvider.GetExchangeRate(CurrencyType.Euro, CurrencyType.UnitedStatesDollar, firstUsedDate);
            _cachedExchangeRateProvider.GetExchangeRate(CurrencyType.Euro, CurrencyType.UnitedStatesDollar, secondUsedDate);

            VerifyCacheRebuildFromDate(new DateTime(firstUsedDate.Year, month: 1, day: 1));
            VerifyCacheRebuildFromDate(new DateTime(secondUsedDate.Year, month: 1, day: 1));
        }

        private void VerifyCacheRebuildFromDate(DateTime expectedDate)
        {
            foreach (CurrencyType fromCurrencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                foreach (CurrencyType toCurrencyType in Enum.GetValues(typeof(CurrencyType)))
                {
                    if(fromCurrencyType == toCurrencyType)
                        continue;
                    
                    _exchangeRateProviderMock.Verify(x => x.GetExchangeRates(fromCurrencyType, toCurrencyType, expectedDate), Times.Once);
                }
            }
        }

        private void SetupExchangeRateProvider()
        {
            _exchangeRateProviderMock
                .Setup(x => x.GetExchangeRates(It.IsAny<CurrencyType>(), It.IsAny<CurrencyType>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns((CurrencyType from, CurrencyType to, DateTime fromDate, DateTime toDate) => GenerateExchangeRates(from, to, fromDate, toDate));

            _exchangeRateProviderMock
                .Setup(x => x.GetExchangeRates(It.IsAny<CurrencyType>(), It.IsAny<CurrencyType>(), It.IsAny<DateTime>()))
                .Returns((CurrencyType from, CurrencyType to, DateTime fromDate) => GenerateExchangeRates(from, to, fromDate, DateTime.Now));
        }

        private static Dictionary<DateTime, CurrencyExchangeRateValue> GenerateExchangeRates(CurrencyType fromCurrency, CurrencyType toCurrency, DateTime fromDate, DateTime toDate)
        {
            var random = new Random();
            var result = new Dictionary<DateTime, CurrencyExchangeRateValue>();
            var amountOfDays = (toDate - fromDate).TotalDays;

            for (var i = 0; i < amountOfDays; i++)
            {
                result.Add(fromDate.AddDays(i), new CurrencyExchangeRateValue(fromCurrency, toCurrency, random.NextDouble(min: 0.10, max: 1.50)));
            }

            return result;
        }
    }
}
