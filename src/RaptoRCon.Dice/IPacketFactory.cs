using System.Collections.Generic;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// The interface describes the factory responsible for creating new <see cref="IPacket"/> instances
    /// </summary>
    public interface IPacketFactory
    {
        /// <summary>
        /// Creates a new <see cref="IPacket"/> instances based on <see cref="byte"/>s
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        IEnumerable<IPacket> FromBytes(IEnumerable<byte> bytes);
    }
}
