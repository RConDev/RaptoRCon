using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// Implementation of <see cref="IPacket"/>
    /// </summary>
    public class Packet : IPacket
    {
        private readonly IList<IWord> words; 

        /// <summary>
        /// Creates a new <see cref="Packet"/> instance
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="words"></param>
        public Packet(IPacketSequence sequence, IEnumerable<IWord> words)
        {
            #region Contracts
            if (sequence == null)
            {
                throw new ArgumentNullException("sequence");
            }

            if (words == null)
            {
                throw new ArgumentNullException("words");
            }
            #endregion

            Sequence = sequence;
            this.words = words.ToList();
        }

        /// <summary>
        /// Gets the <see cref="IPacketSequence"/> for the current <see cref="IPacket"/>
        /// </summary>
        public IPacketSequence Sequence { get; private set; }

        /// <summary>
        /// Gets the size of the <see cref="IPacket"/> instance in bytes
        /// </summary>
        public uint Size
        {
            get
            {
                var sequenceSize = 4;
                var sizeSize = 4;
                var numWordsSize = 4;
                var wordsSize = words.Sum(x => BitConverter.GetBytes(x.Size).Length + x.Size + 1);
                return (uint) (sequenceSize + sizeSize + numWordsSize + wordsSize);
            }
        }

        /// <summary>
        /// Gets the number of <see cref="IWord"/> instances following the <see cref="IPacket"/> 
        /// header
        /// </summary>
        public uint NumWords { get { return (uint) words.Count; } }

        /// <summary>
        /// Gets the <see cref="IWord"/> collection within this <see cref="IPacket"/> instance
        /// </summary>
        public IEnumerable<IWord> Words { get { return words; } }

        /// <summary>
        /// Creates a byte[] representation for the <see cref="IDiceSerializableObject"/> instance to communicate 
        /// </summary>
        public IEnumerable<byte> ToBytes()
        {
            var sequenceBytes = Sequence.ToBytes();
            var sizeBytes = BitConverter.GetBytes(Size);
            var numWordsBytes = BitConverter.GetBytes(NumWords);
            var wordsBytes = words.SelectMany(x => x.ToBytes());


            return sequenceBytes
                .Concat(sizeBytes)
                .Concat(numWordsBytes)
                .Concat(wordsBytes);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("{");

            builder.AppendFormat("[Id: {0}]", Sequence.Id)
                   .Append(" ")
                   .AppendFormat("[{0}]", Sequence.Origin.ToString())
                   .Append(" ")
                   .AppendFormat("[{0}]", Sequence.Type.ToString())
                   .Append(" ")
                   .AppendFormat("[Size: {0}]", Size)
                   .Append(" ");

            foreach (var word in words)
            {
                var index = words.IndexOf(word) + 1;
                builder.AppendFormat("[{0}: {1}]", index, word.Content);
                if (index < words.Count)
                {
                    builder.Append(" ");
                }
            }

            builder.Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IPacket other)
        {
            if (other == null) return false;
            return Equals(Sequence, other.Sequence)
                   && words.SequenceEqual(other.Words);
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
            return Equals((Packet)obj);
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
                return  (words.GetHashCode() *397) ^ Sequence.GetHashCode();
            }
        }
    }
}