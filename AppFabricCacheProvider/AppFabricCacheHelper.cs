using System;

namespace CacheSpike
{
    public class AppFabricCacheHelper<T> : ICache<T>
    {

        public void Set(string key, T value)
        {
            AppFabricCacheProvider.Cache.Add(key, value, new TimeSpan(0, 0, 2, 0));
        }

        public T Get(string key)
        {
            return (T)AppFabricCacheProvider.Cache.Get(key);
        }
    }
}