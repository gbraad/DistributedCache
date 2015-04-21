using System;

namespace CacheSpike
{
    public class SessionCacheHelper
    {

        public bool Add(string sessionId)
        {
            try
            {
                Session session = new Session();
                session.Id = sessionId;

                CacheProvider.Cache.Add(sessionId, session, new TimeSpan(0, 0, 2, 0));
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
                return (Session)CacheProvider.Cache.Get(sessionId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}