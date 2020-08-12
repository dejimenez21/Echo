using System;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketSender.StartClient(args[0]);
        }
    }
}
