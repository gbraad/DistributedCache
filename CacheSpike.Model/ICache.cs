using System;

namespace CacheSpike
{
    public interface ICache<T>
    {
        T Get(string key);
        void Set(string key, T obj);
        //void Remove(string key);
    }
}
