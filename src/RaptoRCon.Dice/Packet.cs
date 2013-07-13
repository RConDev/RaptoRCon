using System.Collections.Generic;
using System.Linq;

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
                var wordsSize = words.Sum(x => x.Size + 1);
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
    }
}