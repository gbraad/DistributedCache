using System;
using Microsoft.ApplicationServer.Caching;
using DistributedCache.Providers;

namespace DistributedCache
{
    public class AppFabricCache<T> : ICache<T>
    {

        public void Set(string key, T value)
        {
            Set(key, value, default(TimeSpan));
        }

        public void Set(string key, T value, TimeSpan expirationTimeSpan)
        {

            var token = (T)AppFabricCacheProvider.Cache.Get(key);
            if (token == null)
            {
                AppFabricCacheProvider.Cache.Add(key, value, expirationTimeSpan);
            }
            else
            {
                AppFabricCacheProvider.Cache[key] = value;
                if (expirationTimeSpan != default (TimeSpan))
                {
                    AppFabricCacheProvider.Cache.ResetObjectTimeout(key, expirationTimeSpan);
                }
            }
        }

        public void Remove(string key)
        {
            AppFabricCacheProvider.Cache.Remove(key);
        }

        public T Get(string key)
        {
            return (T)AppFabricCacheProvider.Cache.Get(key);
        }
    }
}
