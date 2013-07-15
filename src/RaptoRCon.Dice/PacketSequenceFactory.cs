using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RaptoRCon.Dice.Properties;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// Implementation of <see cref="IPacketSequenceFactory"/>
    /// </summary>
    public class PacketSequenceFactory : IPacketSequenceFactory
    {
        /// <summary>
        /// Creates a new <see cref="IPacketSequence"/> instance from delivered bytes
        /// </summary>
        /// <param name="bytes">The Collection of <see cref="byte"/>s to create the <see cref="IPacketSequence"/> from</param>
        /// <returns>
        /// The extracted <see cref="IPacketSequence"/> information
        /// </returns>
        /// <exception cref="ArgumentNullException">When the <param name="bytes" />-Collection is NULL.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When the <param name="bytes" />-Collection is not at the length of 4.</exception>
        public IPacketSequence FromBytes(IEnumerable<byte> bytes)
        {
            #region Contracts

            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            var bytesArray = bytes as byte[] ?? bytes.ToArray();
            if (bytesArray.Length != 4)
            {
                throw new ArgumentOutOfRangeException("bytes", bytesArray.Length, Resources.EXC_MSG_UINT_BYTES_LENGTH);
            }

            #endregion

            var id = GetIdFromBytes(bytesArray);
            var type = GetTypeFromBytes(bytesArray);
            var origin = GetOriginFromBytes(bytesArray);

            return new PacketSequence(id, type, origin);
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

        private PacketOrigin GetOriginFromBytes(byte[] bytes)
        {
            return new BitArray(bytes)[31] ? PacketOrigin.Client : PacketOrigin.Server;
        }

        #endregion
    }
}