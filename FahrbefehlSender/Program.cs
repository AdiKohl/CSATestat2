using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FahrbefehlSender
{
    class Program
    {
        static void Main(string[] args)

        {
            /*
            try
            {
                string fahrbefehle;
                FileStream fs = new FileStream("C:/temp/fahrbefehle.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                Console.WriteLine("Fahrbefehle:");
                while ((fahrbefehle = sr.ReadLine()) != null)
                {
                    Console.WriteLine(fahrbefehle);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            */

            
            FileStream fs = new FileStream("C:/temp/fahrbefehle.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string lineTwo;
            Console.Write("Bitte IP des Roboters eingeben: ");
            string ipAddress = Console.ReadLine();

            TcpClient client = new TcpClient(ipAddress, 8888);
            StreamWriter sender = new StreamWriter(client.GetStream());
            Console.WriteLine("Verbindung mit Roboter erfolgreich!");

            string fahrbefehl;
            Console.Write("Zum senden der Fahrbefehle ENTER drücken...");
            while ((lineTwo = Console.ReadLine()) != "close")
            {
                while((fahrbefehl = sr.ReadLine()) != null)
                {
                    sender.WriteLine(fahrbefehl);
                    sender.Flush();
                    Console.WriteLine(fahrbefehl);
                }
                Console.WriteLine("alle Fahrbefehle gesendet");
                client.Close();
                Console.WriteLine("Roboter startet jetzt...");
            }
        }
    }
}
