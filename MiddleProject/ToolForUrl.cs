namespace MiddleProject
{
    public class ToolForUrl
    {
        /// <summary>
        /// 获取路径文件夹名
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string getDirName(string path)
        {
            int index = path.LastIndexOf('\\');
            string parentUrl = null;
            if (index > 0)
            {
                parentUrl = path.Remove(index + 1, path.Length - 1- index);
                return parentUrl;
            }
            return parentUrl;
        }
        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filterExten">过滤扩展名</param>
        /// <returns></returns>
        public static string getDirEndName(string path,bool filterExten=false)
        {
            string endName = null;
            int index = path.LastIndexOf('\\');
            if (index >=0)
            {
                endName = path.Remove(0, index + 1);
            }

            if (filterExten)
            {
                endName = filterEnd(endName);
            }

            return endName;
        }

        /// <summary>
        /// 去除扩展名
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string filterEnd(string path)
        {
            string[] split = path.Split('.');
            return split[split.Length - 2];
        }
    }
}