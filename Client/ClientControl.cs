using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Client.accept;
using MiddleProject;
using MiddleProject.model;

namespace Client
{
    public class ClientControl
    {

        private int clientPort; //本机端口
        private int serverPort;

        //本地侦听网段
        private IPEndPoint serverIp;
        public Dictionary<string, SocketUDP> clientDic = new Dictionary<string, SocketUDP>();

        public event ReceiveMsgDelegate receiveMsgCallBack;
        
        public ClientControl(int clientPort, int serverPort)
        {
            this.clientPort = clientPort;
            this.serverPort = serverPort;
        }
        
        public void BeginReceive()
        {
            List<string> address = ToolForIp.getLocalAddress();
            if (address.Count == 0)
                return;
            foreach (string _address in address)
            {
                SocketUDP client = new SocketUDP(_address, clientPort);
                client.Ac_ReceiveMsg += AC_ReceiveMsgCallBack;

                lock (clientDic)
                {
                    addClient(_address,client);
                }
  
                LogUtil.Log.InfoFormat("{0} 开始侦听...",_address);
                client.SyncReceiveMessage();
            }
        }

        /// <summary>
        /// 处理接收到的信息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="udp"></param>
        private void AC_ReceiveMsgCallBack(Result result)
        {
            if(!BlockKey.IsBlock(result.data))
                LogUtil.Log.DebugFormat("收到[{0}]:{1}",result.ipEndPoint,result.data);
            
            OrderCode code = result.data.code;
            if (code == OrderCode.ServerResponse)
                conSuccess(result);
                
            if (receiveMsgCallBack != null)
                receiveMsgCallBack(result);
        }

        private void conSuccess(Result result)
        {
            LogUtil.Log.InfoFormat("连接服务器 [{0}] 成功！！",result.ipEndPoint);
            addServer(result.ipEndPoint);
            SendToServer(new Data(OrderCode.HeartBeat));
        }
        
        public void connect()
        {
            lock (clientDic)
            {
                foreach (SocketUDP client in clientDic.Values)
                {
                    try
                    {
                        client.Send(
                            new Data(OrderCode.ClientRquest), 
                            new IPEndPoint(IPAddress.Broadcast, serverPort));
                    }
                    catch (Exception e)
                    {
                        LogUtil.Log.Error(e.Message);
                    }
                }
            }
        }

        public bool IsConnected()
        {
            return serverIp!=null;
        }

        private void addServer(IPEndPoint ip)
        {
            serverIp = ip;
        }

        public void removeServer()
        {
            serverIp = null;
        }

        private void addClient(string ip, SocketUDP udp)
        {
            lock (clientDic)
            {
                string id = ToolForIp.getChildIp(ip,3);
                if(!clientDic.ContainsKey(id))
                    clientDic.Add(id,udp);
            }
            
        }

        private SocketUDP getClient(IPEndPoint ip)
        {
            lock (clientDic)
            {
                string id = ToolForIp.getChildIp(ip.Address.ToString(),3);
                SocketUDP client;
                clientDic.TryGetValue(id, out client);
                return client;
            }
            
        }

        public IPEndPoint getServer()
        {
            return serverIp;
        }

        public void SendToServer(Data data)
        {
            if(serverIp==null)
                return;
            SocketUDP udp = getSocket(serverIp);
            udp.Send(data,serverIp);
        }
        
        private SocketUDP getSocket(IPEndPoint ip)
        {
            string id = ToolForIp.getChildIp(ip.Address.ToString(), 3);
            SocketUDP udp;
            clientDic.TryGetValue(id, out udp);
            return udp;
        }

        public void Close()
        {
            SendToServer(new Data(OrderCode.Close));
            foreach (string key in clientDic.Keys)
                clientDic[key].Close();
            
            clientDic.Clear();
            removeServer();
            (AssemblyHandler.GetInstance<HeartBeat>() as HeartBeat).Close();
        }

    }
}