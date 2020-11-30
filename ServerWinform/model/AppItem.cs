using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServerWinform.model
{
    public enum AppType
    {
        /// <summary>
        /// 应用
        /// </summary>
        Application,
        /// <summary>
        /// 批处理
        /// </summary>
        Bat
    }

    public class AppItem
    {
        public string name;
        [JsonConverter(typeof(StringEnumConverter))]
        public AppType appType;
        
        public string data;

        public AppItem()
        {
            this.appType = AppType.Bat;
        }
        
        public AppItem(string name,string data,AppType appType)
        {
            this.appType = appType;
            this.name = name;
            this.data = data;
        }
    }
}