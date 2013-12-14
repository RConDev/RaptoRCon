using System;
using System.Collections.Generic;
using Seterlund.CodeGuard;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// Implementation for <see cref="ISocketData"/> a binary byte-array containing a byte[]
    /// </summary>
    public class SocketData : ISocketData
    {
        /// <summary>
        /// The content of the data in a binary format
        /// </summary>
        public IEnumerable<byte> Data { get; private set; }

        /// <summary>
        /// Creates a new <see cref="SocketData"/> instance
        /// </summary>
        /// <param name="data"></param>
        public SocketData(IEnumerable<byte> data)
        {
            Guard.That(() => data).IsNotNull();

            Data = data;
        }
    }
}