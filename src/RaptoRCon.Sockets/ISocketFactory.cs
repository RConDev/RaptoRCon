﻿using System;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// This factory creates new <see cref="ISocket"/> instances
    /// </summary>
    public interface ISocketFactory
    {
        /// <summary>
        /// Creates a new <see cref="ISocket"/> instance connected to the stated remote host
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="onDataReceivedHandler"></param>
        /// <returns></returns>
        ISocket CreateAndConnect(string hostname, int port, EventHandler<SocketDataReceivedEventArgs> onDataReceivedHandler);
    }
}
