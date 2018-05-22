using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
namespace FileServer

{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpListener listen = new TcpListener(IPAddress.Any, 8888);
            // 4.
            //TcpListener listen = new TcpListener(IPAddress.Any,13);
            listen.Start();
            while (true)
            {
                Console.WriteLine("Warte auf Verbindung auf Port " +
                    listen.LocalEndpoint + "...");
                TcpClient client = listen.AcceptTcpClient();
                Console.WriteLine("Verbindung zu " +
                    client.Client.RemoteEndPoint);
                TextWriter tw = new StreamWriter(client.GetStream());
                tw.Write(DateTime.Now.ToString());
                tw.Flush();
                client.Close();
            }
        }
    }
}
