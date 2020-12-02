using System;
using System.Diagnostics;
using System.Text;
using MiddleProject;
using MiddleProject.impl;
using MiddleProject.model;

namespace Client.accept
{
    public class Uninstall:IAccept
    {
        public Action callback;

        public void acceptMessage(Result result)
        {
            Data data = result.data;
            if (data.code == OrderCode.Uninst)
            {
                try
                {
                    //如果路径出现特殊符号问题 可以替换这个
                    //System.Reflection.Assembly.GetEntryAssembly().Location
                    //System.Windows.Forms.Application.ExecutablePath;
                    //AppDomain.CurrentDomain.SetupInformation.ApplicationBase
                    string appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
                    string appUrl = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                    
                    string[] fileNames =
                    {
                        appName,
                        "log4.net.config",
                    };
                    string[] dirNames =
                    {
                        "Log",
                    };

                    StringBuilder strCMD = new StringBuilder();
                    strCMD.Append("/C ping 1.1.1.1 -n 2 -w 1000 > Nul & ");
                    strCMD.AppendFormat("cd /d {0} & ",appUrl);
                
                    strCMD.Append("rd /s /q ");
                    foreach (string dirname in dirNames)
                        strCMD.AppendFormat("\"{0}\" & ", dirname);
                    strCMD.Append("del /f /q ");
                    foreach (string fileName in fileNames)
                        strCMD.AppendFormat("\"{0}\" ",fileName);
                    strCMD.Append("&exit");
                    
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", strCMD.ToString());
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    psi.CreateNoWindow = true;
                    
                    Process.Start(psi);
                    if (callback != null)
                        callback();
                }
                catch (Exception e)
                {
                    LogUtil.Error(e.StackTrace);
                }
            }
        }
    }
}