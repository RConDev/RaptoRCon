using System;
using System.Net.Sockets;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// The interface describes the basic connection via <see cref="System.Net.Sockets.Socket"/>
    /// </summary>
    public interface ISocket : IDisposable
    {
        /// <summary>
        /// This event is invoked, when the connection receives data from the remote host
        /// </summary>
        event EventHandler<SocketDataReceivedEventArgs> DataReceived;

        /// <summary>
        /// Connects to the stated remote host
        /// </summary>
        /// <param name="hostname">Name or IP-Address of the remote host</param>
        /// <param name="port">Port number of the remote host to connect to</param>
        /// <returns></returns>
        void ConnectAsync(string hostname, int port);
        
        /// <summary>
        /// Sends a content to the remote host
        /// </summary>
        /// <param name="socketData"></param>
        void SendAsync(ISocketData socketData);
    }
}
