using System;
using System.Configuration;
using CacheSpike.Model;

namespace CacheSpike
{
    public class RedisCacheHelper
    {
        private static readonly string REDIS_CACHENAME = ConfigurationManager.AppSettings["REDIS_CACHENAME"];


        public bool Add(string sessionId)
        {
            try
            {
               var list = RedisCacheProvider.Cache.As<Session>();

                Session session = new Session();
                session.Id = sessionId;

                var urn = String.Format("urn:{0}:{1}", REDIS_CACHENAME, sessionId);
                list.SetEntry(urn, session, new TimeSpan(0, 0, 2, 0));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Session Get(string sessionId)
        {
            try
            {
                var urn = String.Format("urn:{0}:{1}", REDIS_CACHENAME, sessionId);
                var list = RedisCacheProvider.Cache.As<Session>();
                return list.GetValue(urn);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}