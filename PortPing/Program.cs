using System;
using System.Net.Sockets;
using System.Threading;

namespace PortPing
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: PortPing [host] [port]");
                return;
            }

            var host = args[0];
            var port = int.Parse(args[1]);


            while (true)
            {
                try
                {
                    using (var client = new TcpClient())
                    {
                        client.Connect(host, port);
                        Console.WriteLine($"Connected to {host}:{port}");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Couldn't connect to {host}:{port} - {e.Message}");
                }
            }
        }
    }
}
