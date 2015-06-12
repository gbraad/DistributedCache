using System;
using System.Configuration;
using StackExchange.Redis;

namespace DistributedCache.Providers
{
    internal class RedisCacheProvider
    {
        private static ConnectionMultiplexer connection;

        private static readonly string REDIS_SERVER_HOSTNAME =
            ConfigurationManager.AppSettings["REDIS_SERVER_HOSTNAME"];

        private static readonly int REDIS_SERVER_PORT =
            Int32.Parse(ConfigurationManager.AppSettings["REDIS_SERVER_PORT"]);

        public static IDatabase Cache
        {
            get {
                if (connection != null)
                    connection = ConnectionMultiplexer.Connect(string.Format("{0}:{1}", REDIS_SERVER_HOSTNAME, REDIS_SERVER_PORT));

                return connection.GetDatabase();
            }
        }
    }
}
