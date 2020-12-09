using System;
using System.Collections.Generic;
using System.Reflection;

namespace MiddleProject
{
    public class AssemblyHandler
    {
        private static Dictionary<Type,object> objsDic = new Dictionary<Type, object>();
        public static List<T> CreateInstance<T>()
        {
            List<T> classArray = new List<T>();
            Assembly assembly = Assembly.GetCallingAssembly();
            foreach (Type item in assembly.GetTypes())
            {
                if (item.GetInterface(typeof(T).ToString()) != null)
                {
                    object obj = getObj(item);
                    classArray.Add((T)obj);
                }
            }
            return classArray;
        }

        public static object GetInstance<T>()
        {
            return getObj(typeof(T));
        }

        private static void addObj(Type t,object o)
        {
            if(!objsDic.ContainsKey(t))
                objsDic.Add(t,o);
        }

        private static object getObj(Type t)
        {
            object o;
            if (!objsDic.TryGetValue(t, out o))
            {
                o = Activator.CreateInstance(t);
                addObj(t, o);
            }
            return o;
        }
    }
}