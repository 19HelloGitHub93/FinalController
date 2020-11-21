using MiddleProject.model;
using Server;

namespace Server.accept
{
    public interface IServer
    {
        void init(ServerSocket ss);
    }
}