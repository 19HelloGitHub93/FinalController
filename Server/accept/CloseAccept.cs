using Client.controller;
using MiddleProject;
using MiddleProject.model;

namespace Server.accept
{
    public class CloseAccept:IAccept,IServer
    {
        private ServerSocket server;
        public void init(ServerSocket ss)
        {
            server = ss;
        }
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.Close)
            {
                server.removeClient(result.ipEndPoint);
            }
        }
    }
}