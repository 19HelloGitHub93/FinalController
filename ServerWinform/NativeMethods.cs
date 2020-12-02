using System.Runtime.InteropServices;

namespace ServerWinform
{
    public class NativeMethods
    {
        ///   <summary>
        ///  启动控制台
        ///   </summary>
        ///   <returns></returns>
        [DllImport( "kernel32.dll" )]
        public   static   extern   bool  AllocConsole();
        ///   <summary>
        ///  释放控制台
        ///   </summary>
        ///   <returns></returns>
        [DllImport( "kernel32.dll" )]
        public   static   extern   bool  FreeConsole();
    }
}