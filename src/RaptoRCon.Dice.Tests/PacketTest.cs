using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class PacketTest
    {
        private readonly Mock<IDicePacketSequence> packetSequenceMock;
        private readonly List<IDiceWord> wordsMock;

        public PacketTest()
        {
            packetSequenceMock = new Mock<IDicePacketSequence>();
            wordsMock = new List<IDiceWord>();
        }

        #region ctor

        [Fact]
        public void ctor_SequenceNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DicePacket(null, new List<IDiceWord>{new DiceWord("Test")}));
        }

        [Fact]
        public void ctor_WordsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new DicePacket(new DicePacketSequence(123u, PacketType.Request, PacketOrigin.Client), null));
        }

        [Fact]
        public void ctor_ImplementsIPacket()
        {
            var instance = new DicePacket(packetSequenceMock.Object, wordsMock);
            Assert.IsAssignableFrom<IDicePacket>(instance);
        }
        
        [Fact]
        public void ctor_WithWords_WordsReturnsValue()
        {
            var instance = new DicePacket(packetSequenceMock.Object, wordsMock);
            Assert.Equal(wordsMock, instance.Words);
        }

        [Fact]
        public void ctor_WithOneWords_NumWords1()
        {
            wordsMock.Add(new DiceWord("myWord"));
            var instance = new DicePacket(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint)1, instance.NumWords);
        }

        [Fact]
        public void ctor_With3Words_NumWords3()
        {
            wordsMock.Add(new DiceWord("myWord"));
            wordsMock.Add(new DiceWord("myWord"));
            wordsMock.Add(new DiceWord("myWord"));
            var instance = new DicePacket(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint)3, instance.NumWords);
        }

        [Fact]
        public void ctor_With1WordTest_Size17()
        {
            wordsMock.Add(new DiceWord("Test"));
            var instance = new DicePacket(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint) 21, instance.Size);
        }

        [Fact]
        public void ctor_With2WordsTestTest_Size22()
        {
            wordsMock.Add(new DiceWord("Test"));
            wordsMock.Add(new DiceWord("Test"));
            var instance = new DicePacket(packetSequenceMock.Object, wordsMock);
            Assert.Equal((uint)30, instance.Size);
        }

        #endregion

        #region ToBytes()

        [Fact]
        public void ToBytes_Packet458RequestServerListPlayersAll_BytesEqual()
        {
            var packetSequence = new DicePacketSequence((uint)458, PacketType.Request, PacketOrigin.Client);
            var words = new List<IDiceWord>() {new DiceWord("listPlayers"), new DiceWord("all")};
            var packet = new DicePacket(packetSequence, words);

            var expectedBytes = Convert.FromBase64String("ygEAgCQAAAACAAAACwAAAGxpc3RQbGF5ZXJzAAMAAABhbGwA");
            Assert.Equal(expectedBytes, packet.ToBytes());
        }

        #endregion

        #region ToString()

        [Fact]
        public void ToString_123ClientRequestServerInfo_123ClientRequestServerInfoSize()
        {
            var packet = new DicePacket(new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client),
                                    new List<IDiceWord>() {new DiceWord("serverInfo")});
            var actual = packet.ToString();
            Assert.Equal("{[Id: 123] [Client] [Request] [Size: 27] [1: serverInfo]}", actual);
        }

        [Fact]
        public void ToString_123ClientRequestListPlayersAll_123ClientRequestListPlayersAllSize()
        {
            var packet = new DicePacket(new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client),
                                    new List<IDiceWord>() { new DiceWord("listPlayers"), new DiceWord("all") });
            var actual = packet.ToString();
            Assert.Equal("{[Id: 123] [Client] [Request] [Size: 36] [1: listPlayers] [2: all]}", actual);
        }

        #endregion

        #region Equals() 

        [Fact]
        public void Equals_PacketSequenceMockTest_True()
        {
            var packet = new DicePacket(packetSequenceMock.Object, new List<IDiceWord>() {new DiceWord("Test")});
            var packet2 = new DicePacket(packetSequenceMock.Object, new List<IDiceWord>() { new DiceWord("Test") });
            Assert.Equal(packet, packet2);
        }

        [Fact]
        public void Equals_WithString_False()
        {
            var packet = new DicePacket(packetSequenceMock.Object, new List<IDiceWord>() { new DiceWord("Test") });
            
            Assert.False(packet.Equals("A String"));
        }

        [Fact]
        public void Equals_Null_False()
        {
            var packet = new DicePacket(packetSequenceMock.Object, new List<IDiceWord>() { new DiceWord("Test") });

            Assert.False(packet.Equals(null));
        }

        [Fact]
        public void Equals_SameInstance_True()
        {
            var packet = new DicePacket(packetSequenceMock.Object, new List<IDiceWord>() { new DiceWord("Test") });

            Assert.True(packet.Equals(packet));
        }

        [Fact]
        public void Equals_AnotherPacket_True()
        {
            var packet = new DicePacket(packetSequenceMock.Object, new List<IDiceWord>() { new DiceWord("Test") });
            var packet2 = new DicePacket(new DicePacketSequence(123, PacketType.Request, PacketOrigin.Client), new List<IDiceWord>() { new DiceWord("Test2") });
            Assert.False(packet.Equals(packet2));
        }

        #endregion

        #region GetHashCode()

        [Fact]
        public void GetHashCode_PacketSequenceMockTest_True()
        {
            var packet = new DicePacket(packetSequenceMock.Object, new List<IDiceWord>() { new DiceWord("Test") });
            Assert.Equal(packet.GetHashCode(), packet.GetHashCode());
        }

        #endregion
    }
}
