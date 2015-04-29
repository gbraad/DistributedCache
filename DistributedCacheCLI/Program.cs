using System;
using DistributedCache;
using DistributedCache.Shared;

namespace DistributedCache
{
    class Program
    {
        static void Main(string[] args)
        {
            var cacheHelper = new AppFabricCache<Session>();

            for (var i = 0; i < 1000; i++)
            {
                cacheHelper.Set(i.ToString(), new Session { Id = i.ToString()}, new TimeSpan(0, 0, 2, 0));
                Console.WriteLine("Put: " + i);
            }

            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Get: " + cacheHelper.Get(i.ToString()).Id);
            }

	    Console.WriteLine("Press Play On Tape to close.");
            Console.ReadKey();
        }
    }
}
