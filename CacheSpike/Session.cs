using System;

namespace CacheSpike
{
    [Serializable]
    public class Session
    {
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string id = "";
    }
}
