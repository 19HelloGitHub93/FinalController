using Newtonsoft.Json;

namespace MiddleProject.model
{
    public class Result
    {
        public string address;
        public int port;
        public Data data;
        
        public Result(){}

        public Result(string address, int port, Data data)
        {
            this.address = address;
            this.port = port;
            this.data = data;
        }
    }
}