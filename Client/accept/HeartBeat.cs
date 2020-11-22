using System;
using System.Threading;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Client.accept
{
    public class HeartBeat:IAccept,IClient
    {
        private int lostCount = 3;//丢包次数
        private int lossTime = 10;//丢包间隔时间 单位/s
        private int waitTime = 3000;//检测时间间隔 单位 毫秒
        
        private bool enable;

        private Heart serverHeart = new Heart();
        
        public void init(ClientControl cs)
        {
            enable = true;
            Thread t = new Thread(() => { updateServer(cs); });
            t.Start();
        }
        
        public void Close()
        {
            enable = false;
        }
        
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.HeartBeat)
            {
                serverHeart.ipEndPoint = result.ipEndPoint;
                serverHeart.reset();
            }
        }
        
        private void updateServer(ClientControl clControl)
        {
            if (clControl != null)
            {
                LogUtil.Log.Debug("启动心跳检测");
                while (enable)
                {
                    if (clControl.IsConnected())
                    {
                        serverHeart.activeTime = DateTime.Now;
                        if ((int)serverHeart.getTimeinterval() > lossTime)
                        {
                            serverHeart.lostCount++;
                            LogUtil.Log.DebugFormat("服务端 [{0}] 丢包次数:{1}",serverHeart.ipEndPoint,serverHeart.lostCount);
                            clControl.connect();
                        }
                        if (serverHeart.lostCount > lostCount)
                        {
                            clControl.removeServer(serverHeart.ipEndPoint);
                            LogUtil.Log.InfoFormat("服务器 [{0}] 已断开！！",serverHeart.ipEndPoint);
                        }
                    }
                    else
                    {
                        clControl.connect();
                    }
                    
                    clControl.SendToServer(new Data(OrderCode.HeartBeat));

                    Thread.Sleep(waitTime);
                }
            }
        }

       
    }
}