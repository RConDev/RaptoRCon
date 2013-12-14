using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RaptoRCon.Games.Dice.Properties;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice.Factories
{
    /// <summary>
    /// Implementation of <see cref="IDicePacketSequenceFactory"/>
    /// </summary>
    public class DicePacketSequenceFactory : IDicePacketSequenceFactory
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
        public IDicePacketSequence FromBytes(IEnumerable<byte> bytes)
        {
            Guard.That(() => bytes).IsNotNull().Length(4);

            byte[] bytesArray = bytes.ToArray();
            var id = GetIdFromBytes(bytesArray);
            var type = GetTypeFromBytes(bytesArray);
            var origin = GetOriginFromBytes(bytesArray);

            return new DicePacketSequence(id, type, origin);
        }

        #region Private Helpers

        private uint GetIdFromBytes(byte[] bytes)
        {
            var bitArray = new BitArray(bytes);
            bitArray[31] = false;
            bitArray[30] = false;
            var idBytes = new byte[4];
            bitArray.CopyTo(idBytes, 0);
            return BitConverter.ToUInt32(idBytes, 0);
        }

        private PacketType GetTypeFromBytes(byte[] bytes)
        {
            var bitArray = new BitArray(bytes);
            return bitArray[30] ? PacketType.Response : PacketType.Request;
        }

        private Origin GetOriginFromBytes(byte[] bytes)
        {
            return new BitArray(bytes)[31] ? Origin.Client : Origin.Server;
        }

        #endregion
    }
}