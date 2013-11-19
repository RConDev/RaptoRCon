using System;
using System.Threading.Tasks;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// This factory creates new <see cref="ISocketClient"/> instances
    /// </summary>
    public interface ISocketClientFactory
    {
        /// <summary>
        /// Creates a new <see cref="ISocketClient"/> instance connected to the stated remote host with no added event handler
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        Task<ISocketClient> CreateAsync(string hostname, int port);
    }
}
