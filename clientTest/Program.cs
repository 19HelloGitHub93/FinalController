using System;
using FinalController;

namespace clientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start!!");
            BroadcastsAddress broadcastsAddress = new BroadcastsAddress(10801,10802);
            string address = broadcastsAddress.getRemoteAddress(2000);
            Console.WriteLine(address);
            Console.WriteLine("end!!");
            Console.ReadKey();
        }
    }
}