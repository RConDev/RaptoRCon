﻿using System;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// This interface describes the first part of each <see cref="IDicePacket"/>.
    /// It informs about the function, origin and order of it.
    /// </summary>
    public interface IDicePacketSequence : IDiceSerializableObject, IEquatable<IDicePacketSequence>
    {
        /// <summary>
        /// Gets the Id of the <see cref="IDicePacketSequence"/> instance
        /// </summary>
        /// <remarks>
        /// Each Id should be unique in one communication channel
        /// </remarks>
        uint Id { get; }

        /// <summary>
        /// Gets the <see cref="Origin"/>-option, to show where the command
        /// of the current request/response communication was originated
        /// </summary>
        Origin Origin { get; }

        /// <summary>
        /// Gets the <see cref="PacketType"/>-option, to show wheather the current
        /// <see cref="IDicePacket"/> is a request or a response
        /// </summary>
        PacketType Type { get; }
    }
}
