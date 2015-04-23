using System;
using CacheSpike;
using CacheSpike.Model;

namespace CacheSpikeCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var cacheHelper = new AppFabricCacheHelper<Session>();

            for (var i = 0; i < 1000; i++)
            {
                cacheHelper.Set(i.ToString(), new Session { Id = i.ToString()});
                Console.WriteLine("Put: " + i);
            }

            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Get: " + cacheHelper.Get(i.ToString()).Id);
            }

            Console.ReadKey();
        }
    }
}
