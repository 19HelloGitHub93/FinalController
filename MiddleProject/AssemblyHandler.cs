using System;
using System.Collections.Generic;
using System.Reflection;

namespace MiddleProject
{
    public class AssemblyHandler
    {
        public static List<T> CreateInstance<T>()
        {
            List<T> classArray = new List<T>();
            Type type = typeof(T);
            Assembly assembly = Assembly.GetCallingAssembly();
            foreach (Type item in assembly.GetTypes())
            {
                if (item.GetInterface(typeof(T).ToString()) != null)
                {
                    object obj = Activator.CreateInstance(item);
                    classArray.Add((T)obj);
                }
            }
            return classArray;
        }
    }
}