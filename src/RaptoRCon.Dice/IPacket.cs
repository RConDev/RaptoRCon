using System;
using System.Collections.Generic;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// This interface describes the structure used for communicating with 
    /// remote console servers for games published by DICE (http://dice.se/)
    /// </summary>
    public interface IPacket : IDiceSerializableObject, IEquatable<IPacket>
    {
        /// <summary>
        /// Gets the <see cref="IPacketSequence"/> for the current <see cref="IPacket"/>
        /// </summary>
        IPacketSequence Sequence { get; }

        /// <summary>
        /// Gets the size of the <see cref="IPacket"/> instance in bytes
        /// </summary>
        uint Size { get; }

        /// <summary>
        /// Gets the number of <see cref="IWord"/> instances following the <see cref="IPacket"/> 
        /// header
        /// </summary>
        uint NumWords { get; }

        /// <summary>
        /// Gets the <see cref="IWord"/> collection within this <see cref="IPacket"/> instance
        /// </summary>
        IEnumerable<IWord> Words { get; }
    }
}
