using System;
using System.Threading.Tasks;
using Common.Logging;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// Implementation of <see cref="ISocketFactory"/>
    /// </summary>
    public class SocketFactory  : ISocketFactory
    {
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creates a new <see cref="ISocket"/> instance connected to the stated remote host
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task<ISocket> CreateAndConnectAsync(string hostname, int port)
        {
            return await CreateAndConnectAsync(hostname, port, null);
        }

        /// <summary>
        /// Creates a new <see cref="ISocket"/> instance connected to the stated remote host
        /// </summary>
        /// <param name="hostname">the domain name or ip-address of the remote host</param>
        /// <param name="port"></param>
        /// <param name="onDataReceivedHandler"></param>
        /// <returns></returns>
        public async Task<ISocket> CreateAndConnectAsync(string hostname, int port, EventHandler<SocketDataReceivedEventArgs> onDataReceivedHandler)
        {
            logger.TraceFormat("CreateAndConnectAsync({0}, {1}, {2})", hostname, port, onDataReceivedHandler);

            var socket = new Socket();
            if (onDataReceivedHandler != null)
            {
                socket.DataReceived += onDataReceivedHandler;
            }

            var mySocket = await socket.ConnectAsync(hostname, port);

            logger.TraceFormat("CreateAndConnectAsync({0}, {1}, {2}) returning {3}", hostname, port, onDataReceivedHandler, mySocket);

            return mySocket;
        }
    }
}