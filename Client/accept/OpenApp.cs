using System;
using System.Diagnostics;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Client.accept
{
    public class OpenApp:IAccept
    {
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.App)
            {
                try
                {
                    //创建一个进程
                    Process p = new Process();
                    p.StartInfo.FileName = @data.msg;
                    p.Start(); //启动程序
                }
                catch (Exception e)
                {
                    LogUtil.Error(e.StackTrace);
                }
            }
        }
    }
}