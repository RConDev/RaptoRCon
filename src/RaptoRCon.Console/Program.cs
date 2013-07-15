using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaptoRCon.Dice;
using RaptoRCon.Sockets;

namespace RaptoRCon.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var packetFactory = new PacketFactory();
            ISocketFactory factory = new SocketFactory();
            var socket = 
                factory.CreateAndConnect("127.0.0.1", 11000, (sender, e) =>
                                                                 {
                                                                     var receivedPacket =
                                                                         packetFactory.FromBytes(e.DataReceived.
                                                                                                   ToArray()).ToArray()[
                                                                                                       0];
                                                                     System.Console.WriteLine("Received Packet: {0} ", receivedPacket);
                                                                 }
                    );

            var packet = new Packet(new PacketSequence(1, PacketType.Request, PacketOrigin.Client),
                                    new List<IWord>() {new Word("serverInfo")});
            socket.SendAsync(new SocketData(packet.ToBytes()));

            System.Console.ReadLine();
        }
    }
}
