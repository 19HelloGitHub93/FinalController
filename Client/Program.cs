using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("start!!");
                BroadcastsAddress broadcastsAddress = new BroadcastsAddress(10801,10802);
                broadcastsAddress.connRemoteAddress(0);
                Console.WriteLine("end!!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}