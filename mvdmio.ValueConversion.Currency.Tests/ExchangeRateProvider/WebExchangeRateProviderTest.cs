using Microsoft.VisualStudio.TestTools.UnitTesting;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers;
using mvdmio.ValueConversion.Currency.ExchangeRates.Providers.WebProvider;
using mvdmio.ValueConversion.UnitsOfMeasurement.Enums.Quantities;

namespace mvdmio.ValueConversion.Currency.Tests.ExchangeRateProvider
{
    [TestClass]
    [Ignore]
    public class WebExchangeRateProviderTest
    {
        private const double ExchangeRateEpsilon = 0.000000001;

        private static HttpClient _httpClient;
        private static WebExchangeRateProvider _provider;

        [TestInitialize]
        public void Initialize()
        {
            _httpClient = new HttpClient();
            _provider = new WebExchangeRateProvider(_httpClient);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _httpClient?.Dispose();
        }

        [TestMethod]
        public void ShouldRetrieveExchangeRateOfToday()
        {
            var exchangeRate = _provider.GetExchangeRate(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, DateTime.Now);

            Assert.IsTrue(exchangeRate.Value > 0);
        }

        [TestMethod]
        public void ShouldRetrieveExchangeRateOfSaturday()
        {
            /*
             * Exchange rates are not given on non-working days like weekends.
             * The library should determine the correct exchange rates for the given periods and return a value for every day, even if the returned DataSet does not contain values for weekend days.
             * The most accurate exchange rate is the rate of the next monday.
             */

            var saturdayTwoWeeksAgo = GetDayInPast(DayOfWeek.Saturday, TimeSpan.FromDays(14));
            var previousFriday = saturdayTwoWeeksAgo.Subtract(TimeSpan.FromDays(1));
            var nextMonday = saturdayTwoWeeksAgo.Add(TimeSpan.FromDays(2));

            var exchangeRate = _provider.GetExchangeRate(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, saturdayTwoWeeksAgo);
            var previousFridayExchangeRate = _provider.GetExchangeRate(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, previousFriday);
            var nextMondayExchangeRate = _provider.GetExchangeRate(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, nextMonday);

            if (!ExchangeRateEquals(previousFridayExchangeRate, nextMondayExchangeRate))
            {
                Assert.IsFalse(ExchangeRateEquals(exchangeRate, previousFridayExchangeRate), "Weekend exchange rate should be equal to the monday exchange rate, not the previous friday exchange rate.");
            }

            Assert.IsTrue(ExchangeRateEquals(exchangeRate, nextMondayExchangeRate), "Weekend exchange rate should be equal to the monday exchange rate, not the previous friday exchange rate.");
        }

        [TestMethod]
        public void ShouldRetrieveExchangeRateOfSunday()
        {
            /*
             * Exchange rates are not given on non-working days like weekends.
             * The library should determine the correct exchange rates for the given periods and return a value for every day, even if the returned DataSet does not contain values for weekend days.
             * The most accurate exchange rate is the rate of the next monday.
             */

            var sundayTwoWeeksAgo = GetDayInPast(DayOfWeek.Sunday, TimeSpan.FromDays(14));
            var previousFriday = sundayTwoWeeksAgo.Subtract(TimeSpan.FromDays(2));
            var nextMonday = sundayTwoWeeksAgo.Add(TimeSpan.FromDays(1));

            var exchangeRate = _provider.GetExchangeRate(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, sundayTwoWeeksAgo);
            var previousFridayExchangeRate = _provider.GetExchangeRate(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, previousFriday);
            var nextMondayExchangeRate = _provider.GetExchangeRate(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, nextMonday);

            if (!ExchangeRateEquals(previousFridayExchangeRate, nextMondayExchangeRate))
            {
                Assert.IsFalse(ExchangeRateEquals(exchangeRate, previousFridayExchangeRate), "Weekend exchange rate should be equal to the monday exchange rate, not the previous friday exchange rate.");
            }

            Assert.IsTrue(ExchangeRateEquals(exchangeRate, nextMondayExchangeRate), "Weekend exchange rate should be equal to the monday exchange rate, not the previous friday exchange rate.");
        }

        [TestMethod]
        public void ShouldRetrieveExchangeRateOfOneWorkingWeek()
        {
            var mondayTwoWeeksAgo = GetDayInPast(DayOfWeek.Monday, TimeSpan.FromDays(14));
            var fridayTwoWeeksAgo = GetDayInPast(DayOfWeek.Friday, TimeSpan.FromDays(14));
            var exchangeRate = _provider.GetExchangeRates(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, mondayTwoWeeksAgo, fridayTwoWeeksAgo);

            Assert.AreEqual(5, exchangeRate.Count);
            Assert.AreEqual(mondayTwoWeeksAgo, Enumerable.First<DateTime>(exchangeRate.Keys));
            Assert.AreEqual(fridayTwoWeeksAgo, Enumerable.Last<DateTime>(exchangeRate.Keys));
            Assert.IsTrue(Enumerable.All(exchangeRate, x => x.Value.Value > 0));
        }

        [TestMethod]
        public void ShouldRetrieveExchangeRateOfLastWeek()
        {
            var today = DateTime.Now.Date;
            var todayOneWeekAgo = today.Subtract(TimeSpan.FromDays(7));
            var exchangeRate = _provider.GetExchangeRates(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, todayOneWeekAgo, today);

            Assert.AreEqual(8, exchangeRate.Count);
            Assert.AreEqual(todayOneWeekAgo, Enumerable.First<DateTime>(exchangeRate.Keys), "Invalid first day");
            Assert.AreEqual(today, Enumerable.Last<DateTime>(exchangeRate.Keys), "Invalid last day");

            Assert.IsTrue(Enumerable.All(exchangeRate, x => x.Value.Value > 0), "Some exchange rates do not have a value.");
        }

        [TestMethod]
        public void ShouldRetrieveExchangeRateOfTheWeekBeforeLastWeek()
        {
            var todayOneWeekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7)).Date;
            var todayTwoWeeksAgo = todayOneWeekAgo.Subtract(TimeSpan.FromDays(7)).Date;
            var exchangeRate = _provider.GetExchangeRates(CurrencyType.UnitedStatesDollar, CurrencyType.Euro, todayTwoWeeksAgo, todayOneWeekAgo);

            Assert.AreEqual(8, exchangeRate.Count);
            Assert.AreEqual(todayTwoWeeksAgo, Enumerable.First<DateTime>(exchangeRate.Keys), "Invalid first day");
            Assert.AreEqual(todayOneWeekAgo, Enumerable.Last<DateTime>(exchangeRate.Keys), "Invalid last day");

            Assert.IsTrue(Enumerable.All(exchangeRate, x => x.Value.Value > 0), "Some exchange rates do not have a value.");
        }

        private static bool ExchangeRateEquals(CurrencyExchangeRateValue first, CurrencyExchangeRateValue second)
        {
            return Math.Abs((double)(first.Value - second.Value)) < ExchangeRateEpsilon;
        }

        private static DateTime GetDayInPast(DayOfWeek dayOfWeek, TimeSpan timeAgo)
        {
            var dayOfWeekIn = dayOfWeek - DateTime.Today.DayOfWeek;

            return DateTime.Today.Date.Add(TimeSpan.FromDays(dayOfWeekIn)).Subtract(timeAgo);
        }
    }
}
