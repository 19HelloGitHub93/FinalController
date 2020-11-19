using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using MiddleProject;

namespace Client
{
    public class ClientSocket
    {
        private int clientPort; //本机端口
        private int serverPort;
        private string clientSignal; //本地信号
        private string serverSignal; //远端信号
        
        private Dictionary<string, SocketUDP> serverDic = new Dictionary<string, SocketUDP>();
        public event ReceiveMsgDelegate receiveMsgCallBack;
        
        
        public ClientSocket(int clientPort, int serverPort)
        {
            this.clientPort = clientPort;
            this.serverPort = serverPort;
            clientSignal = clientPort.ToString();
            serverSignal = serverPort.ToString();
        }

        /// <summary>
        /// 旧方法
        /// </summary>
        public void BeginReceive()
        {
            List<string> address = ToolForIp.getLocalAddress();
            if (address.Count == 0)
                return;

            foreach (string _address in address)
            {
                string ipHead = _address.Remove(_address.LastIndexOf('.') + 1);
                int ipEnd = Int32.Parse(_address.Remove(0, ipHead.Length));
                
                SocketUDP client = new SocketUDP(_address, clientPort);
                client.Ac_ReceiveMsg += AC_ReceiveMsgCallBack;
                serverDic.Add(ToolForIp.getChildIp(_address,3),client);
                
                Console.WriteLine("{0}开始侦听...",_address);
                client.SyncReceiveMessage();
                for (int i = 1; i < 255; i++)
                {
                    string tempIp = string.Format("{0}{1}", ipHead, i);
                    try
                    {
                        if(client.ApplicationIsQuitting)
                           break;
                        client.Send(clientSignal, tempIp, serverPort);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 处理接收到的信息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="socketUdp"></param>
        private void AC_ReceiveMsgCallBack(SocketUDP.Result result,SocketUDP socketUdp)
        {
            string ip = string.Format("{0}:{1}", result.address, result.port);
            string msg = result.message;
            Console.WriteLine("收到{0}：{1}",ip,msg);
            if (receiveMsgCallBack != null)
                receiveMsgCallBack(result, socketUdp);
        }

        public void Close()
        {
            Console.WriteLine("释放所有网段侦听...");
            foreach (string key in serverDic.Keys)
            {
                serverDic[key].Close();
            }
        }

    }
}