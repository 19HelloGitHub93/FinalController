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
        public static void Main(string[] args)
        {
            ClientSocket clientSocket = null;
            try
            {
                Console.WriteLine("start!!");
                clientSocket = new ClientSocket(10801, 10802);

                List<IAccept> recControllers = new List<IAccept>();
                recControllers = AssemblyHandler.CreateInstance<IAccept>();
                foreach (IAccept controller in recControllers)
                    clientSocket.receiveMsgCallBack += controller.acceptMessage;

                clientSocket.BeginReceive();
                Console.WriteLine("end!!");
                Console.ReadKey();
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