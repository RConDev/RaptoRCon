using System;
using System.Threading.Tasks;
using RaptoRCon.Sockets;

namespace RaptoRCon.Games.Dice.Factories
{
    /// <summary>
    /// The interface describes the factory responsible for creating <see cref="IDiceConnection"/> instances
    /// </summary>
    public interface IDiceConnectionFactory
    {
        /// <summary>
        /// Creates a new <see cref="IDiceConnection"/> instance
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="packetReceivedHandler"></param>
        /// <returns></returns>
        Task<IDiceConnection> CreateAsync(string hostname, int port, EventHandler<DicePacketEventArgs> packetReceivedHandler = null);

        /// <summary>
        /// Gets or sets the <see cref="ISocketClientFactory"/> implementation used within this <see cref="IDiceConnectionFactory"/>
        /// </summary>
        ISocketClientFactory SocketClientFactory { get; set; }
    }
}
