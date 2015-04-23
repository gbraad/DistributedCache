using System;
using CacheSpike;

namespace CacheSpikeCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var cacheHelper = new RedisCacheHelper();

            for (var i = 0; i < 1000; i++)
            {
                cacheHelper.Add(i.ToString());
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
