using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketListener.StartListening();
        }
    }
}
