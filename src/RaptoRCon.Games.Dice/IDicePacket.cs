using System;
using System.Collections.Generic;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// This interface describes the structure used for communicating with 
    /// remote console servers for games published by DICE (http://dice.se/)
    /// </summary>
    public interface IDicePacket : IDiceSerializableObject, IEquatable<IDicePacket>
    {
        /// <summary>
        /// Gets the <see cref="IDicePacketSequence"/> for the current <see cref="IDicePacket"/>
        /// </summary>
        IDicePacketSequence Sequence { get; }

        /// <summary>
        /// Gets the size of the <see cref="IDicePacket"/> instance in bytes
        /// </summary>
        uint Size { get; }

        /// <summary>
        /// Gets the number of <see cref="IDiceWord"/> instances following the <see cref="IDicePacket"/> 
        /// header
        /// </summary>
        uint NumWords { get; }

        /// <summary>
        /// Gets the <see cref="IDiceWord"/> collection within this <see cref="IDicePacket"/> instance
        /// </summary>
        IEnumerable<IDiceWord> Words { get; }
    }
}
