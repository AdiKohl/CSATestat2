using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace HTTPServer
{
    class HTTPServer
    {
        TcpListener myListner;

        public HTTPServer(int port) {
            myListner = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            myListner.Start();

            while (true)
            {

                TcpClient myClient = myListner.AcceptTcpClient();
                HTTPHandler myHandler = new HTTPHandler(myClient);
                new Thread(myHandler.Do).Start();
            }
        }
    }
}
