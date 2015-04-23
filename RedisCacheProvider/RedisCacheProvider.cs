using System;
using System.Collections.Generic;
using System.Configuration;
using ServiceStack.Redis;

namespace CacheSpike
{
    public class RedisCacheProvider
    {
        private static RedisClient cacheClient = null;

        private static readonly string REDIS_SERVER_HOSTNAME =
            ConfigurationManager.AppSettings["REDIS_SERVER_HOSTNAME"];

        private static readonly int REDIS_SERVER_PORT =
            Int32.Parse(ConfigurationManager.AppSettings["REDIS_SERVER_PORT"]);

        private static readonly string REDIS_SERVER_PASSWORD = ConfigurationManager.AppSettings["REDIS_SERVER_PASSWORD"];

        public static RedisClient Cache
        {
            get { return GetCache(); }
        }

        private static RedisClient GetCache()
        {
            if (cacheClient != null)
                return cacheClient;

            Console.WriteLine(REDIS_SERVER_HOSTNAME);
            Console.WriteLine(REDIS_SERVER_PORT);

            cacheClient = new RedisClient(REDIS_SERVER_HOSTNAME, REDIS_SERVER_PORT);
            //, REDIS_SERVER_PASSWORD);

            return cacheClient;
        }
    }
}