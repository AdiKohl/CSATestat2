using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using HTTPServer;
using FileServer; 

namespace RobotTestat2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen zum CSA Testat2 Projekt der Hochschule Luzern");
            //Robot robot = new Robot()

            //Fahrbefehlserver starten
            FahrbefehlServer fbs = new FahrbefehlServer();
            fbs.DoListen();



            Console.WriteLine("Programm beendet... ");

        }
    }
}

