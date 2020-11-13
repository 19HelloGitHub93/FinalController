using System;
using server;
using Server;

namespace serverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ListenAddress serverListen = new ListenAddress(10801, 10802);
            try
            {
                while (true)
                {
                    try
                    {
                        SocketUDP.Result response = serverListen.ReceiveMessage();
                        Console.WriteLine("[{0}:{1}]{2}", response.address, response.port, response.message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }
    }
}