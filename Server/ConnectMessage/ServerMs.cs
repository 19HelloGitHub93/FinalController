using System;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server.ConnectMessage
{
    public class ServerMs:WebSocketBehavior
    {
        public string ip;
        private ConnetTag tag = ConnetTag.Server;
        private WebSocketServer _server;

        public ServerMs(WebSocketServer server)
        {
            _server = server;
        }
        
        protected override void OnMessage (MessageEventArgs e)
        {
            Console.WriteLine("[{0}]{1}",tag,e.Data);
            handle(e.Data);
        }

        private void handle(string data)
        {
            if (data.Contains("getall"))
            {
                getall();
                return;
            }
            SendClient(data);
        }

        private void SendServer(string data)
        {
            Send(data);
        }

        private void SendClient(string data)
        {
            foreach (WebSocketServiceHost host in _server.WebSocketServices.Hosts)
            {
                if (host.Path.Equals("/ClientMs"))
                {
                    host.Sessions.Broadcast(data);
                    break;
                }
            }
        }

        private void getall()
        {
            WebSocketSessionManager clients = getClientsManager();
            if (clients != null)
            {
                StringBuilder ms = new StringBuilder();
                foreach (ClientMs client in clients.Sessions)
                {
                    ms.Append(client.ip).Append(",");
                }

                if (ms.ToString().EndsWith(","))
                {
                    ms.Remove(ms.Length - 1, 1);
                }
                SendServer(ms.ToString());
            }
        }

        private WebSocketSessionManager getClientsManager()
        {
            foreach (WebSocketServiceHost host in _server.WebSocketServices.Hosts)
            {
                if (host.Path.Equals("/ClientMs"))
                {
                    return host.Sessions;
                }
            }
            return null;
        }
    }
}