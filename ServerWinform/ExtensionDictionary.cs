using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MiddleProject;
using MiddleProject.utils;

namespace ServerWinform
{
    public static class ExtensionDictionary
    {
        public static List<KeyValuePair<IPEndPoint, T>> sort<T>(this Dictionary<IPEndPoint, T> dic)
        {
            List<KeyValuePair<IPEndPoint,T>> keyValuePairs = dic.ToList();
            keyValuePairs.Sort((a, b) =>
            {
                int aId = Convert.ToInt32(ToolForIp.getChildIp(a.Key.Address.ToString(), 4));
                int bId = Convert.ToInt32(ToolForIp.getChildIp(b.Key.Address.ToString(), 4));
                var o = aId - bId;
                return o;
            });
            return keyValuePairs;
        }
    }
}