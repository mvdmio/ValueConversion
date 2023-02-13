using mvdmio.ValueConversion.Currency.ExchangeRates.Providers;

namespace mvdmio.ValueConversion.Currency.Tests.Mocks;

public class MockExchangeRateProvider : IExchangeRateProvider
{
    private readonly IDictionary<CurrencyType, double> _conversionDictionary = new Dictionary<CurrencyType, double> {
        { CurrencyType.UnitedStatesDollar, 1 },
        { CurrencyType.Euro, 0.896688083 },
        { CurrencyType.MexicanPeso, 19.0363785 },
        { CurrencyType.CanadianDollar, 1.41 },
    };

    public CurrencyExchangeRateValue GetLatestExchangeRate(CurrencyType from, CurrencyType to)
    {
        return GetExchangeRate(from, to, DateTime.Now);
    }

    public CurrencyExchangeRateValue GetExchangeRate(CurrencyType from, CurrencyType to, DateTime date)
    {
        if (!_conversionDictionary.TryGetValue(from, out var fromValue))
            throw new InvalidOperationException($"No mocked exchange rate could be found for {from}");

        if (!_conversionDictionary.TryGetValue(to, out var toValue))
            throw new InvalidOperationException($"No mocked exchange rate could be found for {from}");

        var exchangeRate = toValue / fromValue;
        var result = new CurrencyExchangeRateValue(from, to, exchangeRate);

        return result;
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start)
    {
        return GetExchangeRates(from, to, start, DateTime.Now);
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime start, DateTime end)
    {
        var totalDays = (start.Date - end.Date).TotalDays;
        var exchangeRate = GetLatestExchangeRate(from, to);

        var result = new Dictionary<DateTime, CurrencyExchangeRateValue>();
        for (var i = 0; i < totalDays; i++)
        {
            result.Add(start.Date.AddDays(i), exchangeRate);
        }

        return result;
    }
}