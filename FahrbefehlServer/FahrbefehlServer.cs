using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Collections;
namespace FileServer

{
    public class FahrbefehlServer
    {
        private ArrayList befehlArray;

        public FahrbefehlServer()
        {
            befehlArray = new ArrayList();

           
        }



        public void DoListen()
        {
            TcpListener listen = new TcpListener(IPAddress.Any, 8888);
            listen.Start();
            
            while (true)
            {
                TcpClient client = listen.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                Console.WriteLine("empfange Fahrbefehle...");

                // ABFÜLLEN ARRAY
                string line;
                int i=0;
                while((line = sr.ReadLine()) != null)
                {
                    befehlArray.Add(line);
                    i++;
                    Console.WriteLine(line);
                }
                Console.WriteLine("Fahrbefehle erhalten");
                client.Close();



                // WENN FERTIG, DANN FAHRBEFEHLEXE MIT ARRAY AUFRUFEN
                FahrbefehlExe exe = new FahrbefehlExe(befehlArray);
                exe.DoExe();


                /*
                Console.WriteLine("Warte auf Verbindung auf Port " +
                    listen.LocalEndpoint + "...");
                TcpClient client = listen.AcceptTcpClient();
                Console.WriteLine("Verbindung zu " +
                    client.Client.RemoteEndPoint);
                TextWriter tw = new StreamWriter(client.GetStream());
                tw.Write(DateTime.Now.ToString());
                tw.Flush();
                client.Close();
                */
            }
        }

        static void Main(string[] args)
        {
            FahrbefehlServer fbs = new FahrbefehlServer();
            fbs.DoListen();

        }

    }
}

