using System;
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
        /// <param name="hostname">the domain name or ip-address of the remote host</param>
        /// <param name="port"></param>
        /// <param name="onDataReceivedHandler"></param>
        /// <returns></returns>
        public ISocket CreateAndConnect(string hostname, int port, EventHandler<SocketDataReceivedEventArgs> onDataReceivedHandler)
        {
            logger.TraceFormat("CreateAndConnect({0}, {1}, {2})", hostname, port, onDataReceivedHandler);

            var socket = new Socket();
            socket.DataReceived += onDataReceivedHandler;
            socket.ConnectAsync(hostname, port);
            
            logger.TraceFormat("CreateAndConnect({0}, {1}, {2}) returning {3}", hostname, port, onDataReceivedHandler, socket);
            return socket;
        }
    }
}