using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MiddleProject;
using MiddleProject.impl;

namespace ClientWinform
{
    static class Program
    {
        private static Mutex appMutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            globalMutex();
            Application.Run(new Form1());
            
            Application.ApplicationExit += OnApplicationExit;
        }
        
        static void OnApplicationExit(object sender, EventArgs e)
        {
            RelMutex();
        }

        private static void globalMutex()
        {
            string exeName = ToolForUrl.getDirEndName(Application.ExecutablePath);
            string globalMutexName = @"Global\" + exeName;

            bool createNew;
            appMutex = new Mutex(true, globalMutexName, out createNew);
            if (!createNew)
            {
                appMutex.Close(); appMutex = null;
                MessageBox.Show("\""+exeName+"\" 已在运行，不能重复运行。", "提示");
                Environment.Exit(1);
            }
        }
        
        private static void RelMutex()
        {
            try
            {
                if (appMutex != null)
                {
                    appMutex.ReleaseMutex();
                    appMutex.Close();
                }
            }
            catch (Exception expMu) { }
        }
    }
}
