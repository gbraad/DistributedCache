using System;
using System.Configuration;

namespace CacheSpike
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

            list.SetEntry(key, value, new TimeSpan(0, 0, 2, 0));
        }

        public T Get(string key)
        {
            var list = RedisCacheProvider.Cache.As<T>();
            return list.GetValue(key);
        }
    }
}