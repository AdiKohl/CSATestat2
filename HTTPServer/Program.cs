using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTTPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HTTPServer hs = new HTTPServer(8080);
            new Thread(hs.Start).Start();
            
        }
    }
}
