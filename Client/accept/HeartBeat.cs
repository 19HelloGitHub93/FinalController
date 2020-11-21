using System;
using System.Threading;
using MiddleProject;
using MiddleProject.model;

namespace Client.controller
{
    public class HeartBeat:IAccept,IClient
    {
        private ClientSocket cs;
        
        public void init(ClientSocket cs)
        {
            this.cs = cs;
        }
        
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.HeartBeat)
            {
                Data heartData = new Data(OrderCode.HeartBeat);
                cs.SendToServer(heartData);
            }
        }

       
    }
}