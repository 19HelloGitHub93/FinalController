using System;
using System.Runtime.InteropServices;

namespace Client
{
    public class SystemHandle
    {
        const int WM_CLOSE = 0x10; //关闭
        const int WM_DESTROY = 0x02;
        const int WM_QUIT = 0x12;
        
        
        [DllImport("user32.dll",EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public static void Close(IntPtr handel)
        {
            //IntPtr window = FindWindow(null,windowName);
            if (handel != IntPtr.Zero)
            {
                Console.WriteLine("close...");
                SendMessage(handel, WM_CLOSE, 0, 0);
            }
        }
    }
}