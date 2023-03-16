using mvdmio.ValueConversion.Currency.ExchangeRates.Providers;

namespace mvdmio.ValueConversion.Currency.Tests.Mocks;

public class MockExchangeRateProvider : IExchangeRateProvider
{
    private readonly IDictionary<string, double> _conversionDictionary = new Dictionary<string, double> {
        { "UnitedStatesDollar", 1 },
        { "Euro", 0.896688083 },
        { "MexicanPeso", 19.0363785 },
        { "CanadianDollar", 1.41 },
    };

    public CurrencyExchangeRateValue GetLatestExchangeRate(string from, string to)
    {
        return GetExchangeRate(from, to, DateTime.Now);
    }

    public CurrencyExchangeRateValue GetExchangeRate(string from, string to, DateTime date)
    {
        if (!_conversionDictionary.TryGetValue(from, out var fromValue))
            throw new InvalidOperationException($"No mocked exchange rate could be found for {from}");

        if (!_conversionDictionary.TryGetValue(to, out var toValue))
            throw new InvalidOperationException($"No mocked exchange rate could be found for {from}");

        var exchangeRate = toValue / fromValue;
        var result = new CurrencyExchangeRateValue(from, to, exchangeRate);

        return result;
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string from, string to, DateTime start)
    {
        return GetExchangeRates(from, to, start, DateTime.Now);
    }

    public IDictionary<DateTime, CurrencyExchangeRateValue> GetExchangeRates(string from, string to, DateTime start, DateTime end)
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