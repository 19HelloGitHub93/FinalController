using MiddleProject;
using MiddleProject.model;

namespace Server.commend
{
    public class OpenNote:ICommend
    {
        public Data ClientCommend()
        {
            return new Data()
            {
                code = OrderCode.Cmd,
                msg = "notepad",
            };
        }
    }
}