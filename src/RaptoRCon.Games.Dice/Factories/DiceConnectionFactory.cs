using System;
using System.Threading.Tasks;
using RaptoRCon.Sockets;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice.Factories
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
            this.SocketClientFactory = new SocketClientFactory();
        }

        /// <summary>
        /// Creates a new <see cref="DiceConnectionFactory"/> using the delivered <see cref="ISocketClientFactory"/>
        /// for creating the underlying <see cref="ISocket"/> connection
        /// </summary>
        /// <param name="socketClientFactory"></param>
        public DiceConnectionFactory(ISocketClientFactory socketClientFactory)
        {
            Guard.That(() => socketClientFactory).IsNotNull();

            SocketClientFactory = socketClientFactory;
        }

        /// <summary>
        /// Gets or sets the <see cref="ISocketClientFactory"/> implementation used within this <see cref="IDiceConnectionFactory"/>
        /// </summary>
        public ISocketClientFactory SocketClientFactory { get; set; }

        /// <summary>
        /// Creates a new <see cref="IDiceConnection"/> instance
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IDiceConnection> CreateAsync(string hostname, int port, string password)
        {
            Guard.That(() => hostname).IsNotNull();
            Guard.That(() => port).IsGreaterThan(0);
            Guard.That(() => password).IsNotNull();

            var socketClient = await SocketClientFactory.CreateAsync(hostname, port);
            var connection = new DiceConnection(hostname, port, password, socketClient);

            return connection;
        }
    }
}