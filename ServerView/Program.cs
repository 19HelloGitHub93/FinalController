using System;
using System.Net.NetworkInformation;
using System.Text;
using WebSocketSharp;

namespace ServerInput
{
    class Program
    {
        static void Main(string[] args)
        {
           string url = "ws://127.0.0.1:7080/ServerMs";
           using (var ws = new WebSocket (url))
           {
               //ws.OnOpen += (sender, e) => { ws.Send("controller online!!!!"); };
               ws.OnMessage += (sender, e) =>
               {
                   Console.WriteLine("[server]{0}",e.Data);
               };
               ws.Connect ();
               while (true)
               {
                   string message = Console.ReadLine();
                   if (message.Equals("q"))
                   {
                       ws.Close();
                       break;
                   }
                   ws.Send(message);
               }
           }
           
        }
        
        static private bool PingIp(string strIP)
        {
            bool bRet = false;
            try
            {
                Ping pingSend = new Ping();
                PingReply reply = pingSend.Send(strIP, 1000);
                if (reply.Status == IPStatus.Success)
                    bRet = true;
            }
            catch (Exception e)
            {
                bRet = false;
                Console.WriteLine(e.Message);
            }

            return bRet;
        }
    }
}