using System;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server.ConnectMessage
{
    public class ClientMs:WebSocketBehavior
    {
        public string ip;
        public ConnetTag tag = ConnetTag.Client;
        private WebSocketServer _server;
        public ClientMs(WebSocketServer server)
        {
            _server = server;
        }
        
        protected override void OnMessage (MessageEventArgs e)
        {
            Console.WriteLine("[{0}]{1}",tag,e.Data);
        }
        protected override void OnOpen()
        {
            ip = Context.UserEndPoint.ToString();
            Console.WriteLine( "[{0}]{1}",tag,ip);
            SendServer( String.Format("[{0}]{1}",tag,ip));
            base.OnOpen();
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("[{0}]{1} exit.....",tag,ip);
            base.OnClose(e);
        }

        private void SendServer(string data)
        {
            foreach (WebSocketServiceHost host in _server.WebSocketServices.Hosts)
            {
                if (host.Path.Equals("/ServerMs"))
                {
                    host.Sessions.Broadcast(data);
                    break;
                }
            }
        }
    }
}