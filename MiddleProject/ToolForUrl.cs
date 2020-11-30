namespace MiddleProject
{
    public class ToolForUrl
    {
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
                endName = endName.Split('.')[0];
            }

            return endName;
        }
    }
}