using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    public class Server
    {

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient LocalSocket = socket;
                    DoClient(LocalSocket);
                });
            }
        }

        public void DoClient(TcpClient socket)
        {
            string line = "";
            string myLine = "";

            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                while (line != "STOP" && myLine != "STOP")
                {
                    line = sr.ReadLine();
                    Console.WriteLine(line);
                    myLine = Console.ReadLine();
                    sw.WriteLine(myLine);
                    sw.Flush();
                }
            }
        }
    }
}
