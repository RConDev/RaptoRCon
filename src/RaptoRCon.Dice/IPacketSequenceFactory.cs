using System.Collections.Generic;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// This interface describes a factory responsible for creating <see cref="IPacketSequence"/> instances
    /// </summary>
    public interface IPacketSequenceFactory
    {
        /// <summary>
        /// Creates a new <see cref="IPacketSequence"/> instance from delivered bytes
        /// </summary>
        /// <param name="bytes">The Collection of <see cref="byte"/>s to create the <see cref="IPacketSequence"/> from</param>
        /// <returns>
        /// The extracted <see cref="IPacketSequence"/> information
        /// </returns>
        IPacketSequence FromBytes(IEnumerable<byte> bytes);
    }
}
