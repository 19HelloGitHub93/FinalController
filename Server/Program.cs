﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Client.controller;
using log4net.Core;
using MiddleProject;
using MiddleProject.model;
using Server.accept;
using Server.commend;

namespace Server
{
    internal class Program
    {
        private static void init(ServerSocket ss)
        {
            List<IAccept> acs = AssemblyHandler.CreateInstance<IAccept>();
            foreach (IAccept ac in acs)
                ss.receiveMsgCallBack += ac.acceptMessage;
            
            List<IServer> ses = AssemblyHandler.CreateInstance<IServer>();
            foreach (IServer se in ses)
                se.init(ss);
        }
        public static void Main(string[] args)
        {
            ServerSocket server = new ServerSocket(10802);
            try
            {
                //Console.WriteLine(IPAddress.Broadcast);
                LogUtil.Log.DebugFormat("本机Ip:{0}",server.Ip);
                server.receiveMsgCallBack += ServerOnReceiveMsgCallBack;
                
                init(server);
                
                server.BeginReceive();
                
                Console.ReadKey();
            }
            catch (Exception e)
            {
                LogUtil.Log.Error(e.Message);
            }
            finally
            {
                if(server!=null)
                    server.Close();
                
                HeartBeatAccept instance = AssemblyHandler.GetInstance<HeartBeatAccept>() as HeartBeatAccept;
                instance.enable = false;
            }
        }

        private static void ServerOnReceiveMsgCallBack(Result result)
        {
            //Console.WriteLine("[{0}:{1}]{2}", result.address, result.port, result.data);
            //Thread.Sleep(3000);
           // socketudp.Send(new Data(OrderCode.Close,null), result.ipEndPoint);
            //Data clientCommend = new OpenNote().ClientCommend();
            //socketudp.Send(clientCommend,result.address, result.port);
            
        }
    }
}