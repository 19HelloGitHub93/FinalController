using System;
using server;

namespace Server
{
    public class ListenAddress
    {
        private int port;//本机端口
        private string clientSignal;
        private string serverSignal;
        private SocketUDP _server;

        public ListenAddress(int clientPort,int serverPort)
        {
            this.port = serverPort;
            this.clientSignal = clientPort.ToString();
            this.serverSignal = serverPort.ToString();
            _server = new SocketUDP("192.168.3.48",port);
        }
        
        public SocketUDP.Result ReceiveMessage()
        {
            SocketUDP.Result response = _server.ReceiveMessage();
            if (response.message.Equals(clientSignal))
            {
                _server.Send(serverSignal,response.address,response.port);
            }

            return response;
        }

        public void Close()
        {
            _server.Close();
        }
    }
}