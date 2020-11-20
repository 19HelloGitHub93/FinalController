using System;
using MiddleProject;
using MiddleProject.model;

namespace Client.controller
{
    public class Close:IAccept
    {
        public void acceptMessage(Result result, SocketUDP socketUdp)
        {
            Data data = result.data;
            if (data.code==OrderCode.Close)
            {
                socketUdp.Close();
            }
        }
    }
}