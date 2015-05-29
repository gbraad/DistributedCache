using System;
using System.Web;
using System.Web.Caching;

namespace DistributedCache
{
    public class AspNetCache<T> : ICache<T>
    {
        private readonly Cache aspNetCache = HttpRuntime.Cache;

        public T Get(string key)
        {
            return (T)aspNetCache.Get(key);
        }

        public void Set(string key, T obj)
        {
            aspNetCache.Add(key,
            obj,
            null,
            Cache.NoAbsoluteExpiration,
            Cache.NoSlidingExpiration,
            CacheItemPriority.Default,
            null);
        }

        public void Set(string key, T obj, TimeSpan expirationTimeSpan)
        {
            aspNetCache.Add(key,
            obj,
            null,
            DateTime.Now.Add(expirationTimeSpan),
            Cache.NoSlidingExpiration,
            CacheItemPriority.Default,
            null);
        }

        public void Remove(string key)
        {
            aspNetCache.Remove(key);
        }
    }
}