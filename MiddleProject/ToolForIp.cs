using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace MiddleProject
{
    public class ToolForIp
    {
        /// <summary>
        /// 获取本地主Ip
        /// </summary>
        /// <returns></returns>
        public static string getlocalIp()
        {
            Socket sk = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            // 获取百度的ip
            IPAddress ip_add = Dns.GetHostAddresses("www.baidu.com")[0];
            //连接百度的地址
            sk.Connect(ip_add, 80);
            //获取socket使用的本机ip
            string end_p = sk.LocalEndPoint.ToString();
            return end_p.Split(':')[0];
        }
        
        /// <summary>
        /// 截取ip子网段
        /// </summary>
        /// <param name="ip">源ip</param>
        /// <param name="index">网段位置</param>
        /// <returns></returns>
        public static string getChildIp(string ip, int index)
        {
            string[] childs = ip.Split('.');
            if (childs.Length != 4)
                return String.Empty;
            return childs[index - 1];
        }
        
        //获取本地Ip集
        public static List<string> getLocalAddress()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);

            List<string> ips = new List<string>();
            for (var i = 0; i < ipHostEntry.AddressList.Length; i++)
            {
                IPAddress curIp = ipHostEntry.AddressList[i];
                if (curIp.AddressFamily == AddressFamily.InterNetwork)
                {
                    ips.Add(curIp.ToString());
                }
            }

            return ips;
        }

    }
}