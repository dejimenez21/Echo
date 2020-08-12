using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text; 

namespace EchoClient
{
    public class SocketSender
    {
        public static void StartClient(string word) {  
        
        byte[] bytes = new byte[1024];  
  
        
        try {  
             
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
            IPAddress ipAddress = ipHostInfo.AddressList[0];  
            IPEndPoint remoteEP = new IPEndPoint(ipAddress,8081);  
  
              
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp );  
  
            
            try {  
                sender.Connect(remoteEP);  
  
                Console.WriteLine("Socket connected to {0}",  
                    sender.RemoteEndPoint.ToString());  
  
                 
                byte[] msg = Encoding.ASCII.GetBytes(word);  
  
                
                int bytesSent = sender.Send(msg);  
  
                
                int bytesRec = sender.Receive(bytes);  
                Console.WriteLine("Echoed test = {0}",  
                    Encoding.ASCII.GetString(bytes,0,bytesRec));  
  
                  
                sender.Shutdown(SocketShutdown.Both);  
                sender.Close();  
  
            } catch (ArgumentNullException ane) {  
                Console.WriteLine("ArgumentNullException : {0}",ane.ToString());  
            } catch (SocketException se) {  
                Console.WriteLine("SocketException : {0}",se.ToString());  
            } catch (Exception e) {  
                Console.WriteLine("Unexpected exception : {0}", e.ToString());  
            }  
  
        } catch (Exception e) {  
            Console.WriteLine( e.ToString());  
        }  
    }  
  
     
    }
}