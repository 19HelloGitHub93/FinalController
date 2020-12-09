using System;
using System.Net;

namespace MiddleProject.model
{
    public class Heart
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