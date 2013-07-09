using System.Collections.Generic;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// The interface describes the data received and send through the <see cref="ISocket"/> instances
    /// </summary>
    public interface ISocketData
    {
        /// <summary>
        /// Gets the contained data within the <see cref="ISocketData"/> instance as a 
        /// <see cref="IEnumerable{T}"/> of <see cref="byte"/>
        /// </summary>
        IEnumerable<byte> Data { get; }
    }
}
