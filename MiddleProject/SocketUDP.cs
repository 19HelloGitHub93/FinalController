using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using log4net;
using MiddleProject.model;
using Newtonsoft.Json;

namespace MiddleProject
{
    public class SocketUDP
    {
        private UdpClient _server;
        private string _ip;
        private int _port;
        public event ReceiveMsgDelegate Ac_ReceiveMsg;

        private readonly static object _lock = new object();
        private bool applicationIsQuitting = false;

        public bool ApplicationIsQuitting
        {
            get
            {
                lock (_lock)
                {
                    return applicationIsQuitting;
                }
            }
            set => applicationIsQuitting = value;
        }

        public UdpClient Server
        {
            get => _server;
            private set => _server = value;
        }

        public IPEndPoint address { get; private set; }

        public SocketUDP(string localIp, int port)
        {
            _ip = localIp;
            _port = port;

            address = new IPEndPoint(IPAddress.Parse(_ip), _port);
            _server = new UdpClient(address);
        }

        public void Send(string data, string ip, int port)
        {
            if (_server != null)
            {
                EndPoint targetPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                Data _data = new Data()
                {
                    code = OrderCode.None,
                    msg = data
                };
                byte[] b_Data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_data));
                _server.Send(b_Data, b_Data.Length, targetPoint as IPEndPoint);
            }
        }
        
        public void Send(Data data, string ip, int port)
        {
            if (_server != null)
            {
                EndPoint targetPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                byte[] b_Data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                _server.Send(b_Data, b_Data.Length, targetPoint as IPEndPoint);
            }
        }

        public void SyncReceiveMessage()
        {
            if(_server!=null)
                _server.BeginReceive(receiveCallBack, this);
        }

        private void receiveCallBack(IAsyncResult ar)
        {
            SocketUDP _socket = null;
            try
            {
                if (ApplicationIsQuitting)
                    return;
                
                _socket = ar.AsyncState as SocketUDP;
                UdpClient client = _socket.Server;
                IPEndPoint address = _socket.address;
                byte[] data = client.EndReceive(ar, ref address);
                if (data.Length == 0)
                    return;

                string msg = Encoding.UTF8.GetString(data, 0, data.Length);

                if (Ac_ReceiveMsg != null)
                {
                    Result rs = new Result(address.Address.ToString(), address.Port, JsonConvert.DeserializeObject<Data>(msg));
                    Ac_ReceiveMsg( rs,this);
                }
                    
                SyncReceiveMessage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                SyncReceiveMessage();
            }
        }

        public void Close()
        {
            ApplicationIsQuitting = true;
            if (_server != null)
            {
                _server.Client.Shutdown(SocketShutdown.Both);
                _server.Close();
                _server = null;
                LogUtil.Log.InfoFormat("{0}:{1}释放成功", _ip, _port);
            }
        }


    }
}