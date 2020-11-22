using System;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Client.accept
{
    public class Close:IAccept,IClient
    {
        private ClientControl cs;
        public void init(ClientControl cs)
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