using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatClient
{
    public class Client
    {
        public void Start()
        {
            //car.Color = "Toyota";
            //car.Model = "Hybrid";
            //car.RegNo = "1234DCF";

            using (TcpClient socket = new TcpClient(IPAddress.Loopback.ToString(), 7070))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {

                //sw.WriteLine(car.ToString());
                //sw.Flush();

                //String incomingString = sr.ReadLine();
                //Console.WriteLine("Ekko er modtaget" + incomingString);

            }

        }


    }
}
