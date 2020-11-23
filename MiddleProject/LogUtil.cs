using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using log4net;

namespace MiddleProject
{
    public class LogUtil
    {
        private static Dictionary<Type, ILog> logDic = new Dictionary<Type, ILog>();
        public static ILog Log
        {
            get
            {
                Type t = findCaller();
                return getILog(t);
            }
        }
        
        private static Type findCaller() {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(2);//1代表上级，2代表上上级，以此类推
            MethodBase method = frame.GetMethod();
            return  method.ReflectedType;
        }

        private static ILog getILog(Type t)
        {
            ILog _log;
            lock (logDic)
            {
                bool result = logDic.TryGetValue(t, out _log);
                if (!result)
                {
                    _log = LogManager.GetLogger(t);
                    logDic.Add(t,_log);
                }
                return _log;
            }
        }

    }
}