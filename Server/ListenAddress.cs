using System.Net;

namespace Server
{
    public class ListenAddress
    {
        private int port;//本机端口
        private string clientSignal;
        private string serverSignal;
        private SocketUDP _server;
        private IPAddress IpAddress = IPAddress.Any;

        public ListenAddress(int clientPort,int serverPort)
        {
            this.port = serverPort;
            this.clientSignal = clientPort.ToString();
            this.serverSignal = serverPort.ToString();
            _server = new SocketUDP(IpAddress.ToString(),port);
        }

        public IPAddress getIpAddress()
        {
            return IpAddress;
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