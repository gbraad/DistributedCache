using System;

namespace CacheSpike.Model
{
    [Serializable]
    public class Session
    {
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string id;
    }
}