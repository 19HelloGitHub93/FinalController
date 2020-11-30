using System;
using System.Collections.Generic;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;
using Server.accept;

namespace Server
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            ServerController server = new ServerController(10802);
            try
            {
                //Console.WriteLine(IPAddress.Broadcast);
                LogUtil.DebugFormat("本机Ip:{0}",server.Ip);
                server.receiveMsgCallBack += ServerOnReceiveMsgCallBack;
                server.BeginReceive();
                
                Console.ReadKey();
            }
            catch (Exception e)
            {
                LogUtil.Error(e.Message);
            }
            finally
            {
                if(server!=null)
                    server.Close();
            }
        }

        private static void ServerOnReceiveMsgCallBack(Result result)
        {
            //Console.WriteLine("[{0}:{1}]{2}", result.address, result.port, result.data);
            //Thread.Sleep(3000);
           // socketudp.Send(new Data(OrderCode.Close,null), result.ipEndPoint);
            //Data clientCommend = new RunApp().ClientCommend();
            //socketudp.Send(clientCommend,result.address, result.port);
            
        }
    }
}