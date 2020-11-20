using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using log4net.Core;
using MiddleProject;
using MiddleProject.model;
using Server.commend;

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServerSocket server = new ServerSocket(10801, 10802);
            try
            {
                LogUtil.Log.DebugFormat("本机Ip:{0}",server.Ip);
                server.receiveMsgCallBack += ServerOnReceiveMsgCallBack;
                server.BeginReceive();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                LogUtil.Log.Error(e.Message);
            }
            finally
            {
                if(server!=null)
                    server.Close();
            }
        }

        private static void ServerOnReceiveMsgCallBack(Result result, SocketUDP socketudp)
        {
            //Console.WriteLine("[{0}:{1}]{2}", result.address, result.port, result.data);
            Thread.Sleep(2000);
            socketudp.Send(OrderCode.Close.ToString(),result.address, result.port);
            //Data clientCommend = new OpenNote().ClientCommend();
            //socketudp.Send(clientCommend,result.address, result.port);
        }
    }
}