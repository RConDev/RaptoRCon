using System;
using System.Collections.Generic;
using System.Linq;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// Implementation of <see cref="IPacketFactory"/>
    /// </summary>
    public class PacketFactory : IPacketFactory
    {
        private static readonly IPacketSequenceFactory packetSequenceFactory = new PacketSequenceFactory();

        private static readonly IWordFactory wordFactory = new WordFactory();

        /// <summary>
        /// Creates a new <see cref="IPacket"/> instances based on <see cref="byte"/>s
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/>s-Collection the <see cref="IPacket"/>-Collection will be created from</param>
        /// <returns>The <see cref="IPacket"/>-Collection extracted from <param name="bytes"></param></returns>
        /// <exception cref="ArgumentNullException">When </exception>
        public IEnumerable<IPacket> FromBytes(IEnumerable<byte> bytes)
        {
            #region Contracts

            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            #endregion

            return ExtractFromBytes(bytes);
        }

        private static IEnumerable<IPacket> ExtractFromBytes(IEnumerable<byte> bytes)
        {
            var bytesToExtract = bytes.ToArray();

            var packetSize = BitConverter.ToUInt32(bytesToExtract.Skip(4).Take(4).ToArray(), 0);

            //while

            var sequence = packetSequenceFactory.FromBytes(bytesToExtract.Take(4).ToArray());
            var wordCount = BitConverter.ToUInt32(bytesToExtract.Skip(8).Take(4).ToArray(), 0);

            var words = new List<IWord>();
            var totalWordsLength = 0;
            for (uint index = 0; index < wordCount; index++)
            {
                var offset = 12 + totalWordsLength;
                var wordSize = BitConverter.ToUInt32(bytesToExtract.Skip(offset).ToArray(), 0);
                var wordBytes = bytesToExtract.Skip(offset).Take(4 + (int) wordSize + 1).ToArray();
                var word = wordFactory.FromBytes(wordBytes);
                words.Add(word);

                totalWordsLength += 4 + (int) wordSize + 1;
            }

            yield return new Packet(sequence, words);
        }
    }
}