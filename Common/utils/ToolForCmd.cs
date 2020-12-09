using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MiddleProject.utils
{
    public class ToolForCmd
    {
        public static void CreateShortcut()
        {
            string appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            string appDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            //string linkPath = StartUpPath + ToolForUrl.filterEnd(appName) + ".lnk";
            //string targetPath = appDir + appName;

            //if (File.Exists(linkPath))
            //   return;
            StringBuilder strCmd = new StringBuilder();
            strCmd.AppendFormat("set \"exe={0}\"\r\n", appName);
            strCmd.AppendFormat("set \"lnk={0}\"\r\n", ToolForUrl.filterEnd(appName));
            strCmd.Append("mshta VBScript:Execute(\"Set a=CreateObject(\"\"WScript.Shell\"\"):");
            strCmd.Append("Set b=a.CreateShortcut(a.SpecialFolders(\"\"Startup\"\") & \"\"\\%lnk%.lnk\"\"):");
            strCmd.AppendFormat("b.TargetPath=\"\"{0}%exe%\"\":b.WorkingDirectory=\"\"{0}\"\":b.Save:close\")",appDir);

            cmd(strCmd.ToString(),true);
        }

        public static void addFirewall()
        {
            string appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            string appDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            addFirewall(appDir + appName);
        }
        
        public static void addFirewall(string appPath)
        {
            StringBuilder strCMD = new StringBuilder();
            string appName = ToolForUrl.getDirEndName(appPath,true);
            strCMD.AppendFormat("/netsh advfirewall firewall add rule name=\"{0}\" dir=in action=allow program=\"{1}\" enable=yes",
                appName, appPath);
            cmd(strCMD.ToString(),true);
        }
        
        public static void deleteFirewall(string appPath)
        {
            StringBuilder strCMD = new StringBuilder();
            string appName = ToolForUrl.getDirEndName(appPath,true);
            strCMD.AppendFormat("netsh advfirewall firewall delete rule name=\"{0}\" program=\"{1}\"",
                appName, appPath);
            cmd(strCMD.ToString(),true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="runas">提权</param>
        private static void cmd(string command,bool runas=false)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true; //不显示程序窗口
                if (runas)
                    p.StartInfo.Verb= "runas";
                p.Start(); //启动程序
                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(command + "&exit");
                p.StandardInput.AutoFlush = true;
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                LogUtil.Error(e.StackTrace);
            }

        }
        
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
            [MarshalAs(UnmanagedType.LPTStr)]string path,
            [MarshalAs(UnmanagedType.LPTStr)]StringBuilder short_path,
            int short_len
        );
        public static string GetShortPath(string name)
        {
            int lenght = 0;
            lenght = GetShortPathName(name, null, 0);
            if (lenght == 0)
            {
                return name;
            }
            StringBuilder short_name = new StringBuilder(lenght);
            lenght = GetShortPathName(name, short_name, lenght);
            if (lenght == 0)
            {
                return name;
            }
            return short_name.ToString();
        }
    }
}