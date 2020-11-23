using System;
using System.Collections.Generic;
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
        private static void init(ClientControl cs)
        {
            List<IAccept> acs = AssemblyHandler.CreateInstance<IAccept>();
            foreach (IAccept ac in acs)
                cs.receiveMsgCallBack += ac.acceptMessage;
            
            List<IClient> cls = AssemblyHandler.CreateInstance<IClient>();
            foreach (IClient cl in cls)
                cl.init(cs);
                
        }
        public static void Main(string[] args)
        {
            ClientControl clientControl = null;
            try
            {
                clientControl = new ClientControl(10801, 10802);
                
                init(clientControl);
                
                clientControl.BeginReceive();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if(clientControl!=null)
                    clientControl.Close();
            }
        }
    }
}