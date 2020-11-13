using System;

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
                string address = broadcastsAddress.getRemoteAddress(500);
                Console.WriteLine(address);
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