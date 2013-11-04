using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RaptoRCon.Games.Dice.Properties;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Implementation of <see cref="IDicePacketSequence"/>
    /// </summary>
    public class DicePacketSequence : IDicePacketSequence
    {
        /// <summary>
        /// The maximum value for the <see cref="Id"/>
        /// </summary>
        public const int MaxIdValue = 1073741823;

        /// <summary>
        /// Gets the Id of the <see cref="IDicePacketSequence"/> instance
        /// </summary>
        /// <remarks>
        /// Each Id should be unique in one communication channel
        /// </remarks>
        public uint Id { get; private set; }

        /// <summary>
        /// Gets the <see cref="PacketType"/>-option, to show wheather the current
        /// <see cref="IDicePacket"/> is a request or a response
        /// </summary>
        public PacketType Type { get; private set; }

        /// <summary>
        /// Gets the <see cref="PacketOrigin"/>-option, to show where the command
        /// of the current request/response communication was originated
        /// </summary>
        public PacketOrigin Origin { get; private set; }

        /// <summary>
        /// Creates a new <see cref="DicePacketSequence"/> instance based on the given values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="origin"></param>
        public DicePacketSequence(uint id, PacketType type, PacketOrigin origin)
        {
            #region Contracts
            if (id > MaxIdValue)
            {
                var message = string.Format(Resources.EXC_MSG_PARAMETER_EXCEEDS_VALUE, MaxIdValue);
                throw new ArgumentOutOfRangeException("id", id, message);
            }
            #endregion

            Id = id;
            Type = type;
            Origin = origin;
        }

        /// <summary>
        /// Creates a byte[] representation for the <see cref="IDicePacketSequence"/> instance to communicate 
        /// </summary>
        public IEnumerable<byte> ToBytes()
        {
            var idBytes = BitConverter.GetBytes(Id);
            var bitArray = new BitArray(idBytes);
            bitArray[30] = Type == PacketType.Response;
            bitArray[31] = Origin == PacketOrigin.Client;
            var sequenceBytes = new byte[4];
            bitArray.CopyTo(sequenceBytes, 0);
            return sequenceBytes;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IDicePacketSequence other)
        {
            return Id == other.Id
                   && Origin == other.Origin
                   && Type == other.Type;
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
            
            return Equals((DicePacketSequence) obj);
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
                var hashCode = (int)Id;
                hashCode = (hashCode * 397) ^ (int)Type;
                hashCode = (hashCode * 397) ^ (int)Origin;
                return hashCode;
            }
        }
    }
}