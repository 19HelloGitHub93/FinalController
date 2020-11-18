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

        public void connRemoteAddress(int millisecondsTimeout)
        {
            List<string> address = getLocalAddress();
            if (address.Count == 0)
                return;

            Dictionary<string, SocketUDP> broadMsgDic = new Dictionary<string, SocketUDP>();

            foreach (string _address in address)
            {
                string ipHead = _address.Remove(_address.LastIndexOf('.') + 1);
                int ipEnd = Int32.Parse(_address.Remove(0, ipHead.Length));
                
                SocketUDP client = new SocketUDP(_address, clientPort);
                client.Ac_ReceiveMsg += AcReceiveMsg;
                broadMsgDic.Add(getChildIp(_address,3),client);
                
                Console.WriteLine("{0}开始侦听...",_address);
                client.SyncReceiveMessage();
                for (int i = 1; i < 255; i++)
                {
                    string tempIp = string.Format("{0}{1}", ipHead, i);
                    try
                    {
                        Console.WriteLine(tempIp);
                        client.Send(clientSignal, tempIp, serverPort);
                        Console.WriteLine("发送{0}到{1}:{2}",clientSignal,tempIp,serverPort);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            
            Thread.Sleep(millisecondsTimeout);
            foreach (string key in broadMsgDic.Keys)
            {
                if (!broadMsgDic[key].hasResponse)
                {
                    Console.WriteLine("{0}释放网段...",key);
                    broadMsgDic[key].Close();
                }
            }
        }

        private void AcReceiveMsg(SocketUDP.Result result)
        {
            if (result.message.Equals(serverSignal))
            {
                string ip = string.Format("{0}:{1}", result.address, result.port);
                Console.WriteLine("收到{0}：{1}",ip,result.message);
            }
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
    }
}