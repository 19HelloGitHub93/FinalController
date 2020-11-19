using System;
using System.Net;
using System.Net.Sockets;
using MiddleProject;

namespace Server
{
    public class ServerSocket
    {
        private int port;//本机端口
        private string clientSignal;
        private string serverSignal;
        private SocketUDP _server;
        private string _ip;

        public string Ip => _ip;

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
        
        private void AC_ReceiveMsgCallBack(SocketUDP.Result result,SocketUDP socketUdp)
        {
            string ip = string.Format("{0}:{1}", result.address, result.port);
            string msg = result.message;
            Console.WriteLine("收到{0}：{1}",ip,msg);

            if (msg.Equals(clientSignal))
                _server.Send(serverSignal,result.address,result.port);
            
            if (receiveMsgCallBack != null)
                receiveMsgCallBack(result, socketUdp);
        }

        public void Close()
        {
            _server.Close();
        }
    }
}