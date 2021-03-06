﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Implementation of <see cref="IDiceWord"/>
    /// </summary>
    public class DiceWord : IDiceWord
    {
        /// <summary>
        /// Creates a new <see cref="DiceWord"/> instance
        /// </summary>
        /// <param name="content"></param>
        public DiceWord(string content)
        {
            Guard.That(() => content).IsNotNull();

            Content = content;
        }

        /// <summary>
        /// Gets the number of bytes in the <see cref="IDiceWord"/> instance
        /// </summary>
        /// <remarks>
        /// The trailing NULL-Byte is excluded.
        /// </remarks>
        public uint Size
        {
            get
            {
                return Convert.ToUInt32(Content.Length);
            }
        }

        /// <summary>
        /// Gets the content of the <see cref="IDiceWord"/> instance
        /// </summary>
        /// <remarks>
        /// The <see cref="IDiceWord.Content"/> must not contain any NULL-Byte
        /// </remarks>
        public string Content { get; private set; }

        /// <summary>
        /// Gets the Terminator 
        /// </summary>
        /// <remarks>
        /// In the DICE specs this is a NULL-Byte
        /// </remarks>
        public char Terminator { get; private set; }

        /// <summary>
        /// Creates a byte[] representation for the <see cref="IDiceSerializableObject"/> instance to communicate 
        /// </summary>
        public IEnumerable<byte> ToBytes()
        {
            var content = Content + Terminator;
            var sizeBytes = BitConverter.GetBytes(Size);
            var contentBytes = Encoding.GetEncoding(1252).GetBytes(content);

            return sizeBytes.Concat(contentBytes); ;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IDiceWord other)
        {
            return Content == other.Content;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            return Equals((DiceWord) obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                return Content.GetHashCode() * 397;
            }
        }
    }
}