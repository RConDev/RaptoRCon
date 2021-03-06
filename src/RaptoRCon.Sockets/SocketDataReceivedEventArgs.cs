﻿using System;
using System.Collections.Generic;
using Seterlund.CodeGuard;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// Implementation of <see cref="EventArgs"/> for the <see cref="ISocket.DataReceived"/> event
    /// </summary>
    /// <remarks>
    /// This <see cref="EventArgs"/> implementation contains the data received from the remote host in
    /// a binary format.
    /// </remarks>
    public class SocketDataReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the data received from the remote host
        /// </summary>
        public IEnumerable<byte> DataReceived { get; private set; }

        /// <summary>
        /// Creates a new <see cref="SocketDataReceivedEventArgs"/> instance
        /// </summary>
        /// <param name="dataReceived"></param>
        public SocketDataReceivedEventArgs(IEnumerable<byte> dataReceived)
        {
            Guard.That(() => dataReceived).IsNotNull();

            DataReceived = dataReceived;
        }
    }
}
