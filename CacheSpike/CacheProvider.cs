using System;
using Microsoft.ApplicationServer.Caching;
using System.Collections.Generic;
using System.Configuration;

namespace CacheSpike
{
    public class CacheProvider
    {
        private static DataCacheFactory dataCacheFactory = null;
        private static DataCache dataCache = null;

        private static readonly string DATACACHE_SERVER_HOSTNAME =
            ConfigurationManager.AppSettings["DATACACHE_SERVER_HOSTNAME"];

        private static readonly int DATACACHE_SERVER_PORT =
            Int32.Parse(ConfigurationManager.AppSettings["DATACACHE_SERVER_PORT"]);

        private static readonly string DATACACHE_NAME = ConfigurationManager.AppSettings["DATACACHE_NAME"];

        public static DataCache Cache
        {
            get { return GetCache(); }
        }

        private static DataCache GetCache()
        {
            if (dataCache != null)
                return dataCache;

            Console.WriteLine(DATACACHE_SERVER_HOSTNAME);
            Console.WriteLine(DATACACHE_SERVER_PORT);

            var servers = new List<DataCacheServerEndpoint>(1)
            {
                new DataCacheServerEndpoint(DATACACHE_SERVER_HOSTNAME, DATACACHE_SERVER_PORT)
            };

            var configuration = new DataCacheFactoryConfiguration
            {
                Servers = servers,
                LocalCacheProperties = new DataCacheLocalCacheProperties()
            };

            DataCacheClientLogManager.ChangeLogLevel(System.Diagnostics.TraceLevel.Off);

            dataCacheFactory = new DataCacheFactory(configuration);
            dataCache = dataCacheFactory.GetCache(DATACACHE_NAME);

            return dataCache;
        }
    }
}