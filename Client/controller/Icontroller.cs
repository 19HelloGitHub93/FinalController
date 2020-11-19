using MiddleProject;

namespace Client.controller
{
    public interface Icontroller
    {
        void receiveMsgCallBack(SocketUDP.Result result, SocketUDP socketUdp);
    }
}