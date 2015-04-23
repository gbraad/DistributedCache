using System;
using CacheSpike.Model;

namespace CacheSpike
{
    public class AppFabricCacheHelper
    {

        public bool Add(string sessionId)
        {
            try
            {
                Session session = new Session();
                session.Id = sessionId;

                AppFabricCacheProvider.Cache.Add(sessionId, session, new TimeSpan(0, 0, 2, 0));
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
                return (Session)AppFabricCacheProvider.Cache.Get(sessionId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}