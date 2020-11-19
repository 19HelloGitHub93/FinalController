using System;
using MiddleProject;

namespace Client.controller
{
    public class Close:Icontroller
    {
        public void receiveMsgCallBack(SocketUDP.Result result, SocketUDP socketUdp)
        {
            string msg = result.message;
            if (msg.Equals("close"))
            {
                socketUdp.Close();
            }
        }

        public void name(string x)
        {
            Console.WriteLine(x);
        }
    }
}