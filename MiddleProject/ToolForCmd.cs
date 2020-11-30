using System.Diagnostics;
using System.Text;

namespace MiddleProject
{
    public class ToolForCmd
    {
        public static void addFirewall(string appPath)
        {
            StringBuilder strCMD = new StringBuilder();
            string appName = ToolForUrl.getDirEndName(appPath,true);
            strCMD.AppendFormat("/user:Administrator netsh advfirewall firewall add rule name=\"{0}\" dir=in action=allow program=\"{1}\" enable=yes",
                appName, appPath);
            strCMD.Append("&exit");
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", strCMD.ToString());
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.CreateNoWindow = true;

            Process.Start(psi);
        }
        
        public static void deleteFirewall(string appPath)
        {
            StringBuilder strCMD = new StringBuilder();
            string appName = ToolForUrl.getDirEndName(appPath,true);
            strCMD.AppendFormat("netsh advfirewall firewall delete rule name=\"{0}\" program=\"{1}\"",
                appName, appPath);
            strCMD.Append("&exit");
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", strCMD.ToString());
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.CreateNoWindow = true;
                    
            Process.Start(psi);
        }
    }
}