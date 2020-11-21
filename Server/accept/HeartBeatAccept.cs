using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Client.controller;
using MiddleProject;
using MiddleProject.model;

namespace Server.accept
{
    public class HeartBeatAccept:IAccept,IServer
    {
        private int lostCount = 3;//丢包次数
        private int lossTime = 10;//丢包间隔时间 单位/s
        private int waitTime = 3000;//检测时间间隔 单位 毫秒
        
        //private ServerSocket server;
        private Dictionary<IPEndPoint,Client> clientHeartDic =new Dictionary<IPEndPoint, Client>();

        public bool enable = true;

        public void init(ServerSocket server)
        {
            Thread t = new Thread(() => { updateClient(server); });
            t.Start();
        }
        
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.HeartBeat)
            {
                Client client;
                if (clientHeartDic.TryGetValue(result.ipEndPoint,out client))
                {
                    client.reset();
                    return;
                }
                
                client = new Client()
                {
                    ipEndPoint = result.ipEndPoint,
                    lostCount = 0,
                    activeTime = DateTime.Now,
                    lastTime = DateTime.Now,
                };
                clientHeartDic.Add(result.ipEndPoint,client);
            }
        }

        private void updateClient(ServerSocket server)
        {
            if (server != null)
            {
                LogUtil.Log.Debug("启动心跳检测");
                Client client=null;
                while (enable)
                {
                    foreach (IPEndPoint ip in server.getClients())
                    {
                        if (clientHeartDic.TryGetValue(ip, out client))
                        {
                            client.activeTime = DateTime.Now;
                            if ((int)client.getTimeinterval() > lossTime)
                            {
                                client.lostCount++;
                                LogUtil.Log.DebugFormat("客户端 [{0}] 丢包次数:{1}",client.ipEndPoint,client.lostCount);
                            }
                            
                            if (client.lostCount > lostCount)
                            {
                                server.removeClient(ip);
                                clientHeartDic.Remove(ip);
                            }
                        }
                    }
                    //LogUtil.Log.Debug("心跳检测中...");
                    if(client!=null)
                        server.Send(new Data(OrderCode.HeartBeat),client.ipEndPoint);
                    Thread.Sleep(waitTime);
                }
            }
        }
    }
}