using System.Net;
using Newtonsoft.Json;

namespace MiddleProject.model
{
    public class Result
    {
        public Data data;
        public IPEndPoint ipEndPoint;
        
        public Result(){}

        public Result(Data data,string address, int port)
        {
            this.data = data;
            this.ipEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
        }

        public Result(Data data, IPEndPoint ipEndPoin)
        {
            this.data = data;
            this.ipEndPoint = ipEndPoin;
        }
    }
}