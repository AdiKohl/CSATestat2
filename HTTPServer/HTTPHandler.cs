using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace HTTPServer
{
    class HTTPHandler
    {
        private TcpClient myClient;
        public HTTPHandler(TcpClient client)
        {
            this.myClient = client;
        }
        public void Do()
        {
            try
            {
                string data = "noch keine Daten vorhanden!"; //Rohtext wird später überschrieben
                int contentLength = 0; //länge des Datenstrings der Datei ToDo

                StreamReader sr = new StreamReader(myClient.GetStream());
                StreamWriter sw = new StreamWriter(myClient.GetStream());
                Console.WriteLine("Verbindung zu " +
                    myClient.Client.RemoteEndPoint);

                // Datei lesen wenn Browserverbindung steht
                string header = sr.ReadLine();
                if (header.Contains("GET"))
                {
                    try
                    {
                        using (StreamReader srf = new StreamReader(@"Temp\DataFile.txt"))
                        {
                            data = srf.ReadToEnd();
                            contentLength = data.Length;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Da war ein Error: " + e.ToString());
                    }
                }


                // Datei im HTTP-Format senden
                //Header
                sw.WriteLine("HTTP/1.1 200 OK");
                sw.WriteLine("Server: RoboServer");
                sw.WriteLine("Content-type: text/plane");
                sw.WriteLine("Content-length: " + contentLength);

                sw.WriteLine(""); //Leerzeile trennt Header von Body

                //Body
                sw.WriteLine("Data-File von Urs Mueller, Adrian Kohler");
                sw.WriteLine(" ");
                sw.WriteLine(data); //Daten senden

                //Ende HTTP

                sw.Flush(); //ohne Flush wird nix angezeigt

                myClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Es ist ein Fehler aufgetreten" + e.Message);
                myClient.Close();
            }
        }

    }
}
