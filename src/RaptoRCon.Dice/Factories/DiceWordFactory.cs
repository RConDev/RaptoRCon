﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaptoRCon.Dice.Factories
{
    /// <summary>
    /// Implementation of <see cref="IDiceWordFactory"/>
    /// </summary>
    public class DiceWordFactory : IDiceWordFactory
    {
        /// <summary>
        /// Creates a new <see cref="IDiceWord"/> instance from delievered bytes
        /// </summary>
        /// <param name="bytes">The Collection of <see cref="byte"/> to extract the <see cref="IDiceWord"/> instance from</param>
        /// <returns>The extracted <see cref="IDiceWord"/> instance</returns>
        public IDiceWord FromBytes(IEnumerable<byte> bytes)
        {
            #region Contracts
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            #endregion

            var bytesToExtract = bytes.ToArray();
            var wordLength = BitConverter.ToUInt32(bytesToExtract.Take(4).ToArray(), 0);
            var word = Encoding.GetEncoding(1252).GetString(bytesToExtract.Skip(4).Take((int) wordLength).ToArray());

            return new DiceWord(word);
        }
    }
}