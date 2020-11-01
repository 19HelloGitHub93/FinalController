using System;
using System.Net;
using NUnit.Framework;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace test
{
    public class Tests
    {
        public static void Main(string[] args)
        {
            WebSocketServer _server = new WebSocketServer ("ws://127.0.0.1:7777");
            _server.AddWebSocketService<Laputa>("/Laputa");
            _server.Start();
            Console.WriteLine("start!!!!!");
            Console.ReadLine();
            _server.Stop();
            Console.WriteLine("stop!!!!!");
        }
    }
    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage (MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);
        }
    }
}