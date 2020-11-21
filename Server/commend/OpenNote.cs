using MiddleProject;
using MiddleProject.model;

namespace Server.commend
{
    public class OpenNote:ICommand
    {
        public Data ClientCommand()
        {
            return new Data()
            {
                code = OrderCode.Cmd,
                msg = "notepad",
            };
        }
    }
}