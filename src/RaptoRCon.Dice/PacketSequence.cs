using System;
using System.Collections;
using RaptoRCon.Dice.Properties;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// Implementation of <see cref="IPacketSequence"/>
    /// </summary>
    public class PacketSequence : IPacketSequence
    {
        /// <summary>
        /// Gets the Id of the <see cref="IPacketSequence"/> instance
        /// </summary>
        /// <remarks>
        /// Each Id should be unique in one communication channel
        /// </remarks>
        public uint Id { get; private set; }

        /// <summary>
        /// Gets the <see cref="PacketType"/>-option, to show wheather the current
        /// <see cref="IPacket"/> is a request or a response
        /// </summary>
        public PacketType Type { get; private set; }

        /// <summary>
        /// Gets the <see cref="PacketOrigin"/>-option, to show where the command
        /// of the current request/response communication was originated
        /// </summary>
        public PacketOrigin Origin { get; private set; }

        /// <summary>
        /// Creates a new <see cref="PacketSequence"/> instance based on the given values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="origin"></param>
        public PacketSequence(uint id, PacketType type, PacketOrigin origin)
        {
            Id = id;
            Type = type;
            Origin = origin;
        }

        /// <summary>
        /// Creates a new <see cref="PacketSequence"/> instance based on the sequence bytes 
        /// of the <see cref="IPacket"/>
        /// </summary>
        /// <param name="bytes"></param>
        public PacketSequence(byte[] bytes)
        {
            #region Contracts

            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            if (bytes.Length != 4)
            {
                throw new ArgumentOutOfRangeException("bytes", bytes.Length, Resources.EXC_MSG_UINT_BYTES_LENGTH);
            }

            #endregion

            Id = GetIdFromBytes(bytes);
            Type = GetTypeFromBytes(bytes);
            Origin = GetOriginFromBytes(bytes);
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
            return bitArray[30] ? PacketType.Response: PacketType.Request;
        }

        private PacketOrigin GetOriginFromBytes(byte[] bytes)
        {
            return new BitArray(bytes)[31] ? PacketOrigin.Client : PacketOrigin.Server;
        }

        #endregion
    }
}