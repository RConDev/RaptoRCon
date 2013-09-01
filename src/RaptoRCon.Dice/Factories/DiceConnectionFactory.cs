using System;
using System.Threading.Tasks;
using RaptoRCon.Sockets;

namespace RaptoRCon.Dice.Factories
{
    /// <summary>
    /// Implementation of <see cref="IDiceConnectionFactory"/>
    /// </summary>
    public class DiceConnectionFactory : IDiceConnectionFactory
    {
        /// <summary>
        /// Creates a new <see cref="DiceConnectionFactory"/> instance
        /// </summary>
        public DiceConnectionFactory()
        {
            this.SocketFactory = new SocketFactory();
        }

        /// <summary>
        /// Creates a new <see cref="DiceConnectionFactory"/> using the delivered <see cref="ISocketFactory"/>
        /// for creating the underlying <see cref="ISocket"/> connection
        /// </summary>
        /// <param name="socketFactory"></param>
        public DiceConnectionFactory(ISocketFactory socketFactory)
        {
            #region Contracts

            if (socketFactory == null)
            {
                throw new ArgumentNullException("socketFactory");
            }

            #endregion Contracts

            SocketFactory = socketFactory;
        }

        /// <summary>
        /// Gets or sets the <see cref="ISocketFactory"/> implementation used within this <see cref="IDiceConnectionFactory"/>
        /// </summary>
        public ISocketFactory SocketFactory { get; set; }

        /// <summary>
        /// Creates a new <see cref="IDiceConnection"/> instance
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="packetReceivedHandler"></param>
        /// <returns></returns>
        public async Task<IDiceConnection> CreateAsync(string hostname, int port, EventHandler<DicePacketEventArgs> packetReceivedHandler = null)
        {
            #region Contracts

            if (hostname == null)
            {
                throw new ArgumentNullException("hostname");
            }

            if (port <= 0)
            {
                throw new ArgumentOutOfRangeException("port");
            }

            #endregion Contracts

            var socket = await SocketFactory.CreateAndConnectAsync(hostname, port);
            var connection = new DiceConnection(socket, packetReceivedHandler);

            return connection;
        }
    }
}