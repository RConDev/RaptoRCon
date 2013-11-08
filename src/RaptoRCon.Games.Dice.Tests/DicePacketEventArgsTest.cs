using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    [ExcludeFromCodeCoverage]
    public class DicePacketEventArgsTest
    {
        #region CTOR

        [Fact]
        public void Ctor_WithNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DicePacketEventArgs(null));
        }
        
        [Fact]
        public void Ctor_WithIDicePacket_FillsProperty()
        {
            var dicePacket = new DicePacket(new DicePacketSequence(123u, PacketType.Request, PacketOrigin.Client), new List<IDiceWord>(){new DiceWord("123")});
            var instance = new DicePacketEventArgs(dicePacket);

            Assert.Equal(dicePacket, instance.Packet);
        }

        #endregion
    }
}
