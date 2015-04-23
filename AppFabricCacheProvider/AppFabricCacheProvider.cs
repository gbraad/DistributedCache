using System;
using Microsoft.ApplicationServer.Caching;
using System.Collections.Generic;
using System.Configuration;

namespace CacheSpike
{
    public class AppFabricCacheProvider
    {
        private static DataCacheFactory dataCacheFactory = null;
        private static DataCache dataCache = null;

        private static readonly string APPFABRIC_SERVER_HOSTNAME =
            ConfigurationManager.AppSettings["APPFABRIC_SERVER_HOSTNAME"];

        private static readonly int APPFABRIC_SERVER_PORT =
            Int32.Parse(ConfigurationManager.AppSettings["APPFABRIC_SERVER_PORT"]);

        private static readonly string APPFABRIC_CACHENAME = ConfigurationManager.AppSettings["APPFABRIC_NAME"];

        public static DataCache Cache
        {
            get { return GetCache(); }
        }

        private static DataCache GetCache()
        {
            if (dataCache != null)
                return dataCache;

            Console.WriteLine(APPFABRIC_SERVER_HOSTNAME);
            Console.WriteLine(APPFABRIC_SERVER_PORT);

            var servers = new List<DataCacheServerEndpoint>(1)
            {
                new DataCacheServerEndpoint(APPFABRIC_SERVER_HOSTNAME, APPFABRIC_SERVER_PORT)
            };

            var configuration = new DataCacheFactoryConfiguration
            {
                Servers = servers,
                LocalCacheProperties = new DataCacheLocalCacheProperties()
            };

            DataCacheClientLogManager.ChangeLogLevel(System.Diagnostics.TraceLevel.Off);

            dataCacheFactory = new DataCacheFactory(configuration);
            dataCache = dataCacheFactory.GetCache(APPFABRIC_CACHENAME);

            return dataCache;
        }
    }
}