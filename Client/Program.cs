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

                List<Icontroller> recControllers = new List<Icontroller>();
                recControllers = AssemblyHandler.CreateInstance<Icontroller>();
                foreach (Icontroller controller in recControllers)
                    clientSocket.receiveMsgCallBack += controller.receiveMsgCallBack;

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