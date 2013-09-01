using System.Collections.Generic;

namespace RaptoRCon.Dice.Factories
{
    /// <summary>
    /// The interface describes the factory responsible for creating new <see cref="IDicePacket"/> instances
    /// </summary>
    public interface IDicePacketFactory
    {
        /// <summary>
        /// Creates a new <see cref="IDicePacket"/> instances based on <see cref="byte"/>s
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        IEnumerable<IDicePacket> FromBytes(IEnumerable<byte> bytes);
    }
}
