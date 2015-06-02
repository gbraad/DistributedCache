using System;
using System.Configuration;
using StackExchange.Redis;

namespace DistributedCache.Providers
{
    internal class RedisCacheProvider
    {
        private static ConnectionMultiplexer connection;
        private static IDatabase database;

        private static readonly string REDIS_SERVER_HOSTNAME =
            ConfigurationManager.AppSettings["REDIS_SERVER_HOSTNAME"];

        private static readonly int REDIS_SERVER_PORT =
            Int32.Parse(ConfigurationManager.AppSettings["REDIS_SERVER_PORT"]);


        public static IDatabase Cache
        {
            get { return GetCache(); }
        }

        private static IDatabase GetCache()
        {
            if (database != null)
                return database;

            connection = ConnectionMultiplexer.Connect(string.Format("{0}:{1}", REDIS_SERVER_HOSTNAME, REDIS_SERVER_PORT));

            Console.WriteLine(REDIS_SERVER_HOSTNAME);
            Console.WriteLine(REDIS_SERVER_PORT);

            database = connection.GetDatabase();

            return database;
        }
    }
}
