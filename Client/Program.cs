using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Client.controller;
using MiddleProject;

namespace Client
{
    internal class Program
    {
        private static void init(ClientSocket cs)
        {
            List<IAccept> acs = AssemblyHandler.CreateInstance<IAccept>();
            foreach (IAccept ac in acs)
            {
                cs.receiveMsgCallBack += ac.acceptMessage;
            }
            
            List<IClient> cls = AssemblyHandler.CreateInstance<IClient>();
            foreach (IClient cl in cls)
            {
                cl.init(cs);
            }
        }
        public static void Main(string[] args)
        {
            ClientSocket clientSocket = null;
            try
            {
                clientSocket = new ClientSocket(10801, 10802);
                
                init(clientSocket);
                
                clientSocket.BeginReceive();

                while (true)
                {
                    string code = Console.ReadLine();
                    if (code.Equals("exit"))
                        break;
                    if (code.Equals("conn"))
                        clientSocket.reconnect();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if(clientSocket!=null)
                    clientSocket.Close();
            }
        }
    }
}