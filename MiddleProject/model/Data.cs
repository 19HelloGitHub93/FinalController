using Newtonsoft.Json;

namespace MiddleProject.model
{
    public class Data
    {
        public OrderCode code;
        public string msg;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}