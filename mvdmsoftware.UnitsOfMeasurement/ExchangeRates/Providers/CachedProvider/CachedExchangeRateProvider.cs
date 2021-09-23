using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Ridder.UnitsOfMeasurement.Enums.Quantities;

namespace Ridder.UnitsOfMeasurement.ExchangeRates.Providers.CachedExchangeRateProvider
{
    public class CachedExchangeRateProvider : IExchangeRateProvider
    {
        private readonly IExchangeRateProvider _exchangeRateProvider;

        private DateTime _cacheStartDate;
        private readonly object lockObject = new object();
        private readonly IDictionary<DateTime, IList<CurrencyExchangeRateValue>> _cache;

        public CachedExchangeRateProvider(IExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider;

            _cacheStartDate = DateTime.MaxValue; // Initialize to MaxValue so that the cache is always rebuilt on the first run.
            _cache = new SortedDictionary<DateTime, IList<CurrencyExchangeRateValue>>();
        }

        public async Task<CurrencyExchangeRateValue> GetLatestExchangeRate(CurrencyType from, CurrencyType to)
        {
            var cacheWorkingCopy = await RetrieveCacheWorkingCopy();

            var latestCachedExchangeRate = cacheWorkingCopy.Max();
            var exchangeRate = latestCachedExchangeRate.Value.FirstOrDefault(x => x.From == from && x.To == to);

            if (exchangeRate == null)
                return await _exchangeRateProvider.GetLatestExchangeRate(from, to);

            return exchangeRate;
        }

        public async Task<CurrencyExchangeRateValue> GetExchangeRate(CurrencyType from, CurrencyType to, DateTime utcDate)
        {
            var usedDate = utcDate.Date;
            var cacheWorkingCopy = await RetrieveCacheWorkingCopy(usedDate);
            
            if (!cacheWorkingCopy.ContainsKey(usedDate))
                // If the cache still does not contain the value after rebuild, try retrieving the values without the cache.
                return await _exchangeRateProvider.GetExchangeRate(from, to, usedDate);

            var cachedExchangeRates = cacheWorkingCopy[usedDate];
            var exchangeRate = cachedExchangeRates.FirstOrDefault(x => x.From == from && x.To == to);

            if(exchangeRate == null)
                // If the cache does not contain the value after rebuild, try retrieving the values without the cache.
                return await _exchangeRateProvider.GetExchangeRate(from, to, usedDate);

            return exchangeRate;
        }

        public async Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime fromDate)
        {
            var usedDate = fromDate.Date;
            var cacheWorkingCopy = await RetrieveCacheWorkingCopy(usedDate);

            var result = new SortedDictionary<DateTime, CurrencyExchangeRateValue>();
            var relevantKeys = cacheWorkingCopy.Keys.Where(x => x.Date >= usedDate);

            foreach(var key in relevantKeys)
            {
                var exchangeRate = cacheWorkingCopy[key].FirstOrDefault(x => x.From == from && x.To == to);

                result.Add(key, exchangeRate);
            }

            return result;
        }

        public async Task<IDictionary<DateTime, CurrencyExchangeRateValue>> GetExchangeRates(CurrencyType from, CurrencyType to, DateTime fromDate, DateTime end)
        {
            var usedFromDate = fromDate.Date;
            var usedToDate = end.Date;
            var cacheWorkingCopy = await RetrieveCacheWorkingCopy(usedFromDate);

            var result = new SortedDictionary<DateTime, CurrencyExchangeRateValue>();
            var relevantKeys = cacheWorkingCopy.Keys.Where(x => x.Date >= usedFromDate && x.Date <= usedToDate);

            foreach(var key in relevantKeys)
            {
                var exchangeRate = cacheWorkingCopy[key].FirstOrDefault(x => x.From == from && x.To == to);

                result.Add(key, exchangeRate);
            }

            return result;
        }

        private async Task RebuildCache(DateTime? cacheStartDate = null)
        {
            if (cacheStartDate.HasValue && cacheStartDate.Value < _cacheStartDate)
                // If the requested utcDate is before the start-utcDate of the cache, make sure that the cache is filled with the entire year of the requested utcDate.
                _cacheStartDate = new DateTime(cacheStartDate.Value.Year, month: 01, day: 01);

            _cache.Clear();
            
            foreach (CurrencyType fromCurrencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                foreach (CurrencyType toCurrencyType in Enum.GetValues(typeof(CurrencyType)))
                {
                    if(fromCurrencyType == toCurrencyType)
                        continue;
                    
                    var retrievedExchangeRates = await _exchangeRateProvider.GetExchangeRates(fromCurrencyType, toCurrencyType, _cacheStartDate);

                    foreach (var exchangeRate in retrievedExchangeRates)
                    {
                        if (!_cache.TryGetValue(exchangeRate.Key.Date, out var cachedExchangeRates))
                        {
                            cachedExchangeRates = new List<CurrencyExchangeRateValue>();
                            _cache.Add(exchangeRate.Key.Date, cachedExchangeRates);
                        } 

                        cachedExchangeRates.Add(exchangeRate.Value);
                    }
                }
            }
        }

        private async Task<IDictionary<DateTime, IList<CurrencyExchangeRateValue>>> RetrieveCacheWorkingCopy(DateTime? minUsedDate = null)
        {
            // Rebuilding the cache, if needed. Should be done thread-safe.
            return await LockCache(
                async () => {
                    if(!_cache.Keys.Any() || _cache.Keys.Max().Date < DateTime.UtcNow.Date)
                    {
                        //Rebuild the cache if it has become outdated. This could happen when we retain the cache for more than a day.
                        await RebuildCache(minUsedDate);

                        //Return a working-copy of the cache, that way the cache can be rebuild while some other thread is still using the previous cache.
                        return new ReadOnlyDictionary<DateTime, IList<CurrencyExchangeRateValue>>(_cache);
                    }
                    
                    if (!minUsedDate.HasValue || _cache.ContainsKey(minUsedDate.Value))
                    {
                        //Return a working-copy of the cache, that way the cache can be rebuild while some other thread is still using the previous cache.
                        return new ReadOnlyDictionary<DateTime, IList<CurrencyExchangeRateValue>>(_cache);
                    }
                    
                    await RebuildCache(minUsedDate);

                    //Return a working-copy of the cache, that way the cache can be rebuild while some other thread is still using the previous cache.
                    return new ReadOnlyDictionary<DateTime, IList<CurrencyExchangeRateValue>>(_cache);
                }
            );
        }

        private TReturn LockCache<TReturn>(Func<TReturn> action)
        {
            lock (lockObject)
            {
                return action.Invoke();
            }
        }
    }
}
