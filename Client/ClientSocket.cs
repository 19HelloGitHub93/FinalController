using System;
using System.Collections.Generic;
using System.Net;
using MiddleProject;
using MiddleProject.model;

namespace Client
{
    public class ClientSocket
    {
        private int clientPort; //本机端口
        private int serverPort;

        //本地侦听网段
        private Dictionary<string, SocketUDP> clientSocketDic = new Dictionary<string, SocketUDP>();
        private Dictionary<string,IPEndPoint> serverIpDic = new Dictionary<string, IPEndPoint>();
        public event ReceiveMsgDelegate receiveMsgCallBack;
        
        public ClientSocket(int clientPort, int serverPort)
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
                clientSocketDic.Add(ToolForIp.getChildIp(_address,3),client);
                
                LogUtil.Log.InfoFormat("{0} 开始侦听...",_address);
                client.SyncReceiveMessage();

                try
                {
                    if(client.ApplicationIsQuitting)
                        break;
                    client.Send(
                        new Data(OrderCode.ClientRquest,null), 
                        new IPEndPoint(IPAddress.Broadcast, serverPort));
                }
                catch (Exception e)
                {
                    LogUtil.Log.Error(e.Message);
                }
                
                /*
                 string ipHead = _address.Remove(_address.LastIndexOf('.') + 1);
                 int ipEnd = Int32.Parse(_address.Remove(0, ipHead.Length));
                 
                 for (int i = 1; i < 255; i++)
                {
                    string tempIp = string.Format("{0}{1}", ipHead, i);
                    try
                    {
                        if(client.ApplicationIsQuitting)
                           break;
                        client.Send(new Data(OrderCode.Connect,null), tempIp, serverPort);
                    }
                    catch (Exception e)
                    {
                        LogUtil.Log.Error(e.Message);
                    }
                }*/
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

        private void addServer(IPEndPoint ip)
        {
            string id = ToolForIp.getChildIp(ip.Address.ToString(), 3);
            if (!serverIpDic.ContainsKey(id))
                serverIpDic.Add(id,ip);
        }

        public void reconnect()
        {
            SendToServer(new Data(OrderCode.ClientRquest));
        }

        public void SendToServer(Data data)
        {
            foreach ( IPEndPoint serverIp in serverIpDic.Values)
            {
                SocketUDP udp = getSocket(serverIp);
                udp.Send(data,serverIp);
            }
        }

        private SocketUDP getSocket(IPEndPoint ip)
        {
            string id = ToolForIp.getChildIp(ip.Address.ToString(), 3);
            SocketUDP udp;
            clientSocketDic.TryGetValue(id, out udp);
            return udp;
        }

        public void Close()
        {
            //LogUtil.Log.InfoFormat("释放所有网段侦听...");
            
            SendToServer(new Data(OrderCode.Close));
            foreach (string key in clientSocketDic.Keys)
                clientSocketDic[key].Close();
            
            clientSocketDic.Clear();
            serverIpDic.Clear();
        }

    }
}