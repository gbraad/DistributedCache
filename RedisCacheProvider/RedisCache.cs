using System;
using System.Configuration;
using DistributedCache.Providers;
using Newtonsoft.Json;

namespace DistributedCache
{
    public class RedisCache<T> : ICache<T>
    {
        private static readonly string REDIS_CACHENAME = ConfigurationManager.AppSettings["REDIS_CACHENAME"];

        public string IdToUrn(string id)
        {
            return String.Format("urn:{0}:{1}", REDIS_CACHENAME, id);
        }

        public void Set(string key, T value)
        {
            RedisCacheProvider.Cache.StringSet(key, JsonConvert.SerializeObject(value));
        }

        public void Set(string key, T value, TimeSpan expirationTimeSpan)
        {
            RedisCacheProvider.Cache.StringSet(key, JsonConvert.SerializeObject(value), expirationTimeSpan);
        }

        public void Remove(string key)
        {
            RedisCacheProvider.Cache.KeyDelete(key);
        }

        public T Get(string key)
        {
            return JsonConvert.DeserializeObject<T>(RedisCacheProvider.Cache.StringGet(key));
        }
    }
}
