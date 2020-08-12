using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;

namespace EchoServer
{
    public class SocketListener
    {
        public static string data = null;

        public static void StartListening()
        {
            byte[] bytes = new Byte[1024];
            var iPHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var iPAddress = iPHostInfo.AddressList[0];
            var localEndPoint = new IPEndPoint(iPAddress, 8081);

            Socket listener = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try{
                listener.Bind(localEndPoint);
                listener.Listen(1);

                while (true) {  
                    Console.WriteLine("Waiting for a connection...");  
                     
                    Socket handler = listener.Accept();  
                    data = null;  
    
                 
                    while (true) {  
                        int bytesRec = handler.Receive(bytes);  
                        data += Encoding.ASCII.GetString(bytes,0,bytesRec);  
                        if (data != null) {  
                            break;  
                        }  
                    }  
    
                    
                    Console.WriteLine( "Text received : {0}", data);  
    
                    
                    byte[] msg = Encoding.ASCII.GetBytes(data);  
    
                    handler.Send(msg);  
                    handler.Shutdown(SocketShutdown.Both);  
                    handler.Close();  
                }  
    
            } catch (Exception e) {  
                Console.WriteLine(e.ToString());  
            }  
    
            Console.WriteLine("\nPress ENTER to continue...");  
            Console.Read();  
    
      
        
        }
    }
}