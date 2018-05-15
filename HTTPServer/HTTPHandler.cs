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
                string htmlText = "noch keine Daten vorhanden!"; //Rohtext wird später überschrieben
                int contentLength = 0; //länge des Datenstrings der Datei ToDo

                StreamReader sr = new StreamReader(myClient.GetStream());
                StreamWriter sw = new StreamWriter(myClient.GetStream());
                Console.WriteLine("Verbindung zu " +
                    myClient.Client.RemoteEndPoint);
                // Datei lesen


                // Datei im HTTP-Format senden
                sw.WriteLine("HTTP/1.1 200 OK");
                sw.WriteLine("Server: RoboServer");
                sw.WriteLine("Content - type: text / plane");
                sw.WriteLine("Content - length: "+ contentLength);
                sw.WriteLine(""); //Leerzeile trennt Header von Body

                //HTML:
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<title>Gruppe Mueller Kohler</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<div>");
                sw.WriteLine("<h1>Urs Mueller, Adrian Kohler</h1");
                sw.WriteLine(htmlText);
                sw.WriteLine("</div>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
                //Ende HTML

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
