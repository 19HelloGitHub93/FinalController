using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MiddleProject.model
{
    public class Data
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public OrderCode code;
        
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string msg;

        public Data(){}
        
        public Data(OrderCode code)
        {
            this.code = code;
        }

        public Data(OrderCode code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}