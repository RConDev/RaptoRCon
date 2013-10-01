using System;
using System.Threading.Tasks;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// This factory creates new <see cref="ISocket"/> instances
    /// </summary>
    public interface ISocketFactory
    {
        /// <summary>
        /// Creates a new <see cref="ISocket"/> instance connected to the stated remote host with no added event handler
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        Task<ISocket> CreateAndConnectAsync(string hostname, int port);

        /// <summary>
        /// Creates a new <see cref="ISocket"/> instance connected to the stated remote host
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="onDataReceivedHandler"></param>
        /// <returns></returns>
        Task<ISocket> CreateAndConnectAsync(string hostname, int port, EventHandler<SocketDataReceivedEventArgs> onDataReceivedHandler);
    }
}
