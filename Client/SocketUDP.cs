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
        private const string CLOSE_LOCALSERVER = "closeLocalServer";

        public UdpClient Server
        {
            get => _server;
            private set => _server = value;
        }

        public IPEndPoint address
        {
            get;
            private set;
        }

        public SocketUDP(string localIp,int port)
        {
            _ip = localIp;
            _port = port;
            
            //_server = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            //_server.Bind(new IPEndPoint(IPAddress.Parse(_ip),_port));
            address = new IPEndPoint(IPAddress.Parse(_ip), _port);
            _server = new UdpClient(address);
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
            
            Console.WriteLine("接收到{0}",message);
            if (message.Equals(CLOSE_LOCALSERVER))
                _Close();

            return new Result()
            {
                address = remoteEndPoint.Address.ToString(),
                port = remoteEndPoint.Port,
                message = message,
            };
        }
        
        
        public void SyncReceiveMessage()
        {
            _server.BeginReceive(receiveCallBack, this);
        }

        private void receiveCallBack(IAsyncResult ar)
        {
            SocketUDP _socket = null;
            try
            {
                _socket = ar.AsyncState as SocketUDP;
                UdpClient client = _socket.Server;
                IPEndPoint address = _socket.address;
                byte[] data = client.EndReceive(ar,ref address);
                if (data.Length == 0)
                {
                    Console.WriteLine("长度0 退出");
                    client.Close();
                    return;
                }
                string msg = Encoding.UTF8.GetString(data, 0, data.Length);
                Console.WriteLine("从[{0}]接收到数据:{1}",address,msg);
                client.BeginReceive(receiveCallBack, _socket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (_socket._server != null)
                {
                    Console.WriteLine("异常 退出");
                    _socket._server.Close();
                }
            }
        }

        public void Close()
        {
            Send(CLOSE_LOCALSERVER, _ip, _port);
        }

        private void _Close()
        {
            Console.WriteLine("释放client!!!!");
            _server.Client.Shutdown(SocketShutdown.Both);
            _server.Close();
            Console.WriteLine("释放client成功");
        }
        
        public class Result
        {
            public string address;
            public int port;
            public string message;
        }
    }
}