using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Sockets;

namespace RaptoRCon.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ISocketFactory factory = new SocketFactory();
            factory.CreateAndConnect("127.0.0.1", 11000, (sender, e) => System.Console.WriteLine("Received {0} bytes", e.DataReceived.Length));
            ISocket socket = new Socket();
            
            System.Console.ReadLine();
        }
    }
}
