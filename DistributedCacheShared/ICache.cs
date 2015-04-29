using System;

namespace DistributedCache
{
    public interface ICache<T>
    {
        T Get(string key);
        void Set(string key, T obj);
        void Set(string key, T obj, TimeSpan expirationTimeSpan);
        void Remove(string key);
    }
}
