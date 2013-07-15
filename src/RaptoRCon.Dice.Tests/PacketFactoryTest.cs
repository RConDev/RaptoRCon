using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class PacketFactoryTest
    {
        private PacketFactory packetFactory;

        public PacketFactoryTest()
        {

            var sequence = new PacketSequence(458u, PacketType.Request, PacketOrigin.Server);
            var words = new List<IWord> { new Word("listPlayers"), new Word("all") };
            var expectedPacket = new Packet(sequence, words);

            packetFactory = new PacketFactory();
        }

        [Fact]
        public void Test1()
        {
            var packetBytes = Convert.FromBase64String("ygEAgCQAAAACAAAACwAAAGxpc3RQbGF5ZXJzAAMAAABhbGwA");

            var deserializedPackets = packetFactory.FromBytes(packetBytes).ToArray();

            Assert.Equal(1, deserializedPackets.Length);
            Assert.Equal("listPlayers", deserializedPackets[0].Words.ToArray()[0].Content);
            Assert.Equal("all", deserializedPackets[0].Words.ToArray()[1].Content);
        }

        ////[Fact]
        ////public void FromBytes_MultiplePacketBytes_ReturnsTwoPackets()
        ////{
        ////    var expectedPacket = new Packet(new PacketSequence(458, PacketType.Response, PacketOrigin.Server),
        ////                                    new List<IWord>() {new Word("OK"), new Word("21"), new Word("test")});
        ////    var packetBytes = Convert.FromBase64String("ygEAQCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=").Concat(
        ////        Convert.FromBase64String("ygEAQCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=")).ToArray();
        ////    var deserializedPackets = this.packetFactory.FromBytes(packetBytes).ToArray();
        ////    Assert.Equal(2, deserializedPackets.Length);
        ////    Assert.Equal(expectedPacket, deserializedPackets[0]);
        ////    Assert.Equal(expectedPacket, deserializedPackets[1]);
        ////}

        [Fact]
        public void FromBytes_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => packetFactory.FromBytes(null));
        }
    }
}
