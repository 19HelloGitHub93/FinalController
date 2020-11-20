using System;
using System.Collections.Generic;
using System.Net;
using log4net;
using MiddleProject;
using MiddleProject.model;

namespace Server
{
    public class ServerSocket
    {
        //private ILog _log = LogManager.GetLogger(typeof(ServerSocket));
        private int port;//本机端口
        private string clientSignal;
        private string serverSignal;
        private SocketUDP _server;
        private string _ip;

        public string Ip => _ip;
        
        private Dictionary<string,string> clientDic = new Dictionary<string, string>();
        public event ReceiveMsgDelegate receiveMsgCallBack;

        public ServerSocket(int clientPort,int serverPort)
        {
            this.port = serverPort;
            this.clientSignal = clientPort.ToString();
            this.serverSignal = serverPort.ToString();
            this._ip = IPAddress.Any.ToString();
            _server = new SocketUDP(_ip,port);
        }

        public void BeginReceive()
        {
            _server.Ac_ReceiveMsg += AC_ReceiveMsgCallBack;
            _server.SyncReceiveMessage();
        }

        private void AC_ReceiveMsgCallBack(Result result,SocketUDP socketUdp)
        {
            string ip = string.Format("{0}:{1}", result.address, result.port);
            string msg = result.data.msg;

            LogUtil.Log.InfoFormat("收到{0}：{1}", ip, msg);

            if (msg.Equals(clientSignal))
            {
                _server.Send(serverSignal,result.address,result.port);
                addClient(result.address);
            }
            
            if (receiveMsgCallBack != null)
                receiveMsgCallBack(result, socketUdp);
        }

        public void addClient(string ip)
        {
            string id = ToolForIp.getChildIp(ip, 4);
            if (!clientDic.ContainsKey(id))
                clientDic.Add(id,ip);
        }

        public void removeClient(string ip)
        {
            string id = ToolForIp.getChildIp(ip, 4);
            if (clientDic.ContainsKey(id))
                clientDic.Remove(id);
        }

        public string getClient(string id)
        {
            string ip = String.Empty;
            clientDic.TryGetValue(id, out ip);
            return ip;
        }

        public void Close()
        {
            _server.Close();
        }
    }
}