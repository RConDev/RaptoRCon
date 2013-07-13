using System.Collections.Generic;
using Moq;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class PacketTest
    {
        private readonly Mock<IPacketSequence> packetSequenceMock;
        private readonly List<IWord> words;

        public PacketTest()
        {
            packetSequenceMock = new Mock<IPacketSequence>();
            words = new List<IWord>();
        }

        #region ctor

        [Fact]
        public void ctor_ImplementsIPacket()
        {
            var instance = new Packet(packetSequenceMock.Object, words);
            Assert.IsAssignableFrom<IPacket>(instance);
        }

        [Fact]
        public void ctor_WithIPacketSequence_PacketSequenceReturnsValue()
        {
            var instance = new Packet(packetSequenceMock.Object, words);
            Assert.Equal(packetSequenceMock.Object, instance.Sequence);
        }

        [Fact]
        public void ctor_WithWords_WordsReturnsValue()
        {
            var instance = new Packet(packetSequenceMock.Object, words);
            Assert.Equal(words, instance.Words);
        }

        [Fact]
        public void ctor_WithOneWords_NumWords1()
        {
            words.Add(new Word("myWord"));
            var instance = new Packet(packetSequenceMock.Object, words);
            Assert.Equal((uint)1, instance.NumWords);
        }

        [Fact]
        public void ctor_With3Words_NumWords3()
        {
            words.Add(new Word("myWord"));
            words.Add(new Word("myWord"));
            words.Add(new Word("myWord"));
            var instance = new Packet(packetSequenceMock.Object, words);
            Assert.Equal((uint)3, instance.NumWords);
        }

        [Fact]
        public void ctor_With1WordTest_Size17()
        {
            words.Add(new Word("Test"));
            var instance = new Packet(packetSequenceMock.Object, words);
            Assert.Equal((uint) 17, instance.Size);
        }

        [Fact]
        public void ctor_With2WordsTestTest_Size22()
        {
            words.Add(new Word("Test"));
            words.Add(new Word("Test"));
            var instance = new Packet(packetSequenceMock.Object, words);
            Assert.Equal((uint)22, instance.Size);
        }

        #endregion
    }
}
