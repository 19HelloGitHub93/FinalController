using System;
using MiddleProject;
using MiddleProject.model;

namespace Client.controller
{
    public class Close:IAccept,IClient
    {
        private ClientSocket cs;
        public void init(ClientSocket cs)
        {
            this.cs = cs;
        }
        
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code==OrderCode.Close)
            {
                cs.Close();
            }
        }

        
    }
}