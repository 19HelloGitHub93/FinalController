using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Server.accept
{
    public class ClientOffline:IAccept,IServer
    {
        private ServerController server;
        public void init(ServerController ss)
        {
            server = ss;
        }
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.OffLine)
            {
                server.removeClient(result.ipEndPoint);
            }
        }
    }
}