using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace FinalController
{
    public class BroadcastsAddress
    {

        private int clientPort;//本机端口
        private int serverPort;
        private string clientSignal;//本地信号
        private string serverSignal;//远端信号

        public BroadcastsAddress(int clientPort,int serverPort)
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
            
            foreach (string _address in address)
            {
                string ipHead = _address.Remove(_address.LastIndexOf('.')+1);
                int ipEnd = Int32.Parse(_address.Remove(0, ipHead.Length));
                
                SocketUDP client = new SocketUDP(_address,clientPort);
                try
                {
                    Task<string> findIpTask = new Task<string>(() =>
                    {
                        SocketUDP.Result respone;
                        while (true)
                        {
                            respone = client.ReceiveMessage();
                            if (respone.message.Equals(serverSignal))
                            {
                                string ip = string.Format("{0}:{1}", respone.address, respone.port);
                                return ip;
                            }
                        }
                    });

                    findIpTask.Start();

                    for (int i = 1; i <= 255; i++)
                    {
                        string ip = string.Format("{0}{1}", ipHead, i);
                        client.Send(clientSignal, ip, serverPort);
                    }

                    findIpTask.Wait(millisecondsTimeout);
                    return findIpTask.Result;

                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    client.Close();
                }
            }
            
            return String.Empty;
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