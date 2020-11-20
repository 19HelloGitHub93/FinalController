using System;
using System.Diagnostics;
using System.Reflection;
using log4net;

namespace MiddleProject
{
    public class LogUtil
    {
        public static ILog Log
        {
            get
            {
                Type t = findCaller();
                return LogManager.GetLogger(t);
            }
        }
        
        private static Type findCaller() {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(2);//1代表上级，2代表上上级，以此类推
            MethodBase method = frame.GetMethod();
            return  method.ReflectedType;
        }

    }
}