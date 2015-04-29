using System;
using System.Configuration;
using DistributedCache.Providers;

namespace DistributedCache
{
    public class RedisCacheHelper<T> : ICache<T>
    {
        private static readonly string REDIS_CACHENAME = ConfigurationManager.AppSettings["REDIS_CACHENAME"];

        public string IdToUrn(string id)
        {
            return String.Format("urn:{0}:{1}", REDIS_CACHENAME, id);
        }

        public void Set(string key, T value)
        {
            var list = RedisCacheProvider.Cache.As<T>();

            list.SetEntry(key, value);
        }

        public void Set(string key, T value, TimeSpan expirationTimeSpan)
        {
            var list = RedisCacheProvider.Cache.As<T>();

            list.SetEntry(key, value, expirationTimeSpan);
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public T Get(string key)
        {
            var list = RedisCacheProvider.Cache.As<T>();
            return list.GetValue(key);
        }
    }
}
