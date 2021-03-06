﻿using System;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// The interface describes the DiceWord-Type defined in the DICE protocol specs
    /// </summary>
    public interface IDiceWord : IDiceSerializableObject, IEquatable<IDiceWord>
    {
        /// <summary>
        /// Gets the number of bytes in the <see cref="IDiceWord"/> instance
        /// </summary>
        /// <remarks>
        /// The trailing NULL-Byte is excluded.
        /// </remarks>
        uint Size { get; }

        /// <summary>
        /// Gets the content of the <see cref="IDiceWord"/> instance
        /// </summary>
        /// <remarks>
        /// The <see cref="Content"/> must not contain any NULL-Byte
        /// </remarks>
        string Content { get; }

        /// <summary>
        /// Gets the Terminator 
        /// </summary>
        /// <remarks>
        /// In the DICE specs this is a NULL-Byte
        /// </remarks>
        char Terminator { get; }
    }
}
