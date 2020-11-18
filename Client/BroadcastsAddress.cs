using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

//using System.Threading.Tasks;

namespace Client
{
    public class BroadcastsAddress
    {
        private int clientPort; //本机端口
        private int serverPort;
        private string clientSignal; //本地信号
        private string serverSignal; //远端信号

        public BroadcastsAddress(int clientPort, int serverPort)
        {
            this.clientPort = clientPort;
            this.serverPort = serverPort;
            clientSignal = clientPort.ToString();
            serverSignal = serverPort.ToString();
        }

        public string getRemoteAddress(int millisecondsTimeout)
        {
            List<string> address = getLocalAddress();
            if (address.Count == 0)
                return String.Empty;

            string ip = String.Empty;

//            Task task_receiveMessage = null;
//            Task task_broadMessage = null;

            Dictionary<string, Thread> broadMsgThreadDic = new Dictionary<string, Thread>();

            foreach (string _address in address)
            {
                string ipHead = _address.Remove(_address.LastIndexOf('.') + 1);
                int ipEnd = Int32.Parse(_address.Remove(0, ipHead.Length));
                SocketUDP client = new SocketUDP(_address, clientPort);
                Thread t = new Thread(() =>
                {
                    try
                    {
                        while (true)
                        {
                            SocketUDP.Result respone = client.ReceiveMessage();
                            if (respone.message.Equals(serverSignal))
                            {
                                ip = string.Format("{0}:{1}", respone.address, respone.port);
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        client.Close();
                    }
                });
                
                broadMsgThreadDic.Add(getChildIp(_address,3),t);
                
                Console.WriteLine("{0}开始侦听...",_address);
                t.Start();

                for (int i = 1; i <= 255; i++)
                {
                    string tempIp = string.Format("{0}{1}", ipHead, i);
                    client.Send(clientSignal, tempIp, serverPort);
                }
                
            }
            
            Thread.Sleep(millisecondsTimeout);
            foreach (string key in broadMsgThreadDic.Keys)
            {
                if (ip == String.Empty||!key.Equals(getChildIp(ip, 3)))
                {
                    Console.WriteLine("{0}释放网段...",key);
                    broadMsgThreadDic[key].Abort();
                }
            }

            return ip;
        }

        //获取本地Ip集
        private List<string> getLocalAddress()
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

        /// <summary>
        /// 截取ip子网段
        /// </summary>
        /// <param name="ip">源ip</param>
        /// <param name="index">网段位置</param>
        /// <returns></returns>
        private string getChildIp(string ip, int index)
        {
            string[] childs = ip.Split('.');
            if (childs.Length != 4)
                return String.Empty;
            return childs[index - 1];
        }

        /*private bool PingIp(string strIP)
        {
            bool bRet = false;
            try
            {
                Ping pingSend = new Ping();
                PingReply reply = pingSend.Send(strIP, 100);
                if (reply.Status == IPStatus.Success)
                    bRet = true;
            }
            catch (Exception e)
            {
                bRet = false;
                Console.WriteLine(e.Message);
            }

            return bRet;
        }*/
    }
}