using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MiddleProject;

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServerSocket server = new ServerSocket(10801, 10802);
            try
            {
                Console.WriteLine("本机Ip:{0}",server.Ip);
                server.receiveMsgCallBack += ServerOnReceiveMsgCallBack;
                server.BeginReceive();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(server!=null)
                    server.Close();
            }
        }

        private static void ServerOnReceiveMsgCallBack(SocketUDP.Result result, SocketUDP socketudp)
        {
            Console.WriteLine("[{0}:{1}]{2}", result.address, result.port, result.message);
            Thread.Sleep(3000);
            socketudp.Send("close",result.address, result.port);
        }
    }
}