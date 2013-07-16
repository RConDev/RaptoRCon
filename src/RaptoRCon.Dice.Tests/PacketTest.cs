using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class PacketTest
    {
        private readonly Mock<IPacketSequence> packetSequenceMock;
        private readonly List<IWord> wordsMock;

        public PacketTest()
        {
            packetSequenceMock = new Mock<IPacketSequence>();
            wordsMock = new List<IWord>();
        }

        #region ctor

        [Fact]
        public void ctor_SequenceNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Packet(null, new List<IWord>{new Word("Test")}));
        }

        [Fact]
        public void ctor_WordsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Packet(new PacketSequence(123u, PacketType.Request, PacketOrigin.Client), null));
        }

        [Fact]
        public void ctor_ImplementsIPacket()
        {
            var instance = new Packet(packetSequenceMock.Object, wordsMock);
            Assert.IsAssignableFrom<IPacket>(instance);
        }
        
        [Fact]
        public void ctor_WithWords_WordsReturnsValue()
        {
            var instance = new Packet(packetSequenceMock.Object, wordsMock);
            Assert.Equal(wordsMock, instance.Words);
        }

        [Fact]
        public void ctor_WithOneWords_NumWords1()
        {
            wordsMock.Add(new Word("myWord"));
            var instance = new Packet(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint)1, instance.NumWords);
        }

        [Fact]
        public void ctor_With3Words_NumWords3()
        {
            wordsMock.Add(new Word("myWord"));
            wordsMock.Add(new Word("myWord"));
            wordsMock.Add(new Word("myWord"));
            var instance = new Packet(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint)3, instance.NumWords);
        }

        [Fact]
        public void ctor_With1WordTest_Size17()
        {
            wordsMock.Add(new Word("Test"));
            var instance = new Packet(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint) 21, instance.Size);
        }

        [Fact]
        public void ctor_With2WordsTestTest_Size22()
        {
            wordsMock.Add(new Word("Test"));
            wordsMock.Add(new Word("Test"));
            var instance = new Packet(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint)30, instance.Size);
        }

        #endregion

        #region ToBytes()

        [Fact]
        public void ToBytes_Packet458RequestServerListPlayersAll_BytesEqual()
        {
            var packetSequence = new PacketSequence((uint)458, PacketType.Request, PacketOrigin.Client);
            var words = new List<IWord>() {new Word("listPlayers"), new Word("all")};
            var packet = new Packet(packetSequence, words);

            var expectedBytes = Convert.FromBase64String("ygEAgCQAAAACAAAACwAAAGxpc3RQbGF5ZXJzAAMAAABhbGwA");
            Assert.Equal(expectedBytes, packet.ToBytes());
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_123ClientRequestServerInfo_123ClientRequestServerInfoSize()
        {
            var packet = new Packet(new PacketSequence(123, PacketType.Request, PacketOrigin.Client),
                                    new List<IWord>() {new Word("serverInfo")});
            var actual = packet.ToString();
            Assert.Equal("{[Id: 123] [Client] [Request] [Size: 27] [1: serverInfo]}", actual);
        }

        [Fact]
        public void ToString_123ClientRequestListPlayersAll_123ClientRequestListPlayersAllSize()
        {
            var packet = new Packet(new PacketSequence(123, PacketType.Request, PacketOrigin.Client),
                                    new List<IWord>() { new Word("listPlayers"), new Word("all") });
            var actual = packet.ToString();
            Assert.Equal("{[Id: 123] [Client] [Request] [Size: 36] [1: listPlayers] [2: all]}", actual);
        }

        #endregion

        #region Equals() 

        [Fact]
        public void Equals_PacketSequenceMockTest_True()
        {
            var packet = new Packet(packetSequenceMock.Object, new List<IWord>() {new Word("Test")});
            var packet2 = new Packet(packetSequenceMock.Object, new List<IWord>() { new Word("Test") });
            Assert.Equal(packet, packet2);
        }

        [Fact]
        public void Equals_WithString_False()
        {
            var packet = new Packet(packetSequenceMock.Object, new List<IWord>() { new Word("Test") });
            
            Assert.False(packet.Equals("A String"));
        }

        [Fact]
        public void Equals_Null_False()
        {
            var packet = new Packet(packetSequenceMock.Object, new List<IWord>() { new Word("Test") });

            Assert.False(packet.Equals(null));
        }

        [Fact]
        public void Equals_SameInstance_True()
        {
            var packet = new Packet(packetSequenceMock.Object, new List<IWord>() { new Word("Test") });

            Assert.True(packet.Equals(packet));
        }

        [Fact]
        public void Equals_AnotherPacket_True()
        {
            var packet = new Packet(packetSequenceMock.Object, new List<IWord>() { new Word("Test") });
            var packet2 = new Packet(new PacketSequence(123, PacketType.Request, PacketOrigin.Client), new List<IWord>() { new Word("Test2") });
            Assert.False(packet.Equals(packet2));
        }

        #endregion

        #region GetHashCode()

        [Fact]
        public void GetHashCode_PacketSequenceMockTest_True()
        {
            var packet = new Packet(packetSequenceMock.Object, new List<IWord>() { new Word("Test") });
            Assert.Equal(packet.GetHashCode(), packet.GetHashCode());
        }

        #endregion
    }
}
