using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Client.accept;
using MiddleProject;
using MiddleProject.impl;

namespace Client
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            ClientControl clientControl = null;
//            try
//            {
//                clientControl = new ClientControl(10801, 10802);
//                
//                clientControl.BeginReceive();
//
//                Console.ReadKey();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//            }
//            finally
//            {
//                if(clientControl!=null)
//                    clientControl.Close();
//            }

            string appName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            string appUrl = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Console.WriteLine(appName);
            Console.WriteLine(appUrl);
        }

        static void KillProcessAndChildren(int pid)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                //KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
                int _pid = Convert.ToInt32(mo["ProcessID"]);
                Process proc = Process.GetProcessById(_pid);
                Console.WriteLine("{0}:{1}",proc.ProcessName,proc.Id);
            }
        }
    }
}