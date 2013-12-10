using System;
using System.Threading.Tasks;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// The interface describes the basic connection via <see cref="System.Net.Sockets.Socket"/>
    /// </summary>
    public interface ISocketClient : IDisposable
    {
        /// <summary>
        /// This event is invoked, when the connection receives data from the remote host
        /// </summary>
        event EventHandler<SocketDataReceivedEventArgs> DataReceived;

        /// <summary>
        /// This event is invoked, when the underlying connection is closed.
        /// </summary>
        event EventHandler<ConnectionClosedEventArgs> ConnectionClosed;
        
        /// <summary>
        /// Gets the underlying communication instance of <see cref="ISocket"/>
        /// </summary>
        ISocket Socket { get; }

        /// <summary>
        /// Connects to the stated remote host
        /// </summary>
        /// <param name="hostname">Name or IP-Address of the remote host</param>
        /// <param name="port">Port number of the remote host to connect to</param>
        /// <returns></returns>
        Task<ISocketClient> ConnectAsync(string hostname, int port);
        
        /// <summary>
        /// Sends a content to the remote host
        /// </summary>
        /// <param name="socketData"></param>
        /// <returns>the number of bytes send to the remote host</returns>
        Task<int> SendAsync(ISocketData socketData);

        Task DisconnectAsync(bool reuseSocket);
    }
}
