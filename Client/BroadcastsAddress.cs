using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Client
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
            
            string ip = String.Empty;
            
            Task task_receiveMessage = null;
            Task task_broadMessage = null;
                
            foreach (string _address in address)
            {
                string ipHead = _address.Remove(_address.LastIndexOf('.')+1);
                int ipEnd = Int32.Parse(_address.Remove(0, ipHead.Length));
                
                SocketUDP client = new SocketUDP(_address,clientPort);
                
                try
                {
                    bool beginReceive = true;
                    
                    task_receiveMessage = new Task(() =>
                    {
                        SocketUDP.Result respone;
                        while (beginReceive)
                        {
                            respone = client.ReceiveMessage();
                            if (respone.message.Equals(serverSignal))
                            {
                                ip = string.Format("{0}:{1}", respone.address, respone.port);
                            }
                        }
                    });
                    
                    task_broadMessage = new Task(() =>
                    {
                        for (int i = 1; i <= 255; i++)
                        {
                            string tempIp = string.Format("{0}{1}", ipHead, i);
                            client.Send(clientSignal, tempIp, serverPort);
                        }

                        beginReceive = false;
                        client.Close();
                    });
                    
                    task_receiveMessage.Start();
                    task_broadMessage.Start();
                    //task_broadMessage.Wait(millisecondsTimeout);
                    task_receiveMessage.Wait(millisecondsTimeout);
//                    Thread.Sleep(millisecondsTimeout);
//                    return task_receiveMessage.Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //client.Close();
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