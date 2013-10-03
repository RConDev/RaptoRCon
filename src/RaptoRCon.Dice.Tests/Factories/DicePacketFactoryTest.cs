using System;
using System.Collections.Generic;
using System.Linq;
using RaptoRCon.Dice.Factories;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace RaptoRCon.Dice.Tests.Factories
{
    [ExcludeFromCodeCoverage]
    public class DicePacketFactoryTest
    {
        private DicePacketFactory dicePacketFactory;

        public DicePacketFactoryTest()
        {

            var sequence = new DicePacketSequence(458u, PacketType.Request, PacketOrigin.Server);
            var words = new List<IDiceWord> { new DiceWord("listPlayers"), new DiceWord("all") };
            var expectedPacket = new DicePacket(sequence, words);

            dicePacketFactory = new DicePacketFactory();
        }

        [Fact]
        public void Test1()
        {
            var packetBytes = Convert.FromBase64String("ygEAgCQAAAACAAAACwAAAGxpc3RQbGF5ZXJzAAMAAABhbGwA");

            var deserializedPackets = dicePacketFactory.FromBytes(packetBytes).ToArray();

            Assert.Equal(1, deserializedPackets.Length);
            Assert.Equal("listPlayers", deserializedPackets[0].Words.ToArray()[0].Content);
            Assert.Equal("all", deserializedPackets[0].Words.ToArray()[1].Content);
        }

        [Fact]
        public void FromBytes_MultiplePacketBytes_ReturnsTwoPackets()
        {
            var expectedPacket = new DicePacket(new DicePacketSequence(458, PacketType.Response, PacketOrigin.Server),
                                            new List<IDiceWord>() { new DiceWord("OK"), new DiceWord("21"), new DiceWord("test") });
            var packetBytes = Convert.FromBase64String("ygEAQCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=").Concat(
                Convert.FromBase64String("ygEAQCMAAAADAAAAAgAAAE9LAAIAAAAyMQAEAAAAdGVzdAA=")).ToArray();
            var deserializedPackets = dicePacketFactory.FromBytes(packetBytes).ToArray();
            Assert.Equal(2, deserializedPackets.Length);
            Assert.Equal(expectedPacket, deserializedPackets[0]);
            Assert.Equal(expectedPacket, deserializedPackets[1]);
        }

        [Fact]
        public void FromBytes_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => dicePacketFactory.FromBytes(null));
        }
    }
}
