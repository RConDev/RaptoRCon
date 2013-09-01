using System;
using System.Collections.Generic;

namespace RaptoRCon.Dice.Factories
{
    /// <summary>
    /// This interface describes a factory responsible for creating <see cref="IDicePacketSequence"/> instances
    /// </summary>
    public interface IDicePacketSequenceFactory
    {
        /// <summary>
        /// Creates a new <see cref="IDicePacketSequence"/> instance from delivered bytes
        /// </summary>
        /// <param name="bytes">The Collection of <see cref="byte"/>s to create the <see cref="IDicePacketSequence"/> from</param>
        /// <returns>
        /// The extracted <see cref="IDicePacketSequence"/> information
        /// </returns>
        /// <exception cref="ArgumentNullException">When the <param name="bytes" />-Collection is NULL.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When the <param name="bytes" />-Collection is not at the length of 4.</exception>
        IDicePacketSequence FromBytes(IEnumerable<byte> bytes);
    }
}
