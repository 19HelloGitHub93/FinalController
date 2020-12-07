using System;
using System.Collections.Generic;
using System.Net;
using log4net;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;
using Server.accept;

namespace Server
{
    public class ServerController
    {
        private int port;//本机端口
        private SocketUDP _server;
        private string _ip;

        public string Ip { 
            get {return _ip;}
        }
        public int Port {
            get
            {
                return port;
            }
        } 

        private List<IPEndPoint> clientDic = new List<IPEndPoint>();
        public event ReceiveMsgDelegate receiveMsgCallBack;
        public Action<IPEndPoint> AcAddclient;
        public Action<IPEndPoint> AcRemoveclient;
        

        public ServerController(int serverPort)
        {
            this.port = serverPort;
            this._ip = IPAddress.Any.ToString();
            _server = new SocketUDP(_ip,port);
            init();
        }
        
        private void init()
        {
            List<IAccept> acs = AssemblyHandler.CreateInstance<IAccept>();
            foreach (IAccept ac in acs)
                this.receiveMsgCallBack += ac.acceptMessage;

            List<IServer> ses = AssemblyHandler.CreateInstance<IServer>();
            foreach (IServer se in ses)
                se.init(this);
        }

        public void BeginReceive()
        {
            _server.Ac_ReceiveMsg += AC_ReceiveMsgCallBack;
            _server.SyncReceiveMessage();
        }

        private void AC_ReceiveMsgCallBack(Result result)
        {
            if(!BlockKey.IsBlock(result.data))
                LogUtil.DebugFormat("收到[{0}]:{1}",result.ipEndPoint,result.data);
            
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
        
        
        public void Send(OrderCode code, IPEndPoint ipEndPoint)
        {
            Send(code, null, ipEndPoint);
        }

        public void Send(OrderCode code, string msg, IPEndPoint ipEndPoint)
        {
            _server.Send(new Data(code,msg), ipEndPoint);
        }

        
        public void addClient(IPEndPoint ip)
        {
            LogUtil.InfoFormat("客户端 [{0}] 已连接...",ip);
            if (!clientDic.Contains(ip))
            {
                clientDic.Add(ip);
                LogUtil.InfoFormat("当前在线数:{0}",clientDic.Count);

                if (AcAddclient != null)
                    AcAddclient(ip);
            }
        }

        public void removeClient(IPEndPoint ip)
        {
            if (clientDic.Contains(ip))
            {
                clientDic.Remove(ip);
                LogUtil.InfoFormat("客户端 [{0}] 已断开...",ip);
                LogUtil.InfoFormat("当前在线数:{0}",clientDic.Count);
                
                if (AcRemoveclient != null)
                    AcRemoveclient(ip);
            }
        }

        public IPEndPoint getClient(IPEndPoint ip)
        {
            return clientDic.Find(item => item == ip); 
        }
        
        public List<IPEndPoint> getClients()
        {
            return clientDic; 
        }

        public void Close()
        {
            _server.Close();
            clientDic.Clear();
            //(AssemblyHandler.GetInstance<HeartBeat>() as HeartBeat).Close();
        }
    }
}