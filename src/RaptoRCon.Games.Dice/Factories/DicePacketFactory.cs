using System;
using System.Collections.Generic;
using System.Linq;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice.Factories
{
    /// <summary>
    /// Implementation of <see cref="IDicePacketFactory"/>
    /// </summary>
    public class DicePacketFactory : IDicePacketFactory
    {
        private readonly object extractLock = new object();
        
        private static readonly IDicePacketSequenceFactory dicePacketSequenceFactory = new DicePacketSequenceFactory();

        private static readonly IDiceWordFactory diceWordFactory = new DiceWordFactory();

        /// <summary>
        /// Creates a new <see cref="IDicePacket"/> instances based on <see cref="byte"/>s
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/>s-Collection the <see cref="IDicePacket"/>-Collection will be created from</param>
        /// <returns>The <see cref="IDicePacket"/>-Collection extracted from <param name="bytes"></param></returns>
        /// <exception cref="ArgumentNullException">When </exception>
        public IEnumerable<IDicePacket> FromBytes(IEnumerable<byte> bytes)
        {
            Guard.That(() => bytes).IsNotNull();
         
            lock (extractLock)
            {
                return ExtractFromBytes(bytes);
            }
        }

        private static IEnumerable<IDicePacket> ExtractFromBytes(IEnumerable<byte> bytes)
        {
            var packetOffset = 0;
            var bytesToExtract = bytes.ToArray();

            var packetSize = BitConverter.ToUInt32(bytesToExtract.Skip(4).Take(4).ToArray(), 0);
            var packetBytes = bytesToExtract.Skip(packetOffset).Take(Convert.ToInt32(packetSize)).ToArray();
            while (packetBytes.Length > 0)
            {
                packetOffset += Convert.ToInt32(packetSize);
                var sequence = dicePacketSequenceFactory.FromBytes(packetBytes.Take(4).ToArray());
                var wordCount = BitConverter.ToUInt32(packetBytes.Skip(8).Take(4).ToArray(), 0);

                var words = new List<IDiceWord>();
                var totalWordsLength = 0;
                for (uint index = 0; index < wordCount; index++)
                {
                    var offset = 12 + totalWordsLength;
                    var wordSize = BitConverter.ToUInt32(packetBytes.Skip(offset).ToArray(), 0);
                    var wordBytes = packetBytes.Skip(offset).Take(4 + (int)wordSize + 1).ToArray();
                    var word = diceWordFactory.FromBytes(wordBytes);
                    words.Add(word);

                    totalWordsLength += 4 + (int) wordSize + 1;
                }

                yield return new DicePacket(sequence, words);

                bytesToExtract = bytesToExtract.Skip(packetOffset).ToArray();
                if (bytesToExtract.Length > 0)
                {
                    packetSize = BitConverter.ToUInt32(bytesToExtract.Skip(4).Take(4).ToArray(), 0);
                    packetBytes = bytesToExtract.Take(Convert.ToInt32(packetSize)).ToArray();
                }
                else
                {
                    packetBytes = new byte[0];
                }
            }
        }
    }
}