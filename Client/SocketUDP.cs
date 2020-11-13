using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class SocketUDP
    {
        private UdpClient _server;
        private string _ip;
        private int _port;

        public SocketUDP(string localIp,int port)
        {
            _ip = localIp;
            _port = port;
            
            //_server = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            //_server.Bind(new IPEndPoint(IPAddress.Parse(_ip),_port));
            
            _server = new UdpClient(new IPEndPoint(IPAddress.Parse(_ip),_port));
        }
        
        public void Send(string data, string ip, int port)
        {
            EndPoint targetPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            byte[] b_Data = Encoding.UTF8.GetBytes(data);
            
            //_server.SendTo(b_Data, targetPoint);
            _server.Send(b_Data, b_Data.Length, targetPoint as IPEndPoint);
        }

        public Result ReceiveMessage()
        {
            //EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            //byte[] data = new byte[1024];
            //int length = _server.ReceiveFrom(data, ref remoteEndPoint);
            //string message = Encoding.UTF8.GetString(data, 0, length);
            //IPEndPoint remotePoint = remoteEndPoint as IPEndPoint;
            
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = _server.Receive(ref remoteEndPoint);
            string message = Encoding.UTF8.GetString(data);
            

            return new Result()
            {
                address = remoteEndPoint.Address.ToString(),
                port = remoteEndPoint.Port,
                message = message,
            };
        }

        public void Close()
        {
            Console.WriteLine("释放client!!!");
            _server.Close();
            _server.Dispose();
        }
        
        public class Result
        {
            public string address;
            public int port;
            public string message;
        }
    }
}