using System;
using System.Net;

namespace Server
{
    public class Client
    {
        public IPEndPoint ipEndPoint;
        public int lostCount;

        public DateTime lastTime;
        public DateTime activeTime;

        public double getTimeinterval()
        {
            return (activeTime - lastTime).TotalSeconds;
        }

        public void reset()
        {
            lostCount = 0;
            this.activeTime = DateTime.Now;
            this.lastTime = DateTime.Now;
        }
    }
}