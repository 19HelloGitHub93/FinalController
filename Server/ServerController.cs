using System;
using System.Collections.Generic;
using System.Net;
using log4net;
using MiddleProject;
using MiddleProject.model;
using Server.accept;

namespace Server
{
    public class ServerController
    {
        private int port;//本机端口
        private SocketUDP _server;
        private string _ip;

        public string Ip => _ip;
        public int Port => port;

        private Dictionary<string,IPEndPoint> clientDic = new Dictionary<string, IPEndPoint>();
        public event ReceiveMsgDelegate receiveMsgCallBack;

        public ServerController(int serverPort)
        {
            this.port = serverPort;
            this._ip = IPAddress.Any.ToString();
            _server = new SocketUDP(_ip,port);
        }

        public void BeginReceive()
        {
            _server.Ac_ReceiveMsg += AC_ReceiveMsgCallBack;
            _server.SyncReceiveMessage();
        }

        private void AC_ReceiveMsgCallBack(Result result)
        {
            if(!BlockKey.IsBlock(result.data))
                LogUtil.Log.DebugFormat("收到[{0}]:{1}",result.ipEndPoint,result.data);
            
            OrderCode code = result.data.code;
            if (code == OrderCode.ClientRquest)
            {
                Data _data = new Data()
                {
                    code = OrderCode.ServerResponse,
                    msg = "success",
                };
                _server.Send(_data,result.ipEndPoint);
                _server.Send(new Data(OrderCode.HeartBeat),result.ipEndPoint);
                
                addClient(result.ipEndPoint);
            }
            
            if (receiveMsgCallBack != null)
                receiveMsgCallBack(result);
        }

        public void Send(Data data,IPEndPoint ipEndPoint)
        {
            _server.Send(data,ipEndPoint);
        }

        public void addClient(IPEndPoint ip)
        {
            LogUtil.Log.InfoFormat("客户端 [{0}] 已连接...",ip);
            string id = ToolForIp.getChildIp(ip.Address.ToString(), 4);
            if (!clientDic.ContainsKey(id))
            {
                clientDic.Add(id,ip);
                LogUtil.Log.InfoFormat("当前在线数:{0}",clientDic.Count);
            }
            
        }

        public void removeClient(IPEndPoint ip)
        {
            string id = ToolForIp.getChildIp(ip.Address.ToString(), 4);
            if (clientDic.ContainsKey(id))
            {
                clientDic.Remove(id);
                LogUtil.Log.InfoFormat("客户端 [{0}] 已断开...",ip);
                LogUtil.Log.InfoFormat("当前在线数:{0}",clientDic.Count);
            }
        }

        public IPEndPoint getClient(string id)
        {
            IPEndPoint ip;
            clientDic.TryGetValue(id, out ip);
            return ip;
        }
        
        public List<IPEndPoint> getClients()
        {
            List<IPEndPoint> clents = new List<IPEndPoint>();
            foreach (var item in clientDic.Values)
            {
                clents.Add(item);
            }
            return clents;
        }

        public void Close()
        {
            _server.Close();
            (AssemblyHandler.GetInstance<HeartBeat>() as HeartBeat).Close();
        }
    }
}