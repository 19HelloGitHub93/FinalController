using System;
using System.Diagnostics;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Client.accept
{
    public class CloseApp:IAccept,IClient
    {
        private readonly string[] BlockAppName =
        {
            "explorer",
        };
        
        private ClientControl cs;

        public Action callback;
        public void init(ClientControl cs)
        {
            this.cs = cs;
        }
        
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code==OrderCode.CloseApp)
            {
                if (callback != null)
                    callback();
                
                foreach (Process process in Process.GetProcesses())
                {
                    if (isBlockName(process.ProcessName))
                    {
                        //process.Kill();
                        //process.Start();
                        continue; 
                    }
                        
                    process.CloseMainWindow();
                } 
            }
        }

        private bool isBlockName(string appName)
        {
            foreach (string block in BlockAppName)
            {
                if (appName.Equals(block))
                    return true;
            }

            return false;
        }
    }
}